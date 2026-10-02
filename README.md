# BaiKiemTra01
# Nguyễn Trung Thành - 24810310462
### Bai01
[Bailam.md](https://github.com/user-attachments/files/32944962/Bailam.md)
### Câu 1:
Value Types và Reference Types khác nhau chủ yếu ở cách lưu trữ và cách hoạt động khi gán biến.

Value Type là kiểu giá trị, biến sẽ lưu trực tiếp giá trị của nó. Các kiểu như int, double, char, bool, struct là Value Type. Khi khai báo biến cục bộ thì thường được lưu trên Stack. Khi gán một biến Value Type cho biến khác thì giá trị được copy sang biến mới nên hai biến không ảnh hưởng đến nhau.

Ví dụ:

int a = 10;

int b = a;

b = 20;

Lúc này a vẫn bằng 10, còn b bằng 20.

Reference Type là kiểu tham chiếu, biến không lưu trực tiếp object mà lưu tham chiếu đến object nằm trên Heap. Các kiểu như class, array, string, object là Reference Type. Khi gán hai biến Reference Type cho nhau thì hai biến có thể cùng tham chiếu đến một object, nên thay đổi object thông qua một biến thì biến kia cũng thấy thay đổi.

Vì vậy, Value Type lưu trực tiếp giá trị, còn Reference Type lưu tham chiếu đến object. Value Type thường liên quan đến Stack, còn object của Reference Type được lưu trên Heap.
### Câu 2:
init là một cách khai báo thuộc tính cho phép gán giá trị khi tạo object nhưng không cho phép thay đổi sau khi object đã được tạo.

Khác với set, set cho phép thay đổi giá trị của thuộc tính nhiều lần trong quá trình chương trình chạy.

Ví dụ:

class Student

{
    
    public string Id { get; init; }
    public string Name { get; set; }
}

Khi tạo object:

Student sv = new Student
{

    Id = "SV001",
    Name = "Nguyen Van A"
};

Id được gán lúc tạo object. Sau đó không thể gán lại sv.Id, nhưng sv.Name vẫn có thể thay đổi vì Name dùng set.

Vi vậy, trong thực tế, init có thể dùng cho những thông tin không nên thay đổi sau khi tạo object, ví dụ như mã sinh viên, mã sản phẩm hoặc mã hóa đơn.
### Câu 3:
virtual và override đều liên quan đến tính đa hình.

virtual được dùng ở lớp cha, để cho phép phương thức đó có thể được lớp con ghi đè. Còn override được dùng ở lớp con, để ghi đè lại phương thức virtual của lớp cha.

Ví dụ:

class Animal
{
    
    public virtual void Sound()
    {
        Console.WriteLine("Động vật phát ra âm thanh");
    }
}

class Dog : Animal
{
    
    public override void Sound()
    {
        Console.WriteLine("Chó sủa");
    }
}

Nếu viết:

Animal a = new Dog();

a.Sound();

thì kết quả là "Chó sủa".

Lý do là biến a có kiểu Animal nhưng object thực tế được tạo là Dog, nên phương thức override của Dog được gọi.
### Câu 4:
static là thành phần thuộc về Class, không thuộc riêng về từng Object. Vì vậy, các object được tạo từ cùng một class sẽ dùng chung thành phần static.

Ví dụ:

class Student
{

    public static int Count = 0;
}

Có thể truy cập Count bằng:

Student.Count

mà không cần tạo object bằng new.

Nếu tạo:

Student sv = new Student();

thì sv chỉ là một object của lớp Student, còn Count vẫn thuộc về lớp Student chứ không thuộc riêng về sv.

Vì vậy, thành phần static được truy cập thông qua tên Class, còn các thành phần bình thường thường được truy cập thông qua Object. static được dùng khi muốn tạo một thành phần dùng chung cho toàn bộ class.
### Bai02 (OOP)
TEST CASE 01

<img width="1917" height="1020" alt="image" src="https://github.com/user-attachments/assets/4bda43b3-33b1-41c8-ada4-50efa3aae11d" />

TEST CASE 02

<img width="1917" height="1022" alt="image" src="https://github.com/user-attachments/assets/36f864c1-04f1-44c0-903c-02e4cdcea2e9" />

TEST CASE 03

<img width="1917" height="1016" alt="image" src="https://github.com/user-attachments/assets/f72f9b5c-e11d-4081-84a7-1edc108c8f09" />

TEST CASE 04

<img width="1917" height="1020" alt="image" src="https://github.com/user-attachments/assets/886b8062-8dcf-42fd-bb72-7ce7706e2d4c" />

<img width="1917" height="1020" alt="image" src="https://github.com/user-attachments/assets/b6b9807b-0609-446e-ad9a-6407953af626" />

TEST CASE 05

<img width="1917" height="1022" alt="image" src="https://github.com/user-attachments/assets/c17848a5-6974-4080-84ab-a52bcb246820" />



### BAI03 (WindowForm)
TEST CASE 01

<img width="1917" height="1018" alt="image" src="https://github.com/user-attachments/assets/5d0a1147-27d8-4b6c-90fe-ce6fb24b896a" />

TEST CASE 02

<img width="1917" height="1020" alt="image" src="https://github.com/user-attachments/assets/f6f167af-e852-4eb6-84e2-ad7ecc916ecc" />

TEST CASE 03

<img width="1917" height="1020" alt="image" src="https://github.com/user-attachments/assets/da11264f-72f8-4c72-9bb8-20a3b5ff2991" />

TEST CASE 04

<img width="1917" height="1018" alt="image" src="https://github.com/user-attachments/assets/51a395c3-b69e-4996-90ac-42bee164675a" />

TEST CASE 05

<img width="1915" height="1017" alt="image" src="https://github.com/user-attachments/assets/472778fb-6b22-4947-9c20-388c9f36b876" />

<img width="1917" height="1017" alt="image" src="https://github.com/user-attachments/assets/d2c3b674-9b9a-4281-99db-b99c1cc34be2" />
