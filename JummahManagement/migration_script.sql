-- ----------------------------------------------------------------------------
-- MySQL Workbench Migration
-- Migrated Schemata: JummahManagement
-- Source Schemata: JummahManagement
-- Created: Mon Sep 23 16:56:42 2019
-- Workbench Version: 8.0.17
-- ----------------------------------------------------------------------------

SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------------------------------------------------------
-- Schema JummahManagement
-- ----------------------------------------------------------------------------
DROP SCHEMA IF EXISTS `JummahManagement` ;
CREATE SCHEMA IF NOT EXISTS `JummahManagement` ;

-- ----------------------------------------------------------------------------
-- Table JummahManagement.tbl_Branches
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `JummahManagement`.`tbl_Branches` (
  `Branch_ID` VARCHAR(20) CHARACTER SET 'utf8mb4' NOT NULL,
  `Branch_Name` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
  `JIP_Name` VARCHAR(40) CHARACTER SET 'utf8mb4' NOT NULL,
  `JIP_Contact` CHAR(15) CHARACTER SET 'utf8mb4' NOT NULL,
  `No` INT NULL,
  `Street_Name` VARCHAR(50) CHARACTER SET 'utf8mb4' NULL,
  `City` VARCHAR(50) CHARACTER SET 'utf8mb4' NULL,
  `District` VARCHAR(50) CHARACTER SET 'utf8mb4' NULL,
  PRIMARY KEY (`Branch_ID`));

-- ----------------------------------------------------------------------------
-- Table JummahManagement.tbl_Branches_Deleted
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `JummahManagement`.`tbl_Branches_Deleted` (
  `Branch_ID` VARCHAR(20) CHARACTER SET 'utf8mb4' NOT NULL,
  `Branch_Name` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
  `JIP_Name` VARCHAR(40) CHARACTER SET 'utf8mb4' NOT NULL,
  `JIP_Contact` CHAR(15) CHARACTER SET 'utf8mb4' NOT NULL,
  `No` INT NULL,
  `Street_Name` VARCHAR(50) CHARACTER SET 'utf8mb4' NULL,
  `City` VARCHAR(50) CHARACTER SET 'utf8mb4' NULL,
  `District` VARCHAR(50) CHARACTER SET 'utf8mb4' NULL,
  PRIMARY KEY (`Branch_ID`));

-- ----------------------------------------------------------------------------
-- Table JummahManagement.tbl_City
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `JummahManagement`.`tbl_City` (
  `City_ID` INT NOT NULL,
  `City` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
  PRIMARY KEY (`City_ID`));

-- ----------------------------------------------------------------------------
-- Table JummahManagement.tbl_Dhae
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `JummahManagement`.`tbl_Dhae` (
  `Dhae_ID` INT NOT NULL,
  `Dhae_Name` VARCHAR(100) CHARACTER SET 'utf8mb4' NOT NULL,
  `Dhae_Contact` VARCHAR(15) CHARACTER SET 'utf8mb4' NOT NULL,
  `House_No` CHAR(10) CHARACTER SET 'utf8mb4' NULL,
  `Street_Name` VARCHAR(50) CHARACTER SET 'utf8mb4' NULL,
  `City` VARCHAR(50) CHARACTER SET 'utf8mb4' NULL,
  `District` VARCHAR(20) CHARACTER SET 'utf8mb4' NULL,
  PRIMARY KEY (`Dhae_ID`));

-- ----------------------------------------------------------------------------
-- Table JummahManagement.tbl_Dhae_Deleted
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `JummahManagement`.`tbl_Dhae_Deleted` (
  `Dhae_ID` INT NOT NULL,
  `Dhae_Name` VARCHAR(100) CHARACTER SET 'utf8mb4' NOT NULL,
  `Dhae_Contact` VARCHAR(15) CHARACTER SET 'utf8mb4' NOT NULL,
  `House_No` CHAR(10) CHARACTER SET 'utf8mb4' NULL,
  `Street_Name` VARCHAR(50) CHARACTER SET 'utf8mb4' NULL,
  `City` VARCHAR(50) CHARACTER SET 'utf8mb4' NULL,
  `District` VARCHAR(20) CHARACTER SET 'utf8mb4' NULL,
  PRIMARY KEY (`Dhae_ID`));

-- ----------------------------------------------------------------------------
-- Table JummahManagement.tbl_Jummah_Schedule
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `JummahManagement`.`tbl_Jummah_Schedule` (
  `ID` INT NOT NULL,
  `Row_Count` INT NOT NULL,
  `Dhae_Name` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
  `Dhae_Contact` VARCHAR(20) CHARACTER SET 'utf8mb4' NOT NULL,
  `Branch_Name` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
  `JIP_Name` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
  `JIP_Contact` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
  `Date` VARCHAR(20) CHARACTER SET 'utf8mb4' NOT NULL,
  PRIMARY KEY (`ID`));

-- ----------------------------------------------------------------------------
-- Table JummahManagement.sysdiagrams
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `JummahManagement`.`sysdiagrams` (
  `name` VARCHAR(160) NOT NULL,
  `principal_id` INT NOT NULL,
  `diagram_id` INT NOT NULL,
  `version` INT NULL,
  `definition` LONGBLOB NULL,
  PRIMARY KEY (`diagram_id`),
  UNIQUE INDEX `UK_principal_name` (`principal_id` ASC, `name` ASC) VISIBLE);

