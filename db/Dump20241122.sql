-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: localhost    Database: dbmcpms
-- ------------------------------------------------------
-- Server version	9.0.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tblallowance`
--

DROP TABLE IF EXISTS `tblallowance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblallowance` (
  `allowanceID` int NOT NULL AUTO_INCREMENT,
  `allowanceName` varchar(45) NOT NULL,
  `status` varchar(45) NOT NULL,
  PRIMARY KEY (`allowanceID`),
  UNIQUE KEY `allowanceID_UNIQUE` (`allowanceID`),
  UNIQUE KEY `allowanceName_UNIQUE` (`allowanceName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblallowance`
--

LOCK TABLES `tblallowance` WRITE;
/*!40000 ALTER TABLE `tblallowance` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblallowance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblattendance`
--

DROP TABLE IF EXISTS `tblattendance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblattendance` (
  `attendanceID` int NOT NULL AUTO_INCREMENT,
  `employeeID` int NOT NULL,
  `date` date NOT NULL,
  `login` datetime DEFAULT NULL,
  `logout` datetime DEFAULT NULL,
  `report` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`attendanceID`),
  UNIQUE KEY `attendanceID_UNIQUE` (`employeeID`,`date`)
) ENGINE=InnoDB AUTO_INCREMENT=85 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblattendance`
--

LOCK TABLES `tblattendance` WRITE;
/*!40000 ALTER TABLE `tblattendance` DISABLE KEYS */;
INSERT INTO `tblattendance` VALUES (4,1,'2024-11-17','2024-11-17 09:06:56','2024-11-17 18:06:58','Present'),(5,1,'2024-11-16','2024-11-16 08:00:00','2024-11-16 19:00:00','Present'),(6,1,'2024-11-15','2024-11-15 08:00:00','2024-11-15 23:00:00','Present'),(7,1,'2024-11-13','2024-11-13 08:00:00','2024-11-13 18:00:00','Present'),(8,1,'2024-11-11','2024-11-11 08:00:00','2024-11-11 16:00:00','Present'),(9,1,'2024-11-10','2024-11-10 08:00:00','2024-11-10 17:00:00','Present'),(10,1,'2024-11-09','2024-11-09 08:00:00','2024-11-09 17:00:00','Present'),(11,1,'2024-11-08','2024-11-08 08:00:00','2024-11-08 23:00:00','Present'),(65,4,'2024-11-01',NULL,NULL,'On Leave'),(66,4,'2024-11-02',NULL,NULL,'On Leave'),(67,4,'2024-11-03',NULL,NULL,'On Leave'),(68,4,'2024-11-04',NULL,NULL,'On Leave'),(69,4,'2024-11-05',NULL,NULL,'On Leave'),(70,4,'2024-11-06',NULL,NULL,'On Leave'),(71,4,'2024-11-07',NULL,NULL,'On Leave'),(72,4,'2024-11-08',NULL,NULL,'On Leave'),(73,4,'2024-11-09',NULL,NULL,'On Leave'),(74,4,'2024-11-10',NULL,NULL,'On Leave'),(75,4,'2024-11-11',NULL,NULL,'On Leave'),(76,4,'2024-11-12',NULL,NULL,'On Leave'),(77,4,'2024-11-13',NULL,NULL,'On Leave'),(78,4,'2024-11-14',NULL,NULL,'On Leave'),(79,4,'2024-11-15',NULL,NULL,'On Leave'),(81,4,'2024-11-30','2024-11-30 08:00:00',NULL,'Present'),(82,1,'2024-11-02','2024-11-02 23:00:00',NULL,'Present');
/*!40000 ALTER TABLE `tblattendance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbldepartment`
--

DROP TABLE IF EXISTS `tbldepartment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbldepartment` (
  `departmentID` int NOT NULL AUTO_INCREMENT,
  `departmentName` varchar(45) NOT NULL,
  `status` varchar(45) NOT NULL,
  PRIMARY KEY (`departmentID`),
  UNIQUE KEY `departmentID_UNIQUE` (`departmentID`),
  UNIQUE KEY `departmentName_UNIQUE` (`departmentName`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbldepartment`
--

