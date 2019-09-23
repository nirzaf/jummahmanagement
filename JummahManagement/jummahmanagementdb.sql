CREATE TABLE tbl_Branches (
    `Branch_ID`   VARCHAR (20) NOT NULL,
    `Branch_Name` VARCHAR (50) NOT NULL,
    `JIP_Name`    VARCHAR (40) NOT NULL,
    `JIP_Contact` CHAR (15)    NOT NULL,
    `No`          INT           NULL,
    `Street_Name` VARCHAR (50) NULL,
    `City`        VARCHAR (50) NULL,
    `District`    VARCHAR (50) NULL
);

CREATE TABLE tbl_Branches_Deleted (
    `Branch_ID`   VARCHAR (20) NOT NULL,
    `Branch_Name` VARCHAR (50) NOT NULL,
    `JIP_Name`    VARCHAR (40) NOT NULL,
    `JIP_Contact` CHAR (15)    NOT NULL,
    `No`          INT           NULL,
    `Street_Name` VARCHAR (50) NULL,
    `City`        VARCHAR (50) NULL,
    `District`    VARCHAR (50) NULL
);

CREATE TABLE tbl_Branches_temp (
    `Branch_ID`   VARCHAR (20) NOT NULL,
    `Branch_Name` VARCHAR (50) NOT NULL,
    `JIP_Name`    VARCHAR (40) NOT NULL,
    `JIP_Contact` CHAR (15)    NOT NULL,
    `No`          INT           NULL,
    `Street_Name` VARCHAR (50) NULL,
    `City`        VARCHAR (50) NULL,
    `District`    VARCHAR (50) NULL
);

CREATE TABLE tbl_City (
    `City_ID` INT           AUTO_INCREMENT NOT NULL,
    `City`    VARCHAR (50) NOT NULL
);

CREATE TABLE tbl_Dhae (
    `Dhae_ID`      INT            NOT NULL,
    `Dhae_Name`    VARCHAR (100) NOT NULL,
    `Dhae_Contact` VARCHAR (15)  NOT NULL,
    `House_No`     CHAR (10)     NULL,
    `Street_Name`  VARCHAR (50)  NULL,
    `City`         VARCHAR (50)  NULL,
    `District`     VARCHAR (20)  NULL
);

CREATE TABLE tbl_Dhae_Deleted (
    `Dhae_ID`      INT            NOT NULL,
    `Dhae_Name`    VARCHAR (100) NOT NULL,
    `Dhae_Contact` VARCHAR (15)  NOT NULL,
    `House_No`     CHAR (10)     NULL,
    `Street_Name`  VARCHAR (50)  NULL,
    `City`         VARCHAR (50)  NULL,
    `District`     VARCHAR (20)  NULL
);

CREATE TABLE tbl_Dhae_temp (
    `Dhae_ID`      INT            NOT NULL,
    `Dhae_Name`    VARCHAR (100) NOT NULL,
    `Dhae_Contact` VARCHAR (15)  NOT NULL,
    `House_No`     CHAR (10)     NULL,
    `Street_Name`  VARCHAR (50)  NULL,
    `City`         VARCHAR (50)  NULL,
    `District`     VARCHAR (20)  NULL
);

CREATE TABLE tbl_Jummah_Schedule (
    `ID`           INT           AUTO_INCREMENT NOT NULL,
    `Row_Count`    INT           NOT NULL,
    `Dhae_Name`    VARCHAR (50) NOT NULL,
    `Dhae_Contact` VARCHAR (20) NOT NULL,
    `Branch_Name`  VARCHAR (50) NOT NULL,
    `JIP_Name`     VARCHAR (50) NOT NULL,
    `JIP_Contact`  VARCHAR (50) NOT NULL,
    `Date`         VARCHAR (20) NOT NULL
);

CREATE TABLE tbl_Jummah_Schedule_temp (
    `ID`           INT           AUTO_INCREMENT NOT NULL,
    `Row_Count`    INT           NOT NULL,
    `Dhae_Name`    VARCHAR (50) NOT NULL,
    `Dhae_Contact` VARCHAR (20) NOT NULL,
    `Branch_Name`  VARCHAR (50) NOT NULL,
    `JIP_Name`     VARCHAR (50) NOT NULL,
    `JIP_Contact`  VARCHAR (50) NOT NULL,
    `Date`         VARCHAR (20) NOT NULL
);

