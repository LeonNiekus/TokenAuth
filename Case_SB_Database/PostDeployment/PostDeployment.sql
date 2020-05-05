/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

MERGE INTO Users AS Target 
USING (VALUES 
        (1, 'Leon Niekus', 'wachtwoord1', 'Admin', 'leon@outlook.com'), 
		(2, 'Luuk Ammerlaan', 'wachtwoord2', 'SuperAdmin', 'luuk@outlook.com'),
		(3, 'Avans Hogeschool', 'wachtwoord3', 'User', 'avans@outlook.com')
) 
AS Source (Id, Name, Password, Role, Email) 
ON Target.Id = Source.Id 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Name, Password, Role, Email) 
VALUES (Name, Password, Role, Email);

MERGE INTO Products AS Target
USING (VALUES 
        (1, 'Pen', 'Een mooie blauwe balpen.', 1.50),
		(2, 'Potlood', NULL, 0.50),
		(3, 'Gum', 'Ook beschikbaar in blauw.', 0.75),
		(4, 'Schrift', NULL, 2.10),
		(5, 'Hamsterbal', '0.25m³ inhoud', 3.25)
)
AS Source (Id, Name, Description, Price)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Name, Description, Price)
VALUES (Name, Description, Price);

MERGE INTO Clients AS Target
USING (VALUES 
        (1, NewID(), NewID(), 'BlackBoard', GetDate()),
		(2, NewID(), NewID(), 'Skype', GetDate()),
		(3, NewID(), NewID(), 'BobNET', GetDate())
)
AS Source (KeyId, Id, Secret, Name, CreatedOn)
ON Target.KeyId = Source.KeyId
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id, Secret, Name, CreatedOn)
VALUES (Id, Secret, Name, CreatedOn);