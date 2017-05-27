# BookLibraty Todo list #

Do not forget to update the ToDo list by every change :)!
----------
## Features-driven Development
- [x] Create database model;
- [x] Create seed data;

### Database Model

Genres = {
	Id,
	Name
}

Authors = {
	Id,
	FirstName,
	LastName
}

Pictures = {
	Id,
	Name,
      	Width,
      	Height,
      	SizeMb,
      	Url
}

Book = {
	Id,
	Title,
      	Description,
      	Pages,
      	CreationDate,
      	PictureId,
      	AuthorId,
      	GenreId
}

----------

### Genre Feature
- [x] Database maping;
- [x] Extract and use data model interface;
- [x] Create data model second partial class and inherit the respective Interface;
- [x] Define guard constants;
- [ ] Set data model constraints in MSSQL;
- [x] Set data model guard attributes in MetaData file;
- [x] Create Data Service class and implement the basic CRUD (Create, Read, Update, Delete) operations;
- [x] Bind all in the used container-Ninject.
- [x] Raw view for Preview, Edit, Insert, Delete;
- [x] Add View Model with validation attributes;
- [x] Views:
	- [x] Index View:
		- [x] List all items with some basic UI styles;
		- [x] Test every single function from the service Preview, Edit, Insert, Delete;
	- [x] Create View:
		- [x] Put some basic UI styles;
		- [x] Validation, Html.ValidationMessage, Html.ValidationSummary, Validation.RequireField;
		- [x] Test every single function from the service Preview, Edit, Insert, Delete;
	- [x] Edit View:
		- [x] Put with some basic UI styles;
		- [x] Validation, Html.ValidationMessage, Html.ValidationSummary, Validation.RequireField;
		- [x] Test every single function from the service Preview, Edit, Insert, Delete;
	- [x] Delete Confirm View:
		- [x] Extraxt delete confirm in modal form;
		- [x] Put some basic UI styles;
		- [x] Test every single function from the service Preview, Edit, Insert, Delete;
- [ ] Unit testing:
	- [ ] Unit tests for the service layer;
	- [ ] Unit tests for the controller;	
- [ ] Routing and base Redirects/Rewrites;

### Author Feature
- [x] Database maping;
- [x] Extract and use data model interface;
- [x] Create data model second partial class and inherit the respective Interface;
- [x] Define guard constants;
- [ ] Set data model constraints in MSSQL;
- [x] Set data model guard attributes in MetaData file;
- [x] Create Data Service class and implement the basic CRUD (Create, Read, Update, Delete) operations;
- [x] Bind all in the used container-Ninject.
- [x] Raw view for Preview, Edit, Insert, Delete;
- [x] Add View Model with validation attributes;
- [x] Views:
	- [x] Index View:
		- [x] List all items with some basic UI styles;
		- [x] Test every single function from the service Preview, Edit, Insert, Delete;
	- [x] Create View:
		- [x] Put some basic UI styles;
		- [x] Validation, Html.ValidationMessage, Html.ValidationSummary, Validation.RequireField;
		- [x] Test every single function from the service Preview, Edit, Insert, Delete;
	- [x] Edit View:
		- [x] Put with some basic UI styles;
		- [x] Validation, Html.ValidationMessage, Html.ValidationSummary, Validation.RequireField;
		- [x] Test every single function from the service Preview, Edit, Insert, Delete;
	- [x] Delete Confirm View:
		- [x] Extraxt delete confirm in modal form;
		- [x] Put some basic UI styles;
		- [x] Test every single function from the service Preview, Edit, Insert, Delete;
- [ ] Unit testing:
	- [ ] Unit tests for the service layer;
	- [ ] Unit tests for the controller;	
- [ ] Routing and base Redirects/Rewrites;
	
### Books Feature
- [x] Database maping;
- [x] Extract and use data model interface;
- [x] Create data model second partial class and inherit the respective Interface;
- [x] Define guard constants;
- [ ] Set data model constraints in MSSQL;
- [x] Set data model guard attributes in MetaData file;
- [x] Create Data Service class and implement the basic CRUD (Create, Read, Update, Delete) operations;
- [x] Bind all in the used container-Ninject.
- [x] Raw view for Preview, Edit, Insert, Delete;
- [x] Add View Model with validation attributes;
- [x] Views:
	- [x] Index View:
		- [x] List all items with some basic UI styles;
		- [x] Test every single function from the service Preview, Edit, Insert, Delete;
	- [x] Create View:
		- [x] Put some basic UI styles;
		- [x] Validation, Html.ValidationMessage, Html.ValidationSummary, Validation.RequireField;
		- [x] Test every single function from the service Preview, Edit, Insert, Delete;
	- [x] Edit View:
		- [x] Put some basic UI styles;
		- [x] Validation, Html.ValidationMessage, Html.ValidationSummary, Validation.RequireField;
		- [x] Test every single function from the service Preview, Edit, Insert, Delete;
	- [x] Delete Confirm View:
		- [x] Extraxt delete consifm in modal form;
		- [x] Put some basic UI styles;
		- [x] Test every single function from the service Preview, Edit, Insert, Delete;
- [ ] Unit testing:
	- [ ] Unit tests for the service layer;
	- [ ] Unit tests for the controller;	
- [ ] Routing and base Redirects/Rewrites;
- [ ] Local IIS Deployment and manual test.
	http://www.booklibrary.com
- [ ] Azure Deployment;
	http://booklibrary.azurewebsites.net/
- [ ] Continuous integrationa and delivery with Jenkins; ???

----------

### General Tasks
1. [x] Separate the Identity in project *.Default.Auth;
1. [x] Data provider project with the general CRUD operations *.Data.Provider;
1. [x] Crate separate Ef Models, Pure Models and View Models and MyMapper;
	- https://lostechies.com/jimmybogard/2009/06/30/how-we-do-mvc-view-models/
1. [ ] Change the favicon;
1. [ ] Create SiteMap file. ???
1. [ ] Install and make bundle for jQuery UI;
	- http://stackoverflow.com/questions/20081328/how-to-add-jqueryui-library-in-mvc-5-project
	
----------

### Jenkins Tasks ???
1. [ ] Create Automatic job for the unint tests - AutomaticUnitTesting.
1. [ ] Create Manual job for SIT IIS deploy - ManualSitDeploy.

### Research Tasks
1. [ ] Admin and other Area - research;

### Continuous Integration and Deployment
1. [ ] Start with Unit Testing
2. [ ] Jenkins integration
3. [ ] Upload in the Cloud ???