LOCK TABLES `tbldepartment` WRITE;
/*!40000 ALTER TABLE `tbldepartment` DISABLE KEYS */;
INSERT INTO `tbldepartment` VALUES (1,'first','Active');
/*!40000 ALTER TABLE `tbldepartment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbldepartmenthead`
--

DROP TABLE IF EXISTS `tbldepartmenthead`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbldepartmenthead` (
  `departmentheadID` int NOT NULL AUTO_INCREMENT,
  `departmentID` int NOT NULL,
  `employeeID` int DEFAULT NULL,
  PRIMARY KEY (`departmentheadID`),
  UNIQUE KEY `departmentID_UNIQUE` (`departmentID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbldepartmenthead`
--

LOCK TABLES `tbldepartmenthead` WRITE;
/*!40000 ALTER TABLE `tbldepartmenthead` DISABLE KEYS */;
INSERT INTO `tbldepartmenthead` VALUES (1,1,2);
/*!40000 ALTER TABLE `tbldepartmenthead` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblemployee`
--

DROP TABLE IF EXISTS `tblemployee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblemployee` (
  `employeeID` int NOT NULL AUTO_INCREMENT,
  `employeeNumber` int NOT NULL,
  `rfidnumber` varchar(45) NOT NULL,
  `firstname` varchar(45) NOT NULL,
  `middlename` varchar(45) DEFAULT NULL,
  `lastname` varchar(45) NOT NULL,
  `departmentID` int NOT NULL,
  `positionID` int DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`employeeID`),
  UNIQUE KEY `employeeNumber_UNIQUE` (`employeeNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblemployee`
--

LOCK TABLES `tblemployee` WRITE;
/*!40000 ALTER TABLE `tblemployee` DISABLE KEYS */;
INSERT INTO `tblemployee` VALUES (1,20240001,'2711325364','Renz Irish','Morano','Garcia',1,1,'Regular','asd'),(2,20240002,'123123123','asdasdasdasdqweqwe','qweqweqwe','qweqwe',1,2,'Regular','asd'),(3,20240003,'1234512345','Ryan','James','Lumayag',1,1,'Regular','asd'),(4,20240004,'1234567890','Clifford','Jepoy','Villena',1,2,'Regular','asd'),(5,20240005,'12312412214','asdasdqwe','qweqweqweqw','qweqwe',1,1,'Resigned','asd'),(6,20240006,'2716425380','Albert','Nerza','De Guzman',1,1,'Probationary','asd');
/*!40000 ALTER TABLE `tblemployee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblempvoluntary`
--

DROP TABLE IF EXISTS `tblempvoluntary`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblempvoluntary` (
  `empvoluntaryID` int NOT NULL AUTO_INCREMENT,
  `employeeID` int NOT NULL,
  `voluntaryID` int NOT NULL,
  `amount` decimal(10,2) NOT NULL,
  PRIMARY KEY (`empvoluntaryID`),
  UNIQUE KEY `Unique` (`employeeID`,`voluntaryID`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblempvoluntary`
--

LOCK TABLES `tblempvoluntary` WRITE;
/*!40000 ALTER TABLE `tblempvoluntary` DISABLE KEYS */;
INSERT INTO `tblempvoluntary` VALUES (1,1,1,500.00),(6,2,1,0.00),(10,5,1,300.00),(13,6,1,500.00),(14,3,1,0.00),(15,4,1,0.00);
/*!40000 ALTER TABLE `tblempvoluntary` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblfiledftio`
--

DROP TABLE IF EXISTS `tblfiledftio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblfiledftio` (
  `ftioID` int NOT NULL AUTO_INCREMENT,
  `employeeID` int NOT NULL,
  `date` date NOT NULL,
  `time` time NOT NULL,
  `classification` varchar(45) NOT NULL,
  `reason` varchar(1000) NOT NULL,
  `status` varchar(45) NOT NULL,
  PRIMARY KEY (`ftioID`),
  UNIQUE KEY `Unique` (`employeeID`,`date`,`classification`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblfiledftio`
--

LOCK TABLES `tblfiledftio` WRITE;
/*!40000 ALTER TABLE `tblfiledftio` DISABLE KEYS */;
INSERT INTO `tblfiledftio` VALUES (1,1,'2024-11-02','23:00:00','Login','Fail to login','Approve'),(2,1,'2024-11-08','23:00:00','Logout','Fail to logout','Approve'),(3,1,'2024-11-08','23:00:00','Login','Fail to login','Approve'),(4,4,'2024-11-30','08:00:00','Login','asd','Approve');
/*!40000 ALTER TABLE `tblfiledftio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblfiledleave`
--

DROP TABLE IF EXISTS `tblfiledleave`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblfiledleave` (
  `filedleaveID` int NOT NULL AUTO_INCREMENT,
  `employeeID` int NOT NULL,
  `leavefrom` date NOT NULL,
  `leaveto` date NOT NULL,
  `leaveID` int NOT NULL,
  `leavereason` varchar(1000) NOT NULL,
  `noofdays` int NOT NULL,
  `status` varchar(45) NOT NULL,
  PRIMARY KEY (`filedleaveID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblfiledleave`
--

LOCK TABLES `tblfiledleave` WRITE;
/*!40000 ALTER TABLE `tblfiledleave` DISABLE KEYS */;
INSERT INTO `tblfiledleave` VALUES (1,1,'2024-11-02','2024-11-02',1,'asd',1,'Approve'),(2,4,'2024-11-01','2024-11-15',1,'qwe',15,'Approve');
/*!40000 ALTER TABLE `tblfiledleave` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblholiday`
--

DROP TABLE IF EXISTS `tblholiday`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblholiday` (
  `holidayID` int NOT NULL AUTO_INCREMENT,
  `date` date NOT NULL,
  `classification` varchar(45) NOT NULL,
  `holidayName` varchar(45) NOT NULL,
  PRIMARY KEY (`holidayID`),
  UNIQUE KEY `holidayID_UNIQUE` (`holidayID`) /*!80000 INVISIBLE */,
  UNIQUE KEY `holidayName` (`holidayName`,`date`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblholiday`
--

LOCK TABLES `tblholiday` WRITE;
/*!40000 ALTER TABLE `tblholiday` DISABLE KEYS */;
INSERT INTO `tblholiday` VALUES (1,'2024-11-17','Regular Holiday','Sample'),(2,'2024-01-01','Regular Holiday','New Year');
/*!40000 ALTER TABLE `tblholiday` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblincentives`
--

DROP TABLE IF EXISTS `tblincentives`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblincentives` (
  `incentiveID` int NOT NULL AUTO_INCREMENT,
  `incentiveName` varchar(45) NOT NULL,
  `status` varchar(45) NOT NULL,
  PRIMARY KEY (`incentiveID`),
  UNIQUE KEY `idtblincentives_UNIQUE` (`incentiveID`),
  UNIQUE KEY `incentiveName_UNIQUE` (`incentiveName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblincentives`
--

LOCK TABLES `tblincentives` WRITE;
/*!40000 ALTER TABLE `tblincentives` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblincentives` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbljoballowance`
--

DROP TABLE IF EXISTS `tbljoballowance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbljoballowance` (
  `jobAllowanceID` int NOT NULL AUTO_INCREMENT,
  `positionID` int NOT NULL,
  `allowanceID` int NOT NULL,
  `amount` decimal(10,2) NOT NULL,
  PRIMARY KEY (`jobAllowanceID`),
  UNIQUE KEY `jobAllowanceID_UNIQUE` (`jobAllowanceID`) /*!80000 INVISIBLE */,
  UNIQUE KEY `Unique` (`positionID`,`allowanceID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbljoballowance`
--

LOCK TABLES `tbljoballowance` WRITE;
/*!40000 ALTER TABLE `tbljoballowance` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbljoballowance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbljobleave`
--

DROP TABLE IF EXISTS `tbljobleave`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbljobleave` (
  `jobleaveID` int NOT NULL AUTO_INCREMENT,
  `positionID` int NOT NULL,
  `leaveID` int NOT NULL,
  `days` decimal(10,0) NOT NULL,
  PRIMARY KEY (`jobleaveID`),
  UNIQUE KEY `jobleaveID_UNIQUE` (`jobleaveID`),
  UNIQUE KEY `Unique Combi` (`positionID`,`leaveID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbljobleave`
--

LOCK TABLES `tbljobleave` WRITE;
/*!40000 ALTER TABLE `tbljobleave` DISABLE KEYS */;
INSERT INTO `tbljobleave` VALUES (1,1,1,15),(2,1,2,15),(3,1,3,15),(4,2,1,10),(5,2,2,12),(6,2,3,1);
/*!40000 ALTER TABLE `tbljobleave` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblleave`
--

DROP TABLE IF EXISTS `tblleave`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblleave` (
  `leaveID` int NOT NULL AUTO_INCREMENT,
  `leaveType` varchar(45) NOT NULL,
  `status` varchar(45) NOT NULL,
  PRIMARY KEY (`leaveID`),
  UNIQUE KEY `idtblleave_UNIQUE` (`leaveID`),
  UNIQUE KEY `leaveType_UNIQUE` (`leaveType`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblleave`
--

LOCK TABLES `tblleave` WRITE;
/*!40000 ALTER TABLE `tblleave` DISABLE KEYS */;
INSERT INTO `tblleave` VALUES (1,'Maternity Leave','Active'),(2,'Sick Leave','Active'),(3,'Vacation Leave','Active');
/*!40000 ALTER TABLE `tblleave` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblovertime`
--

DROP TABLE IF EXISTS `tblovertime`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblovertime` (
  `overtimeID` int NOT NULL AUTO_INCREMENT,
  `employeeID` int NOT NULL,
  `attendanceID` int NOT NULL,
  `remarks` varchar(45) NOT NULL,
  PRIMARY KEY (`overtimeID`),
  UNIQUE KEY `Unique` (`employeeID`,`attendanceID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblovertime`
--

LOCK TABLES `tblovertime` WRITE;
/*!40000 ALTER TABLE `tblovertime` DISABLE KEYS */;
INSERT INTO `tblovertime` VALUES (1,1,7,'Approved'),(2,1,6,'Approved'),(3,1,5,'Declined');
/*!40000 ALTER TABLE `tblovertime` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblpagibig`
--

DROP TABLE IF EXISTS `tblpagibig`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblpagibig` (
  `pagibigID` int NOT NULL AUTO_INCREMENT,
  `rate` int NOT NULL,
  `date` datetime NOT NULL,
  PRIMARY KEY (`pagibigID`),
  UNIQUE KEY `idtblpagibig_UNIQUE` (`pagibigID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblpagibig`
--

LOCK TABLES `tblpagibig` WRITE;
/*!40000 ALTER TABLE `tblpagibig` DISABLE KEYS */;
INSERT INTO `tblpagibig` VALUES (1,200,'2024-11-19 08:11:40');
/*!40000 ALTER TABLE `tblpagibig` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblpayroll`
--

DROP TABLE IF EXISTS `tblpayroll`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblpayroll` (
  `payrollID` int NOT NULL AUTO_INCREMENT,
  `employeeID` int NOT NULL,
  `payrollperiodID` int NOT NULL,
  `grosspay` decimal(10,0) NOT NULL,
  PRIMARY KEY (`payrollID`),
  UNIQUE KEY `Unique` (`employeeID`,`payrollperiodID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblpayroll`
--

LOCK TABLES `tblpayroll` WRITE;
/*!40000 ALTER TABLE `tblpayroll` DISABLE KEYS */;
INSERT INTO `tblpayroll` VALUES (6,1,1,1850);
/*!40000 ALTER TABLE `tblpayroll` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblpayrollperiod`
--

DROP TABLE IF EXISTS `tblpayrollperiod`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblpayrollperiod` (
  `payrollperiodID` int NOT NULL AUTO_INCREMENT,
  `payrollperiodname` varchar(45) NOT NULL,
  `datefrom` date NOT NULL,
  `dateto` date NOT NULL,
  `payout` varchar(45) NOT NULL,
  PRIMARY KEY (`payrollperiodID`),
  UNIQUE KEY `payrollperiodname_UNIQUE` (`payrollperiodname`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblpayrollperiod`
--

LOCK TABLES `tblpayrollperiod` WRITE;
/*!40000 ALTER TABLE `tblpayrollperiod` DISABLE KEYS */;
INSERT INTO `tblpayrollperiod` VALUES (1,'November 15 Payroll','2024-11-01','2024-11-15','Yes'),(2,'November 30 Payroll','2024-11-16','2024-11-30','Yes');
/*!40000 ALTER TABLE `tblpayrollperiod` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblphilhealth`
--

DROP TABLE IF EXISTS `tblphilhealth`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblphilhealth` (
  `philhealthID` int NOT NULL AUTO_INCREMENT,
  `rate` int NOT NULL,
  `date` datetime NOT NULL,
  PRIMARY KEY (`philhealthID`),
  UNIQUE KEY `philhealthID_UNIQUE` (`philhealthID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblphilhealth`
--

LOCK TABLES `tblphilhealth` WRITE;
/*!40000 ALTER TABLE `tblphilhealth` DISABLE KEYS */;
INSERT INTO `tblphilhealth` VALUES (1,5,'2024-11-19 08:11:42');
/*!40000 ALTER TABLE `tblphilhealth` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblposition`
--

DROP TABLE IF EXISTS `tblposition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblposition` (
  `positionID` int NOT NULL AUTO_INCREMENT,
  `positionName` varchar(45) NOT NULL,
  `status` varchar(45) NOT NULL,
  `departmentID` int NOT NULL,
  PRIMARY KEY (`positionID`),
  UNIQUE KEY `positionID_UNIQUE` (`positionID`),
  UNIQUE KEY `position` (`positionName`,`departmentID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblposition`
--

LOCK TABLES `tblposition` WRITE;
/*!40000 ALTER TABLE `tblposition` DISABLE KEYS */;
INSERT INTO `tblposition` VALUES (1,'kahit ano','Active',1),(2,'asdasd','Active',1);
/*!40000 ALTER TABLE `tblposition` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblrates`
--

DROP TABLE IF EXISTS `tblrates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblrates` (
  `ratesID` int NOT NULL AUTO_INCREMENT,
  `rateClassification` varchar(45) NOT NULL,
  `rate` int NOT NULL,
  PRIMARY KEY (`ratesID`),
  UNIQUE KEY `ratesID_UNIQUE` (`ratesID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblrates`
--

LOCK TABLES `tblrates` WRITE;
/*!40000 ALTER TABLE `tblrates` DISABLE KEYS */;
INSERT INTO `tblrates` VALUES (1,'Night Differential Rate',110),(2,'Overtime - Regular Rate',130),(3,'Overtime - Special Rate',140),(4,'Rest Day Rate',130),(5,'Special Holiday Rate',130),(6,'Regular Holiday Rate',200),(7,'Double Holiday Rate',260);
/*!40000 ALTER TABLE `tblrates` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblsalary`
--

DROP TABLE IF EXISTS `tblsalary`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblsalary` (
  `salaryID` int NOT NULL AUTO_INCREMENT,
  `employeeID` int NOT NULL,
  `salary` decimal(10,0) NOT NULL,
  `type` varchar(45) NOT NULL,
  `daily` decimal(20,7) DEFAULT NULL,
  PRIMARY KEY (`salaryID`),
  UNIQUE KEY `employeeID_UNIQUE` (`employeeID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblsalary`
--

LOCK TABLES `tblsalary` WRITE;
/*!40000 ALTER TABLE `tblsalary` DISABLE KEYS */;
INSERT INTO `tblsalary` VALUES (1,1,30000,'Monthly',1379.3103448),(2,2,200,'Monthly',200.0000000),(3,3,100,'Monthly',4.5977011),(4,4,610,'Monthly',28.0459770),(5,5,500,'Monthly',NULL),(6,6,610,'Monthly',28.1538462);
/*!40000 ALTER TABLE `tblsalary` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblschedule`
--

DROP TABLE IF EXISTS `tblschedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblschedule` (
  `scheduleID` int NOT NULL AUTO_INCREMENT,
  `employeeID` int NOT NULL,
  `day` varchar(45) NOT NULL,
  `remark` varchar(45) NOT NULL,
  PRIMARY KEY (`scheduleID`),
  UNIQUE KEY `Unique` (`employeeID`,`day`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblschedule`
--

LOCK TABLES `tblschedule` WRITE;
/*!40000 ALTER TABLE `tblschedule` DISABLE KEYS */;
INSERT INTO `tblschedule` VALUES (1,1,'Monday','With Duty'),(2,1,'Tuesday','With Duty'),(3,1,'Wednesday','With Duty'),(4,1,'Thursday','With Duty'),(5,1,'Friday','With Duty'),(6,1,'Saturday','Day Off'),(7,1,'Sunday','Day Off'),(8,3,'Monday','With Duty'),(9,3,'Tuesday','With Duty'),(10,3,'Wednesday','With Duty'),(11,3,'Thursday','With Duty'),(12,3,'Friday','With Duty'),(13,3,'Saturday','Day Off'),(14,3,'Sunday','Day Off'),(15,4,'Monday','With Duty'),(16,4,'Tuesday','With Duty'),(17,4,'Wednesday','With Duty'),(18,4,'Thursday','With Duty'),(19,4,'Friday','With Duty'),(20,4,'Saturday','Day Off'),(21,4,'Sunday','Day Off'),(22,6,'Monday','With Duty'),(23,6,'Tuesday','With Duty'),(24,6,'Wednesday','With Duty'),(25,6,'Thursday','Day Off'),(26,6,'Friday','Day Off'),(27,6,'Saturday','With Duty'),(28,6,'Sunday','With Duty');
/*!40000 ALTER TABLE `tblschedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblsss`
--

DROP TABLE IF EXISTS `tblsss`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblsss` (
  `sssID` int NOT NULL AUTO_INCREMENT,
  `minSalary` decimal(10,2) NOT NULL,
  `maxSalary` decimal(10,2) NOT NULL,
  `EE` decimal(10,2) NOT NULL,
  `WISP` decimal(10,2) NOT NULL,
  `total` decimal(10,2) NOT NULL,
  PRIMARY KEY (`sssID`),
  UNIQUE KEY `sssID_UNIQUE` (`sssID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblsss`
--

LOCK TABLES `tblsss` WRITE;
/*!40000 ALTER TABLE `tblsss` DISABLE KEYS */;
INSERT INTO `tblsss` VALUES (1,0.00,2000.00,200.00,0.00,200.00),(2,2000.01,20000.00,200.00,200.00,400.00),(3,20000.01,30000.00,500.00,200.00,700.00),(4,30000.01,90000.00,600.00,200.00,800.00);
/*!40000 ALTER TABLE `tblsss` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbltax`
--

DROP TABLE IF EXISTS `tbltax`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbltax` (
  `taxID` int NOT NULL AUTO_INCREMENT,
  `minSalary` decimal(10,2) NOT NULL,
  `maxSalary` decimal(10,2) NOT NULL,
  `fixedAmount` decimal(10,2) NOT NULL,
  `percentage` int NOT NULL,
  PRIMARY KEY (`taxID`),
  UNIQUE KEY `taxID_UNIQUE` (`taxID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbltax`
--

LOCK TABLES `tbltax` WRITE;
/*!40000 ALTER TABLE `tbltax` DISABLE KEYS */;
INSERT INTO `tbltax` VALUES (1,0.00,1000.00,100.00,5),(2,1000.01,100000.00,1000.00,5);
/*!40000 ALTER TABLE `tbltax` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbltimeschedule`
--

DROP TABLE IF EXISTS `tbltimeschedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbltimeschedule` (
  `timescheduleID` int NOT NULL AUTO_INCREMENT,
  `employeeID` int NOT NULL,
  `timein` time DEFAULT NULL,
  `timeout` time DEFAULT NULL,
  `breakin` time DEFAULT NULL,
  `breakout` time DEFAULT NULL,
  `noofhours` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`timescheduleID`),
  UNIQUE KEY `employeeID_UNIQUE` (`employeeID`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbltimeschedule`
--

LOCK TABLES `tbltimeschedule` WRITE;
/*!40000 ALTER TABLE `tbltimeschedule` DISABLE KEYS */;
INSERT INTO `tbltimeschedule` VALUES (1,1,'08:00:00','17:00:00','13:00:00','14:00:00',8.00),(13,6,'08:00:00','17:00:00','13:00:00','14:00:00',8.00),(16,4,'12:00:00','21:00:00','17:00:00','18:00:00',8.00),(20,3,'08:00:00','17:00:00','12:00:00','13:00:00',8.00);
/*!40000 ALTER TABLE `tbltimeschedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblusers`
--

DROP TABLE IF EXISTS `tblusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblusers` (
  `userID` int NOT NULL AUTO_INCREMENT,
  `firstName` varchar(45) NOT NULL,
  `lastName` varchar(45) NOT NULL,
  `role` varchar(45) NOT NULL,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  PRIMARY KEY (`userID`),
  UNIQUE KEY `userID_UNIQUE` (`userID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblusers`
--

LOCK TABLES `tblusers` WRITE;
/*!40000 ALTER TABLE `tblusers` DISABLE KEYS */;
INSERT INTO `tblusers` VALUES (1,'Clifford','Villena','Payroll Staff','sausage','123'),(2,'Renz','Morano','Admin','admin','123');
/*!40000 ALTER TABLE `tblusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblvoluntary`
--

DROP TABLE IF EXISTS `tblvoluntary`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblvoluntary` (
  `voluntaryID` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `status` varchar(45) NOT NULL,
  PRIMARY KEY (`voluntaryID`),
  UNIQUE KEY `idtblvoluntary_UNIQUE` (`voluntaryID`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblvoluntary`
--

LOCK TABLES `tblvoluntary` WRITE;
/*!40000 ALTER TABLE `tblvoluntary` DISABLE KEYS */;
INSERT INTO `tblvoluntary` VALUES (1,'Additional SSS','Active');
/*!40000 ALTER TABLE `tblvoluntary` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-22 20:50:14
