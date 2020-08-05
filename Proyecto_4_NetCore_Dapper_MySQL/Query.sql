**** MySQL
CREATE TABLE Thing(
	Id INT NOT NULL AUTO_INCREMENT,
	Name VARCHAR(100) NOT NULL,
	Description VARCHAR(500) NOT NULL,
	PRIMARY KEY(Id)
);
INSERT INTO Thing(Name, Description) VALUES ('Nombre 1','Description 1');
INSERT INTO Thing(Name, Description) VALUES ('Nombre 2','Description 2');
INSERT INTO Thing(Name, Description) VALUES ('Nombre 3','Description 3');
INSERT INTO Thing(Name, Description) VALUES ('Nombre 4','Description 4');
INSERT INTO Thing(Name, Description) VALUES ('Nombre 5','Description 5');

**** SQL SERVER
CREATE DATABASE DemoNetCore21DB;
GO
USE DemoNetCore21DB;
GO
CREATE TABLE Student
(
	StudentId INT IDENTITY(1,1),
	Name VARCHAR(100),
	Roll VARCHAR(100),
	Message VARCHAR(100),
	CONSTRAINT pk_Student PRIMARY KEY(StudentId),
)
GO
CREATE PROCEDURE [dbo].[SP_Student]
	@StudentId varchar(100),
	@Name varchar(100),
	@Roll varchar(100),
	@OperationType int
AS
BEGIN TRAN
	IF(@OperationType = 1) --INSERT
	BEGIN
		SET @StudentId = (SELECT COUNT(*) FROM Student) + 1
		
		INSERT INTO Student(Name, Roll)
		VALUES(@Name,@Roll)
		
		SELECT * FROM Student WHERE StudentId=@StudentId
		
	END
	ELSE IF(@OperationType = 2) --UPDATE
	BEGIN
		IF(@StudentId = 0)
		BEGIN
			ROLLBACK
				RAISERROR(N'Invalid Student !!!~',16,1);
			RETURN
		END
		
		UPDATE Student SET [Name]=@Name, Roll=@Roll
		WHERE StudentId=@StudentId
		
		SELECT * FROM Student WHERE StudentId=@StudentId
	END
	ELSE IF(@OperationType = 3) --DELETE
	BEGIN
		IF(@StudentId = 0)
		BEGIN
			ROLLBACK
				RAISERROR(N'Invalid Student !!!~',16,1);
			RETURN
		END
		
		DELETE FROM Student WHERE StudentId=@StudentId
	END
COMMIT TRAN
