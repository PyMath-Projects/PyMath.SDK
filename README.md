# PyMathSDK


## Overview

PyMathSDK is a versatile NuGet package that provides a generic-purpose SDK for organizations to handle common objects
and enums. It offers a set of tools and utilities to streamline the management of various objects and enums that an 
organization might require. This SDK aims to simplify development and improve productivity by providing reusable 
components.

## Installation

You can install PyMathSDK using NuGet Package Manager in Rider or by using the .NET CLI. 
Here's how you can do it in Rider:

### NuGet Package Manager (JetBrains Rider)

1. Open your project in Rider.
2. Find the "Show Nuget Tool Window' command. You can press shift twice and search for it from the pop up window.
3. On the Nuget Tool Window, find Sources and add a new source pointing to: 
   https://nuget.pkg.github.com/PyMath-Projects/index.json  
   Authenticate using a Personal Access token from the Organisation.
4. Search for PyMathSDK and install any of the required subpackages.
5. Click on the "Install" button to add the package to your project.

Follow the appropriate instructions of the IDE you are using if it is not Rider.

## Features

- **Organization Enums**: PyMathSDK provides a collection of commonly used enums for organizations. 
  These enums can be used to represent various aspects like departments, roles, status, currency, country, etc.


- **Common Objects**: The SDK includes generic-purpose common objects that organizations frequently use. 
  These objects are designed to be flexible and customizable to meet specific organizational needs.


- **Simplified Development**: By using PyMathSDK, you can save development time by leveraging pre-built components for managing objects and enums. Focus on business logic instead of reinventing the wheel.


- **Easy Integration**: PyMathSDK is designed to seamlessly integrate into your existing projects. It follows standard coding conventions and is compatible with popular development frameworks.

## Usage

### Organization Enums

PyMathSDK provides a set of enums that can be used to represent common attributes in organizations. To use an enum, simply reference it in your code:

```csharp
using PyMathSDK.Common.Enums;

...

Department department = Department.Marketing;
UserRole role = UserRole.Admin;
EmployeeStatus status = EmployeeStatus.Active;
```

### Common Objects

The common objects provided by PyMathSDK are designed to be simple and extensible. 
You can use these objects in your project by instantiating them with the necessary data:

```csharp
using PymathSDK.Objects;

...

// Create a new instance of the Employee class
Employee employee = new Employee
{
    FirstName = "John",
    LastName = "Doe",
    Department = Department.HumanResources,
    Role = UserRole.Manager,
    Status = EmployeeStatus.Active
};

// Perform operations with the employee object
...
```

## Contributing

We welcome contributions to enhance the functionality and usability of PyMathSDK. 
If you have found a bug, have suggestions, or want to contribute in any way, please follow our [contribution guidelines](https://example.com/pymathsdk/contributing).

## License

PyMathSDK is licensed under our organization's internal licensing agreement. 
It is intended solely for private use within our organization and may not be distributed or used outside our 
organization without proper authorization.

## Support

If you encounter any issues or have questions related to PyMathSDK, please reach out to our support team or contact 
the designated maintainers within our organization. We are here to assist you with any challenges or inquiries you may 
have.

---
Thank you for choosing PyMathSDK! We hope this package simplifies and enhances your development experience. 
If you have any feedback or suggestions, we'd love to hear from you. Happy coding!