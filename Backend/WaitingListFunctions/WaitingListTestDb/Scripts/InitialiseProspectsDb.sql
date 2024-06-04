CREATE TABLE Prospects (
    Id int IDENTITY(1,1) PRIMARY KEY,
    SecondName varchar(255) NOT NULL,
    FirstName varchar(255),
    Email varchar(255),
	PhoneNumber varchar(255),
    StartDate date 
); 
GO


INSERT INTO Prospects (SecondName, FirstName, Email, PhoneNumber, StartDate) VALUES ('Smith', 'John', 'john.smith@gmail.com', '0123456789', '09/06/2024');
GO