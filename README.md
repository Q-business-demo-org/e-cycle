# E-Cycle

E-Cycle is a full-stack .NET project designed to revolutionize electronic waste management. Our platform connects consumers with certified e-waste recycling centers, promoting responsible disposal of electronic devices.

## Table of Contents
- [Technologies Used](#technologies-used)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [API Documentation](#api-documentation)
- [Contributing](#contributing)
- [License](#license)

## Technologies Used
- ASP.NET Core 6.0
- C# 10
- Microsoft SQL Server 2019
- React 18.2.0
- Entity Framework Core 6.0
- Identity Server 4
- Azure Blob Storage

## Features
- User authentication and authorization
- Interactive map of nearby e-waste recycling centers
- QR code generation for easy device tracking
- Recycling center dashboard for inventory management
- Reward system for frequent recyclers
- Real-time analytics on recycling trends

## Getting Started

### Prerequisites
- .NET SDK 6.0 or later
- Microsoft SQL Server 2019 or later
- Node.js 14.0 or later
- Azure account for blob storage

### Installation
1. Clone the repository
   ```
   git clone https://github.com/e-cycle/e-cycle-platform.git
   ```
2. Navigate to the project directory
   ```
   cd e-cycle-platform
   ```
3. Restore the required packages
   ```
   dotnet restore
   ```
4. Update the database connection string in `appsettings.json`
5. Apply database migrations
   ```
   dotnet ef database update
   ```
6. Navigate to the client app directory and install dependencies
   ```
   cd ClientApp
   npm install
   ```

## Usage
1. Start the backend server:
   ```
   dotnet run
   ```
2. In a separate terminal, start the React frontend:
   ```
   cd ClientApp
   npm start
   ```
3. Access the application at `http://localhost:3000`

## API Documentation
Our API documentation is available at `https://api.e-cycle.com/docs`. Key endpoints include:

- `GET /api/recycling-centers`: Retrieve nearby recycling centers
- `POST /api/devices`: Register a new device for recycling
- `GET /api/user/rewards`: Retrieve user's recycling rewards

For full API documentation, please refer to our [API Guide](https://e-cycle.com/api-guide).

## Contributing
We welcome contributions to E-Cycle! Please follow these steps:

1. Fork the repository
2. Create a new branch: `git checkout -b feature-branch-name`
3. Make your changes and commit them: `git commit -m 'Add some feature'`
4. Push to the branch: `git push origin feature-branch-name`
5. Submit a pull request

Please read our [Contribution Guidelines](CONTRIBUTING.md) for more details.

## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