-- ----------------------------------------------------------------------------
-- Table JummahManagement.tbl_Dhae_temp
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `JummahManagement`.`tbl_Dhae_temp` (
  `Dhae_ID` INT NOT NULL,
  `Dhae_Name` VARCHAR(100) CHARACTER SET 'utf8mb4' NOT NULL,
  `Dhae_Contact` VARCHAR(15) CHARACTER SET 'utf8mb4' NOT NULL,
  `House_No` CHAR(10) CHARACTER SET 'utf8mb4' NULL,
  `Street_Name` VARCHAR(50) CHARACTER SET 'utf8mb4' NULL,
  `City` VARCHAR(50) CHARACTER SET 'utf8mb4' NULL,
  `District` VARCHAR(20) CHARACTER SET 'utf8mb4' NULL,
  PRIMARY KEY (`Dhae_ID`));

-- ----------------------------------------------------------------------------
-- Table JummahManagement.tbl_Branches_temp
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `JummahManagement`.`tbl_Branches_temp` (
  `Branch_ID` VARCHAR(20) CHARACTER SET 'utf8mb4' NOT NULL,
  `Branch_Name` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
  `JIP_Name` VARCHAR(40) CHARACTER SET 'utf8mb4' NOT NULL,
  `JIP_Contact` CHAR(15) CHARACTER SET 'utf8mb4' NOT NULL,
  `No` INT NULL,
  `Street_Name` VARCHAR(50) CHARACTER SET 'utf8mb4' NULL,
  `City` VARCHAR(50) CHARACTER SET 'utf8mb4' NULL,
  `District` VARCHAR(50) CHARACTER SET 'utf8mb4' NULL,
  PRIMARY KEY (`Branch_ID`));

-- ----------------------------------------------------------------------------
-- Table JummahManagement.tbl_Jummah_Schedule_temp
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `JummahManagement`.`tbl_Jummah_Schedule_temp` (
  `ID` INT NOT NULL,
  `Row_Count` INT NOT NULL,
  `Dhae_Name` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
  `Dhae_Contact` VARCHAR(20) CHARACTER SET 'utf8mb4' NOT NULL,
  `Branch_Name` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
  `JIP_Name` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
  `JIP_Contact` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
  `Date` VARCHAR(20) CHARACTER SET 'utf8mb4' NOT NULL,
  PRIMARY KEY (`ID`));

-- ----------------------------------------------------------------------------
-- View JummahManagement.GetBranches
-- ----------------------------------------------------------------------------
-- USE `JummahManagement`;
-- CREATE  OR REPLACE PROCEDURE GetBranches
-- AS
-- SELECT * FROM tbl_Branches
-- GO;;

-- ----------------------------------------------------------------------------
-- View JummahManagement.sp_upgraddiagrams
-- ----------------------------------------------------------------------------
-- USE `JummahManagement`;
-- 
-- 	CREATE  OR REPLACE PROCEDURE dbo.sp_upgraddiagrams
-- 	AS
-- 	BEGIN
-- 		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
-- 			return 0;
-- 	
-- 		CREATE TABLE dbo.sysdiagrams
-- 		(
-- 			name sysname NOT NULL,
-- 			principal_id int NOT NULL,	-- we may change it to varbinary(85)
-- 			diagram_id int PRIMARY KEY IDENTITY,
-- 			version int,
-- 	
-- 			definition varbinary(max)
-- 			CONSTRAINT UK_principal_name UNIQUE
-- 			(
-- 				principal_id,
-- 				name
-- 			)
-- 		);
-- 
-- 
-- 		/* Add this if we need to have some form of extended properties for diagrams */
-- 		/*
-- 		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
-- 		BEGIN
-- 			CREATE TABLE dbo.sysdiagram_properties
-- 			(
-- 				diagram_id int,
-- 				name sysname,
-- 				value varbinary(max) NOT NULL
-- 			)
-- 		END
-- 		*/
-- 
-- 		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
-- 		begin
-- 			insert into dbo.sysdiagrams
-- 			(
-- 				[name],
-- 				[principal_id],
-- 				[version],
-- 				[definition]
-- 			)
-- 			select	 
-- 				convert(sysname, dgnm.[uvalue]),
-- 				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
-- 				0,							-- zero for old format, dgdef.[version],
-- 				dgdef.[lvalue]
-- 			from dbo.[dtproperties] dgnm
-- 				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
-- 				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
-- 				
-- 			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
-- 			return 2;
-- 		end
-- 		return 1;
-- 	END
-- 	;

-- ----------------------------------------------------------------------------
-- View JummahManagement.sp_helpdiagrams
-- ----------------------------------------------------------------------------
-- USE `JummahManagement`;
-- 
-- 	CREATE  OR REPLACE PROCEDURE dbo.sp_helpdiagrams
-- 	(
-- 		@diagramname sysname = NULL,
-- 		@owner_id int = NULL
-- 	)
-- 	WITH EXECUTE AS N'dbo'
-- 	AS
-- 	BEGIN
-- 		DECLARE @user sysname
-- 		DECLARE @dboLogin bit
-- 		EXECUTE AS CALLER;
-- 			SET @user = USER_NAME();
-- 			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
-- 		REVERT;
-- 		SELECT
-- 			[Database] = DB_NAME(),
-- 			[Name] = name,
-- 			[ID] = diagram_id,
-- 			[Owner] = USER_NAME(principal_id),
-- 			[OwnerID] = principal_id
-- 		FROM
-- 			sysdiagrams
-- 		WHERE
-- 			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
-- 			(@diagramname IS NULL OR name = @diagramname) AND
-- 			(@owner_id IS NULL OR principal_id = @owner_id)
-- 		ORDER BY
-- 			4, 5, 1
-- 	END
-- 	;

