# Bài 7 - Middleware cơ bản trong ASP.NET Core MVC

## Câu 1
Middleware trong ASP.NET Core dùng để xử lý request và response trước hoặc sau khi request đi tới Controller.

## Câu 2
Middleware xử lý request trong pipeline.
Controller xử lý nghiệp vụ và trả về View hoặc dữ liệu cho người dùng.

## Câu 3
Dòng lệnh:

await _next(context);

có tác dụng chuyển request tới middleware tiếp theo trong pipeline.

## Câu 4
Khi middleware gọi return; thì request sẽ dừng lại tại middleware đó và không tiếp tục đi tới Controller.

## Câu 5
Nếu đặt middleware sau app.MapControllerRoute(...) thì request có thể được xử lý bởi Controller trước, middleware sẽ không hoạt động như mong muốn.

## Câu 6
Có thể thêm middleware khác bằng cách:

app.UseMiddleware<MiddlewareA>();
app.UseMiddleware<MiddlewareB>();

Middleware sẽ chạy theo thứ tự được khai báo.