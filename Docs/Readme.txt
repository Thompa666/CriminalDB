========== R E A D M E ============

1.Steps to create and initialize the database
----------------------------------------------
Run Source\NationalCriminalDB.sql Sricpt in your SQL Server



2.Steps to prepare the source code to build properly
-----------------------------------------------------
1.Get the connection string of the NationalCriminalDB database. 

2.Create a temp folder in your machine.

3.Find the 'SearchSite' solution -> 'SearchSite' web application -> Web.config file.

4.Update the connectionString(name='DefaultConnection') to the new database connection string value.

5.Build and publish 'SearchSite' to IIS.

6.Find the 'NCDB' solution -> 'QueryCriminalDBService' wcf service -> Web.config  file

7.Update the connectionString(name='NCDBConnectionString') to the new database connection string value.

8.Update the appSetting(name='TempFolder') to the new temp folder path value

9.Find the 'NCDB' solution -> 'HostCriminalDBService' console application -> App.config  file

10.Update the connectionString(name='NCDBConnectionString') to the new database connection string value.

11.Update the appSetting(name='TempFolder') to the new temp folder path value

12.Build the solution and run 'HostCriminalDBService' console application to host the service



3.Assumptions made and missing requirements
--------------------------------------------
1.National criminal database service and the search site operate seperately.
2.localhost:17097 is not in use on the machine which hosts the web service
3.If no results found no need to notify the inquirer

4.Feedback
-----------
Challenging because of the time frame.

