# GameZoon

GameZoon is an online platform dedicated to gaming enthusiasts. It provides a space for users to discover, discuss, and play games. This project is built using ASP.NET Core MVC, with authentication and authorization managed by the Identity package, and data stored in a SQL Server database.

## Features

- **User Authentication and Authorization**: Managed using ASP.NET Core Identity.
- **Game Library**: A collection of games available for users to browse and play.
- **User Profiles**: Personalized profiles where users can manage their game collection and interact with other gamers.
- **Discussion Forums**: Engage in conversations about your favorite games, share tips, and discuss gaming news.
- **Search Functionality**: Easily find games, users, and forum threads.

## Technologies Used

- **ASP.NET Core MVC**: For building the web application.
- **Identity Package**: For user authentication and authorization.
- **SQL Server**: For data storage and management.
- **Entity Framework Core**: For database access.

## Getting Started

### Prerequisites

- .NET 6.0 SDK or later
- SQL Server 2019 or later

### Installation

1. **Clone the repository**:
    ```sh
    git clone https://github.com/MoAdel23/GameZoon.git
    cd GameZoon
    ```

2. **Set up the database**:
    - Update the connection string in `appsettings.json` to match your SQL Server configuration.
    - Apply migrations to create the database schema:
        ```sh
        dotnet ef database update
        ```

3. **Run the application**:
    ```sh
    dotnet run
    ```

4. **Access the application**:
    Open your web browser and navigate to `https://localhost:5001`.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
