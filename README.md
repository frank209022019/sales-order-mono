# SalesOrder Assessment

This monorepo contains two distinct projects: `sales-order-api` and `sales-order-upload-app`. Both projects are designed to enable the uploading and processing of sales orders.

The `sales-order-api` project is a RESTful API that serves as the backend for the sales order system. It provides an endpoint for uploading and processing sales orders.

The `sales-order-upload-app` project is a web application that allows users to upload sales orders in a JSON format file. The app then processes the uploaded data and sends it to the "sales-order-api" backend for further processing.

*This is just a sample solution and therefore no authentication, authrorization or caching mechanisms have been implemented*.

---

# SalesOrder Client

## Overview

This is a create-react-app project that serves as the client for the SalesOrder API project. The project is built using React and TypeScript and consumes the `SalesOrder.API` to display and process sales orders. The project uses several third-party packages for styling and functionality.

## Installation and Setup

To install and run the SalesOrderClient project, please follow the steps below:

1. Install Node.js and npm from [Node.js official website](https://nodejs.org/en/).
2. Clone the repository to your local machine.
3. Navigate to the SalesOrderClient project directory in your terminal or command prompt.
4. Run the command `npm install` to install the project dependencies.
5. Run the command `npm start` to start the application.

## Packages Used

The following packages are used in this project:

- ESLInt: A pluggable and configurable linter tool for identifying and reporting on patterns in JavaScript and TypeScript
- SCSS: A CSS preprocessor that adds features like variables, nested rules, and mixins to CSS
- Typescript: A superset of JavaScript that adds optional static typing and other features
- Bootstrap: A popular CSS framework for building responsive and mobile-first websites
- React-Bootstrap: A set of reusable UI components built with Bootstrap and React
- React-Dropzone: A React library for drag and drop file uploads.
- React-Toastify A React library for displaying notifications.

## License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).

---

# SalesOrder API

## Overview

This is a .NET 6 API project which follows a tiered architecture approach and uses a code-first approach with migrations. The project is divided into four separate projects:

1. **SalesOrder.API**: Serves as the entry point to the application and is responsible for handling HTTP requests and responses

2. **SalesOrder.Service**: Responsible for implementing the business logic of the application,

3. **SalesOrder.Database**: Responsible for handling database interactions and migration scripts

4. **SalesOrder.Shared**: Contains common classes and interfaces used across the application.

## Installation and Setup

To install and run the SalesOrder API project, please follow the steps below:

1. Install .NET 6 SDK and runtime from [Microsoft's official website](https://dotnet.microsoft.com/download/dotnet/6.0).

2. Clone the repository to your local machine

3. Update the connection string in the SalesOrder.API `appsettings.development.json` file to point to your database

4. Open the `package manager console`, set the default project to `SalesOrder.Database` and run the command `update-database`. This will initalize a new database with the current model structure, and seed some mock data into the tables:
   
   - Customers
   
   - Users
   
   - Products
   
   - Categories

5. To run the API, we can set the solutions start project to `SalesOrder.API` and run the solution in `debug`

## Packages Used

The following packages are used in this project:

- Entity Framework Core is a lightweight, extensible, and cross-platform version of the popular Entity Framework data access technology
- Entity Framework Core SQL Server database provider
- Entity Framework Core design-time support
- Serilog: A logging framework that supports structured logging
- Stylecop.Analyzer: A static code analysis tool that enforces a set of style and consistency rules
- NewtonSoft.Json: A popular JSON framework for .NET

## License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).

---

# Testing Files

There is a folder named `Templates` in the root directory of the solution that includes some JSON templates that can be utilized to test the upload feature. The `SalesOrder.Service` functionality verifies the JSON file and its data against the following criteria:

- User code
- Category code
- Order date - between current date and 7 days prior
- Customer code
- Product count
- Product code & quantity
