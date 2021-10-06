# Electricity Plans
Electricity Plans is a Project for checking and comparing Electricity Products and related Tariff Calculation Plans.


## Description
Electricity Plans is build using:
- Angular for the UI Layer
- ASP.NET Core based REST API for the backend communication
- Database entries are handled by Products.json file


## Installation

Use npm/angular cli commands to install node modules and run ElectricPlansUi.

```bash
npm install
npm start
ng serve
```
Use Visual Studio or .NET CLI to run ElectricPlansApi
Visual Studio Steps;
- Open Electrify.sln file in Visual Studio
- Hit RUN or Fn+ F5 key

Upon successful installation and running of ElectricPlansUi and ElectricPlansApi
navigate to http://localhost:4200/products
ElectricPlanApi is developed using Open Api Specification and can be tested at the below location:
http://localhost:62191/swagger/index.html
API are covered using Unit Test case framework: xUnit and Mocking Framework: Moq