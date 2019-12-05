**************************
Notes to the testers:

Testing and using this console appication requires a postgresql database on the local machine.
Install Postgresql server and pgAdmin from https://www.postgresql.org/download/windows/

This application do not create and initialize the database, ask a sql file from the author to create the database tables on your machine.
The database password is not asked to the user, read from the errors and create a database using the password in the code at line 18 (stingconnection)! ;)

The application uses Npgsql to communicate with the database, remember to check in the dependancie and eventually to install Npgsql in your Visualstudio, using Nuget Package Manager.
Mode details on the integration of Npgsql into visualStudio, here https://www.npgsql.org/doc/ddex.html .

********************
Notes to the users:
This is a great program, the development is frenetically active. 
Be patient if something doesn't go as you expect. 
Your suggestions are wellcome. 


