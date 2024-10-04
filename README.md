# Wiki Viewer

## Description

Wiki Viewer is a C# WinForms application that allows users to log in to a specified wiki page securely. The application stores the user's credentials in an encrypted format and fills them in automatically when navigating to the login page.

## Prerequisites

- **.NET Framework**: Ensure you have .NET Framework 4.6 or later installed.
- **Visual Studio**: Use Visual Studio 2019 or later for development and running the application.
- **NuGet Packages**: Ensure the Microsoft.Web.WebView2 package is installed.

## Installation

1. Clone the repository or download the source code.
2. Open the solution in Visual Studio.
3. Install the required NuGet packages:
   - Right-click on the project in Solution Explorer and select **Manage NuGet Packages**.
   - Search for and install `Microsoft.Web.WebView2`.
4. Build the project to restore any missing dependencies.

## Usage

1. Run the application in Visual Studio.
2. If the username and password are not set in the configuration file, the login panel will appear, prompting you to enter your credentials.
3. After entering your username and password, click the **Save** button to store the encrypted credentials.
4. The application will then navigate to the specified wiki login page and automatically fill in the username and password fields.
5. If the credentials are already saved, the application will navigate directly to the login page without showing the login panel.

## Key Features

- Securely stores user credentials using AES encryption.
- Automatically fills in the login form when navigating to the wiki login page.
- Allows users to show the login panel by pressing `Ctrl + P`.
- Navigates to a specific wiki page after logging in.

## Security Note

- The encryption key and initialization vector (IV) are hardcoded in the application. For production use, consider securing these values, perhaps by using a secure vault or environment variables.
- Ensure that you protect sensitive information and follow best practices for storing and handling credentials.

## License

This project is open-source and can be modified and shared under the terms of the [MIT License](LICENSE).