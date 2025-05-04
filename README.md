# Holidays API

A full-stack application for managing and displaying holidays. The application calculates holidays for any given year (after 1583) including moving holidays like Easter Monday and Pentecost.

## Project Structure

- `Backend/` - .NET Core Web API
- `frontend/` - Vue.js frontend application

## Technologies Used

### Backend
- .NET Core 3.1
- Entity Framework Core 5.0
- SQL Server
- RESTful API

### Frontend
- Vue.js 2
- Bootstrap
- Node.js/npm

## Getting Started

### Prerequisites
- .NET Core SDK 3.1 or later
- Node.js and npm
- SQL Server
- Visual Studio Code or another IDE

### Backend Setup

1. Navigate to the Backend directory:
```
cd Backend
```

2. Restore dependencies:
```
dotnet restore
```

3. Update the database connection string in your user secrets:
```
dotnet user-secrets set "ConnectionStrings:HolidayConnection" "your_connection_string"
```

4. Run the database migrations:
```
dotnet ef database update
```

5. Start the API:
```
dotnet run
```

The API will be available at `https://localhost:5001/api/holidays`

### Frontend Setup

1. Navigate to the frontend directory:
```
cd frontend
```

2. Install dependencies:
```
npm install
```

3. Start the development server:
```
npm run serve
```

The frontend will be available at `http://localhost:8080`

## API Endpoints

- GET `/api/holidays` - Returns holidays for the current year
- GET `/api/holidays/{year}` - Returns holidays for the specified year

## Features

- Calculate holidays for any year after 1583 (Gregorian calendar)
- Automatic calculation of moving holidays (Easter Monday, Pentecost)
- Responsive web interface
- Year-based holiday filtering

## Development

To run both frontend and backend in development mode:

1. Start the backend (in Backend directory):
```
dotnet watch run
```

2. Start the frontend (in frontend directory):
```
npm run serve
```

## Notes

- The application requires a SQL Server database connection
- Moving holidays are calculated using the Gregorian calendar algorithm
- Frontend is configured to connect to the backend at https://localhost:5001
