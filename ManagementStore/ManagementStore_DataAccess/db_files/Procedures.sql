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
	INNER JOIN CANTITATI ON PRODUSE.Id_Cantitate = CANTITATI.Id_Cantitate 
	INNER JOIN DATELE_EXPIRARII ON PRODUSE.Id_Data_Expirarii = DATELE_EXPIRARII.Id_Data_Expirarii
	INNER JOIN TVA ON PRODUSE.Id_TVA = TVA.Id_TVA
	INNER JOIN UNITATI_MASURA ON PRODUSE.Id_Unitate = UNITATI_MASURA.Id_Unitate
	INNER JOIN CONNECT_PRETURI_MONEDE ON  PRODUSE.Id_Connect_Preturi_Moneda = CONNECT_PRETURI_MONEDE.Id_Connect
	INNER JOIN PRODUCATORI ON PRODUSE.Id_Producator = PRODUCATORI.Id_Producator
	INNER JOIN TIPURI ON PRODUSE.Id_Tip = TIPURI.Id_Tip
	INNER JOIN REDUCERI ON PRODUSE.Id_Reducere = REDUCERI.Id_Reducere
	INNER JOIN COD_BARE ON PRODUSE.Id_Cod = COD_BARE.Id_Cod
	INNER JOIN PRETURI ON CONNECT_PRETURI_MONEDE.Id_Pret = PRETURI.Id_Pret
	INNER JOIN MONEDE ON CONNECT_PRETURI_MONEDE.Id_Moneda = MONEDE.Id_Moneda
END
GO

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[Product_DeleteProduct]')) 
DROP PROCEDURE [dbo].[Product_DeleteProduct]
GO


CREATE PROCEDURE [dbo].[Product_DeleteProduct](@productId as int)
AS
BEGIN
	DELETE FROM PRODUSE
	WHERE Id_Produs = @productId
END
GO
