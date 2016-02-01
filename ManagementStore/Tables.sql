IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ROLURI')
BEGIN
	CREATE TABLE ROLURI(
				 Id_Rol int IDENTITY(1,1) primary key
				,Nume_Rol nvarchar(255) NOT NULL
				,Descriere_Rol nvarchar(255)
				)
END	
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UTILIZATORI')
BEGIN
	CREATE TABLE UTILIZATORI(
				 Id_Utilizator int IDENTITY(1,1) primary key
				,Email_Utilizator nvarchar(255)
				,Nume_Utilizator nvarchar(255) NOT NULL
				,Parola_Utilizator nvarchar(255) NOT NULL
				,Id_Rol int NOT NULL references ROLURI(Id_Rol) 
				)
END	
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MAGAZINE')
BEGIN
	CREATE TABLE MAGAZINE (
				 Id_Magazin int IDENTITY(1,1) primary key
				,Nume_Magazin nvarchar(255) NOT NULL
				)
END	
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'FUNCTII')
BEGIN
	CREATE TABLE FUNCTII (
				 Id_Functie int IDENTITY(1,1) primary key
				,Nume_Functie nvarchar(255) NOT NULL
				,Descriere nvarchar(255)
				)
END	
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SALARII')
BEGIN
	CREATE TABLE SALARII (
				 Id_Salariu int IDENTITY(1,1) primary key
				,Pret_Salariu int NOT NULL
				)
END	
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LOCALITATI')
BEGIN
	CREATE TABLE LOCALITATI (
				 Id_Localitate int IDENTITY(1,1) primary key
				,Nume_Localitate nvarchar (255) NOT NULL
				)
END	
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'JUDETE')
BEGIN
	CREATE TABLE JUDETE (
				 Id_Judet int IDENTITY(1,1) primary key
				,Nume_Judet nvarchar (255) NOT NULL
				)
END	
GO




IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ANGAJATI')
BEGIN
	CREATE TABLE ANGAJATI (
				 Id_Angajat int IDENTITY(1,1) primary key
				,Nume_Angajat nvarchar(255)
				,Prenume_Angajat nvarchar(255)
				,Id_Functie int NOT NULL references FUNCTII(Id_Functie)
				,Id_Magazin int NOT NULL references MAGAZINE(Id_Magazin)
				,Id_Salariu int NOT NULL references SALARII(Id_Salariu)
				,Id_Localitate int NOT NULL references LOCALITATI (Id_Localitate)
				,Id_Judet int NOT NULL references JUDETE (Id_Judet)
				)
END	
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CANTITATI')
BEGIN
	CREATE TABLE CANTITATI (
				 Id_Cantitate int IDENTITY(1,1) primary key
				,Total_Cantitate int NOT NULL
				)
END	
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DATELE_EXPIRARII')
BEGIN
	CREATE TABLE DATELE_EXPIRARII (
				 Id_Data_Expirarii int IDENTITY(1,1) primary key
				,Data_Expirarii datetime NOT NULL
				)
END	
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TVA')
BEGIN
	CREATE TABLE TVA (
				 Id_TVA int IDENTITY(1,1) primary key
				,procent_TVA  int NOT NULL
				,Descriere_TVA nvarchar(255) 
				)
END	
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UNITATI_MASURA')
BEGIN
	CREATE TABLE UNITATI_MASURA (
				 Id_Unitate int IDENTITY(1,1) primary key
				,Nume_Unitate  nvarchar (255) NOT NULL
				,Prescurtare_Unitate nvarchar(255) NOT NULL
				)
END	
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PRETURI')
BEGIN
	CREATE TABLE PRETURI (
				 Id_Pret int IDENTITY(1,1) primary key
				,Brut_Pret  int NOT NULL
				)
END	
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MONEDE')
BEGIN
	CREATE TABLE MONEDE (
				 Id_Moneda int IDENTITY(1,1) primary key
				,Nume_Moneda  nvarchar(255) NOT NULL
				)
END	
GO


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CONNECT_PRETURI_MONEDE')
BEGIN
	CREATE TABLE CONNECT_PRETURI_MONEDE (
				 Id_Connect int IDENTITY(1,1) primary key
				,Id_Moneda int NOT NULL references MONEDE(Id_Moneda)
				,Id_Pret int NOT NULL references PRETURI(Id_Pret)
				)
END	
GO


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CONNECT_PRETURI_MONEDE')
BEGIN
	CREATE TABLE CONNECT_PRETURI_MONEDE (
				 Id_Connect int IDENTITY(1,1) primary key
				,Id_Moneda int NOT NULL references MONEDE(Id_Moneda)
				,Id_Pret int NOT NULL references PRETURI(Id_Pret)
				)
END	
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PRODUCATORI')
BEGIN
	CREATE TABLE PRODUCATORI (
				 Id_Producator int IDENTITY(1,1) primary key
				,Nume_Producator nvarchar(255) NOT NULL 
				)
END	
GO


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TIPURI')
BEGIN
	CREATE TABLE TIPURI (
				 Id_Tip int IDENTITY(1,1) primary key
				,Nume_Tip nvarchar(255) NOT NULL 
				,Descriere_Tip nvarchar(255)
				)
END	
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'REDUCERI')
BEGIN
	CREATE TABLE REDUCERI (
				 Id_Reducere int IDENTITY(1,1) primary key
				,Nume_Reducere nvarchar(255) NOT NULL 
				,PROCENT_REDUCERE int NOT NULL
				,Descriere_Reducere nvarchar(255) 
				)
END	
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'COD_BARE')
BEGIN
	CREATE TABLE COD_BARE (
				 Id_Cod int IDENTITY(1,1) primary key
				,Numar_Cod int NOT NULL 
				)
END	
GO


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PRODUSE')
BEGIN
	CREATE TABLE PRODUSE (
					 Id_Produs int IDENTITY(1,1) primary key
					,Nume_Produs nvarchar(255)
					,Descriere_Produs nvarchar(255)
					,Id_Cantitate int NOT NULL references CANTITATI(Id_Cantitate)
					,Id_Data_Expirarii int NOT NULL references DATELE_EXPIRARII(Id_Data_Expirarii)
					,Id_TVA int NOT NULL references TVA(Id_TVA)
					,Id_Unitate int NOT NULL references UNITATI_MASURA(Id_Unitate)
					,Id_Connect_Preturi_Moneda int NOT NULL references CONNECT_PRETURI_MONEDE(Id_Connect)
					,Id_Producator int NOT NULL references PRODUCATORI(Id_Producator)
					,Id_Tip int NOT NULL references TIPURI(Id_Tip)
					,Id_Reducere int NOT NULL references REDUCERI(Id_Reducere)
					,Id_Cod int NOT NULL references COD_BARE(Id_Cod)
					)
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CONNECT_PRODUSE_MAGAZIN')
BEGIN
	CREATE TABLE CONNECT_PRODUSE_MAGAZIN (
					 Id_Connect int IDENTITY(1,1) primary key
					,Id_Magazin int NOT NULL references MAGAZINE(Id_Magazin)
					,Id_Produs int NOT NULL references PRODUSE(Id_Produs)
					)
END
GO



