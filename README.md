# Abstract Factory Design Pattern - Restaurant Menu System

A comprehensive console application demonstrating the **Abstract Factory Design Pattern** in C# with a restaurant menu system example. This project showcases clean architecture principles, SOLID design patterns, product families, and modern C# features.

## 📋 Table of Contents

- [Overview](#overview)
- [Project Structure](#project-structure)
- [Architecture](#architecture)
- [How It Works](#how-it-works)
- [Design Pattern Explained](#design-pattern-explained)
- [Factory vs Abstract Factory](#factory-vs-abstract-factory)
- [Getting Started](#getting-started)
- [AI Analysis Report](#ai-analysis-report)
- [Contributing](#contributing)
- [License](#license)

## 🎯 Overview

This project demonstrates the **Abstract Factory Design Pattern** through a multi-restaurant ordering system that supports different cuisine types (Italian, Chinese, Mexican). The abstract factory pattern encapsulates the creation of related product families, ensuring consistency and interchangeability.

### Key Features

- ✅ Clean Architecture with DDD-inspired layers
- ✅ SOLID principles implementation
- ✅ Abstract Factory pattern with multiple product families
- ✅ Modern C# 12 features (Primary Constructors, Sealed Classes)
- ✅ Type-safe product family creation
- ✅ Extensible design for adding new restaurant types

## 📁 Project Structure

```
DesignPatterns.AbstractFactory/
├── Domain/                          # Core domain layer
│   └── Meals/
│       ├── Abstractions/
│       │   ├── IMainCourse.cs       # Main course interface
│       │   ├── IAppetizer.cs        # Appetizer interface
│       │   └── IDessert.cs          # Dessert interface
│       ├── Italian/
│       │   ├── ItalianPizza.cs      # Italian main course
│       │   ├── ItalianPasta.cs      # Italian appetizer
│       │   └── ItalianTiramisu.cs   # Italian dessert
│       ├── Chinese/
│       │   ├── ChineseNoodle.cs     # Chinese main course
│       │   ├── ChineseDimsum.cs     # Chinese appetizer
│       │   └── ChineseSpringRoll.cs # Chinese dessert
│       └── Mexican/
│           ├── MexicanTaco.cs       # Mexican main course
│           ├── MexicanBurrito.cs    # Mexican appetizer
│           └── MexicanChurros.cs    # Mexican dessert
├── Infrastructure/                  # Infrastructure layer
│   └── Factories/
│       ├── Abstractions/
│       │   └── IRestaurantFactory.cs         # Abstract factory interface
│       ├── ItalianRestaurantFactory.cs       # Italian factory
│       ├── ChineseRestaurantFactory.cs       # Chinese factory
│       └── MexicanRestaurantFactory.cs       # Mexican factory
├── Application/                     # Application services layer
│   └── Services/
│       └── OrderService.cs          # Order placement service
├── Common/                          # Shared components
│   └── Enum/
│       └── RestaurantType.cs        # Restaurant type enumeration
└── Program.cs                       # Entry point
```

## 🏗️ Architecture

The project follows a layered architecture approach with clear separation of concerns:

### 1. **Domain Layer**

Contains the core business logic and domain entities organized by product families.

**Product Interfaces:**
```csharp
public interface IMainCourse
{
    void Prepare();
}

public interface IAppetizer
{
    void Prepare();
}

public interface IDessert
{
    void Prepare();
}
```

**Product Families:**
- **Italian Family**: ItalianPizza, ItalianPasta, ItalianTiramisu
- **Chinese Family**: ChineseNoodle, ChineseDimsum, ChineseSpringRoll
- **Mexican Family**: MexicanTaco, MexicanBurrito, MexicanChurros

### 2. **Infrastructure Layer**

Houses the Abstract Factory interface and concrete factory implementations.

**Abstract Factory Interface:**
```csharp
public interface IRestaurantFactory
{
    IAppetizer CreateAppetizer();
    IMainCourse CreateMainCourse();
    IDessert CreateDessert();
}
```

**Concrete Factories:**
```csharp
public sealed class ItalianRestaurantFactory : IRestaurantFactory
{
    public IAppetizer CreateAppetizer() => new ItalianPasta();
    public IMainCourse CreateMainCourse() => new ItalianPizza();
    public IDessert CreateDessert() => new ItalianTiramisu();
}
```

Each factory creates a consistent family of related products.

### 3. **Application Layer**

Contains application services that orchestrate the business logic.

```csharp
public class OrderService(IRestaurantFactory restaurantFactory)
{
    public void PlaceOrder()
    {
        var appetizer = restaurantFactory.CreateAppetizer();
        appetizer.Prepare();
        
        var mainCourse = restaurantFactory.CreateMainCourse();
        mainCourse.Prepare();
        
        var dessert = restaurantFactory.CreateDessert();
        dessert.Prepare();
    }
}
```

### 4. **Common Layer**

Shared components like enumerations used across the application.

## ⚙️ How It Works

### Factory Selection

```csharp
IRestaurantFactory factory = restaurantType switch
{
    RestaurantType.Italian => new ItalianRestaurantFactory(),
    RestaurantType.Chinese => new ChineseRestaurantFactory(),
    RestaurantType.Mexican => new MexicanRestaurantFactory(),
    _ => throw new NotSupportedException()
};
```

### Order Placement

```csharp
var service = new OrderService(factory);
service.PlaceOrder();
```

### Output Example

```
=== Italian Restaurant Order ===
Preparing authentic Italian Pizza with mozzarella..
Preparing classic Italian Pasta with tomato sauce..
Preparing traditional Italian Tiramisu with mascarpone..

=== Chinese Restaurant Order ===
Preparing delicious Chinese Noodles with soy sauce..
Steaming Chinese Dimsum with pork..
Frying Chinese Spring Rolls...

=== Mexican Restaurant Order ===
Preparing spicy Mexican Tacos with salsa..
Preparing Mexican Burrito with beans and cheese..
Making Mexican Churros with cinnamon..
```

## 🎓 Design Pattern Explained

### What is the Abstract Factory Pattern?

The **Abstract Factory Pattern** is a creational design pattern that provides an interface for creating families of related or dependent objects without specifying their concrete classes. It ensures that products created together are compatible.

### Key Concepts

#### 1. **Product Families**
Related products that work together:
- Italian family: Pizza + Pasta + Tiramisu (all Italian)
- Chinese family: Noodle + Dimsum + Spring Roll (all Chinese)
- Mexican family: Taco + Burrito + Churros (all Mexican)

#### 2. **Abstract Factory Interface**
Defines methods for creating each product type:
```csharp
IAppetizer CreateAppetizer();
IMainCourse CreateMainCourse();
IDessert CreateDessert();
```

#### 3. **Concrete Factories**
Each factory implements the interface to create one complete family:
- `ItalianRestaurantFactory` creates only Italian products
- `ChineseRestaurantFactory` creates only Chinese products
- `MexicanRestaurantFactory` creates only Mexican products

### Benefits in This Project

1. **Family Consistency**: Ensures all products come from the same family
   - ✅ Italian Pizza + Italian Pasta + Italian Tiramisu
   - ❌ Italian Pizza + Chinese Dimsum + Mexican Churros (prevented!)

2. **Separation of Concerns**: Object creation is separated from business logic

3. **Flexibility**: Easy to switch between entire product families

4. **Extensibility**: Adding a new restaurant type requires:
   - Create 3 new product classes (main, appetizer, dessert)
   - Create 1 new factory class
   - No changes to existing code

5. **SOLID Compliance**:
   - **Single Responsibility**: Each factory creates one product family
   - **Open/Closed**: Open for extension (new families), closed for modification
   - **Liskov Substitution**: All factories are interchangeable via interface
   - **Interface Segregation**: Focused interfaces for products and factories
   - **Dependency Inversion**: Depends on abstractions (IRestaurantFactory)

### When to Use Abstract Factory Pattern?

- ✅ When you have multiple related products that must be used together
- ✅ When you need to ensure product compatibility within a family
- ✅ When you want to provide a library of products and reveal only interfaces
- ✅ When runtime determination of product families is needed
- ✅ When you want to enforce constraints on which products can be used together

### Real-World Examples

1. **UI Frameworks**: Windows/Mac/Linux UI components
2. **Database Providers**: SQL Server/PostgreSQL/MySQL connection, command, adapter families
3. **Payment Systems**: Stripe/PayPal/İyzico processor, validator, refund handler families
4. **Cloud Providers**: AWS/Azure/GCP storage, database, messaging families
5. **Theming Systems**: Dark/Light mode UI component families

## 🔄 Factory vs Abstract Factory

Understanding the difference between these two patterns:

### Factory Pattern (Simple Factory)

**Purpose**: Create a single product type

**Structure**:
```
NotificationFactory
  ├── CreateEmail()
  ├── CreateSMS()
  └── CreatePush()
```

**Question it answers**: "Which notification should I create?"

**Example**: Choose between Email, SMS, or Push notification

### Abstract Factory Pattern

**Purpose**: Create families of related products

**Structure**:
```
IRestaurantFactory
  ├── ItalianFactory    → Italian (Pizza + Pasta + Tiramisu)
  ├── ChineseFactory    → Chinese (Noodle + Dimsum + Spring Roll)
  └── MexicanFactory    → Mexican (Taco + Burrito + Churros)
```

**Question it answers**: "Which product family should I create?"

**Example**: Choose an entire restaurant menu (all dishes together)

### Comparison Table

| Aspect | Factory Pattern | Abstract Factory Pattern |
|--------|----------------|--------------------------|
| **Factories** | Single factory | Multiple factories (one per family) |
| **Factory Interface** | Usually none | Required |
| **Products** | Unrelated products | Related product families |
| **Consistency** | Not enforced | Guaranteed within family |
| **Complexity** | Simple | More complex |
| **Use Case** | Object type selection | Product family selection |
| **Example** | Choose notification type | Choose UI theme |

### Evolution Path

```
Simple Factory → Factory Method → Abstract Factory
     ↓                 ↓                    ↓
  1 factory      Abstract creator    Abstract factory
                 with subclasses     with product families
```

## 🚀 Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- Visual Studio 2022 / VS Code / Rider

### Running the Application

```bash
# Navigate to project directory
cd DesignPatterns.AbstractFactory

# Restore dependencies
dotnet restore

# Run the application
dotnet run
```

### Expected Output

```
=== Italian Restaurant Order ===
Preparing authentic Italian Pizza with mozzarella..
Preparing classic Italian Pasta with tomato sauce..
Preparing traditional Italian Tiramisu with mascarpone..

=== Chinese Restaurant Order ===
Preparing delicious Chinese Noodles with soy sauce..
Steaming Chinese Dimsum with pork..
Frying Chinese Spring Rolls...

=== Mexican Restaurant Order ===
Preparing spicy Mexican Tacos with salsa..
Preparing Mexican Burrito with beans and cheese..
Making Mexican Churros with cinnamon..
```

## 🤖 AI Analysis Report

This project was analyzed using AI to evaluate the Abstract Factory Pattern implementation, code quality, and architectural decisions.

### ✅ Strengths Identified

#### 1. **Pattern Implementation (10/10)** ⭐⭐⭐⭐⭐

- ✅ Abstract factory interface properly defined (`IRestaurantFactory`)
- ✅ Three concrete factories correctly implementing the interface
- ✅ All factories have identical method signatures
- ✅ Product families are consistent and isolated

**AI Assessment**: *"Perfect implementation of Abstract Factory Pattern. All factories implement the same interface with identical methods, ensuring polymorphic behavior."*

#### 2. **Product Families (10/10)** ⭐⭐⭐⭐⭐

- ✅ Each family is self-contained (Italian, Chinese, Mexican)
- ✅ Products within a family are related
- ✅ No mixing between families
- ✅ Clear namespace organization

**AI Assessment**: *"Excellent demonstration of the product family concept. Each factory creates only products from its own family, preventing invalid combinations."*

#### 3. **Clean Architecture (9/10)** ⭐⭐⭐⭐⭐

- ✅ Domain-Driven Design layering
- ✅ Proper separation of concerns
- ✅ Well-organized folder structure
- ✅ Clear namespace hierarchy

**AI Assessment**: *"Clean architecture principles applied correctly with DDD-inspired layers. Domain layer contains business entities, infrastructure has factories, application has services."*

#### 4. **SOLID Principles (10/10)** ⭐⭐⭐⭐⭐

| Principle | Implementation | Status |
|-----------|---------------|--------|
| **Single Responsibility** | Each factory creates one product family | ✅ Excellent |
| **Open/Closed** | New families can be added without modifying existing code | ✅ Excellent |
| **Liskov Substitution** | All factories are interchangeable via interface | ✅ Excellent |
| **Interface Segregation** | Small, focused interfaces | ✅ Excellent |
| **Dependency Inversion** | Dependencies on abstractions, not concretions | ✅ Excellent |

**AI Assessment**: *"Full SOLID compliance achieved. The code is maintainable, testable, and extensible."*

#### 5. **Modern C# Features (9/10)** ⭐⭐⭐⭐⭐

- ✅ **Primary Constructors** (C# 12): `OrderService(IRestaurantFactory factory)`
- ✅ **Sealed Classes**: Prevents unnecessary inheritance
- ✅ **Switch Expressions**: Clean factory selection
- ✅ **PascalCase Naming**: C# conventions followed

**AI Assessment**: *"Modern C# features used appropriately. Code is concise, readable, and follows current best practices."*

### 📊 Overall Assessment

| Category | Rating | Notes |
|----------|--------|-------|
| **Code Quality** | ⭐⭐⭐⭐⭐ 9/10 | Clean, well-structured, readable |
| **Design Pattern** | ⭐⭐⭐⭐⭐ 10/10 | Perfect implementation |
| **SOLID Principles** | ⭐⭐⭐⭐⭐ 10/10 | Full compliance |
| **Architecture** | ⭐⭐⭐⭐⭐ 9/10 | Clean, layered architecture |
| **Extensibility** | ⭐⭐⭐⭐⭐ 10/10 | Easy to extend |

**Final AI Assessment**:
> *"Excellent Abstract Factory Pattern implementation demonstrating deep understanding of design patterns, SOLID principles, and clean architecture. The restaurant menu example effectively illustrates product families and factory abstraction. Overall rating: **9.5/10**"*

### 💡 Enhancement Suggestions

#### 1. **Unit Testing** (High Priority)
Add comprehensive tests to ensure reliability:
```csharp
[Fact]
public void ItalianFactory_CreateMainCourse_ReturnsItalianPizza()
{
    var factory = new ItalianRestaurantFactory();
    var result = factory.CreateMainCourse();
    Assert.IsType<ItalianPizza>(result);
}
```

#### 2. **Async Support** (Medium Priority)
Convert to async for better scalability:
```csharp
public interface IMainCourse
{
    Task PrepareAsync(CancellationToken cancellationToken = default);
}
```

#### 3. **Logging** (Medium Priority)
Add structured logging for production monitoring:
```csharp
public sealed class ItalianPizza(ILogger<ItalianPizza> logger) : IMainCourse
{
    public void Prepare()
    {
        logger.LogInformation("Preparing Italian Pizza");
        Console.WriteLine("Preparing authentic Italian Pizza with mozzarella..");
    }
}
```

#### 4. **Configuration** (Low Priority)
Add external configuration support:
```json
{
  "DefaultRestaurant": "Italian",
  "EnableLogging": true
}
```

## 🤝 Contributing

Contributions are welcome! This project is perfect for practicing design patterns and clean code principles.

### How to Contribute

1. **Fork** the repository
2. **Create** a feature branch (`git checkout -b feature/japanese-restaurant`)
3. **Commit** your changes (`git commit -m 'Add Japanese restaurant support'`)
4. **Push** to the branch (`git push origin feature/japanese-restaurant`)
5. **Open** a Pull Request

### Ideas for Contribution

- 🍣 Add new restaurant types (Japanese, French, Indian)
- 🧪 Add unit tests
- 📊 Add logging infrastructure
- ⚡ Add async/await support
- 📝 Improve documentation
- 🎨 Add console UI menu

## 📚 Learning Resources

### Design Patterns

- [Refactoring Guru - Abstract Factory](https://refactoring.guru/design-patterns/abstract-factory)
- [Microsoft Docs - Design Patterns](https://docs.microsoft.com/en-us/azure/architecture/patterns/)
- [Design Patterns: Elements of Reusable Object-Oriented Software (GoF Book)](https://en.wikipedia.org/wiki/Design_Patterns)

### Clean Architecture

- [Clean Architecture by Robert C. Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [SOLID Principles](https://www.digitalocean.com/community/conceptual-articles/s-o-l-i-d-the-first-five-principles-of-object-oriented-design)
- [Domain-Driven Design](https://martinfowler.com/bliki/DomainDrivenDesign.html)

## 📝 License

This project is open source and available under the [MIT License](LICENSE).

---

## 🎯 Next Steps in Your Learning Journey

After mastering the Abstract Factory Pattern, consider exploring:

1. **Builder Pattern** - Construct complex objects step by step
2. **Prototype Pattern** - Clone existing objects
3. **Singleton Pattern** - Ensure single instance creation
4. **Factory Method Pattern** - Define interface for creating objects
5. **Adapter Pattern** - Convert interface of a class into another interface

---

## 🎓 Key Takeaways

**Remember:**
- Abstract Factory creates **families of related objects**
- All factories implement the **same interface**
- Products within a family are **compatible**
- Easy to **switch entire product families**
- Prevents **mixing incompatible products**

**The Pattern in One Sentence:**
> "Abstract Factory ensures that when you pick a restaurant, you get a complete, consistent menu - not a random mix of dishes from different cuisines!"

---

**Happy Coding! 🚀**

*Questions? Open an issue or start a discussion!*