-- ----------------------------------------------------------------------------
-- View JummahManagement.sp_helpdiagramdefinition
-- ----------------------------------------------------------------------------
-- USE `JummahManagement`;
-- 
-- 	CREATE  OR REPLACE PROCEDURE dbo.sp_helpdiagramdefinition
-- 	(
-- 		@diagramname 	sysname,
-- 		@owner_id	int	= null 		
-- 	)
-- 	WITH EXECUTE AS N'dbo'
-- 	AS
-- 	BEGIN
-- 		set nocount on
-- 
-- 		declare @theId 		int
-- 		declare @IsDbo 		int
-- 		declare @DiagId		int
-- 		declare @UIDFound	int
-- 	
-- 		if(@diagramname is null)
-- 		begin
-- 			RAISERROR (N'E_INVALIDARG', 16, 1);
-- 			return -1
-- 		end
-- 	
-- 		execute as caller;
-- 		select @theId = DATABASE_PRINCIPAL_ID();
-- 		select @IsDbo = IS_MEMBER(N'db_owner');
-- 		if(@owner_id is null)
-- 			select @owner_id = @theId;
-- 		revert; 
-- 	
-- 		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
-- 		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
-- 		begin
-- 			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
-- 			return -3
-- 		end
-- 
-- 		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
-- 		return 0
-- 	END
-- 	;

-- ----------------------------------------------------------------------------
-- View JummahManagement.sp_creatediagram
-- ----------------------------------------------------------------------------
-- USE `JummahManagement`;
-- 
-- 	CREATE  OR REPLACE PROCEDURE dbo.sp_creatediagram
-- 	(
-- 		@diagramname 	sysname,
-- 		@owner_id		int	= null, 	
-- 		@version 		int,
-- 		@definition 	varbinary(max)
-- 	)
-- 	WITH EXECUTE AS 'dbo'
-- 	AS
-- 	BEGIN
-- 		set nocount on
-- 	
-- 		declare @theId int
-- 		declare @retval int
-- 		declare @IsDbo	int
-- 		declare @userName sysname
-- 		if(@version is null or @diagramname is null)
-- 		begin
-- 			RAISERROR (N'E_INVALIDARG', 16, 1);
-- 			return -1
-- 		end
-- 	
-- 		execute as caller;
-- 		select @theId = DATABASE_PRINCIPAL_ID(); 
-- 		select @IsDbo = IS_MEMBER(N'db_owner');
-- 		revert; 
-- 		
-- 		if @owner_id is null
-- 		begin
-- 			select @owner_id = @theId;
-- 		end
-- 		else
-- 		begin
-- 			if @theId <> @owner_id
-- 			begin
-- 				if @IsDbo = 0
-- 				begin
-- 					RAISERROR (N'E_INVALIDARG', 16, 1);
-- 					return -1
-- 				end
-- 				select @theId = @owner_id
-- 			end
-- 		end
-- 		-- next 2 line only for test, will be removed after define name unique
-- 		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
-- 		begin
-- 			RAISERROR ('The name is already used.', 16, 1);
-- 			return -2
-- 		end
-- 	
-- 		insert into dbo.sysdiagrams(name, principal_id , version, definition)
-- 				VALUES(@diagramname, @theId, @version, @definition) ;
-- 		
-- 		select @retval = @@IDENTITY 
-- 		return @retval
-- 	END
-- 	;

-- ----------------------------------------------------------------------------
-- View JummahManagement.sp_renamediagram
-- ----------------------------------------------------------------------------
-- USE `JummahManagement`;
-- 
-- 	CREATE  OR REPLACE PROCEDURE dbo.sp_renamediagram
-- 	(
-- 		@diagramname 		sysname,
-- 		@owner_id		int	= null,
-- 		@new_diagramname	sysname
-- 	
-- 	)
-- 	WITH EXECUTE AS 'dbo'
-- 	AS
-- 	BEGIN
-- 		set nocount on
-- 		declare @theId 			int
-- 		declare @IsDbo 			int
-- 		
-- 		declare @UIDFound 		int
-- 		declare @DiagId			int
-- 		declare @DiagIdTarg		int
-- 		declare @u_name			sysname
-- 		if((@diagramname is null) or (@new_diagramname is null))
-- 		begin
-- 			RAISERROR ('Invalid value', 16, 1);
-- 			return -1
-- 		end
-- 	
-- 		EXECUTE AS CALLER;
-- 		select @theId = DATABASE_PRINCIPAL_ID();
-- 		select @IsDbo = IS_MEMBER(N'db_owner'); 
-- 		if(@owner_id is null)
-- 			select @owner_id = @theId;
-- 		REVERT;
-- 	
-- 		select @u_name = USER_NAME(@owner_id)
-- 	
-- 		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
-- 		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
-- 		begin
-- 			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
-- 			return -3
-- 		end
-- 	
-- 		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
-- 		--	return 0;
-- 	
-- 		if(@u_name is null)
-- 			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
-- 		else
-- 			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
-- 	
-- 		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
-- 		begin
-- 			RAISERROR ('The name is already used.', 16, 1);
-- 			return -2
-- 		end		
-- 	
-- 		if(@u_name is null)
-- 			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
-- 		else
-- 			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
-- 		return 0
-- 	END
-- 	;

