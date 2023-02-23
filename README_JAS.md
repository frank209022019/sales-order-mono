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

***If we only wish to test the JASSalesOrderController API endpoints, then we do not need to run any migrations as no database is required for this section.***

## Installation and Setup

To install and run the SalesOrder API project, please follow the steps below:

1. Install .NET 6 SDK and runtime from [Microsoft's official website](https://dotnet.microsoft.com/download/dotnet/6.0).

2. Clone the repository to your local machine from [GitHub](https://github.com/frank209022019/sales-order-mono).

3. Build the solution to restore the packages

4. To run the API, we can set the solutions start project to `SalesOrder.API` and run the solution in `debug`

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

There is a folder named `resources` in the root directory of the solution that includes some a file named `SO.json` that can be used for testing. 

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
	"order": {
		"orderRef": "TestSO123",
		"orderDate": "2023/01/23",
		"currency": "EUR",
		"shipDate": "2023/01/23",
		"categoryCode": "B2C",
		"addresses": [
					{
						"addressType": "BY",
						"locationNumber": 1234,
						"contactName": "Test Name",
						"lastName": "Test Last Name",
						"companyName": "Test Company Name",
						"addressLine1": "123 Address Line 1",
						"addressCity": "City",
						"addressState": "State",
						"postcode": 12345,
						"countryCode": "ZA",
						"phoneNumber": "",
						"emailAddress": ""
					},
					{
						"addressType": "ST",
						"locationNumber": 1234,
						"contactName": "Test Name",
						"lastName": "Test Last Name",
						"companyName": "Test Company Name",
						"addressLine1": "123 Address Line 1",
						"addressCity": "City",
						"addressState": "State",
						"postcode": 12345,
						"countryCode": "ZA",
						"phoneNumber": "",
						"emailAddress": ""
					}
				],
		"lines": [
					{
						"sku": "TestSKU1",
						"qty": 1,
						"desc": "Test SKU 1"
					},
					{
						"sku": "TestSKU2",
						"qty": 4,
						"desc": "Test SKU 2"
					},
					{
						"sku": "TestSKU3",
						"qty": 8,
						"desc": "Test SKU 3"
					}
				]
	}
}
```
