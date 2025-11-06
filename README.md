# 🧩 Students Courses API

This project is an **ASP.NET Core Web API** built using **N-Tier Architecture (DAL, BLL, PL)** as part of an **ITI session task**.  

---

## 📘 Overview
The system manages **Students** and **Courses**:

- Each **Course** can have many **Student**.  
- Each **Student** belongs to only one **Course**.
---

## 🏗️ Architecture Layers

- **DAL (Data Access Layer)** → Contains Entities, DbContext, and Migrations  
- **BLL (Business Logic Layer)** → Contains Services and Business Logic  
- **PL (Presentation Layer)** → The API Controllers  

---

## 🔐 Authentication & Authorization

- Implemented using **ASP.NET Core Identity**
- JWT Tokens are generated upon successful login.
- Only authenticated users can access protected endpoints.

---

## 🧠 Features

✅ Register & Login using Identity  
✅ Manage Students, Courses (CRUD)  
✅ One-to-Many relationship between Students and Courses  
✅ JWT-based authentication  
✅ Tested using **Postman**

---

## 🧰 Technologies Used

- ASP.NET Core 8 Web API  
- Entity Framework Core  
- SQL Server  
- Identity & JWT  
- AutoMapper  
- Postman

---

## 📮 API Testing (Postman)

All endpoints are tested via Postman, including:
- `/api/Auth/Register`
- `/api/Auth/Login`
- `/api/Student/Students`
- `/api/Student/Students/{id}`
- `/api/Course/Courses`
- `/api/api/Course/Courses/{id}`

---

## 🚀 How to Run

1. Clone the repository  
   ```bash
   git clone https://github.com/NadaAhmed712/Students-Courses-Management-API.git
