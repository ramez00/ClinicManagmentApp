# Clinic Management App 🩺

## Overview 📖

The **Clinic Management App** is a scalable, maintainable web application built with **ASP.NET Core**, designed to manage clinic data with full **CRUD operations**.

It follows **Clean Architecture** principles, incorporates design patterns like **Repository** and **Mediator**, and uses **SQL Server** for data storage with **Entity Framework Core** and **MediatR** for request handling.

---

## Features ✨

- 🛠️ **CRUD Operations**: Create, Read, Update, and Delete clinics (name, address, contact number)
- 🧩 **Design Patterns**:
  - 📚 **Repository**: Abstracts data access
  - 🔄 **Mediator**: Decouples request handling using MediatR
- 🏛️ **Clean Architecture**: Separation of concerns across Domain, Application, Infrastructure, and API layers
- 🚨 **Error Handling**: Global exception middleware for consistent error responses

---

## Technologies 🛠️

- **Backend**: ASP.NET Core (C#), Entity Framework Core, SQL Server
- **Libraries**: MediatR

---

## Project Structure 📂

```plaintext
ClinicManagementApp/
├── ClinicManagementApp.Api/
│   └── ASP.NET Core Web API 🌐
├── ClinicManagementApp.Application/
│   └── Business logic, MediatR commands/queries 🧠
├── ClinicManagementApp.Infrastructure/
│   └── Data access, EF Core, Repositories 💾
├── ClinicManagementApp.Domain/
    └── Entities, Interfaces 📋
```

2. Configure the Backend 🖥️
Database Setup 🗄️
Ensure SQL Server LocalDB is installed (comes with Visual Studio or .NET SDK).

Update the connection string in ClinicManagementApp.Api/appsettings.json:

json
Copy
Edit
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=ClinicManagementDb;Trusted_Connection=True;"
  }
}
Run EF Core Migrations:
bash
Copy
Edit
cd ClinicManagementApp.Infrastructure
dotnet ef migrations add InitialCreate --startup-project ../ClinicManagementApp.Api
dotnet ef database update --startup-project ../ClinicManagementApp.Api
3. Build and Run the Backend 🚀
bash
Copy
Edit
cd ClinicManagementApp.Api
dotnet build
dotnet run
The API will be available at: https://localhost:5001

Access Swagger UI at: https://localhost:5001/swagger

Usage 🚀
You can interact with the API via Swagger UI or a tool like Postman.

Example: Create Clinic
POST /api/clinics

json
Copy
Edit
{
   "name": "ENT Clinic",
    "address": "123 Health St, City",
    "phoneNumber": "555-123-3216",
    "email": "Ent.gmail.com"
}
API Endpoints
POST /api/clinics → Create a clinic

GET /api/clinics → Retrieve all clinics

GET /api/clinics/{id} → Retrieve clinic by ID

PUT /api/clinics/{id} → Update a clinic

DELETE /api/clinics/{id} → Delete a clinic

Design Patterns 🧩
📚 Repository: Abstracts data access in ClinicRepository

🔄 Mediator: Uses MediatR for decoupled request handling (e.g., CreateClinicCommand, GetAllClinicsQuery)


