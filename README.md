
**Highlights:**
- **Clean Architecture:** Separation of concerns (Controllers → Services → Repositories)  
- **Asynchronous Operations:** Full async/await for high throughput  
- **Security-first:** JWT Authentication + Role-based Access Control  
- **Real-time Communication:** SignalR for notifications and messaging  
- **Database Management:** Entity Framework Core with Unit of Work pattern  

---

## 🛠️ Technology Stack

| Layer | Technology | Purpose |
| :--- | :--- | :--- |
| Backend | ASP.NET Core 8 🌐 | High-performance Web API framework |
| Auth & Identity | ASP.NET Core Identity + JWT 🔑 | Secure token-based authentication |
| ORM | Entity Framework Core 💾 | Data access and migrations |
| Database | SQL Server 🗃️ | Persistent data storage |
| Real-Time | SignalR 💬 | Real-time notifications & chat |
| Mapping | AutoMapper 🔄 | Mapping DTOs to Entities and vice versa |

---

## 🌟 Key Modules & Features

### **1. User Management**
- Full registration, login, logout functionality  
- User profile management (bio, profile picture, role assignment)  
- Role-based permissions for admin and regular users  

### **2. Posts & Content**
- Create, read, update, delete posts  
- Attach media files (images, videos)  
- Commenting system with replies  
- Like/Unlike posts  

### **3. Friendships**
- Send, accept, reject, or remove friend requests  
- View friends list and pending requests  

### **4. Messaging & Conversations**
- Real-time chat between users using SignalR  
- Support for private conversations  
- Mark messages as read  

### **5. Notifications**
- Real-time notifications for likes, comments, friend requests, and messages  
- Mark notifications as read  
- Store historical notifications  

### **6. Files & Media Upload**
- Upload images and videos  
- Retrieve files by ID  
- Delete files  

### **7. Explore & Search**
- Search users and posts  
- View trending posts globally  

### **8. Admin Dashboard**
- Manage users (view, delete)  
- Manage posts (view, delete)  
- View analytics and activity logs  

---

## 📷 Project Mockups / Conceptual Screens

![Dashboard Mockup](https://via.placeholder.com/800x400.png?text=Admin+Dashboard)
![Feed Mockup](https://via.placeholder.com/800x400.png?text=User+Feed)
![Messaging Mockup](https://via.placeholder.com/800x400.png?text=Messaging+Screen)
![Notifications Mockup](https://via.placeholder.com/800x400.png?text=Notifications+Screen)

> These images are placeholders showing the general layout and flow of the platform.

---

## ⚡ Project Workflow / Flow

1. **User Authentication:** Register or login → Receive JWT → Access protected endpoints  
2. **Content Management:** Users can create posts → Comments & Likes → Notifications are triggered  
3. **Friendship System:** Send/accept requests → Update friends list → Trigger notifications  
4. **Messaging:** Real-time messages via SignalR → Mark as read → Update conversation history  
5. **File Handling:** Upload images/videos → Store in server → Attach to posts or messages  
6. **Admin Monitoring:** Admin can manage users/posts and view system analytics  

---

## 💻 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)  
- SQL Server or any compatible database  
- Visual Studio 2022 / VS Code  

### Installation Steps
```bash
# Clone the repository
git clone https://github.com/abda-24/SocialApp.git
cd SocialApp

# Update connection strings in appsettings.json

# Apply database migrations
dotnet ef database update -c AuthDbContext
dotnet ef database update -c AppDbContext

# Run the project
dotnet run
