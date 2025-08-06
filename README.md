# SamuelLiska.Dev

A personal portfolio and game hosting platform built with **ASP.NET Core MVC (v9)**, **Entity Framework Core**, and **SQLite**.  
It serves as a showcase for Unity WebGL games, SWE skills and includes features like:

- Game catalog with categories and features
- Local SQLite database with seeding
- Unity WebGL games hosted under `/games/`
- Deployable to Windows hosting providers (IIS / SmarterASP) or Azure

---

## 📂 Project Structure

```
SamuelLiska.Dev/
├── Domain/               # Domain entities following DDD
├── DataAccess/           # EF Core DbContext & Migrations
├── BusinessLayer/        # Services, DTOs, and AutoMapper profiles
├── Infrastructure/       # Unit of Work and repository pattern
├── MVC/                  # ASP.NET Core MVC project
├── WebAPI/               # ASP.NET WebApi project
└── README.md
```

---

## 🚀 Features

- **Game Management**
  - List games, categories, and features
  - Features like *ObjectPooling*, *ProceduralGeneration*, *PerlinNoise*, etc.
- **Unity WebGL Hosting**
  - Games can be played directly in the browser
  - Supports Brotli / Gzip compression
- **EF Core with Seeding**
  - Automatically seeds sample games, features, and relationships
  - Uses **many-to-many** join tables: `CategoryGame`, `GameFeature`
- **Deployable Anywhere**
  - Supports IIS (Windows Hosting)
  - Azure App Service or Azure Static Hosting

---

## 🛠️ Tech Stack

- **Backend:** ASP.NET Core MVC 9, C#  
- **ORM:** Entity Framework Core 9 + SQLite  
- **Frontend:** Razor Views 
- **Hosting:** Windows IIS / Azure App Service  

---

## ⚡ Local Development

1. **Clone the repository**
   ```bash
   git clone https://github.com/<your-username>/SamuelLiska.Dev.git
   cd SamuelLiska.Dev/MVC
   ```

2. **Run EF Core migrations**
   ```bash
   dotnet ef database update --project DataAccess --startup-project MVC / WebAPI
   ```

3. **Run the project**
   ```bash
   dotnet run --project MVC / WebApi
   ```

4. Open in browser:  
   ```
   http://localhost:5000
   ```

---

## 🌐 Deployment

### **IIS / SmarterASP (Windows Hosting)**

1. **Publish the project**
   ```bash
   dotnet publish -c Release
   ```

---

### **Azure App Service**

1. **Create an App Service (Windows or Linux)**  
2. **Publish via Visual Studio** or:
   ```bash
   dotnet publish -c Release
   ```
3. Deploy `MVC/bin/Release/.net9/publish` folder via FTP or GitHub Actions.

---

## 🎮 Hosting Unity WebGL Games

- Place your Unity **Build folder** inside:
  ```
  wwwroot/games/<GameName>/
  ```
- Ensure compression settings:
  - **Recommended:** Gzip instead of Brotli for shared hosting
  - Serve `.data.gz`, `.wasm.gz`, `.js.gz` with proper MIME & `Content-Encoding: gzip`  

Example endpoint:
```
https://samuelliskadev.com/games/proceduralrpg/index.html
```

---

## 📦 Database

- **SQLite** used for development & hosting  
- Auto-seeded with:
  - 2 Games
  - 9 Features
  - Sample many-to-many relations in `GameFeature` & `CategoryGame`

---

## 📝 License

This project is for **personal portfolio purposes**.  
Unity game builds and assets are **not for commercial distribution**.

---

## 💡 Future Improvements

- Add admin panel for uploading new games dynamically  
- Switch to Azure SQL for cloud hosting  
- Optimize Unity WebGL builds for mobile browsers
- Finish unfinished games
