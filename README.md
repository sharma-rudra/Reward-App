# Reward Points Management API
A complete RESTful API and frontend application built with .NET 8 and MySQL for managing member registrations, reward points, and redemptions.

## Overview
This project provides a simple yet robust system for businesses to implement a customer loyalty program. It features a secure, token-based authentication system, separate dashboards for users and administrators, and a clean, responsive user interface. The primary goal is to offer a straightforward solution for member management and points administration.


 ## ⭐ Key Features

 ### User Functionality

-   **User Registration:** New users can sign up using their first name, last name, and mobile number.
    
-   **Two-Step Login:** Secure login process requiring a mobile number first, followed by a dummy OTP (`123456`).
    
-   **Points Dashboard:** Authenticated users can view their current reward points balance.
    
-   **Redeem Points:** Users can redeem their points for rewards.
    

### Admin Functionality

-   **Admin Dashboard:** A separate, secure dashboard for administrators.
    
-   **View All Members:** Admins can view a list of all registered members and their current points.
    
-   **Add Points:** Only administrators have the authority to add points to a member's account based on purchase amounts. This is a critical security feature to prevent fraud. Admins can only add points, they cannot deduct them.


 
## ⚙️ Technology Stack

-   **Backend:** .NET 8, ASP.NET Core Web API
    
-   **Database:** MySQL
    
-   **ORM:** Entity Framework Core 8
    
-   **Authentication:** JWT (JSON Web Tokens)
    
-   **Frontend:** HTML5, Tailwind CSS, Vanilla JavaScript

## ⛓️‍💥 Setup

Follow these instructions to set up and run the project on your local machine for development and testing purposes.

### Prerequisites
Before you begin, ensure you have the following installed:
-   [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0 "null")
    
-   [MySQL Server](https://dev.mysql.com/downloads/mysql/) and a management tool like [MySQL Workbench](https://dev.mysql.com/downloads/workbench/)
    
-   [Git](https://git-scm.com/downloads)


###  📥Local Setup Guide

**Step 1: Clone the Repository** Open your terminal or command prompt and clone this repository to your local machine.

```
git clone https://github.com/sharma-rudra/Reward-App.git

cd Reward-App
```

**Step 2: Set Up the Database**

1.  Open MySQL Workbench or your preferred MySQL client.
    
2.  Create a new, empty database. For this project, the recommended name is `reward_app_db`.
    
    ```
    CREATE DATABASE reward_app_db;
    ```
    

**Step 3: Configure the Connection String**

1.  In the project's root directory, find and open the `appsettings.json` file.
    
2.  Locate the `ConnectionStrings` section.
    
3.  Update the `DefaultConnection` value to point to your local MySQL database. Replace `your_server`, `your_username`, and `your_password` with your actual credentials.
    
    ```
    "ConnectionStrings": {
      "DefaultConnection": "Server=your_server;Port=3306;Database=reward_app_db;Uid=your_username;Pwd=your_password;"
    }
    ```
    

**Step 4: Apply Database Migrations** This step will create all the necessary tables in your database and seed the default admin user.

1.  Open your terminal in the project's root directory.
    
2.  Run the following command to apply the migrations:
    
    ```
    dotnet ef database update
    ```
    
    After this command succeeds, you should see the `Members` table inside your `reward_app_db` database.
    

**Step** 5: Run **the Application**

1.  In the same terminal, run the project using the following command:
    
    ```
    dotnet run
    ```
    
2.  The application will start, and your browser should open to the login page at a `localhost` address (e.g., `http://localhost:5111`).
    

You can now use the application locally!

## 📖 API Endpoints Guide

| Method | URL                   | Description             |
|--------|-----------------------|-------------------------|
| POST   | /api/Auth/register    | Register a New User.    |
| POST   | /api/Auth/login       | Log-in (User).          |
| POST   | /api/Auth/login       | Log-in (Admin).         |
| GET    | /api/Members/points   | Get Member Points.      |
| GET    | /api/Members/redeem   | Redeem Points.          |
| GET    | /api/Admin/members    | Get All Members.        |
| GET    | /api/Admin/add-points | Add Points to a Member. |

## 🔀Functional Flow Diagram

<img width="696" height="872" alt="Functional Flow Diagram" src="https://github.com/user-attachments/assets/548fee9c-a4e7-449e-85e8-3ce87f87f60b" />

## Postman Collection
[Link](https://web.postman.co/workspace/My-Workspace~cce9876a-efae-4afd-8f1d-758b698a7ac1/collection/47936145-8fb67936-e7c6-4762-91d5-4d2d0628432b?action=share&source=copy-link&creator=47936145)


## Default Credentials

The application is pre-configured with a default admin user.

-   **Admin Mobile:**  `7697010382`
    
-   **Admin OTP:**  `123456`
    
-   **User OTP (for all registered users):**  `123456`
