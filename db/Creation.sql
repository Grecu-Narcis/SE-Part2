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

CREATE TABLE FAQ (
Id INT IDENTITY(1,1) PRIMARY KEY,
Question NVARCHAR(255) NOT NULL,
Answer NVARCHAR(MAX) NOT NULL,
Topic NVARCHAR(255) NOT NULL
);

drop table FAQ;

INSERT INTO FAQ(Question, Answer, Topic) VALUES
('What is the return policy?', 'Our return policy allows returns within 30 days of purchase.', 'Policies'),
('How do I reset my password?', 'To reset your password, click on the "Forgot Password" link on the login page.', 'Account'),
('Where are you located?', 'We are located at 1234 Main Street, Anytown, USA.', 'General'),
('What payment methods do you accept?', 'We accept Visa, MasterCard, American Express, and PayPal.', 'Payments'),
('How can I track my order?', 'You can track your order using the tracking number provided in the confirmation email.', 'Orders'),
('Do you offer gift wrapping?', 'Yes, we offer gift wrapping for an additional fee.', 'Services'),
('What are your business hours?', 'Our business hours are Monday to Friday, 9 AM to 5 PM.', 'General'),
('Can I change my shipping address?', 'You can change your shipping address within 24 hours of placing the order by contacting customer service.', 'Shipping');

select * from FAQ;







CREATE TABLE ACCOUNTS (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(255) NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    Surname NVARCHAR(255) NOT NULL,
    PhoneNumber NVARCHAR(50) NOT NULL,
    County NVARCHAR(255) NOT NULL,
    City NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    Number NVARCHAR(50) NOT NULL,
    HolderName NVARCHAR(255) NOT NULL,
    ExpiryDate NVARCHAR(50) NOT NULL
);

drop table ACCOUNTS;

INSERT INTO ACCOUNTS (Email, Name, Surname, PhoneNumber, County, City, Address, Number, HolderName, ExpiryDate)
VALUES
('user1@example.com', 'John', 'Doe', '123456789', 'County A', 'City X', 'Address 1', '1234567890123456', 'John Doe', '12/25'),
('user2@example.com', 'Jane', 'Smith', '987654321', 'County B', 'City Y', 'Address 2', '9876543210987654', 'Jane Smith', '06/23'),
('user3@example.com', 'Michael', 'Johnson', '555555555', 'County C', 'City Z', 'Address 3', '1111222233334444', 'Michael Johnson', '09/24'),
('user4@example.com', 'Emily', 'Brown', '444444444', 'County D', 'City W', 'Address 4', '5555666677778888', 'Emily Brown', '03/26'),
('user5@example.com', 'William', 'Wilson', '666666666', 'County E', 'City V', 'Address 5', '9999000011112222', 'William Wilson', '08/25'),
('user6@example.com', 'Sophia', 'Martinez', '777777777', 'County F', 'City U', 'Address 6', '3333444455556666', 'Sophia Martinez', '11/23'),
('user7@example.com', 'Alexander', 'Anderson', '888888888', 'County G', 'City T', 'Address 7', '7777888899990000', 'Alexander Anderson', '02/27'),
('user8@example.com', 'Olivia', 'Garcia', '999999999', 'County H', 'City S', 'Address 8', '4444555566667777', 'Olivia Garcia', '07/22');
 

select * from ACCOUNTS;

