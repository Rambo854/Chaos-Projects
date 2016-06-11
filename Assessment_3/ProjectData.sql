--Data for Assessment Three - Password Management Application. 
--This data in a actual project in the real world must be secured at all costs

Create Table LogIn
(
	logID		int		(3)	Primary Key,
	Username	varchar	(40),
	Password	varchar	(40)
);

Create Table Menu
(
	accountID	int 		(2) 	Primary Key,
	firstName	varchar	(30),
	lastName	varchar	(30),

	Foreign Key (accountID) references Accounts(accountID)
);

Create Table Accounts
(
	accountID	int 		(2),
	typeID		int 		(3),

	PRIMARY KEY (accountID, typeID),
	Foreign Key (typeID) references Details(typeID)
);

Create Table Details
(
	typeID		int 		(3)	PRIMARY KEY,
	accountType	varchar	(30),
	acctUsername	varchar	(40),
	acctPassword	varchar	(40),
	email		varchar	(100),
	phone		varchar	(20),
	websiteURL	varchar	(200)
);

Insert into LogIn
Values
(001, "darkSoulsFan", "apple12");

Insert into Menu
Values
(01, "Jake", "Artorias");

Insert into Accounts
Values
(01, 001),
(01, 002),
(01, 003),
(01, 004);

Insert into Details
Values 
(001, "Facebook Account", "", "happyLife18", "BrandIsCool172@hotmail.com", "0487 346 876",
"https://www.facebook.com/"), 
(002, "Youtube Account", "", "1punchMan635", "BrandIsCool172@hotmail.com", "0487 346 876",
"https://www.youtube.com/"), 
(003, "Microsoft Account", "", "acM1LaNw0g112", "BrandIsCool172@hotmail.com", "",
"https://www.microsoft.com/en-au/"),
(004, "Laptop Account", "wogboy17", "apple12", "", "", "");
