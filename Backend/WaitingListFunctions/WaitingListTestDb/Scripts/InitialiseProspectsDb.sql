CREATE TABLE Prospects (
    Id int IDENTITY(1,1) PRIMARY KEY,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Email varchar(255),
	PhoneNumber varchar(255),
    StartDate date,
    Notes varchar(255),
    PostCode varchar(10),
    IsDeleted bit,
    SpecificStartDate bit,
    IsConfirmed bit
); 
GO


INSERT INTO Prospects (LastName, FirstName, Email, PhoneNumber, StartDate, Notes, PostCode, IsDeleted, SpecificStartDate, IsConfirmed) VALUES ('Smith', 'John', 'john.smith@gmail.com', '0123456789', '09/06/2024', 'Is blind in one eye', 'DE65 5HY', 0, 0, 0);
INSERT INTO Prospects (LastName, FirstName, Email, PhoneNumber, StartDate, Notes, PostCode, IsDeleted, SpecificStartDate, IsConfirmed) VALUES ('Smith', 'Dave', 'dave.smith@gmail.com', '0123456789', '06/13/2024', 'Is blind in one eye', 'DE65 5HY', 0, 0, 0);
INSERT INTO Prospects (LastName, FirstName, Email, PhoneNumber, StartDate, Notes, PostCode, IsDeleted, SpecificStartDate, IsConfirmed) VALUES ('Smith', 'William', 'will.smith@gmail.com', '0123456789', '06/13/2024', 'Is blind in one eye', 'DE65 5HY', 0, 0, 0);
GO