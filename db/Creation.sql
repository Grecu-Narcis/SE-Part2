CREATE DATABASE db_ISS
go
use db_ISS

CREATE TABLE AdAccount (
	ID int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	NameOfCompany VARCHAR(30),
	DomainOfActivity VARCHAR(30),
	WebSiteUrl VARCHAR(30),
	Password VARCHAR(30),
	TaxIdentificationNumber VARCHAR(30),
	HeadquartersLocation VARCHAR(30),
	AuthorizingInstitution VARCHAR(30),
)


CREATE TABLE Campaign (
	ID int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	Name VARCHAR(30),
	StartDate DATE,
	Duration INT,
	AdAccountID INT FOREIGN KEY REFERENCES AdAccount(ID)
)


CREATE TABLE AdSet (
	ID int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	Name varchar(30),
	TargetAudience VARCHAR(30),
	AdAccountID INT FOREIGN KEY REFERENCES AdAccount(ID),
	CampaignID INT FOREIGN KEY REFERENCES Campaign(ID)
)
ALTER TABLE AdSet
ADD CONSTRAINT FK_CampaignID
FOREIGN KEY (CampaignID)
REFERENCES Campaign(ID)
ON DELETE SET NULL;


CREATE TABLE Ad (
	ID int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	Name VARCHAR(30),
	Description VARCHAR(255),
	Url VARCHAR(255),
	Photo VARCHAR(255),
	Video VARCHAR(30),
	AdAccountID INT FOREIGN KEY REFERENCES AdAccount(ID),
	AdSetID INT FOREIGN KEY REFERENCES AdSet(ID)
)
ALTER TABLE Ad
ADD CONSTRAINT FK_AdSetID_AdSet
FOREIGN KEY (AdSetID)
REFERENCES AdSet(ID)
ON DELETE SET NULL;



CREATE TABLE AdPayment (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	AdAccountID INT FOREIGN KEY REFERENCES AdAccount(ID)
)


CREATE TABLE AdSetPayment (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	AdAccountID INT FOREIGN KEY REFERENCES AdAccount(ID)
)


CREATE TABLE CampaignPayment (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	AdAccountID INT FOREIGN KEY REFERENCES AdAccount(ID)
)


CREATE TABLE Subscription (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(30),
	RemainingCampaigns VARCHAR(30),
	AdAccountID INT FOREIGN KEY REFERENCES AdAccount(ID)
)


CREATE TABLE Influencer (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(30),
	FollowerCount int, 
	CollaborationPrice int
)

CREATE TABLE Request (
	AdAccountID INT FOREIGN KEY REFERENCES AdAccount(ID),
	InfluencerID INT FOREIGN KEY REFERENCES Influencer(ID),
	RequestID int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	AdOverview VARCHAR(1000),
	CollaborationTitle VARCHAR(255),
	ContentRequirements VARCHAR(1000),
	CompensationPackage VARCHAR(255),
	InfluencerAccept bit,
	AdAccountAccept bit,
	StartDate Date,
	EndDate Date
)


CREATE TABLE Collaboration (
	AdAccountID INT FOREIGN KEY REFERENCES AdAccount(ID),
	InfluencerID INT FOREIGN KEY REFERENCES Influencer(ID),
	CollaborationID int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	Status BIT,
	AdOverview VARCHAR(150),
	CollaborationTitle VARCHAR(255),
	ContentRequirements VARCHAR(100),
	CollaborationFee VARCHAR(100),
	StartDate Date,
	EndDate Date
)

INSERT INTO Influencer VALUES ('Selly', 10000, 1000)

INSERT INTO Influencer VALUES ('Lebron James', 6000000, 150), ('Dua Lipa', 250000, 60), ('Mihai Bendeac', 10000, 15)

