# ⚡ SocialApp API: The High-Octane Social Backend

<p align="center">
  <img src="https://via.placeholder.com/800x150/000000/00FF00?text=STATUS%3A+ONLINE+%7C+ASP.NET+CORE+ENGINE+OPERATIONAL" alt="API Status Banner" />
</p>

<p align="center">
  <img src="https://img.shields.io/github/license/[YOUR_GITHUB_USERNAME]/[YOUR_REPO_NAME]?style=for-the-badge&color=00FF00" alt="License">
  <img src="https://img.shields.io/badge/Framework-ASP.NET_8-9A47DC?style=for-the-badge&logo=dotnet&logoColor=white" alt="ASP.NET Core">
  <img src="https://img.shields.io/badge/API_Docs-Swagger_UI-00BFFF?style=for-the-badge&logo=openapi-initiative" alt="Swagger">
  <img src="https://img.shields.io/github/stars/[YOUR_GITHUB_USERNAME]/[YOUR_REPO_NAME]?style=for-the-badge&color=FF69B4" alt="Stars">
  <img src="https://img.shields.io/badge/Architecture-Clean_Code-FF5733?style=for-the-badge&logo=csharp" alt="Architecture">
</p>

---

## 🛑 **[ACCESS GRANTED] Project Manifesto**

This is not just another API. This is the **SocialApp Backend**, a robust, lightning-fast engine built to power a large-scale social platform. Our focus is on **low-latency performance**, **unbreakable security**, and **developer elegance**.

### **🔥 Core Strengths**

* **ASP.NET Core Power:** Leveraging the fastest backend framework to handle millions of requests per day.
* **Decoupled Architecture:** Built on the **Clean Architecture** model, making it infinitely scalable and testable.
* **Full Spectrum REST:** Comprehensive, intuitive, and properly versioned endpoints covering every social feature imaginable.

---

## 💻 **SYSTEM SPECIFICATIONS (Tech Stack)**

We chose the best tools for maximum impact and efficiency.

| Component | Technology | 👾 Icon | Value Proposition |
| :---: | :---: | :---: | :--- |
| **Backend Core** | **ASP.NET Core 8+** | `⚡` | **Blazing fast** performance for APIs. |
| **Database** | **[PostgreSQL / SQL Server]** | `💾` | Reliable and powerful data persistence. |
| **Data Layer** | **[Entity Framework Core]** | `🔗` | Seamless interaction via asynchronous ORM. |
| **Security** | **JWT Bearer Token** | `🛡️` | Industry-standard, **stateless** authentication. |
| **Media Handling**| **Dedicated File Endpoints**| `📁` | Secure upload and management for user media. |

---

## 🗺️ **API RESOURCE MAP (The Arsenal)**

Every endpoint is categorized and detailed for easy integration. **Base Path: `/api`**

### 1️⃣ **Authentication & Identity (`/auth`)**
| Function | Method | Endpoint | Security |
| :--- | :---: | :--- | :---: |
| **New User** | `POST` | `/auth/register` | `🔓 Public` |
| **Login** | `POST` | `/auth/login` | `🔓 Public` |
| **Current User** | `GET` | `/auth/me` | `🔐 JWT Required` |
| **User Profile** | `PUT` | `/UserProfile/{userId}` | `🔐 JWT Required` |

### 2️⃣ **Content & Interaction (`/Post`, `/Likes`, `/Comments`)**
| Function | Method | Endpoint | Details |
| :--- | :---: | :--- | :--- |
| **Publish Post** | `POST` | `/Post` | The core content creation endpoint. |
| **Get Feed** | `GET` | `/Feed/{userId}` | Retrieves the user's **personalized timeline**. |
| **Toggle Like** | `POST/DELETE` | `/Likes` | Fast way to interact with content. |
| **Update Comment** | `PUT` | `/Comments/{id}` | Modify existing comments. |

### 3️⃣ **Messaging & Connectivity (`/Conversation`, `/Friendship`)**
| Function | Method | Endpoint | Details |
| :--- | :---: | :--- | :--- |
| **Send Request** | `POST` | `/Friendship/{receiverId}`| Initiate a connection request. |
| **Accept Request**| `PUT` | `/Friendship/{id}/accept`| Approve a pending request instantly. |
| **Get Messages** | `GET` | `/Message-by-conversation/{conversationId}` | Retrieve chat history for a dedicated conversation. |

### 4️⃣ **Discovery & Utilities (`/Search`, `/File`, `/Notification`)**
| Function | Method | Endpoint | Details |
| :--- | :---: | :--- | :--- |
| **Global Search** | `GET` | `/Search/all` | Unified search across **Users & Posts**. |
| **Trending Posts**| `GET` | `/Explore/trending` | Discover popular and viral content. |
| **File Upload** | `POST` | `/File/upload` | Securely upload media for posts/avatars. |

---

## 🕹️ **SETUP PROTOCOL (Get Started)**

### **Dependencies Check**

* **[.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download):** Essential for running the stack.
* **[Database Server]:** Must be accessible (e.g., local PostgreSQL instance).

### **Initialization Sequence**

1.  **Clone the Repository:**
    ```bash
    git clone [YOUR_REPO_URL]
    cd SocialApp.Backend
    ```

2.  **Database Configuration Injection:**
    * Edit the `appsettings.Development.json` file to inject your connection string.
    * *Execute Database Migrations:*
        ```bash
        dotnet ef database update 
        ```

3.  **Run the Server:**
    ```bash
    dotnet run --launch-profile "https"
    # Target URL: https://localhost:7051 (The Swagger Interface)
    ```

### **API Interface Access**

The interactive Swagger UI is your command center for testing:

> **[COMMAND LINK]**: `https://localhost:7051/swagger/index.html` 🔗

---

## 💡 **CONTRIBUTION LOGIC**

We accept all authorized personnel for contributions. Adherence to best practices is mandatory.

### **Contribution Procedure**

1.  **FORK** the repository to your own account.
2.  Create a feature branch: `git checkout -b feat/add-video-support`
3.  Commit your code using **Conventional Commits** (e.g., `fix: Resolve notification reading bug`).
4.  Open a **Pull Request** detailing the task completed.

> **_Maintainers_** appreciate clean, tested
