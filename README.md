# Book Library

![Cover photo](./Dockumentation/Images/Book-Pile-02.jpg) 

## Simple online bool library project.

Simple online library with the possibility of adding new books to a
database and viewing list of available books after logging in the system.

----------
## Used Technologies
- ASP.NET MVC;
- MSSQL;
- Entityframework;
- Bootstrap;
- ...

## Screenshots

### The home page

![Cover photo](./Documentation/Images/Screenshots/Home.JPG) 

### The books page

![Cover photo](./Documentation/Images/Screenshots/Books.jpg) 

### The authors page

![Cover photo](./Documentation/Images/Screenshots/Authors.jpg) 

### The genres page

![Cover photo](./Documentation/Images/Screenshots/Genres.jpg) 

## Installation
- Clone the repository localy;
- User the genreate databse script for creating database in your local MSSQL installation. Use. Change folowing lines according your locai installation.
	( NAME = N'BookLibrary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BookLibrary.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
	( NAME = N'BookLibrary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BookLibrary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
- Change the ConnectionString in the Web.config if using MSSQL Express version - BookLibrary.Clients.Web/Configurations/ConnectionStrings.config


