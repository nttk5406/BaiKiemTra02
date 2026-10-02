using System;
using System.Collections.Generic;
using System.Linq;

abstract class PhuongTien
{
    private string _maPT;
    private string _tenHang;
    private int _namSanXuat;
    private decimal _giaGoc;

    public string MaPT
    {
        get { return _maPT; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                _maPT = "PT000";
            else
                _maPT = value;
        }
    }

    public string TenHang
    {
        get { return _tenHang; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ten hang khong duoc de trong!");

            _tenHang = value;
        }
    }

    public int NamSanXuat
    {
        get { return _namSanXuat; }
        set
        {
            if (value < 1900 || value > DateTime.Now.Year)
                throw new ArgumentException("Nam san xuat khong hop le!");

            _namSanXuat = value;
        }
    }

    public decimal GiaGoc
    {
        get { return _giaGoc; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Gia goc phai lon hon 0!");

            _giaGoc = value;
        }
    }

    public PhuongTien(string maPT, string tenHang, int namSanXuat, decimal giaGoc)
    {
        MaPT = maPT;
        TenHang = tenHang;
        NamSanXuat = namSanXuat;
        GiaGoc = giaGoc;
    }

    public abstract decimal TinhGiaLanBanh();

    public virtual string GetInfo()
    {
        return "Ma PT: " + MaPT +
               ", Ten hang: " + TenHang +
               ", Nam SX: " + NamSanXuat +
               ", Gia goc: " + GiaGoc;
    }
}

class OTo : PhuongTien
{
    public int SoChoNgoi { get; set; }
    public double DungTichDongCo { get; set; }

    public OTo(string maPT, string tenHang, int namSanXuat,
               decimal giaGoc, int soChoNgoi, double dungTichDongCo)
        : base(maPT, tenHang, namSanXuat, giaGoc)
    {
        if (soChoNgoi <= 0)
            throw new ArgumentException("So cho ngoi phai lon hon 0!");

        if (dungTichDongCo <= 0)
            throw new ArgumentException("Dung tich dong co phai lon hon 0!");

        SoChoNgoi = soChoNgoi;
        DungTichDongCo = dungTichDongCo;
    }

    public override decimal TinhGiaLanBanh()
    {
        if (SoChoNgoi <= 9)
        {
            return GiaGoc + GiaGoc * 0.12m + GiaGoc * 0.30m;
        }
        else
        {
            return GiaGoc + GiaGoc * 0.10m;
        }
    }

    public override string GetInfo()
    {
        return base.GetInfo() +
               ", So cho ngoi: " + SoChoNgoi +
               ", Dung tich dong co: " + DungTichDongCo;
    }
}

class XeMay : PhuongTien
{
    public int DungTichXylanh { get; set; }

    public XeMay(string maPT, string tenHang, int namSanXuat,
                 decimal giaGoc, int dungTichXylanh)
        : base(maPT, tenHang, namSanXuat, giaGoc)
    {
        if (dungTichXylanh <= 0)
            throw new ArgumentException("Dung tich xy-lanh phai lon hon 0!");

        DungTichXylanh = dungTichXylanh;
    }

    public override decimal TinhGiaLanBanh()
    {
        if (DungTichXylanh < 175)
        {
            return GiaGoc + GiaGoc * 0.02m;
        }
        else
        {
            return GiaGoc + GiaGoc * 0.05m;
        }
    }

    public override string GetInfo()
    {
        return base.GetInfo() +
               ", Dung tich xy-lanh: " + DungTichXylanh + " cc";
    }
}

class QuanLyPhuongTien
{
    private List<PhuongTien> danhSach;

    public QuanLyPhuongTien()
    {
        danhSach = new List<PhuongTien>();
    }

    public void AddPhuongTien(PhuongTien pt)
    {
        danhSach.Add(pt);
    }

    public void DisplayAll()
    {
        if (danhSach.Count == 0)
        {
            Console.WriteLine("Danh sach rong!");
            return;
        }

        foreach (PhuongTien pt in danhSach)
        {
            Console.WriteLine(pt.GetInfo());
            Console.WriteLine("Gia lan banh: " + pt.TinhGiaLanBanh().ToString("N0") + " VND");
            Console.WriteLine();
        }
    }

    public PhuongTien FindMaxGiaLanBanh()
    {
        if (danhSach.Count == 0)
            return null;

        PhuongTien max = danhSach[0];

        foreach (PhuongTien pt in danhSach)
        {
            if (pt.TinhGiaLanBanh() > max.TinhGiaLanBanh())
            {
                max = pt;
            }
        }

        return max;
    }

