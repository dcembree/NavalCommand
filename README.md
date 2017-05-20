# NavalCommand
A RESTful API to control naval vessels

Initial release, version 1.0.0.0

Use instructions:
1) Database setup:
Target system is SQL Express or SQL Server
Run "./Database Scripts/NavalCommandDb.sql" in SQL Management Studio
This includes the database itself, a table and some data.

2) Connection setup:
Open "NavalCommand.sln"
Navigate to "Models/NavalCommandContext.cs"
Update the connection string in "base(@"Data Source=.\SQLEXPRESS; etc.")" to point to your instance of the table created in the previous step.

3) Select your favorite browser and start the application.
The RESTful API is located at http://localhost:[yourport]/api/VesselsApi/
Example PUT and POST AJAX calls can be found in /Views/EditVessel.cshtml and /Views/CreateVessel.cshtml, respectively.
The Wiki on GitHub for the project (https://github.com/dcembree/NavalCommand/wiki/Fields-Reference) includes reference documentation.
