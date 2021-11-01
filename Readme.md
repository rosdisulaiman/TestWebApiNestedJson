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

but did not get the expected DTO i create. do Run the CARAAPI Assembly to see the problem.

Ah by the way : CARAAPI Assembly are scafold in Entity project.


Mapping showing null data when controller the  ScanNestedDto with profile : CreateMap<ScanData, ScanNestedDto>(); when gettting data from nested child.

{
    "id": 4,
    "scanLocation": "FF008166, Device OUT",
    "time": 946656351,
    "loggedDate": "2021-11-01T12:37:00.0399866",
    "image": null,
    "name": null,
    "faceTemperature": 0,
    "temperatureAlarm": null,
    "timestamp": 0,
    "userId": null
}

and adding include in mapping causing  500 Internal Server Error with mapping config

CreateMap<ScanData, ScanNestedDto>()
                .IncludeMembers(dest => dest.Faces);
            CreateMap<Face, ScanNestedDto>(MemberList.None);

one of the differentces is at the scanRepository i have include face property.
public ScanData GetScanDataById(int scanId, bool trackChanges) => 
FindByCondition(s => s.Id.Equals(scanId), trackChanges)
#.Include(x => x.Faces)
.SingleOrDefault(e => e.Id == scanId);