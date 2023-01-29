# Project Information

This project is a Login&Logout page. Cookies, user roles and database are used in this login page to be realistic. I didn't bother much about the design. If I can find free time, I will look at it again and update the project.

# Methods and Technologies

- Asp.NetCore: version 6
- MVC
- Cookie
- SqlServer

# Development steps

- Added Razor Runtime Compilation nuget packages after creating project. The packages used are:

```
    <PackageReference Include="Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation" Version="6.0.13"/>

    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="6.0.13"/>

    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="6.0.13"/>

    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="6.0.13"/>

    <PackageReference Include="NETCore.Encrypt" Version="2.1.1"/>

    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="6.0.13"/>
```

- Login Page Design

![Login](https://user-images.githubusercontent.com/65676107/215329631-5c14606d-a348-4101-b86d-c5e9ae13c8f9.PNG)


- Register Page Design

![Register](https://user-images.githubusercontent.com/65676107/215329643-9e7aeb9e-96ef-4472-870d-b2887a9b9607.PNG)


- Password Encrypt Process

I have encrypted passwords irreversibly using the encrypt library. I made this even more unpredictable by adding an extra string to it.

- Login Process and Cookie Auth

Login operations were carried out through cookies. This, attempt was made to reduce database operations.

- Using Authorize and AllowAnonymous Attribute

Actions set by user role and Setting Admin Link Visibility. For example, only users with the admin role can see the admin page.

- Profile Page Process

![profile](https://user-images.githubusercontent.com/65676107/215329669-9651fa03-6766-4f43-98e8-325b9bbf0471.PNG)


- Used to ToastrJS

I used this library to show notification when saving
