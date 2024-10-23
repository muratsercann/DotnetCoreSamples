
## Requirements :
	 Microsoft.EntityFrameworkCore.Tools

## Description : 
##### Open Package Manager Console and install this package to use the migration commands
	 
	 Install-Package Microsoft.EntityFrameworkCore.Tools

## Migrations
1. Open package manager console
2. Select default project
3. Run migration commands.

Create a migration :

	 Add-Migration InitialCreate
	 or
	 Add-Migration InitialCreate -Context EFCoreBasics.BloggingContext

Remove the migration :

	  Remove-Migration
	  
	 
Create or update database from migration :

	 Update-Database


