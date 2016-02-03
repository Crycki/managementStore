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