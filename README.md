# SmartBookStore MVC

SmartBookStore MVC is a web application built with ASP.NET Core 8, Entity Framework Core, Identity, SQL Server, and Stripe for payment processing. The application allows users to manage their book store, including CRUD operations for books, user authentication, and handling payments.

## Features

- **User Authentication & Authorization**: Integrated with ASP.NET Core Identity for managing users and roles.
- **CRUD Operations**: Perform create, read, update, and delete operations on books and manage book listings.
- **Stripe Payment Integration**: Secure payment processing using Stripe API.
- **Entity Framework Core**: Code-first migrations for database management.
- **Bootstrap 5**: Used for front-end responsive design.
- **Role Management**: Admins can manage roles and user permissions.
- **Database Seed & Migration**: Automatic database seeding and migrations for data consistency.

## Tech Stack

- **ASP.NET Core 8 MVC**
- **Entity Framework Core**
- **ASP.NET Core Identity**
- **Stripe API**
- **SQL Server**
- **Bootstrap 5**

## Prerequisites

- **Visual Studio 2022** (or newer)
- **ASP .net Core 8**
- **SQL Server Management Studio** (for database management)
- **Stripe Account** (for payment integration)

## Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/UsmanAsad87/SmartBookStore_MVC.git
   ```

2. Navigate to the project directory:

   ```bash
   cd SmartBookStore_MVC
   ```

3. Open the solution in **Visual Studio 2022**.

4. Configure your **SQL Server** connection string in the `appsettings.json` file:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=your_server;Database=SmartBookStoreDb;Trusted_Connection=True;"
   }
   ```

5. Install the required NuGet packages (EF Core, Stripe, etc.).

6. Apply the migrations and seed the database:

   - Open **Package Manager Console** in Visual Studio.
   - Run the following commands:

     ```bash
     Update-Database
     ```

7. Set up Stripe by adding your **Stripe API keys** in the `appsettings.json`:

   ```json
   "Stripe": {
     "PublishableKey": "your_stripe_publishable_key",
     "SecretKey": "your_stripe_secret_key"
   }
   ```

## Running the Application

To run the application locally:

1. Press **Ctrl + F5** in Visual Studio to start the application.

2. The application should now be running locally at `http://localhost:5000` (or whichever port is configured).

## Features to Explore

- **Book Management**: Admins can add, update, or delete books.
- **Payment Handling**: Process payments securely using Stripe.
- **User Management**: Admins can manage users, roles, and permissions.
- **Email Notifications**: Email notifications are sent for important actions (e.g., order confirmation).

## Deployment

To deploy the application on **Microsoft Azure** or **IIS**, follow the respective platform documentation for ASP.NET Core deployment.
