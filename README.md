# 🚀 SocialApp API: Next-Generation Backend

[![License](https://img.shields.io/github/license/[YOUR_GITHUB_USERNAME]/[YOUR_REPO_NAME]?style=for-the-badge&color=2ecc71)](LICENSE)
[![.NET Core](https://img.shields.io/badge/Framework-ASP.NET_Core_8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/en-us/apps/aspnet)
[![API Documentation](https://img.shields.io/badge/Documentation-Swagger_UI-85EA2D?style=for-the-badge&logo=openapi-initiative)](https://localhost:7051/swagger/index.html)
[![GitHub Stars](https://img.shields.io/github/stars/[YOUR_GITHUB_USERNAME]/[YOUR_REPO_NAME]?style=for-the-badge&color=FFD700)](https://github.com/[YOUR_GITHUB_USERNAME]/[YOUR_REPO_NAME]/stargazers)
[![PRs Welcome](https://img.shields.io/badge/PRs-Welcome-FF69B4?style=for-the-badge&logo=github)](CONTRIBUTING.md)

---

## 🎯 Project Overview

This repository hosts the **high-performance, scalable backend** for the SocialApp platform, built entirely on **ASP.NET Core Web API**.

The API is designed following **RESTful principles** and a **layered architecture** (likely Clean or Repository Pattern) to ensure maintainability, testability, and separation of concerns. It handles all core social networking features, from content management to real-time messaging primitives.

### Architectural Highlights

* **Clean Separation:** Controllers, Services (Business Logic), and Data Access are strictly separated.
* **Asynchronous Operations:** Heavy use of `async`/`await` for non-blocking I/O, ensuring high throughput and responsiveness.
* **Security Focused:** Authentication and authorization are managed centrally using **JWT Bearer Tokens**.
* **Database First:** Uses [**Entity Framework Core** or **Dapper**] for efficient data access.

---

## 🛠️ Technology Stack

| Category | Technology | Icon | Purpose |
| :--- | :--- | :---: | :--- |
| **Backend Core** | **ASP.NET Core 8+** | 🌐 | High-performance, cross-platform API framework. |
| **Authentication** | **JWT Bearer** | 🔑 | Secure, stateless, token-based authentication. |
| **Data Access** | **[Entity Framework Core / Dapper]** | 💾 | ORM or Micro-ORM for database interaction. |
| **Database** | **[SQL Server / PostgreSQL]** | 🗃️ | Primary persistent data store. |
| **API Testing** | **Swagger/OpenAPI** | 📝 | Interactive documentation and sandbox environment. |

---

## 📚 API Endpoint Structure

The API is logically grouped to reflect the domain entities, ensuring an intuitive structure for client development.

### 🔐 Auth & Identity Management

| Endpoint | Method | Description |
| :--- | :---: | :--- |
| `/api/auth/register` | `POST` | Registers a new user account. |
| `/api/auth/login` | `POST` | Authenticates user and returns **JWT Token**. |
| `/api/auth/me` | `GET` | Retrieves the profile of the currently authenticated user. |
| `/api/UserProfile/{userId}` | `GET/PUT` | Fetches or updates a specific user profile. |

### 📰 Content & Interaction

| Endpoint | Method | Description |
| :--- | :---: | :--- |
| `/api/Post` | `GET/POST` | Retrieves all posts or creates a new one. |
| `/api/Post/{id}` | `PUT/DELETE` | Updates or deletes a specific post. |
| `/api/Likes` | `POST` | Toggles a Like status on a resource (e.g., a Post). |
| `/api/Comments` | `GET/POST` | Retrieves or adds a new comment. |

### 💬 Communication & Connectivity

| Endpoint | Method | Description |
| :--- | :---: | :--- |
| `/api/Friendship/{receiverId}`| `POST` | Initiates a friend request. |
| `/api/Friendship/{id}/accept`| `PUT` | Accepts a pending friend request. |
| `/api/Conversation` | `POST` | Creates a new private chat conversation. |
| `/api/Message-by-conversation/{conversationId}` | `GET` | Retrieves all messages within a conversation. |

### ⚙️ Discovery & Utilities

| Endpoint | Method | Description |
| :--- | :---: | :--- |
| `/api/File/upload` | `POST` | Uploads media files (images, videos) to the server. |
| `/api/Explore/trending` | `GET` | Returns globally trending and popular posts. |
| `/api/Search/all` | `GET` | Performs a unified search across users and posts. |
| `/api/Notification/{id}/read` | `PUT` | Marks a specific notification as read. |

---

## 💻 Getting Started

### Prerequisites

* **[.NET 8.0 SDK](https://dotnet.microsoft.com/download):** Required to build and run the project.
* **[Your Database System]:** (e.g., SQL Server instance running locally).

### Installation

1.  **Clone the Repository:**
    ```bash
    git clone [YOUR_REPO_URL]
    cd SocialApp.Backend
    ```

2.  **Configure Database Connection:**
    * Update the `ConnectionStrings` section in `appsettings.Development.json`.
    * *If using Entity Framework Core, run migrations:*
        ```bash
        dotnet ef database update
        ```

3.  **Run the API:**
    ```bash
    dotnet run
    # API will typically run on: https://localhost:7051
    ```

### Testing and Documentation

Access the interactive **Swagger UI** to test all API endpoints and view schemas:

> [**Open Swagger Documentation**](https://localhost:7051/swagger/index.html) *(Adjust port if required)*

---

## 🤝 Contribution Guidelines

We highly value contributions! Whether it's a feature, bug fix, or documentation improvement, your input is welcome.

1.  **Fork** the repository.
2.  Create a new branch for your feature: `git checkout -b feature/my-cool-feature`
3.  Commit your changes following the [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/) standard (e.g., `feat: Add endpoint for user blocking`).
4.  Push to the branch: `git push origin feature/my-cool-feature`
5.  Open a **Pull Request (PR)** and detail your changes.

---

## **License**

This project is licensed under the [**MIT License**](LICENSE.md).
