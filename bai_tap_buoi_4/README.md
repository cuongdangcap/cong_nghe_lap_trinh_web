# Bài 6 - Validation cơ bản

## Mục tiêu

Kiểm tra dữ liệu đầu vào khi thêm sách.

## Công nghệ sử dụng

* ASP.NET Core MVC
* Data Annotation
* ModelState

## Yêu cầu thực hiện

### 1. Tên sách

Nếu để trống:

Thông báo:

"Không được để trống"

### 2. Giá sách

Nếu giá nhỏ hơn hoặc bằng 0:

Thông báo:

"Giá phải lớn hơn 0"

## Cách thực hiện

### Data Annotation trong Model

Book.cs sử dụng:

* [Required]
* [Range]

để kiểm tra dữ liệu đầu vào.

### ModelState trong Controller

Khi người dùng gửi form:

* Nếu dữ liệu không hợp lệ → trả lại View và hiển thị lỗi.
* Nếu dữ liệu hợp lệ → hiển thị thông báo thêm sách thành công.

## Kết quả

### Trường hợp tên rỗng

Hiển thị:

"Không được để trống"

### Trường hợp giá <= 0

Hiển thị:

"Giá phải lớn hơn 0"

### Trường hợp dữ liệu hợp lệ

Hiển thị:

"Thêm sách thành công"
