# ✨ SocialApp API: The Next-Gen Social Backend

![GitHub license](https://img.shields.io/github/license/[YOUR_GITHUB_USERNAME]/[YOUR_REPO_NAME]?style=for-the-badge)
![.NET Core](https://img.shields.io/badge/.NET_Core-8.0-512BD4?style=for-the-badge&logo=dotnet)
![Swagger](https://img.shields.io/badge/API_Docs-Swagger-85EA2D?style=for-the-badge&logo=openapi-initiative)
![GitHub stars](https://img.shields.io/github/stars/[YOUR_GITHUB_USERNAME]/[YOUR_REPO_NAME]?style=for-the-badge&color=yellow)

A **robust and scalable** social networking backend built with **ASP.NET Core Web API**. This project serves as the complete engine for a modern social media platform, handling everything from real-time messaging and dynamic feeds to robust user authentication and media management.

---

## 🚀 Key Features & Architectural Highlights

This API is structured into logical resource groups, providing complete RESTful operations for a fully-featured social application.

| Feature Area | Core Functionality | Key Endpoint Example |
| :--- | :--- | :--- |
| **🔐 Auth & Security** | User registration, secure JWT login, forgotten password flow, and user identity retrieval. | `POST /api/auth/register` |
| **📰 Content (Post, Likes, Comments)** | Full CRUD for Posts, managing Likes, and interactive Comment sections. | `POST /api/Post`, `POST /api/Likes` |
| **🤝 Friendship Engine** | Send, accept, and manage friend requests and view established friendships. | `PUT /api/Friendship/{id}/accept` |
| **💬 Real-Time Messaging** | Manage Conversations and exchange private Messages, fetching history by conversation ID. | `GET /api/Message-by-conversation/{conversationId}` |
| **🔔 Notifications** | Retrieve user notifications and mark them as read. | `PUT /api/Notification/{id}/read` |
| **🌍 Explore & Feed** | Logic for personalized user feeds and discovering trending content. | `GET /api/Feed/{userId}`, `GET /api/Explore/trending` |
| **🖼️ Media Handling** | Dedicated endpoint for secure file upload (images, media) and management. | `POST /api/File/upload` |
| **🔍 Search & Discovery** | Unified search across users, posts, and an 'all' search endpoint. | `GET /api/Search/all` |

---

## 🛠️ Tech Stack

| Component | Technology | Description |
| :--- | :--- | :--- |
| **Backend Framework** | **ASP.NET Core Web API** | High-performance, cross-platform framework. |
| **Authentication** | **JWT Bearer Token** | Secure, stateless authentication. |
| **Database** | **[SQL Server / PostgreSQL / MongoDB]** | *Specify your database here.* |
| **ORM** | **[Entity Framework Core / Dapper]** | *Specify your data access technology.* |
| **API Documentation**| **Swagger / OpenAPI** | Interactive API documentation. |

---

## 🚦 Getting Started

### Prerequisites

* [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or newer.
* [Your Database System] (e.g., SQL Server, PostgreSQL).

### Installation & Run

1.  **Clone the repository:**
    ```bash
    git clone [YOUR_REPO_URL]
    cd SocialApp.Backend
    ```

2.  **Database Configuration:**
    * Update the **Connection String** in `appsettings.Development.json`.
    * *If using Entity Framework Core, apply migrations:*
        ```bash
        dotnet ef database update
        ```

3.  **Run the application:**
    ```bash
    dotnet run
    ```
    The API will typically start at `https://localhost:7051`.

### API Documentation Access

Once the server is running, you can access the interactive **Swagger UI** to explore and test all endpoints:

> **[Swagger Documentation Link](https://localhost:7051/swagger/index.html)** *(Update port if necessary)*

---

## 🛡️ Authentication & Usage

All protected routes require a **JSON Web Token (JWT)**.

1.  Log in by calling `POST /api/auth/login`.
2.  Use the returned token in the `Authorization` header for all subsequent protected requests:
