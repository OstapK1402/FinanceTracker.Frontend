# 💰 Personal Finance Manager


## 📖 Опис
**Personal Finance Manager** — це веб-застосунок для обліку фінансів.  
Додаток дозволяє вести облік доходів і витрат, додавати категорії, переглядати історію операцій та формувати щоденні й періодичні звіти.  
Система складається з **бекенду** (API) і **фронтенду** (користувацький інтерфейс), що працюють незалежно.


## ⚙️ Технології

### Backend
- .NET 8
- ASP.NET Core Web API  
- Entity Framework Core (Code First, Migrations)  
- MS SQL Server  
- AutoMapper  
- Dependency Injection
- LINQ, async/await

### Frontend
- Blazor  
- Bootstrap 
- REST API
- AutoMapper  
- Dependency Injection
- LINQ, async/await

- ## ✅ Основний функціонал 
- 💵 **Облік доходів та витрат**  
- 📂 **Категорії фінансових операцій**  
- 📊 **Звіти**: щоденні та періодичні


## 🚀 Як запустити

### Backend
1. Клонувати репозиторій бекенду:
   ```bash
   git clone https://github.com/OstapK1402/FinanceTracker.Backend.git
   cd Task 11
2. Відкрити файл appsettings.json і змінити ім’я сервера у рядку підключення:
  "ConnectionStrings": {
  "DefaultConnection": "Server=ТВІЙ_СЕРВЕР;Database=BankDb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True"
  } Наприклад:
  Server=LAPTOP\SQLEXPRESS;Database=BankDb;
3. Застосувати міграції та створити базу:
   Update-Database
5. Запустити застосунок


### Frontend
1. Клонувати репозиторій бекенду:
   ```bash
   git clone https://github.com/OstapK1402/FinanceTracker.Frontend.git
   cd Task12
2. Запустити застосунок
