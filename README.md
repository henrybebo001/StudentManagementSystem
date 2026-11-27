# Student Management System

A student management application built with **ASP.NET Core Web API (.NET 8)** and **Supabase**. The project provides RESTful CRUD operations and a web dashboard for managing student records.

## Features

- Create, retrieve, update, and delete student records.
- Supabase PostgreSQL database integration.
- Student data validation.
- Student management dashboard.
- Student registration form.
- Separation of business logic using a service layer.
- Swagger API documentation (available in Development mode).

## Technologies Used

- C#
- ASP.NET Core Web API (.NET 8)
- Razor Pages
- Supabase
- PostgreSQL
- Swagger / OpenAPI
- Git and GitHub

## Requirements

Before running the application, install:

- Visual Studio 2022 or another compatible IDE.
- .NET 8 SDK.
- Git.
- An internet connection.
- Access to a Supabase project with the required table and permissions.

## Installation

### 1. Clone the repository

```bash
git clone https://github.com/henrybebo001/StudentManagementSystem.git
cd StudentManagementSystem
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Configure Supabase

The application reads its Supabase configuration from .NET User Secrets. From the directory containing `StudentManagementSystem.csproj`, run:

```bash
dotnet user-secrets init
dotnet user-secrets set "Supabase:Url" "YOUR_SUPABASE_PROJECT_URL"
dotnet user-secrets set "Supabase:Key" "YOUR_SUPABASE_PUBLISHABLE_KEY"
```

Replace the placeholders with the project URL and publishable key from the Supabase project.

**Security:** Do not commit API keys, database passwords, or other secrets to GitHub. Do not use the Supabase `service_role` key in this application.

### 4. Configure the database

The application expects a PostgreSQL table named `students` in the `public` schema with the following columns:

| Column | Type | Constraints |
|---|---|---|
| `id` | `BIGINT` | Primary key, identity |
| `first_name` | `TEXT` | NOT NULL |
| `last_name` | `TEXT` | NOT NULL |
| `enrollment_number` | `TEXT` | NOT NULL, UNIQUE |
| `email` | `TEXT` | NOT NULL, UNIQUE |
| `career` | `TEXT` | NOT NULL |

Row Level Security (RLS), grants, and policies must allow the `anon` role to perform the CRUD operations used by this demonstration. If you use a different Supabase project, make sure its schema and permissions match these requirements.

### 5. Run the application

```bash
dotnet run
```

Open the local HTTPS or HTTP address printed in the terminal. The exact port may differ between computers.

## Application Pages

### Dashboard

The dashboard displays:

- Total registered students.
- Total careers.
- A table of registered students.

### Student Registration

The registration page allows users to enter:

- First name
- Last name
- Enrollment number
- Email address
- Career

## API Endpoints

The REST API uses the following base route:

`/api/students`

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/api/students` | Retrieve all students |
| `GET` | `/api/students/{id}` | Retrieve a student by ID |
| `POST` | `/api/students` | Register a new student |
| `PUT` | `/api/students/{id}` | Update an existing student |
| `DELETE` | `/api/students/{id}` | Delete a student |

## Swagger Documentation

When the application runs in Development mode, Swagger UI is available at:

`/swagger`

Use Swagger UI to test the API endpoints.

## Security Notes

This project is intended for academic demonstration. Its Supabase access policies must be configured to permit the required operations. Public/anonymous database access can expose student data and allow unauthorized changes if used without appropriate restrictions.

For production use, implement authentication and authorization, restrictive Row Level Security policies, server-side validation, and appropriate protection of personal information.

## Author

**Henry Daniel Martínez**

GitHub: [@henrybebo001](https://github.com/henrybebo001)

## Repository

[StudentManagementSystem](https://github.com/henrybebo001/StudentManagementSystem)
