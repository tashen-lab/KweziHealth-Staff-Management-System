# Staff Management System — Enterprise Programming in C#

An ASP.NET Core MVC (.NET 8) app covering all four deliverables: models, an
in-memory service layer, controller/view CRUD with session-based admin auth,
and app configuration.

## Project structure

```
StaffManagementApp/
├── Models/
│   ├── StaffMember.cs        (Deliverable 1)
│   └── SystemAdmin.cs        (Deliverable 1)
├── Services/
│   ├── IStaffService.cs      (Deliverable 2)
│   └── StaffService.cs       (Deliverable 2 in-memory List<StaffMember>)
├── Filters/
│   └── RequireAdminAttribute.cs  (session-based auth guard, Deliverable 3)
├── Controllers/
│   ├── AccessController.cs   (Deliverable 3 login/logout)
│   └── StaffController.cs    (Deliverable 3 CRUD, [RequireAdmin])
├── Views/
│   ├── Access/Login.cshtml
│   ├── Staff/Index.cshtml, Create.cshtml, Edit.cshtml, Delete.cshtml
│   └── Shared/_Layout.cshtml
├── Program.cs                 (Deliverable 4 services, session/auth, routing)
└── appsettings.json
```

## How to run

Requires the .NET 8 SDK.

```bash
cd StaffManagementApp
dotnet build
dotnet run
```

Then open the URL printed in the console (e.g. `https://localhost:5000`).

**Demo admin login:** `admin`/`Admin123!` (hardcoded, there's no
database in this project, matching the "in-memory" requirement)