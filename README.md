# 🍽️ Food Ordering System (Clean Architecture - ASP.NET Core)

## 📌 Project Description

A modular and scalable food ordering system built with **ASP.NET Core Web API** using **Clean Architecture** principles.

The system allows users to:
- Explore restaurants filtered by city and name
- View restaurant menus
- Create customer orders
- Manage orders and menu items
- View system-wide statistics

---

## 🏗️ Solution Structure

The solution is divided into well-organized projects to follow Clean Architecture:

FoodOrdering/
│
├── FoodOrdering.API → ASP.NET Core Web API
├── FoodOrdering.Application → Business logic (Interfaces, Services, DTOs, Validation)
├── FoodOrdering.Domain → Entities (Pure domain models)
├── FoodOrdering.Persistence → EF Core database context and configurations


Each layer depends **only on the layer beneath it**. Infrastructure and Web do not affect business rules directly.

---

## 🧱 Technologies Used

- ASP.NET Core 8 Web API
- Entity Framework Core
- SQL Server
- FluentValidation
- AutoMapper (if added)
- Swagger for API testing

---

## 📦 Features Implemented

### ✅ City Management
- `GET /api/City` - Get all cities
- `GET /api/City/{id}` - Get city by ID
- `POST /api/City` - Create a city
- `DELETE /api/City/{id}` - Delete a city

### ✅ Restaurant Management
- `GET /api/Restaurant` - Get all restaurants (optionally filter by `cityId` and `name`)
- `GET /api/Restaurant/{id}` - Get restaurant by ID
- `POST /api/Restaurant` - Create restaurant
- `PUT /api/Restaurant/{id}` - Update restaurant
- `DELETE /api/Restaurant/{id}` - Delete restaurant

### ✅ Menu Items
- `GET /api/MenuItem` - Get all menu items
- `GET /api/MenuItem/{id}` - Get menu item by ID
- `GET /api/MenuItem/ByRestaurant/{restaurantId}` - Get menu items for a restaurant
- `POST /api/MenuItem` - Create menu item
- `PUT /api/MenuItem/{id}` - Update menu item
- `DELETE /api/MenuItem/{id}` - Delete menu item

### ✅ Customers
- `GET /api/Customer` - Get all customers
- `GET /api/Customer/{id}` - Get customer by ID
- `POST /api/Customer` - Create customer
- `PUT /api/Customer/{id}` - Update customer
- `DELETE /api/Customer/{id}` - Delete customer

### ✅ Orders & Order Items
- `GET /api/Order` - Get all orders
- `GET /api/Order/{id}` - Get order by ID
- `POST /api/Order` - Create order
- `PUT /api/Order/{id}` - Update order
- `DELETE /api/Order/{id}` - Delete order

- `GET /api/OrderItem` - Get all order items
- `GET /api/OrderItem/{id}` - Get order item by ID
- `POST /api/OrderItem` - Create order item
- `PUT /api/OrderItem/{id}` - Update order item
- `DELETE /api/OrderItem/{id}` - Delete order item

### ✅ Statistics
- `GET /api/Statistics/restaurants` - Get total number of restaurants
- `GET /api/Statistics/customers` - Get total number of customers
- `GET /api/Statistics/orders` - Get total number of orders

---

## 📄 Data Flow Example (Frontend Scenario)

1. User selects a city → `GET /api/City`
2. Restaurants filtered by city → `GET /api/Restaurant?cityId=1&name=Radiant`
3. User clicks "MENU" → `GET /api/MenuItem/ByRestaurant/{id}`
4. User selects items and proceeds → totals are calculated on frontend
5. User fills in customer data → `POST /api/Customer`
6. Order is created → `POST /api/Order`
7. Order items are added → `POST /api/OrderItem`

---

## ✅ Validation

All `Create*Dto` and `Update*Dto` classes are validated using **FluentValidation**, ensuring:
- Required fields are provided
- Positive numbers where needed
- Proper string lengths

---

## 🧪 How to Run Locally

1. Clone the repo  
   `git clone https://github.com/your-username/FoodOrdering.git`

2. Open in Visual Studio or VS Code

3. Configure your `appsettings.json` with SQL Server connection

4. Apply migrations and update the database  
   `dotnet ef database update`

5. Run the API  
   `dotnet run --project FoodOrdering.API`

6. Access Swagger at: `https://localhost:<port>/swagger`

---

## 🔐 Future Improvements

- Authentication and Authorization
- Role-based admin panel
- Order tracking and delivery system
- Mobile app integration (Flutter or React Native)

---

## 👨‍💻 Author

Developed by **Mostafa Mohammed**  
Full Stack .NET Developer | [LinkedIn Profile](https://www.linkedin.com/in/mostafa-mohammed-572292189/)

---

## 📃 License

This project is open-source under the MIT License.
