USE VBFlyt
GO

------------------------------------------------------------------------------------
---									STORES										 ---
------------------------------------------------------------------------------------

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[Store_GetStores]')) 
DROP PROCEDURE [dbo].[Store_GetStores]
GO

CREATE PROCEDURE [dbo].[Store_GetStores]
AS
BEGIN
	SELECT *
	FROM MAGAZINE
END
GO


IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[Store_SaveStore]')) 
DROP PROCEDURE [dbo].[Store_SaveStore]
GO

CREATE PROCEDURE [dbo].[Store_SaveStore](@storeId as int, @storeName as nvarchar(255) )
AS
BEGIN
	IF @storeId is NULL 
		BEGIN
			INSERT INTO MAGAZINE 
			(
			Nume_Magazin
			)VALUES(
			@storeName
			)
		END
	ELSE
	 BEGIN
		UPDATE MAGAZINE 
		SET Nume_Magazin = @storeName
		WHERE Id_Magazin = @storeId
	 END
END
GO

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[Store_DeleteStore]')) 
DROP PROCEDURE [dbo].[Store_DeleteStore]
GO


CREATE PROCEDURE [dbo].[Store_DeleteStore](@storeId as int)
AS
BEGIN
	DELETE FROM MAGAZINE
	WHERE Id_Magazin = @storeId
END
GO

------------------------------------------------------------------------------------
---									PRODUCTS									 ---
------------------------------------------------------------------------------------

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[Product_GetProducts]')) 
DROP PROCEDURE [dbo].[Product_GetProducts]
GO

CREATE PROCEDURE [dbo].[Product_GetProducts]
AS
BEGIN
	SELECT *
	FROM PRODUSE
END
GO