ALTER TABLE `dbo`.`tbl_Branches`
    ADD CONSTRAINT `PK_tbl_Branches` PRIMARY KEY (`Branch_ID` ASC);

 
ALTER TABLE `dbo`.`tbl_Branches_Deleted`
    ADD CONSTRAINT `PK_tbl_Branches_Deleted` PRIMARY KEY (`Branch_ID` ASC);

 
ALTER TABLE `dbo`.`tbl_Branches_temp`
    ADD CONSTRAINT `PK_tbl_Branches_temp` PRIMARY KEY (`Branch_ID` ASC);

 
ALTER TABLE `dbo`.`tbl_City`
    ADD CONSTRAINT `PK_tbl_City` PRIMARY KEY (`City_ID` ASC);

 
ALTER TABLE `dbo`.`tbl_Dhae`
    ADD CONSTRAINT `PK_tbl_Dhae` PRIMARY KEY (`Dhae_ID` ASC);

 
ALTER TABLE `dbo`.`tbl_Dhae_Deleted`
    ADD CONSTRAINT `PK_tbl_Dhae_Deleted` PRIMARY KEY (`Dhae_ID` ASC);

 
ALTER TABLE `dbo`.`tbl_Dhae_temp`
    ADD CONSTRAINT `PK_tbl_Dhae_temp` PRIMARY KEY (`Dhae_ID` ASC);

 
ALTER TABLE `dbo`.`tbl_Jummah_Schedule`
    ADD CONSTRAINT `PK_tbl_Jummah_Schedule` PRIMARY KEY (`ID` ASC);

 
ALTER TABLE `dbo`.`tbl_Jummah_Schedule_temp`
    ADD CONSTRAINT `PK_tbl_Jummah_Schedule_temp` PRIMARY KEY (`ID` ASC);

 
CREATE LOGIN `nirzaf_SQLLogin_1`
    WITH PASSWORD = N'|o~ot^|rh&|;vjwtXajbwm,omsFT7_&#$!~<bu~zXEzdob<k';


CREATE PROCEDURE `CreateTempBranchTable`() 
NOT DETERMINISTIC NO SQL SQL SECURITY DEFINER 
BEGIN DROP TABLE `tbl_branches_temp`; 
    CREATE TABLE `tbl_branches_temp` ( 
    `Branch_ID` varchar(20) CHARACTER SET utf8 NOT NULL, 
    `Branch_Name` varchar(50) CHARACTER SET utf8 NOT NULL, 
    `JIP_Name` varchar(40) CHARACTER SET utf8 NOT NULL, 
    `JIP_Contact` char(15) CHARACTER SET utf8 NOT NULL, 
    `No` int(11) DEFAULT NULL, 
    `Street_Name` varchar(50) CHARACTER SET utf8 DEFAULT NULL, 
    `City` varchar(50) CHARACTER SET utf8 DEFAULT NULL, 
    `District` varchar(50) CHARACTER SET utf8 DEFAULT NULL ) 
    ENGINE=InnoDB DEFAULT CHARSET=latin1; 
      
      INSERT INTO tbl_branches_temp (SELECT * FROM tbl_branches); 
END


DELIMITER ;


DELIMITER //

CREATE PROCEDURE Get_Last_Visited_Date (
p_BranchName NVARCHAR (50)) NULL, @DhaeName NVARCHAR (50) NULL
AS
BEGIN
    SELECT Max(Date)
    FROM   tbl_Jummah_Schedule
    WHERE  Dhae_Name = @DhaeName
           AND Branch_Name = p_BranchName;
END;


END;
//

DELIMITER ;


DELIMITER //

CREATE PROCEDURE GetBranches
BEGIN
SELECT *
FROM   tbl_Branches;


END;
//

DELIMITER ;


DELIMITER //

CREATE PROCEDURE GetCities
BEGIN
SELECT *
FROM   tbl_City;


END;
//

DELIMITER ;


DELIMITER //

CREATE PROCEDURE GetDhaes
BEGIN
SELECT *
FROM   tbl_Dhae;


END;
//

DELIMITER ;


DELIMITER //

CREATE PROCEDURE GetJummahSchedule
BEGIN
SELECT *
FROM   tbl_Jummah_Schedule;


END;
//

DELIMITER ;


CREATE SCHEMA nirzaf_SQLLogin_1;
    AUTHORIZATION `nirzaf_SQLLogin_1`;

GO
