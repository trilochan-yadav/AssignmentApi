# Assignment API (.NET 8)

A production-ready ASP.NET Core Web API built with .NET 8 using clean layered architecture, SQLite database, Docker support, and keyset pagination.

---

## 📁 Project Structure

```
AssignmentApi/
├── AssignmentApi/
│   ├── Controllers/
│   ├── BLL/
│   ├── DAL/
│   ├── Data/
│   ├── DTOs/
│   ├── Models/
│   ├── Program.cs
│   ├── AssignmentApi.csproj
│   └── appsettings.json
├── AssignmentApi.sln
├── docker-compose.yml
├── README.md
├── .gitignore
└── .dockerignore
```

---

## 🚀 Features

- User CRUD APIs  
- Keyset Pagination (better than OFFSET for large data)  
- Product transformation API  
- SQLite database with auto-seeding  
- Clean layered architecture (Controller → BLL → DAL)  
- Docker & docker-compose support  
- Swagger documentation  

---

## ⚙️ Tech Stack

- .NET 8  
- ASP.NET Core Web API  
- Entity Framework Core  
- SQLite  
- Docker  

---

## ▶️ Run Locally

```
dotnet restore
dotnet run
```

Swagger:
```
http://localhost:5000/swagger
```

---

## 🐳 Run with Docker

```
docker-compose up --build
```

---

## 🔁 API Endpoints

### Users

**Get users (pagination)**

```
GET /api/users?lastSeenId=0&pageSize=10
```

Response example:

```json
[
  {
    "id": 1,
    "name": "John Doe",
    "address1": "123 Main Street",
    "address2": "Apt 4B"
  }
]
```

---

### Product Transformation

```
POST /api/products/transform
```

Response example:

```json
[
  {
    "id": "p1",
    "name": "Product 1",
    "ImageId": "0:1;1:2",
    "ImageAlt": "0:a;1:b",
    "ImageUrl": "0:url1;1:url2",
    "ImageWidth": "0:100;1:200",
    "ImageHeight": "0:100;1:200"
  }
]
```

---

## 📄 Configuration

appsettings.json:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=users.db"
  }
}
```

---

## 🧠 Key Concept

**Keyset Pagination**

Instead of OFFSET:

```
WHERE Id > lastSeenId
ORDER BY Id
LIMIT pageSize
```

✔ Fast  
✔ Scalable  
✔ No performance issues  

---

## 🗄️ Database

- SQLite database: `users.db`  
- Auto-created on startup  
- Auto-seeded with sample users  

---

## 🐳 Docker Notes

- SQLite file is persisted using Docker volume  
- Run using docker-compose for easy setup  

---