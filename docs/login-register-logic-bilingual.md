# Logic Đăng Ký - Đăng Nhập

---

## Tiếng Việt

### Menu in ra giao diện

    1. Đăng nhập
    2. Đăng ký
    0. Thoát

---

### 1. Đăng nhập

- Người dùng nhập userName.
- Hệ thống kiểm tra username bằng cách tìm file có tên giống username.
    - Nếu không tìm thấy file có chứa username giống người dùng nhập, in ra thông báo tài khoản không tồn tại.
    - Nếu tìm thấy file, chuyển sang bước logic đăng nhập.
- Logic đăng nhập:
    - Kiểm tra username bằng cách mở file username (file này chứa password đã được hash trong lúc đăng ký tài khoản).
    - Hệ thống kiểm tra password mà người dùng nhập bằng cách hash password đó rồi so sánh với password hash đã lưu.
    - Nếu trùng khớp thì thông báo đăng nhập thành công, ngược lại thông báo đăng nhập thất bại.

---

### 2. Đăng ký

- Cho người dùng nhập username, nhập password 2 lần và email.
- Kiểm tra username và email trong folder data, nếu đã tồn tại username hoặc email thì in ra thông báo username đã tồn tại hoặc email đã được đăng ký.
- Username được lưu lại thành tên file.
- Password nhập 2 lần sẽ được so sánh để xác nhận (password luôn được hash để đảm bảo an toàn).
- Sau đó password hash sẽ được lưu vào file với tên file là username của người dùng.

---

## English

### Menu displays on the interface

    1. Login
    2. Register
    0. Exit

---

### 1. Login

- The user enters the userName.
- The system checks the username by searching for a file with the same name as the username.
    - If a file with the entered username is not found, display a message: "Account does not exist".
    - If the file is found, proceed to the login logic.
- Login logic:
    - Check the username by opening the username file (this file contains the hashed password created during registration).
    - The system checks the entered password by hashing it and comparing it with the stored password hash.
    - If they match, display "Login successful"; otherwise, display "Login failed".

---

### 2. Register

- Prompt the user to enter a username, enter the password twice, and provide an email.
- Check the username and email in the data folder. If the username or email already exists, display "Username already exists" or "Email already registered".
- The username is saved as the file name.
- The two entered passwords are compared for confirmation (the password is always hashed for security).
- Then the hashed password is saved into the file named after the user's username.