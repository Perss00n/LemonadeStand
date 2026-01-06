# 🍋 Lemonade Stand

A small Blazor Web App built as a coding assignment during LIA, focusing on **clean architecture**, **domain-driven design**, and **testable business logic**.

The application simulates a lemonade stand where a customer can:
- Choose a recipe
- Provide fruits and payment
- Produce lemonade
- Receive feedback on the result

No database is used — all data is handled **in-memory**.

## 🧠 Architecture Overview

The project follows **Onion Architecture** with a clear separation of concerns.

#### 🟡 Domain
Contains the core business rules:
- Entities and value objects (`Fruit`, `Apple`, `Recipe`, etc.)
- Interfaces (`IFruit`, `IRecipe`)
- No dependencies on other layers

#### 🟠 Application
Contains application logic:
- Services (`FruitPressService`)
- Interfaces (`IFruitPressService`)
- DTOs (`FruitPressResult`)
- Depends only on Domain

#### 🔵 Presentation
Blazor Web App (Interactive Server):
- UI components
- User input handling
- Dependency Injection configuration
- No business logic

#### 🧪 Tests
Unit tests for the application layer:
- Focused on business rules
- No UI or framework dependencies

## 🧪 Testing

Unit tests are written for `FruitPressService` to verify scenarios such as:
- Insufficient payment
- Insufficient fruit
- Successful production
- Correct handling of remaining fruits and change

## 🎨 UI

The frontend is built using:
- **Blazor Web App (.NET 8)**
- **Bootstrap 5**
- **Bootstrap Icons**

Features:
- Centered layout
- Clear order flow
- Visible available recipes
- Success / error feedback with alerts
- No business logic in the UI

## 🧩 Key Design Decisions

- No database — in-memory models only
- Business rules enforced in constructors and services
- Exceptions handled in UI layer
- Interfaces used to decouple logic
- Dependency Injection for services
- Clean separation between UI and logic

## 📌 Technologies Used

- C# / .NET 8
- Blazor Web App (Interactive Server)
- Bootstrap 5
- xUnit
- Onion Architecture

## 👋 Author

**Marcus Lehm**

A backend development student at Uddevalla Yrkeshögskola (Sweden) with a background in flooring and a new career in code.

📬 Reach me at:

Perss00n@gmail.com

<a href="https://marcuslehm.se" target="_blank" rel="noopener noreferrer">marcuslehm.se</a>

