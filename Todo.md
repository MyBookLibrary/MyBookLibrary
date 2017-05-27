# BookLibraty Todo list #

Do not forget to update the ToDo list by every change :)!
----------
## Features-driven Development
- [x] Create database model;
- [x] Create seed data;

### Database Model

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

### Home Feature

### Books Feature
- [x] Database maping;
- [x] Extract and use data model interface;
- [x] Create data model second partial class and inherit the respective Interface;
- [x] Define guard constants;
- [ ] Set data model constraints in MSSQL;
- [x] Set data model guard attributes in MetaData file;
- [x] Create Service Data class and implement the basic CRUD (Create, Read, Update, Delete) operations;
- [ ] Bind all in the used container-Ninject.
- [ ] Raw view for Preview, Edit, Insert, Delete;
- [ ] Add View Model with validation attributes;
- [ ] Views:
	- [ ] Index View:
		- [ ] Put some basic UI styles;
		- [ ] Test every single function from the service Preview, Edit, Insert, Delete;
	- [ ] Create View:
		- [ ] Put some basic UI styles;
		- [ ] Validation, Html.ValidationMessage, Html.ValidationSummary, Validation.RequireField;
		- [ ] Test every single function from the service Preview, Edit, Insert, Delete;
	- [ ] Edit View:
		- [ ] Put some basic UI styles;
		- [ ] Validation, Html.ValidationMessage, Html.ValidationSummary, Validation.RequireField;
		- [ ] Test every single function from the service Preview, Edit, Insert, Delete;
	- [ ] Delete Confirm View:
		- [ ] Extraxt delete consifm in modal form;
		- [ ] Put some basic UI styles;
		- [ ] Test every single function from the service Preview, Edit, Insert, Delete;
	- [ ] Test every single function from the service Preview, Edit, Insert, Delete;
	
- [ ] Routing and base Redirects/Rewrites;
- [ ] Unit testing;
- [ ] Local IIS Deployment and manual test.
	http://www.booklibrary.com
- [ ] Azure Deployment;
	http://booklibrary.azurewebsites.net/
- [ ] Continuous integrationa and delivery with Jenkins; ???

### Jenkins Tasks ???
1. [ ] Create Automatic job for the unint tests - AutomaticUnitTesting.
1. [ ] Create Manual job for SIT IIS deploy - ManualSitDeploy.

### General Tasks
1. [x] Separate the Identity in project *.Default.Auth;
1. [ ] Data provider project with the general CRUD operations *.Data.Provider;
1. [ ] Crate separate Ef Models, Pure Models and View Models and MyMapper;
	- https://lostechies.com/jimmybogard/2009/06/30/how-we-do-mvc-view-models/
1. [ ] Change the favicon;
1. [ ] Create SiteMap file. ???
1. [ ] Install and make bundle for jQuery UI;
	- http://stackoverflow.com/questions/20081328/how-to-add-jqueryui-library-in-mvc-5-project

### Research Tasks
1. [ ] Admin and other Area - research;

### Continuous Integration and Deployment
1. [ ] Start with Unit Testing
2. [ ] Jenkins integration
3. [ ] Upload in the Cloud ???




