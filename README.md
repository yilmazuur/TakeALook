# TakeALook
Good .NET Web API service programming sample coded by myself. I have removed some of the business logic for security, so be aware of that when you check the code. Services are running on local IIS at port 88 (Do not forget to set it up). In this project you fill find:
 - **Web API Solution Best Practices:** a loosely coupled, scalable and testable Web API application
 - **Entity Framework Code First:** Mapping and Migration with explanations in comment lines
 - **Generic Repository Pattern combined with UnitOfWork Pattern**
 - **Swagger(Swashbuckle) API Documentation**
 - **Test Driven Development (NUnit) :** Entity Framework and Web API controller testing
 - How to load external ascx controls from an assembly using service calls: html and jquery/javascript 


Project files are: 
 - **TakeALook.API :** web application to host Web API. There are swagger documentation codesand configuration codes in here.
 - **TakeALook.API.Core :** contains Web API components such as Controllers and ServiceResponse.cs
 - **TakeALook.Model :** entity models are here.
 - **TakeALook.Model.Interface :** interfaces of entity models are here
 - **TakeALook.Operation :** this is an operation layer that contains business logic.
 - **TakeALook.Operation.Interface :** interfaces of operation layer are here.
 - **TakeALook.Repository :** contains db mappings, migration way, generic repository, unitOfWork and DBcontext.
 - **TakeALook.Repository.Interface :** interfaces of repository layer
 - **TakeALook.UnitTest :** unit tests are in here. (used NUnit)

You should check packages files of csproj files to see which package used for which layer.

**After you download the application enable migration using package manager console:**

    Enable-Migrations –EnableAutomaticMigrations -Force -Verbose

**Update DB with newly defined classes if necessary or for the first time using package manager console:**

    Update-Database -Verbose -ConnectionStringName "TakeALookEntities" 

**Swashbuckle Documentation link**

    http://localhost:88/docs/v1/index/

![alt tag](https://raw.githubusercontent.com/yilmazuur/TakeALook/master/screenshot.PNG)

##License
```
The MIT License (MIT)

Copyright (c) 2016 Uğur Yılmaz

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
License located in `LICENSE.md`


