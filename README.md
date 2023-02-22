# SalesOrder Assessment

This monorepo contains two distinct projects: `sales-order-api` and `sales-order-upload-app`. Both projects are designed to enable the uploading and processing of sales orders.

The `sales-order-api` project is a RESTful API that serves as the backend for the sales order system. It provides an endpoint for uploading and processing sales orders.

The `sales-order-upload-app` project is a web application that allows users to upload sales orders in a JSON format file. The app then processes the uploaded data and sends it to the "sales-order-api" backend for further processing.

*This is just a sample solution and therefore no authentication, authrorization or caching mechanisms have been implemented*.

---

# SalesOrder Client

## Overview

This is a create-react-app project that serves as the client for the `SalesOrder API` project. The project is built using React and TypeScript and consumes the `SalesOrder.API` to display and process sales orders. The project uses several third-party packages for styling and functionality.

## Installation and Setup

To install and run the `sales-order-upload-app` project, please follow the steps below:

1. Install Node.js and npm from [Node.js official website](https://nodejs.org/en/).
2. Clone the repository to your local machine from [GitHub](https://github.com/frank209022019/sales-order-mono). 
3. Navigate to the `sales-order-upload-app` project root directory in your terminal or command prompt.
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

2. Clone the repository to your local machine from [GitHub](https://github.com/frank209022019/sales-order-mono).

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

# Testing Files & Responses

There is a folder named `templates` in the root directory of the solution that includes some JSON templates that can be utilized to test the upload feature. The `SalesOrder.Service` functionality verifies the JSON file and its data against the following criteria:

- User code
- Category code
- Order date - between current date and 7 days prior
- Customer code
- Product count
- Product code & quantity

The `SalesOrder.API` will return a response that could contain information regarding the failure or success of the request.

If the request has failed due to validation, server or any other issues, a JSON file with the naming strucutre `FAILED_SALES_ORDER_[DATE].json` will be returned. An example of the file structure will be:

```
{
  "result": "FAILED",
  "messages": [
    {
      "id": 1,
      "message": "Invalid user code in sales order"
    },
    {
      "id": 2,
      "message": "Invalid category code in sales order"
    },
    {
      "id": 3,
      "message": "Invalid date or date format in sales order"
    },
    {
      "id": 4,
      "message": "Invalid category code in sales order"
    },
    {
      "id": 5,
      "message": "No products found in sales order"
    }
  ]
}
```

If the request has successfully been completed, then the server will return  a different formatted JSON file with the naming structure `ORD[RANDOM_ORDER_CODE]_[CATEGORY_CODE]_[DATE].json`. This is the expected sale order for the request and an example of the file structure will be: 

```
{
  "userCode": "USR#1",
  "userFullName": "User, System",
  "orderCode": "ORDPJT5I7K20230222",
  "orderDate": "2023-02-22 15:19",
  "customerCode": "CUS#1",
  "customerName": "Golden Gate Consulting",
  "customerEmail": "golden@nomail.com",
  "customerContact": "081-3110121",
  "shippingAddress": "123 Main Street, Anytown, USA",
  "billingAddress": "123 Main Street, Anytown, USA",
  "vatPercentage": "15",
  "totalProduct": 2.0,
  "subTotal": 68.00,
  "taxTotal": 12.00,
  "orderTotal": 80.00,
  "result": "SUCCESS",
  "messages": [
    {
      "id": 1,
      "message": "Sales order completed successfully"
    }
  ],
  "products": [
    {
      "productCode": "PROD#1",
      "name": "Product #1",
      "price": 20.00,
      "quantity": 2,
      "subTotal": 34.00,
      "taxTotal": 6.00,
      "total": 40.00
    },
    {
      "productCode": "PROD#2",
      "name": "Product #2",
      "price": 40.00,
      "quantity": 1,
      "subTotal": 34.00,
      "taxTotal": 6.00,
      "total": 40.00
    }
  ]
}
```
