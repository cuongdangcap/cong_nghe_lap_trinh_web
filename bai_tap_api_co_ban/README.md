# Bài tập API cơ bản

## API tạo sản phẩm

### POST /api/products

Request:

```json
{
    "name": "Laptop",
    "price": 15000
}
```

Response:

```json
{
    "id": 1,
    "name": "Laptop",
    "price": 15000
}
```

---

## API lấy sản phẩm theo ID

### GET /api/products/1

Response:

```json
{
    "id": 1,
    "name": "Laptop",
    "price": 15000
}
```

---

## Validate

* Name bắt buộc.
* Name tối thiểu 3 ký tự.
* Price bắt buộc.
* Price phải lớn hơn 0.
* Id phải là số nguyên dương.

---

## Hướng dẫn Front-end kết nối API

### JavaScript

```javascript
fetch("https://localhost:7272/api/products/1")
    .then(res => res.json())
    .then(data => console.log(data));
```

### React

```javascript
useEffect(() => {
    fetch("https://localhost:7272/api/products/1")
        .then(res => res.json())
        .then(data => setProduct(data));
}, []);
```

### Flutter

```dart
final response = await http.get(
    Uri.parse('https://localhost:7272/api/products/1')
);
```
