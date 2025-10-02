## Front End


This project consists of a front-end (Angular) and a back-end (.NET 8) application for an address book.

## Prerequisites

- [Angular CLI](https://angular.io/cli) (for the front end, install with `npm install -g @angular/cli`)
- [Node.js](https://nodejs.org/) (for the front end)
- [.NET 6 SDK or later](https://dotnet.microsoft.com/download) (for the back end)
- [npm](https://www.npmjs.com/) (comes with Node.js)


## Front End

1. Navigate to the front-end directory:
   cd card_dispute_portal_frontend

2. Install dependencies:

npm install

3. Start the development server:

npm start

## Backend

1. Navigate to the backend API directory:

cd card_dispute_portal_api

2. Build and run the backend:
dotnet build
dotnet run

3. (First time only) Set up the database:

Install EF Core tools (if not already installed): 
dotnet tool install --global dotnet-ef

Add the initial migration
dotnet ef migrations add InitialCreate 

Update the database:
dotnet ef database update

## Usage
Ensure both the front end and back end are running.
Open your browser and navigate to the front-end URL.
The application should now be ready to use.

## Troubleshooting
If you encounter issues with database migrations, ensure your connection string is correct in appsettings.json.
Make sure ports used by the front end and back end are not blocked or in use by other applications.