-- ----------------------------------------------------------------------------
-- View JummahManagement.sp_alterdiagram
-- ----------------------------------------------------------------------------
-- USE `JummahManagement`;
-- 
-- 	CREATE  OR REPLACE PROCEDURE dbo.sp_alterdiagram
-- 	(
-- 		@diagramname 	sysname,
-- 		@owner_id	int	= null,
-- 		@version 	int,
-- 		@definition 	varbinary(max)
-- 	)
-- 	WITH EXECUTE AS 'dbo'
-- 	AS
-- 	BEGIN
-- 		set nocount on
-- 	
-- 		declare @theId 			int
-- 		declare @retval 		int
-- 		declare @IsDbo 			int
-- 		
-- 		declare @UIDFound 		int
-- 		declare @DiagId			int
-- 		declare @ShouldChangeUID	int
-- 	
-- 		if(@diagramname is null)
-- 		begin
-- 			RAISERROR ('Invalid ARG', 16, 1)
-- 			return -1
-- 		end
-- 	
-- 		execute as caller;
-- 		select @theId = DATABASE_PRINCIPAL_ID();	 
-- 		select @IsDbo = IS_MEMBER(N'db_owner'); 
-- 		if(@owner_id is null)
-- 			select @owner_id = @theId;
-- 		revert;
-- 	
-- 		select @ShouldChangeUID = 0
-- 		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
-- 		
-- 		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
-- 		begin
-- 			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
-- 			return -3
-- 		end
-- 	
-- 		if(@IsDbo <> 0)
-- 		begin
-- 			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
-- 			begin
-- 				select @ShouldChangeUID = 1 ;
-- 			end
-- 		end
-- 
-- 		-- update dds data			
-- 		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;
-- 
-- 		-- change owner
-- 		if(@ShouldChangeUID = 1)
-- 			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;
-- 
-- 		-- update dds version
-- 		if(@version is not null)
-- 			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;
-- 
-- 		return 0
-- 	END
-- 	;

-- ----------------------------------------------------------------------------
-- View JummahManagement.sp_dropdiagram
-- ----------------------------------------------------------------------------
-- USE `JummahManagement`;
-- 
-- 	CREATE  OR REPLACE PROCEDURE dbo.sp_dropdiagram
-- 	(
-- 		@diagramname 	sysname,
-- 		@owner_id	int	= null
-- 	)
-- 	WITH EXECUTE AS 'dbo'
-- 	AS
-- 	BEGIN
-- 		set nocount on
-- 		declare @theId 			int
-- 		declare @IsDbo 			int
-- 		
-- 		declare @UIDFound 		int
-- 		declare @DiagId			int
-- 	
-- 		if(@diagramname is null)
-- 		begin
-- 			RAISERROR ('Invalid value', 16, 1);
-- 			return -1
-- 		end
-- 	
-- 		EXECUTE AS CALLER;
-- 		select @theId = DATABASE_PRINCIPAL_ID();
-- 		select @IsDbo = IS_MEMBER(N'db_owner'); 
-- 		if(@owner_id is null)
-- 			select @owner_id = @theId;
-- 		REVERT; 
-- 		
-- 		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
-- 		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
-- 		begin
-- 			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
-- 			return -3
-- 		end
-- 	
-- 		delete from dbo.sysdiagrams where diagram_id = @DiagId;
-- 	
-- 		return 0;
-- 	END
-- 	;

-- ----------------------------------------------------------------------------
-- View JummahManagement.fn_diagramobjects
-- ----------------------------------------------------------------------------
-- USE `JummahManagement`;
-- 
-- 	CREATE  OR REPLACE FUNCTION dbo.fn_diagramobjects() 
-- 	RETURNS int
-- 	WITH EXECUTE AS N'dbo'
-- 	AS
-- 	BEGIN
-- 		declare @id_upgraddiagrams		int
-- 		declare @id_sysdiagrams			int
-- 		declare @id_helpdiagrams		int
-- 		declare @id_helpdiagramdefinition	int
-- 		declare @id_creatediagram	int
-- 		declare @id_renamediagram	int
-- 		declare @id_alterdiagram 	int 
-- 		declare @id_dropdiagram		int
-- 		declare @InstalledObjects	int
-- 
-- 		select @InstalledObjects = 0
-- 
-- 		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
-- 			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
-- 			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
-- 			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
-- 			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
-- 			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
-- 			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
-- 			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')
-- 
-- 		if @id_upgraddiagrams is not null
-- 			select @InstalledObjects = @InstalledObjects + 1
-- 		if @id_sysdiagrams is not null
-- 			select @InstalledObjects = @InstalledObjects + 2
-- 		if @id_helpdiagrams is not null
-- 			select @InstalledObjects = @InstalledObjects + 4
-- 		if @id_helpdiagramdefinition is not null
-- 			select @InstalledObjects = @InstalledObjects + 8
-- 		if @id_creatediagram is not null
-- 			select @InstalledObjects = @InstalledObjects + 16
-- 		if @id_renamediagram is not null
-- 			select @InstalledObjects = @InstalledObjects + 32
-- 		if @id_alterdiagram  is not null
-- 			select @InstalledObjects = @InstalledObjects + 64
-- 		if @id_dropdiagram is not null
-- 			select @InstalledObjects = @InstalledObjects + 128
-- 		
-- 		return @InstalledObjects 
-- 	END
-- 	;

