
--Creating Users Table 

Create TABLE users (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(255),
    Email VARCHAR(255),
    Username VARCHAR(255),
    Password VARCHAR(255),
    State BIT,
);
Create Table role (
Role_ID int,
Role_Name VARCHAR(255)
)

ALTER TABLE users
ADD Role_ID INT;

ALTER TABLE users
ADD CONSTRAINT FK_Role
FOREIGN KEY (Role_ID)
REFERENCES role(Role_ID);


---------

CREATE PROCEDURE IniciarSesion
	-- Add the parameters for the stored procedure here
	@Password  VARCHAR(255),
	@Username  VARCHAR(255)
AS
BEGIN
	
	SELECT [ID]
	      ,[Name]
	      ,[Email]
	      ,[Username]
	      ,[State]
	      ,[Role_ID]
	FROM [dbo].[users]
	WHERE Username = @Username
		AND [Password] = @Password
		AND [State] = 1;

END
GO
---------Registrar SP------
CREATE PROCEDURE [dbo].[RegistrarUsuario] 
	@CorreoElectronico VARCHAR(255),
    @Contrasenna VARCHAR(255),
    @Nombre VARCHAR(255)
  
AS
BEGIN
	
	INSERT INTO dbo.users([Email],[Password],[Name],[State],[Role_ID])
    VALUES (@CorreoElectronico,@Contrasenna,@Nombre,1,1)

END
GO



----------ROLE INSERTION-------
INSERT INTO dbo.role(Role_ID, Role_Name)
VALUES (2, 'User');

INSERT INTO dbo.role(Role_ID, Role_Name)
VALUES (1, 'Admin');


--------Create Log Table--------
CREATE TABLE LogData (
    IdBitacora BIGINT IDENTITY(1,1) PRIMARY KEY,
    FechaHora DATETIME,
    MensajeDeError VARCHAR(5000),
    Origen VARCHAR(5000),
    IdUsuario INT,
    FOREIGN KEY (IdUsuario) REFERENCES dbo.Users(ID)
);

---------SP to insert Log-------
CREATE PROCEDURE [dbo].[RegistrarLog] 
	@MensajeError	VARCHAR(5000), 
	@Origen			VARCHAR(5000), 
	@IdUsuario		INT

AS
BEGIN

	INSERT INTO dbo.LogData(FechaHora,MensajeDeError,Origen,IdUsuario)
    VALUES (GETDATE(),@MensajeError, @Origen, @IdUsuario)

END
GO


-----Users Insert-----
USE [ProyectoPrograAvanzada]
GO

INSERT INTO [dbo].[users]
           ([Name]
           ,[Email]
           ,[Username]
           ,[Password]
           ,[State]
           ,[Role_ID])
VALUES
    ('John Doe', 'john.doe@example.com', 'johndoe', 'password123', 1, 1),
    ('Jane Smith', 'jane.smith@example.com', 'janesmith', 'abc456', 1, 2),
    ('Emily Johnson', 'emily.johnson@example.com', 'emilyjohn', 'def789', 1, 2),
    ('Michael Williams', 'michael.williams@example.com', 'mwilliams', 'ghi101', 1, 2),
    ('Sarah Brown', 'sarah.brown@example.com', 'sarahb', 'jkl202', 1, 2),
    ('Robert Lee', 'robert.lee@example.com', 'robertl', 'mno303', 1, 2),
    ('Jessica Martinez', 'jessica.martinez@example.com', 'jessicam', 'pqr404', 1, 2),
    ('David Davis', 'david.davis@example.com', 'davidd', 'stu505', 1, 2),
    ('Jennifer Anderson', 'jennifer.anderson@example.com', 'janderson', 'vwx606', 1, 2),
    ('William Thomas', 'william.thomas@example.com', 'wthomas', 'yz789', 1, 2),
    ('Linda Rodriguez', 'linda.rodriguez@example.com', 'lindar', 'pass123', 1, 2),
    ('James Wilson', 'james.wilson@example.com', 'jamesw', 'hello456', 1, 2),
    ('Karen Taylor', 'karen.taylor@example.com', 'karent', 'abc456', 1, 2),
    ('Mark Jackson', 'mark.jackson@example.com', 'markj', 'def789', 1, 2),
    ('Elizabeth White', 'elizabeth.white@example.com', 'elizw', 'ghi101', 1, 2),
    ('Charles Harris', 'charles.harris@example.com', 'charlesh', 'jkl202', 1, 2),
    ('Maria Garcia', 'maria.garcia@example.com', 'mariag', 'mno303', 1, 2),
    ('Thomas Martinez', 'thomas.martinez@example.com', 'thomasm', 'pqr404', 1, 2),
    ('Patricia Robinson', 'patricia.robinson@example.com', 'patriciar', 'stu505', 1, 2),
    ('Christopher Clark', 'christopher.clark@example.com', 'chriscl', 'vwx606', 1, 2),
    ('Barbara Lewis', 'barbara.lewis@example.com', 'barbaral', 'yz789', 1, 2),
    ('Daniel Lee', 'daniel.lee@example.com', 'daniell', 'pass123', 1, 2),
    ('Sarah Hall', 'sarah.hall@example.com', 'sarahh', 'hello456', 1, 2),
    ('Matthew Young', 'matthew.young@example.com', 'matthewy', 'abc456', 1, 2);

-- Add more rows as needed to reach the total of 25

GO

