-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 23, 2019 at 09:21 AM
-- Server version: 10.1.37-MariaDB
-- PHP Version: 7.3.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `jummahmanagement`
--

DELIMITER $$
--
-- Procedures
--
CREATE PROCEDURE `CreateTempBranchTable` ()  NO SQL
BEGIN
DROP TABLE `tbl_branches_temp`;

CREATE TABLE `tbl_branches_temp` (
  `Branch_ID` varchar(20) CHARACTER SET utf8 NOT NULL,
  `Branch_Name` varchar(50) CHARACTER SET utf8 NOT NULL,
  `JIP_Name` varchar(40) CHARACTER SET utf8 NOT NULL,
  `JIP_Contact` char(15) CHARACTER SET utf8 NOT NULL,
  `No` int(11) DEFAULT NULL,
  `Street_Name` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `City` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `District` varchar(50) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO tbl_branches_temp (SELECT * FROM tbl_branches);
END$$
DELIMITER

DELIMITER $$
CREATE PROCEDURE `GetBranches` ()  NO SQL
BEGIN
SELECT * FROM tbl_Branches;
END
$$ DELIMITER

CREATE PROCEDURE `GetCities` ()  NO SQL
SELECT * FROM  tbl_City$$

CREATE PROCEDURE `GetDhaes` ()  NO SQL
SELECT * FROM tbl_Dhae$$

CREATE PROCEDURE `GetJummahSchedule` ()  NO SQL
SELECT * FROM tbl_Jummah_Schedule$$

CREATE PROCEDURE `Get_Last_Visited_Date` (IN `p_BranchName` VARCHAR(50), IN `DhaeName` VARCHAR(50))  NO SQL
BEGIN
    SELECT Max(Date)
    FROM   tbl_Jummah_Schedule
    WHERE  Dhae_Name = @DhaeName
           AND Branch_Name = @p_BranchName;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_branches`
--

CREATE TABLE `tbl_branches` (
  `Branch_ID` varchar(20) CHARACTER SET utf8 NOT NULL,
  `Branch_Name` varchar(50) CHARACTER SET utf8 NOT NULL,
  `JIP_Name` varchar(40) CHARACTER SET utf8 NOT NULL,
  `JIP_Contact` char(15) CHARACTER SET utf8 NOT NULL,
  `No` int(11) DEFAULT NULL,
  `Street_Name` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `City` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `District` varchar(50) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_branches_deleted`
--

CREATE TABLE `tbl_branches_deleted` (
  `Branch_ID` varchar(20) CHARACTER SET utf8 NOT NULL,
  `Branch_Name` varchar(50) CHARACTER SET utf8 NOT NULL,
  `JIP_Name` varchar(40) CHARACTER SET utf8 NOT NULL,
  `JIP_Contact` char(15) CHARACTER SET utf8 NOT NULL,
  `No` int(11) DEFAULT NULL,
  `Street_Name` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `City` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `District` varchar(50) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_branches_temp`
--

CREATE TABLE `tbl_branches_temp` (
  `Branch_ID` varchar(20) CHARACTER SET utf8 NOT NULL,
  `Branch_Name` varchar(50) CHARACTER SET utf8 NOT NULL,
  `JIP_Name` varchar(40) CHARACTER SET utf8 NOT NULL,
  `JIP_Contact` char(15) CHARACTER SET utf8 NOT NULL,
  `No` int(11) DEFAULT NULL,
  `Street_Name` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `City` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `District` varchar(50) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_city`
--

CREATE TABLE `tbl_city` (
  `City_ID` int(11) NOT NULL,
  `City` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_dhae`
--

CREATE TABLE `tbl_dhae` (
  `Dhae_ID` int(11) NOT NULL,
  `Dhae_Name` varchar(100) NOT NULL,
  `Dhae_Contact` varchar(15) NOT NULL,
  `House_No` char(10) DEFAULT NULL,
  `Street_Name` varchar(50) DEFAULT NULL,
  `City` varchar(50) DEFAULT NULL,
  `District` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_dhae_deleted`
--

CREATE TABLE `tbl_dhae_deleted` (
  `Dhae_ID` int(11) NOT NULL,
  `Dhae_Name` varchar(100) NOT NULL,
  `Dhae_Contact` varchar(15) NOT NULL,
  `House_No` char(10) DEFAULT NULL,
  `Street_Name` varchar(50) DEFAULT NULL,
  `City` varchar(50) DEFAULT NULL,
  `District` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_dhae_temp`
--

CREATE TABLE `tbl_dhae_temp` (
  `Dhae_ID` int(11) NOT NULL,
  `Dhae_Name` varchar(100) NOT NULL,
  `Dhae_Contact` varchar(15) NOT NULL,
  `House_No` char(10) DEFAULT NULL,
  `Street_Name` varchar(50) DEFAULT NULL,
  `City` varchar(50) DEFAULT NULL,
  `District` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_jummah_schedule`
--

CREATE TABLE `tbl_jummah_schedule` (
  `ID` int(11) NOT NULL,
  `Row_Count` int(11) NOT NULL,
  `Dhae_Name` varchar(50) NOT NULL,
  `Dhae_Contact` varchar(20) NOT NULL,
  `Branch_Name` varchar(50) NOT NULL,
  `JIP_Name` varchar(50) NOT NULL,
  `JIP_Contact` varchar(50) NOT NULL,
  `Date` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_jummah_schedule_temp`
--

CREATE TABLE `tbl_jummah_schedule_temp` (
  `ID` int(11) NOT NULL,
  `Row_Count` int(11) NOT NULL,
  `Dhae_Name` varchar(50) NOT NULL,
  `Dhae_Contact` varchar(20) NOT NULL,
  `Branch_Name` varchar(50) NOT NULL,
  `JIP_Name` varchar(50) NOT NULL,
  `JIP_Contact` varchar(50) NOT NULL,
  `Date` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_branches`
--
ALTER TABLE `tbl_branches`
  ADD PRIMARY KEY (`Branch_ID`);

--
-- Indexes for table `tbl_branches_deleted`
--
ALTER TABLE `tbl_branches_deleted`
  ADD PRIMARY KEY (`Branch_ID`);

--
-- Indexes for table `tbl_branches_temp`
--
ALTER TABLE `tbl_branches_temp`
  ADD PRIMARY KEY (`Branch_ID`);

--
-- Indexes for table `tbl_city`
--
ALTER TABLE `tbl_city`
  ADD PRIMARY KEY (`City_ID`);

--
-- Indexes for table `tbl_dhae`
--
ALTER TABLE `tbl_dhae`
  ADD PRIMARY KEY (`Dhae_ID`);

--
-- Indexes for table `tbl_dhae_deleted`
--
ALTER TABLE `tbl_dhae_deleted`
  ADD PRIMARY KEY (`Dhae_ID`);

--
-- Indexes for table `tbl_dhae_temp`
--
ALTER TABLE `tbl_dhae_temp`
  ADD PRIMARY KEY (`Dhae_ID`);

--
-- Indexes for table `tbl_jummah_schedule`
--
ALTER TABLE `tbl_jummah_schedule`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `tbl_jummah_schedule_temp`
--
ALTER TABLE `tbl_jummah_schedule_temp`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_city`
--
ALTER TABLE `tbl_city`
  MODIFY `City_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_jummah_schedule`
--
ALTER TABLE `tbl_jummah_schedule`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_jummah_schedule_temp`
--
ALTER TABLE `tbl_jummah_schedule_temp`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