-- ----------------------------------------------------------------------------
-- View JummahManagement.GetDhaes
-- ----------------------------------------------------------------------------
-- USE `JummahManagement`;
-- CREATE  OR REPLACE PROCEDURE GetDhaes
-- AS
-- SELECT * FROM tbl_Dhae
-- GO;;

-- ----------------------------------------------------------------------------
-- View JummahManagement.GetCities
-- ----------------------------------------------------------------------------
-- USE `JummahManagement`;
-- CREATE  OR REPLACE PROCEDURE [dbo].[GetCities]
-- AS
-- SELECT * FROM tbl_City
-- GO;;

-- ----------------------------------------------------------------------------
-- View JummahManagement.GetJummahSchedule
-- ----------------------------------------------------------------------------
-- USE `JummahManagement`;
-- CREATE  OR REPLACE PROCEDURE GetJummahSchedule
-- AS
-- SELECT * FROM tbl_Jummah_Schedule
-- GO;;

-- ----------------------------------------------------------------------------
-- View JummahManagement.CreateTempBranchTable
-- ----------------------------------------------------------------------------
-- USE `JummahManagement`;
-- CREATE  OR REPLACE PROCEDURE [dbo].[CreateTempBranchTable]
-- AS
-- 					DROP TABLE [dbo].[tbl_Branches_temp]
-- 					SET ANSI_NULLS ON
-- 					SET QUOTED_IDENTIFIER ON
-- 					CREATE TABLE [dbo].[tbl_Branches_temp](
-- 						[Branch_ID] [nvarchar](20) NOT NULL,
-- 						[Branch_Name] [nvarchar](50) NOT NULL,
-- 						[JIP_Name] [nvarchar](40) NOT NULL,
-- 						[JIP_Contact] [nchar](15) NOT NULL,
-- 						[No] [int] NULL,
-- 						[Street_Name] [nvarchar](50) NULL,
-- 						[City] [nvarchar](50) NULL,
-- 						[District] [nvarchar](50) NULL,
-- 					 CONSTRAINT [PK_tbl_Branches_temp] PRIMARY KEY CLUSTERED 
-- 					(
-- 						[Branch_ID] ASC
-- 					)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
-- 					) ON [PRIMARY];
-- 
-- 					INSERT INTO tbl_Branches_temp SELECT * FROM tbl_Branches;;

-- ----------------------------------------------------------------------------
-- View JummahManagement.Get_Last_Visited_Date
-- ----------------------------------------------------------------------------
-- USE `JummahManagement`;
-- CREATE  OR REPLACE PROCEDURE [dbo].[Get_Last_Visited_Date]
-- (
--  @BranchName nvarchar(50),
--  @DhaeName nvarchar(50)
-- )
-- AS 
-- BEGIN
-- SELECT Max(Date) From tbl_Jummah_Schedule Where Dhae_Name = @DhaeName AND Branch_Name = @BranchName 
-- END
-- ;

