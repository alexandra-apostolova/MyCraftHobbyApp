# MyCraftHobby App

**MyCraftHobby** is an ASP.NET Core MVC web application designed for crafters to track and manage their knitting and crochet projects. Whether you’re a hobbyist or a serious crafter, this app helps you organize your projects, get inspired by others, and share your creations with the community.

---

## Features

- **Project Management**
  - Create new knitting or crochet projects.
  - Track the progress of each project: start, in-progress, and finished.
  - Edit or delete your projects at any time.

- **Inspiration from Others**
  - Browse projects created by other users.
  - Discover new techniques, patterns, and ideas.

- **Sharing**
  - Share your own projects with the community.
  - Upload images and descriptions for each project.

- **User Accounts**
  - Secure authentication using ASP.NET Core Identity.
  - Personalized experience with each user’s project collection.

---

## Project Structure

- **Controllers**
  - `KnitController` – Handles knitting project pages and actions.
  - `CrochetController` – Handles crochet project pages and actions.

- **Models**
  - `AppUser` – Application user class.
  - `CraftProject` – Base class for all projects.
  - `KnitProject` / `CrochetProject` – Specific project types.
  - `UserProject` – Tracks user progress for each project.

- **Views**
  - Razor Pages for creating, editing, and displaying projects.
  - Separate pages for My Projects, Details, and shared project galleries.

- **Identity**
  - ASP.NET Core Identity integration for authentication and user management.

---

## Installation

1. Clone the repository:
```bash
git clone https://github.com/yourusername/MyCraftHobby.git
cd MyCraftHobby
```
2. Open the solution
Open the solution in Visual Studio 2022 (or newer).

3. Update the connection string
In appsettings.json, update the connection string to point to your database:
```
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MyCraftHobbyDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

4. Apply migrations and create the database:
```
dotnet ef database update
```
5. Run the application
```
dotnet run
```
Once the application is running, you can navigate to https://localhost:5001 (or the URL shown in your console) to start exploring MyCraftHobby.

## Usage

### My Projects Page
- View all your projects separated into **Created**, **Started**, and **Finished**.
- Start or finish a project with a single click.
- Edit or delete your created projects.

### Project Details
- View project information including name, type, difficulty, and description.
- Start or finish the project directly from the details page.
- Navigate back to your projects or explore other projects.

### Community Inspiration
- Browse projects shared by other users.
- Get ideas and inspiration for your next project.

---

## Technologies
- ASP.NET Core MVC
- Entity Framework Core
- ASP.NET Core Identity
- Razor Pages
- Bootstrap & custom CSS for a cozy and user-friendly interface
- SQL Server (or LocalDB)

---

## Contributing
Contributions are welcome! You can:
- Submit bug reports or feature requests.
- Fork the project and create pull requests.
- Improve the UI, add new project types, or enhance functionality.

---

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

Enjoy crafting with **MyCraftHobby**! Keep your projects organized, inspired, and shareable. 🧶✨
