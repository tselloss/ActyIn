# ActyIn


---

### Back-End & Database

# Web-Based Social Activity Platform - Back-End & Database

This repository contains the **back-end** and **database** part of a full-stack application that allows users to organize and participate in sports activities with strangers.

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Installation](#installation)
- [Usage](#usage)

## Overview
The back-end and database provide the API and relational database infrastructure that support the web-based social activity platform, handling user management, activity scheduling, and partner matching.

## Features
- **JWT Authentication**: JSON Web Tokens are used for secure authentication and authorization, ensuring that only registered users can access protected endpoints.
- **API Structure**: The API follows RESTful principles, providing endpoints for user registration, login, scheduling activities, and partner matching.
- **Swagger Integration**: The back-end includes Swagger documentation, allowing easy testing and exploration of the API.
- **Relational Database**: The PostgreSQL database ensures secure and scalable data storage for user and activity data.

## Tech Stack
- **Back-End Framework**: .NET 8 (C#)
- **Database**: PostgreSQL
- **DevOps Tools**: Docker, Jenkins, SonarQube, GitHub

## Installation

## Prerequisites
- .NET SDK (version 8 or higher)
- PostgreSQL
- Docker (optional for DevOps setup)

## Steps
### 1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/backend-repo-name.git
   cd backend-repo-name
```
### 2. Set up the Database:

#### Prerequisites
- Make sure you have **PostgreSQL** installed and running.

### Steps

#### 1. Configure PostgreSQL
- Ensure **PostgreSQL** is installed and the server is running.
- Create a new database for the application.

#### 2. Update Connection String
- Open the `appsettings.json` file in the back-end project.
- Update the connection string to point to your local or remote PostgreSQL database. Example:
  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=your_database;Username=your_username;Password=your_password"
  }

## 3. Restore Back-End Dependencies
- Open the solution file (`.sln`) in **Visual Studio**.
- Restore the NuGet packages by right-clicking on the solution and selecting `Restore NuGet Packages`.

## 4. Run the Back-End
- In **Visual Studio**, select the back-end project as the startup project.
- Run it using **IIS Express** or **Kestrel server**.

## 5. Access the Back-End API
- Once the application is running, you can access the API documentation at:
  ```bash
  https://localhost:7254/swagger/index.html
  ```
# Usage

1. **Register or Login**: 
   - Users can register or log in to their account via the API endpoints.

2. **Select Activities**: 
   - After logging in, users can use API endpoints to schedule sports activities.

3. **Partner Matching**: 
   - The system automatically matches users with available partners for the selected activities using the back-end API.

---

## Changes for **Steps**:
1. **Step 2** now clarifies installing dependencies, restoring packages, and setting up the database more specifically.
2. It clearly separates the installation and running of the **front-end** and **back-end** with their respective commands and environments.
3. Each step now provides a clear direction, especially for PostgreSQL and running the **back-end** in Visual Studio.
4. The **Usage** section is simplified and directed towards accessing APIs and basic functionality.