-- ----------------------------------------------------------------------------
-- Routine JummahManagement.GetBranches
-- ----------------------------------------------------------------------------
-- DELIMITER $$
-- 
-- DELIMITER $$
-- USE `JummahManagement`$$
-- CREATE PROCEDURE GetBranches
-- AS
-- SELECT * FROM tbl_Branches
-- GO;$$
-- 
-- DELIMITER ;
-- 
-- ----------------------------------------------------------------------------
-- Routine JummahManagement.sp_upgraddiagrams
-- ----------------------------------------------------------------------------
-- DELIMITER $$
-- 
-- DELIMITER $$
-- USE `JummahManagement`$$
-- 
-- 	CREATE PROCEDURE dbo.sp_upgraddiagrams
-- 	AS
-- 	BEGIN
-- 		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
-- 			return 0;
-- 	
-- 		CREATE TABLE dbo.sysdiagrams
-- 		(
-- 			name sysname NOT NULL,
-- 			principal_id int NOT NULL,	-- we may change it to varbinary(85)
-- 			diagram_id int PRIMARY KEY IDENTITY,
-- 			version int,
-- 	
-- 			definition varbinary(max)
-- 			CONSTRAINT UK_principal_name UNIQUE
-- 			(
-- 				principal_id,
-- 				name
-- 			)
-- 		);
-- 
-- 
-- 		/* Add this if we need to have some form of extended properties for diagrams */
-- 		/*
-- 		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
-- 		BEGIN
-- 			CREATE TABLE dbo.sysdiagram_properties
-- 			(
-- 				diagram_id int,
-- 				name sysname,
-- 				value varbinary(max) NOT NULL
-- 			)
-- 		END
-- 		*/
-- 
-- 		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
-- 		begin
-- 			insert into dbo.sysdiagrams
-- 			(
-- 				[name],
-- 				[principal_id],
-- 				[version],
-- 				[definition]
-- 			)
-- 			select	 
-- 				convert(sysname, dgnm.[uvalue]),
-- 				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
-- 				0,							-- zero for old format, dgdef.[version],
-- 				dgdef.[lvalue]
-- 			from dbo.[dtproperties] dgnm
-- 				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
-- 				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
-- 				
-- 			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
-- 			return 2;
-- 		end
-- 		return 1;
-- 	END
-- 	$$
-- 
-- DELIMITER ;
-- 
-- ----------------------------------------------------------------------------
-- Routine JummahManagement.sp_helpdiagrams
-- ----------------------------------------------------------------------------
-- DELIMITER $$
-- 
-- DELIMITER $$
-- USE `JummahManagement`$$
-- 
-- 	CREATE PROCEDURE dbo.sp_helpdiagrams
-- 	(
-- 		@diagramname sysname = NULL,
-- 		@owner_id int = NULL
-- 	)
-- 	WITH EXECUTE AS N'dbo'
-- 	AS
-- 	BEGIN
-- 		DECLARE @user sysname
-- 		DECLARE @dboLogin bit
-- 		EXECUTE AS CALLER;
-- 			SET @user = USER_NAME();
-- 			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
-- 		REVERT;
-- 		SELECT
-- 			[Database] = DB_NAME(),
-- 			[Name] = name,
-- 			[ID] = diagram_id,
-- 			[Owner] = USER_NAME(principal_id),
-- 			[OwnerID] = principal_id
-- 		FROM
-- 			sysdiagrams
-- 		WHERE
-- 			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
-- 			(@diagramname IS NULL OR name = @diagramname) AND
-- 			(@owner_id IS NULL OR principal_id = @owner_id)
-- 		ORDER BY
-- 			4, 5, 1
-- 	END
-- 	$$
-- 
-- DELIMITER ;
-- 
-- ----------------------------------------------------------------------------
-- Routine JummahManagement.sp_helpdiagramdefinition
-- ----------------------------------------------------------------------------
-- DELIMITER $$
-- 
-- DELIMITER $$
-- USE `JummahManagement`$$
-- 
-- 	CREATE PROCEDURE dbo.sp_helpdiagramdefinition
-- 	(
-- 		@diagramname 	sysname,
-- 		@owner_id	int	= null 		
-- 	)
-- 	WITH EXECUTE AS N'dbo'
-- 	AS
-- 	BEGIN
-- 		set nocount on
-- 
-- 		declare @theId 		int
-- 		declare @IsDbo 		int
-- 		declare @DiagId		int
-- 		declare @UIDFound	int
-- 	
-- 		if(@diagramname is null)
-- 		begin
-- 			RAISERROR (N'E_INVALIDARG', 16, 1);
-- 			return -1
-- 		end
-- 	
-- 		execute as caller;
-- 		select @theId = DATABASE_PRINCIPAL_ID();
-- 		select @IsDbo = IS_MEMBER(N'db_owner');
-- 		if(@owner_id is null)
-- 			select @owner_id = @theId;
-- 		revert; 
-- 	
-- 		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
-- 		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
-- 		begin
-- 			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
-- 			return -3
-- 		end
-- 
-- 		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
-- 		return 0
-- 	END
-- 	$$
-- 
-- DELIMITER ;
-- 
-- ----------------------------------------------------------------------------
-- Routine JummahManagement.sp_creatediagram
-- ----------------------------------------------------------------------------
-- DELIMITER $$
-- 
-- DELIMITER $$
-- USE `JummahManagement`$$
-- 
-- 	CREATE PROCEDURE dbo.sp_creatediagram
-- 	(
-- 		@diagramname 	sysname,
-- 		@owner_id		int	= null, 	
-- 		@version 		int,
-- 		@definition 	varbinary(max)
-- 	)
-- 	WITH EXECUTE AS 'dbo'
-- 	AS
-- 	BEGIN
-- 		set nocount on
-- 	
-- 		declare @theId int
-- 		declare @retval int
-- 		declare @IsDbo	int
-- 		declare @userName sysname
-- 		if(@version is null or @diagramname is null)
-- 		begin
-- 			RAISERROR (N'E_INVALIDARG', 16, 1);
-- 			return -1
-- 		end
-- 	
-- 		execute as caller;
-- 		select @theId = DATABASE_PRINCIPAL_ID(); 
-- 		select @IsDbo = IS_MEMBER(N'db_owner');
-- 		revert; 
-- 		
-- 		if @owner_id is null
-- 		begin
-- 			select @owner_id = @theId;
-- 		end
-- 		else
-- 		begin
-- 			if @theId <> @owner_id
-- 			begin
-- 				if @IsDbo = 0
-- 				begin
-- 					RAISERROR (N'E_INVALIDARG', 16, 1);
-- 					return -1
-- 				end
-- 				select @theId = @owner_id
-- 			end
-- 		end
-- 		-- next 2 line only for test, will be removed after define name unique
-- 		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
-- 		begin
-- 			RAISERROR ('The name is already used.', 16, 1);
-- 			return -2
-- 		end
-- 	
-- 		insert into dbo.sysdiagrams(name, principal_id , version, definition)
-- 				VALUES(@diagramname, @theId, @version, @definition) ;
-- 		
-- 		select @retval = @@IDENTITY 
-- 		return @retval
-- 	END
-- 	$$
-- 
-- DELIMITER ;
-- 
-- ----------------------------------------------------------------------------
-- Routine JummahManagement.sp_renamediagram
-- ----------------------------------------------------------------------------
-- DELIMITER $$
-- 
-- DELIMITER $$
-- USE `JummahManagement`$$
-- 
-- 	CREATE PROCEDURE dbo.sp_renamediagram
-- 	(
-- 		@diagramname 		sysname,
-- 		@owner_id		int	= null,
-- 		@new_diagramname	sysname
-- 	
-- 	)
-- 	WITH EXECUTE AS 'dbo'
-- 	AS
-- 	BEGIN
-- 		set nocount on
-- 		declare @theId 			int
-- 		declare @IsDbo 			int
-- 		
-- 		declare @UIDFound 		int
-- 		declare @DiagId			int
-- 		declare @DiagIdTarg		int
-- 		declare @u_name			sysname
-- 		if((@diagramname is null) or (@new_diagramname is null))
-- 		begin
-- 			RAISERROR ('Invalid value', 16, 1);
-- 			return -1
-- 		end
-- 	
-- 		EXECUTE AS CALLER;
-- 		select @theId = DATABASE_PRINCIPAL_ID();
-- 		select @IsDbo = IS_MEMBER(N'db_owner'); 
-- 		if(@owner_id is null)
-- 			select @owner_id = @theId;
-- 		REVERT;
-- 	
-- 		select @u_name = USER_NAME(@owner_id)
-- 	
-- 		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
-- 		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
-- 		begin
-- 			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
-- 			return -3
-- 		end
-- 	
-- 		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
-- 		--	return 0;
-- 	
-- 		if(@u_name is null)
-- 			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
-- 		else
-- 			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
-- 	
-- 		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
-- 		begin
-- 			RAISERROR ('The name is already used.', 16, 1);
-- 			return -2
-- 		end		
-- 	
-- 		if(@u_name is null)
-- 			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
-- 		else
-- 			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
-- 		return 0
-- 	END
-- 	$$
-- 
-- DELIMITER ;
-- 
-- ----------------------------------------------------------------------------
-- Routine JummahManagement.sp_alterdiagram
-- ----------------------------------------------------------------------------
-- DELIMITER $$
-- 
-- DELIMITER $$
-- USE `JummahManagement`$$
-- 
-- 	CREATE PROCEDURE dbo.sp_alterdiagram
-- 	(
-- 		@diagramname 	sysname,
-- 		@owner_id	int	= null,
-- 		@version 	int,
-- 		@definition 	varbinary(max)
-- 	)
-- 	WITH EXECUTE AS 'dbo'
-- 	AS
-- 	BEGIN
-- 		set nocount on
-- 	
-- 		declare @theId 			int
-- 		declare @retval 		int
-- 		declare @IsDbo 			int
-- 		
-- 		declare @UIDFound 		int
-- 		declare @DiagId			int
-- 		declare @ShouldChangeUID	int
-- 	
-- 		if(@diagramname is null)
-- 		begin
-- 			RAISERROR ('Invalid ARG', 16, 1)
-- 			return -1
-- 		end
-- 	
-- 		execute as caller;
-- 		select @theId = DATABASE_PRINCIPAL_ID();	 
-- 		select @IsDbo = IS_MEMBER(N'db_owner'); 
-- 		if(@owner_id is null)
-- 			select @owner_id = @theId;
-- 		revert;
-- 	
-- 		select @ShouldChangeUID = 0
-- 		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
-- 		
-- 		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
-- 		begin
-- 			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
-- 			return -3
-- 		end
-- 	
-- 		if(@IsDbo <> 0)
-- 		begin
-- 			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
-- 			begin
-- 				select @ShouldChangeUID = 1 ;
-- 			end
-- 		end
-- 
-- 		-- update dds data			
-- 		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;
-- 
-- 		-- change owner
-- 		if(@ShouldChangeUID = 1)
-- 			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;
-- 
-- 		-- update dds version
-- 		if(@version is not null)
-- 			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;
-- 
-- 		return 0
-- 	END
-- 	$$
-- 
-- DELIMITER ;
-- 
-- ----------------------------------------------------------------------------
-- Routine JummahManagement.sp_dropdiagram
-- ----------------------------------------------------------------------------
-- DELIMITER $$
-- 
-- DELIMITER $$
-- USE `JummahManagement`$$
-- 
-- 	CREATE PROCEDURE dbo.sp_dropdiagram
-- 	(
-- 		@diagramname 	sysname,
-- 		@owner_id	int	= null
-- 	)
-- 	WITH EXECUTE AS 'dbo'
-- 	AS
-- 	BEGIN
-- 		set nocount on
-- 		declare @theId 			int
-- 		declare @IsDbo 			int
-- 		
-- 		declare @UIDFound 		int
-- 		declare @DiagId			int
-- 	
-- 		if(@diagramname is null)
-- 		begin
-- 			RAISERROR ('Invalid value', 16, 1);
-- 			return -1
-- 		end
-- 	
-- 		EXECUTE AS CALLER;
-- 		select @theId = DATABASE_PRINCIPAL_ID();
-- 		select @IsDbo = IS_MEMBER(N'db_owner'); 
-- 		if(@owner_id is null)
-- 			select @owner_id = @theId;
-- 		REVERT; 
-- 		
-- 		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
-- 		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
-- 		begin
-- 			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
-- 			return -3
-- 		end
-- 	
-- 		delete from dbo.sysdiagrams where diagram_id = @DiagId;
-- 	
-- 		return 0;
-- 	END
-- 	$$
-- 
-- DELIMITER ;
-- 
-- ----------------------------------------------------------------------------
-- Routine JummahManagement.GetDhaes
-- ----------------------------------------------------------------------------
-- DELIMITER $$
-- 
-- DELIMITER $$
-- USE `JummahManagement`$$
-- CREATE PROCEDURE GetDhaes
-- AS
-- SELECT * FROM tbl_Dhae
-- GO;$$
-- 
-- DELIMITER ;
-- 
-- ----------------------------------------------------------------------------
-- Routine JummahManagement.GetCities
-- ----------------------------------------------------------------------------
-- DELIMITER $$
-- 
-- DELIMITER $$
-- USE `JummahManagement`$$
-- CREATE PROCEDURE [dbo].[GetCities]
-- AS
-- SELECT * FROM tbl_City
-- GO;$$
-- 
-- DELIMITER ;
-- 
-- ----------------------------------------------------------------------------
-- Routine JummahManagement.GetJummahSchedule
-- ----------------------------------------------------------------------------
-- DELIMITER $$
-- 
-- DELIMITER $$
-- USE `JummahManagement`$$
-- CREATE PROCEDURE GetJummahSchedule
-- AS
-- SELECT * FROM tbl_Jummah_Schedule
-- GO;$$
-- 
-- DELIMITER ;
-- 
-- ----------------------------------------------------------------------------
-- Routine JummahManagement.CreateTempBranchTable
-- ----------------------------------------------------------------------------
-- DELIMITER $$
-- 
-- DELIMITER $$
-- USE `JummahManagement`$$
-- CREATE PROCEDURE [dbo].[CreateTempBranchTable]
-- AS
-- 					DROP TABLE [dbo].[tbl_Branches_temp]
-- 					SET ANSI_NULLS ON
-- 					SET QUOTED_IDENTIFIER ON
-- 					CREATE TABLE [dbo].[tbl_Branches_temp](
-- 						[Branch_ID] [nvarchar](20) NOT NULL,
-- 						[Branch_Name] [nvarchar](50) NOT NULL,
-- 						[JIP_Name] [nvarchar](40) NOT NULL,
-- 						[JIP_Contact] [nchar](15) NOT NULL,
-- 						[No] [int] NULL,
-- 						[Street_Name] [nvarchar](50) NULL,
-- 						[City] [nvarchar](50) NULL,
-- 						[District] [nvarchar](50) NULL,
-- 					 CONSTRAINT [PK_tbl_Branches_temp] PRIMARY KEY CLUSTERED 
-- 					(
-- 						[Branch_ID] ASC
-- 					)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
-- 					) ON [PRIMARY];
-- 
-- 					INSERT INTO tbl_Branches_temp SELECT * FROM tbl_Branches;$$
-- 
-- DELIMITER ;
-- 
-- ----------------------------------------------------------------------------
-- Routine JummahManagement.Get_Last_Visited_Date
-- ----------------------------------------------------------------------------
-- DELIMITER $$
-- 
-- DELIMITER $$
-- USE `JummahManagement`$$
-- CREATE PROCEDURE [dbo].[Get_Last_Visited_Date]
-- (
--  @BranchName nvarchar(50),
--  @DhaeName nvarchar(50)
-- )
-- AS 
-- BEGIN
-- SELECT Max(Date) From tbl_Jummah_Schedule Where Dhae_Name = @DhaeName AND Branch_Name = @BranchName 
-- END
-- $$
-- 
-- DELIMITER ;
-- 
-- ----------------------------------------------------------------------------
-- Routine JummahManagement.fn_diagramobjects
-- ----------------------------------------------------------------------------
-- DELIMITER $$
-- 
-- DELIMITER $$
-- USE `JummahManagement`$$
-- 
-- 	CREATE FUNCTION dbo.fn_diagramobjects() 
-- 	RETURNS int
-- 	WITH EXECUTE AS N'dbo'
-- 	AS
-- 	BEGIN
-- 		declare @id_upgraddiagrams		int
-- 		declare @id_sysdiagrams			int
-- 		declare @id_helpdiagrams		int
-- 		declare @id_helpdiagramdefinition	int
-- 		declare @id_creatediagram	int
-- 		declare @id_renamediagram	int
-- 		declare @id_alterdiagram 	int 
-- 		declare @id_dropdiagram		int
-- 		declare @InstalledObjects	int
-- 
-- 		select @InstalledObjects = 0
-- 
-- 		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
-- 			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
-- 			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
-- 			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
-- 			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
-- 			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
-- 			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
-- 			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')
-- 
-- 		if @id_upgraddiagrams is not null
-- 			select @InstalledObjects = @InstalledObjects + 1
-- 		if @id_sysdiagrams is not null
-- 			select @InstalledObjects = @InstalledObjects + 2
-- 		if @id_helpdiagrams is not null
-- 			select @InstalledObjects = @InstalledObjects + 4
-- 		if @id_helpdiagramdefinition is not null
-- 			select @InstalledObjects = @InstalledObjects + 8
-- 		if @id_creatediagram is not null
-- 			select @InstalledObjects = @InstalledObjects + 16
-- 		if @id_renamediagram is not null
-- 			select @InstalledObjects = @InstalledObjects + 32
-- 		if @id_alterdiagram  is not null
-- 			select @InstalledObjects = @InstalledObjects + 64
-- 		if @id_dropdiagram is not null
-- 			select @InstalledObjects = @InstalledObjects + 128
-- 		
-- 		return @InstalledObjects 
-- 	END
-- 	$$
-- 
-- DELIMITER ;
-- SET FOREIGN_KEY_CHECKS = 1;
