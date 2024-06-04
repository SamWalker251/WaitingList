CREATE TABLE Prospects (
    Id int IDENTITY(1,1) PRIMARY KEY,
    SecondName varchar(255) NOT NULL,
    FirstName varchar(255),
    Email varchar(255),
	PhoneNumber varchar(255)
); 
GO


INSERT INTO Prospects (SecondName, FirstName, Email, PhoneNumber) VALUES ('Smith', 'John', 'john.smith@gmail.com', '0123456789');
GO