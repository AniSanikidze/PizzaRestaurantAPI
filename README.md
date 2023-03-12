# PizzaRestaurantAPI
PizzaRestaurantAPI is a REST API dedicated to managing and applying CRUD operations on pizza restaurant domains, namely orders, pizzas, customers and other related entities. The database for the API was implemented using Code First Approach of EF Core Framework. The API supports localization in Georgian and English Languages. 

## Architecture
The API follows clean architecture principles, separating Presentation(API Controllers),Application(Domains and Services of the API) and Infrastructure(Persistence - DB layer and Repositoy implementations) layers.

## Additional Features
* Localization(GEO and EN)
* Global exception handler middleware
* Request and response logging middleware

## Technologies
* ASP.NET Core
* EF Core
* Swagger Documentation
* MSSQL Server
* Fluent Validation for request models
* Mapster
