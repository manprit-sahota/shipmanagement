
# Overview
A simple CRUD operation to demonstrate usage of .NET Core 6, React Js and Docker with in-memory database. 

Screen consist of a Ship Management module. 

**Ship Attributes:**
 - Code
 - Name
 - Width
 - Length

**Implemented Validations:**
 1. All the attributes are required
 2. Ship code can be in format AAAA-1111-A1 where A can be any latin alphabet and 1 can be any number between 0 to 9.
 3. Concurrency check which prevent data loss when multiple users are using the system.
 4. Duplicate ship code is not allowed

# Technology stack
 - React Js
 - .NET Core 6 Web API
 - Fluent Validation
 - Automapper
 - Moq Testing
 - Service Repository Pattern

# Instruction to run the project
Install [Docker](https://docs.docker.com/desktop/windows/install/) , [VS Code](https://code.visualstudio.com/download) and [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) on windows machine. After installation is done, open the project in VS Code and follow below steps:

 1. Install [Docker](https://code.visualstudio.com/docs/containers/overview) and [C#](https://code.visualstudio.com/docs/languages/csharp) Extension in Visual Studio Code
 2. Build the Docker Images by right click on Docker file and select option "Build Image". There are two docker files. One is for React project which is present inside **reactclient** folder and another is for Web API which is present inside **webservice/Shipmanagement.API** folder.
 3. After both the images are build successfully, open Docker Desktop and navigate to Images tab. 
 4. Run the shipmanagement image by clicking on Run button. Click on Optional setting to set the port for project and enter port 5000. You can add name as "shipAPI" but its optional. 
 5. Navigate to Container tab and verify that Container is running. 
 6. Open browser and enter url http://localhost:5000/swagger. It should open API documentation.
 7. Now return to Docker and navigate again to Images tab.
 8. Run image shipreactapp. Add the port as 3000 and verify that it is also running fine.
 9. Navigate to browser and enter url http://localhost:3000. It should open Ship listing page.

# Screenshots
**Ship Listing** 
![enter image description here](https://i.ibb.co/gF7r16g/image.png)

**Add new ship**
![enter image description here](https://i.ibb.co/9bLSKp7/image.png)
![enter image description here](https://i.ibb.co/5WwxnRD/image.png)

# Notes

 1. Make sure that Virtualization is enabled on windows device. To enable it, go to Bios setting => System Configuration => Virtualization => Enable
 2. Make sure that docker desktop is running before building docker images
