# ⚡ SocialApp API: The High-Performance Social Backend

<p align="center">
  <img src="https://img.shields.io/github/license/[YOUR_GITHUB_USERNAME]/[YOUR_REPO_NAME]?style=for-the-badge&color=2ecc71" alt="License">
  <img src="https://img.shields.io/badge/Framework-ASP.NET_Core_8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="ASP.NET Core">
  <img src="https://img.shields.io/badge/API_Docs-Swagger_UI-85EA2D?style=for-the-badge&logo=openapi-initiative" alt="Swagger">
  <img src="https://img.shields.io/badge/RealTime-SignalR-FF5733?style=for-the-badge&logo=signalr" alt="SignalR">
</p>

---

## ✨ Project Overview

This repository hosts the **core backend** for the **SocialApp** platform. It is a robust, scalable **RESTful API** built on **ASP.NET Core**, meticulously engineered to handle all facets of a modern social network, from **real-time communication** to advanced **content management**.

### **🔥 Core Architectural Highlights**

| Aspect | Description |
| :--- | :--- |
| **Clean Architecture** | Strict separation of concerns (Controllers → Services → Repositories). |
| **Asynchronous Operations** | Full `async`/`await` implementation for high throughput and non-blocking I/O. |
| **Security-first** | **JWT Authentication** reinforced with **Role-based Access Control (RBAC)**. |
| **Real-time Comms** | Integration of **SignalR** for seamless notifications and messaging. |
| **Data Management** | **Entity Framework Core** coupled with the **Unit of Work** pattern for reliable transactions. |

---

## 🛠️ Technology Stack

We utilize a modern and powerful set of technologies to ensure speed, security, and stability.

| Layer | Technology | Purpose |
| :--- | :--- | :--- |
| **Backend** | ASP.NET Core 8 🌐 | High-performance Web API framework. |
| **Auth & Identity** | ASP.NET Core Identity + JWT 🔑 | Secure token-based authentication and user management. |
| **ORM** | Entity Framework Core 💾 | Data access, querying, and code-first migrations. |
| **Database** | SQL Server 🗃️ | Primary persistent data storage. |
| **Real-Time** | **SignalR** 💬 | Enables real-time notifications and chat functionality. |
| **Mapping** | AutoMapper 🔄 | Simplifies object-to-object mapping (DTOs to Entities and vice versa). |

---

## 🌟 Key Modules & Features

The API is fully featured, offering endpoints for all complex social interactions:

### **1. User Management** 👥
* Full registration, login, and secure logout functionality.
* User profile management (bio, profile picture, role assignment).
* **Role-based permissions** for administrative and regular users.

### **2. Posts & Content** 🖼️
* **Full CRUD** (Create, read, update, delete) operations for posts.
* Media attachments support (images, videos).
* Comprehensive commenting system with replies.
* Like/Unlike mechanism.

### **3. Friendships** 🤝
* API endpoints to **send, accept, reject, or remove** friend requests.
* View friends list and pending requests.

### **4. Messaging & Conversations** 💬
* **Real-time chat** between users utilizing **SignalR**.
* Support for private conversations and retrieving conversation history.
* Functionality to mark messages as read.

### **5. Notifications** 🔔
* **Real-time notifications** for events like likes, comments, friend requests, and new messages.
* Endpoints to mark notifications as read and retrieve historical data.

### **6. Files & Media Upload** 📁
* Secure endpoints to **upload and store** media files (images and videos).
* Retrieve and delete files by ID.

### **7. Explore & Search** 🔍
* Robust search functionality across both users and posts.
* Dedicated endpoint to view **trending posts** globally.

### **8. Admin Dashboard** ⚙️
* Administrative endpoints to manage users (view, delete).
* Control and manage posts (view, delete) across the platform.
* View system analytics and activity logs.

---

## ⚡ Project Workflow / Flow

A high-level view of the major system workflows:

1.  **User Auth:** Register or login $\rightarrow$ Receive **JWT** $\rightarrow$ Access protected endpoints.
2.  **Content Management:** Users create posts $\rightarrow$ Comments & Likes are recorded $\rightarrow$ **SignalR Notifications** are triggered instantly.
3.  **Messaging:** Real-time messages are exchanged via **SignalR** $\rightarrow$ History is stored and marked as read.
4.  **File Handling:** Users upload images/videos $\rightarrow$ Stored on server/cloud $\rightarrow$ Attached to posts or messages.

---

## 📷 Project Mockups / Conceptual Screens

These images are conceptual placeholders designed to illustrate the general layout and functional flow of the platform integrated with this backend.

| Feature | Visual Representation |
| :--- | :--- |
| **Admin Dashboard** | ![Dashboard Mockup](https://via.placeholder.com/800x200.png?text=Admin+Dashboard) |
| **User Feed** | ![Feed Mockup](https://via.placeholder.com/800x200.png?text=User+Feed) |
| **Messaging Screen** | ![Messaging Mockup](https://via.placeholder.com/800x200.png?text=Messaging+Screen) |
| **Notifications Screen** | ![Notifications Mockup](https://via.placeholder.com/800x200.png?text=Notifications+Screen) |

---

## 💻 Getting Started (Local Setup)

Follow these steps to set up and run the SocialApp API on your local machine.

### Prerequisites
* **[.NET 8 SDK](https://dotnet.microsoft.com/download)**
* **SQL Server** or any compatible database.
* Visual Studio 2022 / VS Code

### Installation Steps
```bash
# 1. Clone the repository
git clone [https://github.com/abda-24/SocialApp.git](https://github.com/abda-24/SocialApp.git)
cd SocialApp

# 2. Update connection strings in appsettings.json
#    Ensure your database credentials are correct!

# 3. Apply database migrations for Auth and Application Contexts
#    (Requires Entity Framework Core tools)
dotnet ef database update -c AuthDbContext
dotnet ef database update -c AppDbContext

# 4. Run the project
dotnet run
