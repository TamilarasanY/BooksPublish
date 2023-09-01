In this repository I want to give a plain starting point at how to build a WebAPI with ASP.NET Core 6.0.

This repository contains a controller which is dealing with Books. 

Hope this helps.


1.Sorted List API
***************

Created a API for the return a sorted list of these by Publisher, Author (last, first), then title.

2.Sorted List By Author
**********************

 Created a API for the another API method to return a sorted list by Author (last, first) then title.

3.Store Procedure
*****************

Created Separate API methods to return the same results.

4.Get Total Price
*****************

Created an API to return the total price of all books in the database.


5.MLA Format
***********

Added MLA text Format with Separate API.

6.Chicago Text Format
*********************

Added Chicago text Format with Separate API.


------------------------X-----------------------------

In this Project we have Basic Setup of the ASP .Net Core Web API Project.

Controller - Has the Business Logic of the Project.

Entities  - Has the Database Model and Binding Models of the Project

Utilities - Has the Extra Utilities(like Text Format).

------------------------X--------------------------------

Program.cs - Has the Setup of the projects like Dependency Injection, Middlewares Etc...

Appsettings.json - has the Database connection string setup with server configuration.


------------------------X---------------------------------------------