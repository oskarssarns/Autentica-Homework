# Project Launch Instructions

This guide provides step-by-step instructions on how to launch the C# project in Visual Studio and the frontend project in VS Code. Please follow the instructions below:

## Prerequisites

Before proceeding, make sure you have the following software installed:

- **Visual Studio** (version XYZ or higher) - [Download here](https://visualstudio.com)
- **VS Code** - [Download here](https://code.visualstudio.com)
- **.NET SDK** (version XYZ or higher) - [Download here](https://dotnet.microsoft.com/download)

## C# Project (Backend)

1. Open the C# project in Visual Studio.
2. Make sure all the required dependencies are restored. If not, right-click on the project in the Solution Explorer and select **"Restore NuGet Packages."**
3. Press the F5 key or click on the **"Start Debugging"** button to launch the project.
4. The project will be compiled and run in the configured development environment.
5. You should see the application running and any console output or debug information in the Visual Studio output window.

## Frontend Project (Angular)

1. Open the frontend project folder in VS Code.
2. Open the integrated terminal in VS Code (**View -> Terminal**).
3. Run the following command to install the project dependencies:
   npm install
4. Once the dependencies are installed, start the development server with the following command:
   ng serve
5. The frontend application will be compiled and served on a local development server.
6. Open your web browser and navigate to **`http://localhost:4200`** to access the application.

**Note**: Ensure that the C# project is running in the background before launching the frontend project.
