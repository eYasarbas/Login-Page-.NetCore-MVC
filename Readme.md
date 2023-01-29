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

Loginpage.png

- Register Page Design

RegisterPage.png

- Password Encrypt Process

I have encrypted passwords irreversibly using the encrypt library. I made this even more unpredictable by adding an extra string to it.

- Login Process and Cookie Auth

Login operations were carried out through cookies. This, attempt was made to reduce database operations.

- Using Authorize and AllowAnonymous Attribute

Actions set by user role and Setting Admin Link Visibility. For example, only users with the admin role can see the admin page.

- Profile Page Process

profile png

- Used to ToastrJS

I used this library to show notification when saving
