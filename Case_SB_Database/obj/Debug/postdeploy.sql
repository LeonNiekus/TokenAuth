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
AS Source (UserId, UserName, UserPassword, UserRole, UserEmail) 
ON Target.UserId = Source.UserId 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (UserName, UserPassword, UserRole, UserEmail) 
VALUES (UserName, UserPassword, UserRole, UserEmail);

MERGE INTO Products AS Target
USING (VALUES 
        (1, 'Pen', 'Een mooie blauwe balpen.', 1.50),
		(2, 'Potlood', NULL, 0.50),
		(3, 'Gum', 'Ook beschikbaar in blauw.', 0.75),
		(4, 'Schrift', NULL, 2.10),
		(5, 'Hamsterbal', '0.25m³ inhoud', 3.25)
)
AS Source (ProductId, ProductName, ProductDescription, ProductPrice)
ON Target.ProductId = Source.ProductId
WHEN NOT MATCHED BY TARGET THEN
INSERT (ProductName, ProductDescription, ProductPrice)
VALUES (ProductName, ProductDescription, ProductPrice);
GO
