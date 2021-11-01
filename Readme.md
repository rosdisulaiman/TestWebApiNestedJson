### This app will be using SQL LITE FOR TESTING PURPOSE.
### The app are mean to receive a nested Json Payload every time someone enter a bulding via Frace Recognition with payload(default manufacturing format)
### Please Refer to Postman.Json for more extensive details for POST sample. :- (TEST API.postman_collection)

{
	Device Property = ScanDatas.cs
	Face Value = new Face
	[
		{
			Face Property = Face.cs
		}
	]
}

To Understand the the problem
## SELECT TESTAPI Assembly to see the expected result for SCANDATA API either in postman or swagger. 
		## POST API - data in specific json format stored with both parent and child
		## GET All Scan - will display all scan data
		## Get Scan by ID with ChildData - display selected data with nested object.

Utiling book web api core using .5 i am not able to map the DTO for Get by ID.
I also referencing both AutoMapper from CODEmaze 
https://code-maze.com/automapper-net-core/ &  https://code-maze.com/automapper-net-core-custom-projections/

but did not get the expected DTO i create. do check the CARAAPI Assembly to full Reference.

Ah by the way : CARAAPI Assembly are scafold in Entity project 