    public List<PhuongTien> SearchByName(string keyword)
    {
        return danhSach
            .Where(pt => pt.TenHang.ToLower().Contains(keyword.ToLower()))
            .ToList();
    }
    public void TinhGiaLanBanh()
    {
        if (danhSach.Count == 0)
        {
            Console.WriteLine("Danh sach rong!");
            return;
        }

        foreach (PhuongTien pt in danhSach)
        {
            Console.WriteLine(pt.GetInfo());
            Console.WriteLine("Gia lan banh: "
                + pt.TinhGiaLanBanh().ToString("N0") + " VND");
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        QuanLyPhuongTien ql = new QuanLyPhuongTien();

        int chon;

        do
        {
            Console.WriteLine("================================");
            Console.WriteLine(" QUAN LY PHUONG TIEN GIAO THONG");
            Console.WriteLine("================================");
            Console.WriteLine("1. Them O To");
            Console.WriteLine("2. Them Xe May");
            Console.WriteLine("3. Hien thi danh sach");
            Console.WriteLine("4. Tim gia lan banh cao nhat");
            Console.WriteLine("5. Tim theo ten hang");
            Console.WriteLine("6. Tinh gia lan banh");
            Console.WriteLine("0. Thoat");
            Console.Write("Nhap lua chon: ");

            chon = int.Parse(Console.ReadLine());

            try
            {
                if (chon == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("===== NHAP O TO =====");

                    Console.Write("Nhap ma PT: ");
                    string maPT = Console.ReadLine();

                    Console.Write("Nhap ten hang: ");
                    string tenHang = Console.ReadLine();

                    Console.Write("Nhap nam san xuat: ");
                    int namSanXuat = int.Parse(Console.ReadLine());

                    Console.Write("Nhap gia goc: ");
                    decimal giaGoc = decimal.Parse(Console.ReadLine());

                    Console.Write("Nhap so cho ngoi: ");
                    int soChoNgoi = int.Parse(Console.ReadLine());

                    Console.Write("Nhap dung tich dong co: ");
                    double dungTichDongCo = double.Parse(Console.ReadLine());

                    OTo oto = new OTo(
                        maPT,
                        tenHang,
                        namSanXuat,
                        giaGoc,
                        soChoNgoi,
                        dungTichDongCo
                    );

                    ql.AddPhuongTien(oto);

                    Console.WriteLine("Them O To thanh cong!");
                }
                else if (chon == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("===== NHAP XE MAY =====");

                    Console.Write("Nhap ma PT: ");
                    string maPT = Console.ReadLine();

                    Console.Write("Nhap ten hang: ");
                    string tenHang = Console.ReadLine();

                    Console.Write("Nhap nam san xuat: ");
                    int namSanXuat = int.Parse(Console.ReadLine());

                    Console.Write("Nhap gia goc: ");
                    decimal giaGoc = decimal.Parse(Console.ReadLine());

                    Console.Write("Nhap dung tich xy-lanh: ");
                    int dungTichXylanh = int.Parse(Console.ReadLine());

                    XeMay xeMay = new XeMay(
                        maPT,
                        tenHang,
                        namSanXuat,
                        giaGoc,
                        dungTichXylanh
                    );

                    ql.AddPhuongTien(xeMay);

                    Console.WriteLine("Them Xe May thanh cong!");
                }
                else if (chon == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("===== DANH SACH PHUONG TIEN =====");

                    ql.DisplayAll();
                }
                else if (chon == 4)
                {
                    Console.WriteLine();
                    Console.WriteLine("===== GIA LAN BANH CAO NHAT =====");

                    PhuongTien max = ql.FindMaxGiaLanBanh();

                    if (max == null)
                    {
                        Console.WriteLine("Danh sach rong!");
                    }
                    else
                    {
                        Console.WriteLine(max.GetInfo());
                        Console.WriteLine(
                            "Gia lan banh: "
                            + max.TinhGiaLanBanh().ToString("N0")
                            + " VND"
                        );
                    }
                }
                else if (chon == 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("===== TIM THEO TEN HANG =====");

                    Console.Write("Nhap ten hang can tim: ");
                    string keyword = Console.ReadLine();

                    List<PhuongTien> ketQua =
                        ql.SearchByName(keyword);

                    if (ketQua.Count == 0)
                    {
                        Console.WriteLine("Khong tim thay!");
                    }
                    else
                    {
                        foreach (PhuongTien pt in ketQua)
                        {
                            Console.WriteLine(pt.GetInfo());
                            Console.WriteLine(
                                "Gia lanh banh: "
                                + pt.TinhGiaLanBanh().ToString("N0")
                                + " VNd"
                            );
                        }
                    }
                }
                else if (chon == 6)
                {
                    Console.WriteLine();
                    Console.WriteLine("===== TINH GIA LAN BANH =====");

                    ql.TinhGiaLanBanh();
                }
                else if (chon == 0)
                {
                    Console.WriteLine("Ket thuc!");
                }
                else
                {
                    Console.WriteLine("Lua chon khong hop le!");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }

            Console.WriteLine();

        } while (chon != 0);
    }
}