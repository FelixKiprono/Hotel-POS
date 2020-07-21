-- MySqlBackup.NET 2.0.9.2
-- Dump Time: 2016-12-17 20:27:06
-- --------------------------------------
-- Server version 10.1.10-MariaDB mariadb.org binary distribution


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES latin1 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of auditlog
-- 

DROP TABLE IF EXISTS `auditlog`;
CREATE TABLE IF NOT EXISTS `auditlog` (
  `Date` varchar(100) NOT NULL,
  `Time` varchar(100) NOT NULL,
  `Operation` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table auditlog
-- 

/*!40000 ALTER TABLE `auditlog` DISABLE KEYS */;
INSERT INTO `auditlog`(`Date`,`Time`,`Operation`) VALUES
('11/6/2016','10:21 AM','Saved patient Medical Dagnosis'),
('11/6/2016','10:21 AM','Added Bill to patient bills'),
('11/6/2016','7:40 PM','Derrick Lamar Registered '),
('11/6/2016','7:42 PM','Added Bill to patient bills'),
('11/6/2016','7:42 PM','Saved patient Medical Dagnosis'),
('11/7/2016','9:50 AM','Sharon Registered '),
('11/7/2016','10:31 AM','JohnDenver  Medical Dagnosis Recorded '),
('11/7/2016','10:32 AM','FelixKiprono Has a balance of-40'),
('11/7/2016','10:32 AM','FelixKiprono Billed'),
('11/8/2016','11:12 AM','FelixKiprono Attendance Recorded'),
('11/10/2016','4:07 PM','James Registered '),
('11/10/2016','4:13 PM','James Billed onConsultation'),
('11/10/2016','4:13 PM','James  Medical Dagnosis Recorded '),
('11/10/2016','4:19 PM','James Has a balance of-637'),
('11/10/2016','7:51 PM','josphat mbugua Registered '),
('11/10/2016','7:55 PM','josphat mbugua Billed'),
('11/16/2016','3:52 PM','Alan James Attendance Recorded'),
('11/16/2016','3:55 PM','CYNTHIA JEMUTAI  Medical Dagnosis Recorded '),
('11/16/2016','3:55 PM','CYNTHIA JEMUTAI Billed onBook'),
('11/16/2016','4:16 PM','CYNTHIA JEMUTAI Has a balance of-25'),
('11/24/2016','2:00 PM','Warui Symon Registered '),
('11/24/2016','2:11 PM','Warui Symon  Medical Dagnosis Recorded '),
('11/24/2016','7:39 PM','FelixKiprono Attendance Recorded'),
('11/25/2016','6:29 PM','Felrin Husky Registered '),
('11/25/2016','6:36 PM','FelixKiprono Attendance Recorded'),
('11/27/2016','5:34 PM','kennedy kogei Attendance Recorded'),
('12/1/2016','10:24 AM','JohnDenver  Lab Dagnosis Tests Recorded '),
('12/5/2016','1:12 PM','FelixKiprono Attendance Recorded'),
('12/15/2016','7:30 PM','FelixKiprono Attendance Recorded'),
('12/15/2016','7:32 PM','FelixKiprono  Lab Dagnosis Tests Recorded ');
/*!40000 ALTER TABLE `auditlog` ENABLE KEYS */;

-- 
-- Definition of consultation
-- 

DROP TABLE IF EXISTS `consultation`;
CREATE TABLE IF NOT EXISTS `consultation` (
  `ID` int(100) NOT NULL AUTO_INCREMENT,
  `PNumber` varchar(100) NOT NULL,
  `FullNames` varchar(100) NOT NULL,
  `Gender` varchar(100) NOT NULL,
  `Date` varchar(100) NOT NULL,
  `Amount` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table consultation
-- 

/*!40000 ALTER TABLE `consultation` DISABLE KEYS */;
INSERT INTO `consultation`(`ID`,`PNumber`,`FullNames`,`Gender`,`Date`,`Amount`) VALUES
(1,'P12','FelixKiprono','Male','','100'),
(2,'P12','FelixKiprono','Male','','400'),
(3,'P14','Jane Wamboi','Female','Monday, October 17, 2016','150'),
(4,'','Kenny Rogers','Male','10/29/2016','100'),
(5,'','Charlie Pride','Male','10/29/2016','2000'),
(6,'7810','Sally Koskei','Female','10/29/2016','500'),
(7,'12','Jessy James','Female','11/3/2016','540'),
(8,'P15','Judy Koech','Female','11/5/2016','700'),
(9,'PNO197','FelixKiprono','Male','11/5/2016','200'),
(10,'PNO131','Derrick Lamar','Male','11/6/2016','0'),
(11,'PNO197','Sharon','Female','11/7/2016','500'),
(12,'PNO442','FelixKiprono','Male','11/8/2016','500'),
(13,'PNO358','James','Male','11/10/2016','500'),
(14,'PNO232','josphat mbugua','Male','11/10/2016','60'),
(15,'PNO198','Alan James','Male','11/16/2016','0'),
(16,'PNO490','kennedy kogei','Male','11/27/2016','300'),
(17,'PNO464','FelixKiprono','Male','12/5/2016','1000'),
(18,'PNO425','FelixKiprono','Male','12/15/2016','800');
/*!40000 ALTER TABLE `consultation` ENABLE KEYS */;

-- 
-- Definition of debt
-- 

DROP TABLE IF EXISTS `debt`;
CREATE TABLE IF NOT EXISTS `debt` (
  `Date` varchar(100) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Mobile` text NOT NULL,
  `Residence` text NOT NULL,
  `Total` text NOT NULL,
  `Paid` text NOT NULL,
  `Balance` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table debt
-- 

/*!40000 ALTER TABLE `debt` DISABLE KEYS */;
INSERT INTO `debt`(`Date`,`Name`,`Mobile`,`Residence`,`Total`,`Paid`,`Balance`) VALUES
('Friday, October 21, 2016','KennedyKogei','0712220569','Nakuru','570','500','10'),
('Friday, October 21, 2016','Felixkiprono','0700828948','Solian','60','50','0'),
('Monday, October 24, 2016','','','','60','10','50'),
('Monday, October 24, 2016','John Denver','07100265324','Kericho','300','250','50'),
('10/24/2016','Alan Jackson','0711021456','Narok','15','10','0'),
('10/28/2016','Felixkiprono','0700828948','Solian','181','100','81'),
('11/10/2016','James','07024569877','Ngata','737','100','637');
/*!40000 ALTER TABLE `debt` ENABLE KEYS */;

-- 
-- Definition of department
-- 

DROP TABLE IF EXISTS `department`;
CREATE TABLE IF NOT EXISTS `department` (
  `ID` int(100) NOT NULL AUTO_INCREMENT,
  `Name` text NOT NULL,
  `Categories` varchar(100) NOT NULL,
  `Head` text NOT NULL,
  `Services` varchar(500) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table department
-- 

/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department`(`ID`,`Name`,`Categories`,`Head`,`Services`) VALUES
(1,'Dentists','Teeth Cleaning','Kennedy Kogei ','Cleaning teeth'),
(2,'Eye surgery','Surgery','Felix Odhiambo','Cheking of eyes'),
(3,'Consultation','Consultation','Mr James','Consultancy '),
(4,'Pharmacy','Medicine','Mr john','Selling medicine'),
(6,'MRI','MRI Scanns','Mr Denver','Scanning MRI'),
(7,'Laboratory','Lab','','Testing blood,saliva and others'),
(8,'Surgery','Surgery','mr k','brain surgery');
/*!40000 ALTER TABLE `department` ENABLE KEYS */;

-- 
-- Definition of doctors
-- 

DROP TABLE IF EXISTS `doctors`;
CREATE TABLE IF NOT EXISTS `doctors` (
  `ID` int(100) NOT NULL AUTO_INCREMENT,
  `FullNames` varchar(100) NOT NULL,
  `Specialization` varchar(100) NOT NULL,
  `Location` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table doctors
-- 

/*!40000 ALTER TABLE `doctors` DISABLE KEYS */;
INSERT INTO `doctors`(`ID`,`FullNames`,`Specialization`,`Location`) VALUES
(1,'John Koech','Eye surgeon','Nakuru');
/*!40000 ALTER TABLE `doctors` ENABLE KEYS */;

-- 
-- Definition of hospital_profile
-- 

DROP TABLE IF EXISTS `hospital_profile`;
CREATE TABLE IF NOT EXISTS `hospital_profile` (
  `Name` varchar(100) NOT NULL,
  `Location` varchar(100) NOT NULL,
  `Telephone` varchar(100) NOT NULL,
  `KRA` varchar(100) NOT NULL,
  `Owner` varchar(100) NOT NULL,
  `Image` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table hospital_profile
-- 

/*!40000 ALTER TABLE `hospital_profile` DISABLE KEYS */;
INSERT INTO `hospital_profile`(`Name`,`Location`,`Telephone`,`KRA`,`Owner`,`Image`) VALUES
('ST ELIZABETH ','NAKURU','0719279023','P1E23131412','Mr Kago','');
/*!40000 ALTER TABLE `hospital_profile` ENABLE KEYS */;

-- 
-- Definition of hospital_staff
-- 

DROP TABLE IF EXISTS `hospital_staff`;
CREATE TABLE IF NOT EXISTS `hospital_staff` (
  `Name` text NOT NULL,
  `Telephone` text NOT NULL,
  `Position` text NOT NULL,
  `Residence` text NOT NULL,
  `Salary` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table hospital_staff
-- 

/*!40000 ALTER TABLE `hospital_staff` DISABLE KEYS */;
INSERT INTO `hospital_staff`(`Name`,`Telephone`,`Position`,`Residence`,`Salary`) VALUES
('Dr. Felix','100','Nakuru','Doctor','N/A'),
('','','N/A','N/A','N/A'),
('Dr. Sam','100','N/A','N/A','N/A');
/*!40000 ALTER TABLE `hospital_staff` ENABLE KEYS */;

-- 
-- Definition of labtests
-- 

DROP TABLE IF EXISTS `labtests`;
CREATE TABLE IF NOT EXISTS `labtests` (
  `Name` varchar(100) DEFAULT NULL,
  `Requirements` varchar(100) DEFAULT NULL,
  `Other` varchar(100) DEFAULT NULL,
  `Room` varchar(100) DEFAULT NULL,
  `Charges` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table labtests
-- 

/*!40000 ALTER TABLE `labtests` DISABLE KEYS */;
INSERT INTO `labtests`(`Name`,`Requirements`,`Other`,`Room`,`Charges`) VALUES
('Malaria','Fever,Pain in Joints','Null','Room 4','120'),
('Typhoid','Fever,Pain in Joints','Null','Room 4','120'),
('B/S FOR MALARIA','','','','100'),
('WIDAL TEST','','','','100'),
('VDRL','','','','100'),
('HIV','','','','100');
/*!40000 ALTER TABLE `labtests` ENABLE KEYS */;

-- 
-- Definition of login
-- 

DROP TABLE IF EXISTS `login`;
CREATE TABLE IF NOT EXISTS `login` (
  `ID` int(100) NOT NULL AUTO_INCREMENT,
  `Username` varchar(100) NOT NULL,
  `Role` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table login
-- 

/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login`(`ID`,`Username`,`Role`,`Password`) VALUES
(1,'admin','Admin','admin'),
(2,'Denis','Pharmacy','1234'),
(3,'Felix','Doctor','1245'),
(4,'peterson','Admin','1234'),
(5,'pharmacy','Pharmacy','1234');
/*!40000 ALTER TABLE `login` ENABLE KEYS */;

-- 
-- Definition of patient
-- 

DROP TABLE IF EXISTS `patient`;
CREATE TABLE IF NOT EXISTS `patient` (
  `ID` int(100) NOT NULL AUTO_INCREMENT,
  `PNumber` text NOT NULL,
  `Date` varchar(100) NOT NULL,
  `FullName` varchar(100) NOT NULL,
  `Age` varchar(100) NOT NULL,
  `Gender` varchar(100) NOT NULL,
  `IDNumber` varchar(100) NOT NULL,
  `PhoneNumber` varchar(100) NOT NULL,
  `Occupation` varchar(100) NOT NULL,
  `Residence` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table patient
-- 

/*!40000 ALTER TABLE `patient` DISABLE KEYS */;
INSERT INTO `patient`(`ID`,`PNumber`,`Date`,`FullName`,`Age`,`Gender`,`IDNumber`,`PhoneNumber`,`Occupation`,`Residence`) VALUES
(2,'P12','Thursday, October 13, 2016','FelixKiprono','21','Male','32128106','0700828948','ICT','Eldama Ravine'),
(8,'P13','Thursday, October 13, 2016','Kennedy Kogei','20','Male','45151012','0732542012','Programmer','Eldoret'),
(9,'P132','Thursday, October 13, 2016','JohnDenver','24','Male','1231','0700111444','Singer','Colorado'),
(10,'P14','Monday, October 17, 2016','Jane Wamboi','21','Female','32128109','0720044639','Teacher','Nakuru'),
(11,'P15','Monday, October 17, 2016','Judy Koech','19','Female','32128105','07764258410','Nurse','Nakuru'),
(12,'5000','Wednesday, October 19, 2016','kennedy kogei','20','Male','32470184','0712220569','N/A','N/A'),
(13,'P32','Wednesday, October 19, 2016','ALAN JOHNS','20','Male','32129839','0784962000','N/A','N/A'),
(14,'P10','Wednesday, October 19, 2016','Caroline Kapkomoi','20','Female','32120100','0711456850','Teacher','Esageri'),
(15,'P','Thursday, October 20, 2016','Joash Mathews','32','Male','12410854','0712504218','Proffesor','Los Angeles'),
(16,'P21','Friday, October 21, 2016','Don williams','56','Male','32120190','0720152354','Country Music Singer','Tuscon Arizona'),
(17,'P45','Friday, October 21, 2016','Randy Travis','52','Male','32102000','0788457120','Singer/Actor','Ohio Texas'),
(18,'P90','Friday, October 21, 2016','Billy sanford','45','Male','32129812','5040','Programmer','Oklahoma'),
(19,'P89','Friday, October 21, 2016','Elias Tenai','23','Male','12098789','100','Driver','Kabarnet'),
(20,'P4722','Sunday, October 23, 2016','Barnabas Junior','34','Male','129034123','0711232000','Manager','Kericho'),
(21,'7122205696','Sunday, October 23, 2016','CYNTHIA JEMUTAI','65','Female','712220569','0712220569','Teacher','Nairobi'),
(22,'8080','Wednesday, October 26, 2016','Alan James','25','Male','1680254','0712451012','Doctor','Nairobi'),
(23,'320','Wednesday, October 26, 2016','MAMA TUPAC','20','Female','32470185','0712220569','N/A','N/A'),
(24,'33025','10/29/2016','Samuel Sambili','22','Male','321204656','0728245321','Bussiness Man','Nyahururu'),
(25,'785','10/29/2016','Kenny Rogers','68','Male','12000254','+145298720','Country Music Singer','New jersy'),
(26,'451','10/29/2016','Charlie Pride','52','Male','12098321','0712321456','Base Ball Player','Oklahoma'),
(27,'7810','10/29/2016','Sally Koskei','25','Female','32120654','0752123654','Teacher','Rongai'),
(28,'12','11/3/2016','Jessy James','32','Female','12000987','0700825412','Coder','Uta'),
(29,'PNO131','11/6/2016','Derrick Lamar','6','Male','3212909','0700828120','Student','Eldoret'),
(30,'PNO197','11/7/2016','Sharon','6','Female','321525515','200','Doctor','Nyahuru'),
(31,'PNO358','11/10/2016','James','27','Male','12345678','07201215452','Driver','Ngata'),
(32,'PNO232','11/10/2016','josphat mbugua','22','Male','30353824','0728872636','farmer','olk'),
(33,'PNO110','11/24/2016','Warui Symon','57','Male','0012000','0722885756','N/A','N/A'),
(34,'PNO480','11/25/2016','Felrin Husky','26','Male','1209812','0712098789','Doctor ','Nanyuki');
/*!40000 ALTER TABLE `patient` ENABLE KEYS */;

-- 
-- Definition of patient_admission
-- 

DROP TABLE IF EXISTS `patient_admission`;
CREATE TABLE IF NOT EXISTS `patient_admission` (
  `ID` int(100) NOT NULL AUTO_INCREMENT,
  `PNumber` text NOT NULL,
  `Date` varchar(100) NOT NULL,
  `FullName` varchar(100) NOT NULL,
  `Age` varchar(100) NOT NULL,
  `Gender` varchar(100) NOT NULL,
  `IDNumber` varchar(100) NOT NULL,
  `PhoneNumber` varchar(100) NOT NULL,
  `Occupation` varchar(100) NOT NULL,
  `Residence` varchar(100) NOT NULL,
  `AdmissionDate` varchar(100) NOT NULL,
  `Timein` varchar(100) NOT NULL,
  `Dateout` varchar(100) NOT NULL,
  `Timeout` varchar(100) NOT NULL,
  `BedNo` varchar(100) NOT NULL,
  `Gurdian` varchar(100) NOT NULL,
  `Notes` varchar(100) NOT NULL,
  `Charges` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table patient_admission
-- 

/*!40000 ALTER TABLE `patient_admission` DISABLE KEYS */;
INSERT INTO `patient_admission`(`ID`,`PNumber`,`Date`,`FullName`,`Age`,`Gender`,`IDNumber`,`PhoneNumber`,`Occupation`,`Residence`,`AdmissionDate`,`Timein`,`Dateout`,`Timeout`,`BedNo`,`Gurdian`,`Notes`,`Charges`) VALUES
(1,'P12','11/9/2016','FelixKiprono','21','Male','32128106','0700828948','ICT','Eldama Ravine','1500','8:49:46 PM','11/9/2016','8:49:46 PM','01','John','For medication','1500');
/*!40000 ALTER TABLE `patient_admission` ENABLE KEYS */;

-- 
-- Definition of patient_billing
-- 

DROP TABLE IF EXISTS `patient_billing`;
CREATE TABLE IF NOT EXISTS `patient_billing` (
  `ID` int(100) NOT NULL AUTO_INCREMENT,
  `PatientID` varchar(100) NOT NULL,
  `PatientName` varchar(100) NOT NULL,
  `Date` varchar(100) NOT NULL,
  `PrescriptionTotal` varchar(100) NOT NULL,
  `HospitalCharges` varchar(100) NOT NULL,
  `OtherCharges` varchar(100) NOT NULL,
  `Summary` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table patient_billing
-- 

/*!40000 ALTER TABLE `patient_billing` DISABLE KEYS */;
INSERT INTO `patient_billing`(`ID`,`PatientID`,`PatientName`,`Date`,`PrescriptionTotal`,`HospitalCharges`,`OtherCharges`,`Summary`) VALUES
(2,'8080','Alan James','10/28/2016','180','50','150','380'),
(3,'8080','Alan James','10/29/2016','15','100','0','2615'),
(4,'P13','Kennedy Kogei','10/28/2016','171','250','0','621'),
(5,'P12','FelixKiprono','10/29/2016','15','0','0','50'),
(6,'P12','FelixKiprono','11/5/2016','60','100','0','210'),
(7,'P12','FelixKiprono','11/5/2016','100','0','0','100'),
(8,'P12','FelixKiprono','11/7/2016','60','0','0','60'),
(9,'PNO232','josphat mbugua','11/10/2016','75','0','0','75');
/*!40000 ALTER TABLE `patient_billing` ENABLE KEYS */;

-- 
-- Definition of patient_history_visit
-- 

DROP TABLE IF EXISTS `patient_history_visit`;
CREATE TABLE IF NOT EXISTS `patient_history_visit` (
  `PNumber` varchar(100) NOT NULL,
  `PatientName` varchar(100) NOT NULL,
  `Gender` varchar(100) NOT NULL,
  `Date` varchar(120) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table patient_history_visit
-- 

/*!40000 ALTER TABLE `patient_history_visit` DISABLE KEYS */;
INSERT INTO `patient_history_visit`(`PNumber`,`PatientName`,`Gender`,`Date`) VALUES
('33025','Samuel Sambili','Male','10/29/2016'),
('P12','FelixKiprono','Male','10/29/2016'),
('P12','FelixKiprono','Male','10/29/2016'),
('P12','FelixKipronO','Male','10/29/2016'),
('12','Jessy James','Female','11/3/2016'),
('P15','Judy Koech','Female','11/5/2016'),
('P15','Judy Koech','Female','11/5/2016'),
('PNO197','FelixKiprono','Male','11/5/2016'),
('PNO131','Derrick Lamar','Male','11/6/2016'),
('PNO197','Sharon','Female','11/7/2016'),
('PNO442','FelixKiprono','Male','11/8/2016'),
('PNO358','James','Male','11/10/2016'),
('PNO232','josphat mbugua','Male','11/10/2016'),
('PNO198','Alan James','Male','11/16/2016'),
('PNO110','Warui Symon','Male','11/24/2016'),
('PNO472','FelixKiprono','Male','11/24/2016'),
('PNO480','Felrin Husky','Male','11/25/2016'),
('PNO212','FelixKiprono','Male','11/25/2016'),
('PNO490','kennedy kogei','Male','11/27/2016'),
('PNO464','FelixKiprono','Male','12/5/2016'),
('PNO425','FelixKiprono','Male','12/15/2016');
/*!40000 ALTER TABLE `patient_history_visit` ENABLE KEYS */;

-- 
-- Definition of patient_lab_diagnosis
-- 

DROP TABLE IF EXISTS `patient_lab_diagnosis`;
CREATE TABLE IF NOT EXISTS `patient_lab_diagnosis` (
  `ID` int(50) NOT NULL AUTO_INCREMENT,
  `Room` varchar(100) NOT NULL,
  `PNumber` varchar(100) NOT NULL,
  `FullNames` varchar(100) NOT NULL,
  `Gender` varchar(100) NOT NULL,
  `Age` varchar(100) NOT NULL,
  `Date` varchar(100) NOT NULL,
  `LabResults` varchar(900) NOT NULL,
  `Doctor` varchar(100) NOT NULL,
  `TotalCharges` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table patient_lab_diagnosis
-- 

/*!40000 ALTER TABLE `patient_lab_diagnosis` DISABLE KEYS */;
INSERT INTO `patient_lab_diagnosis`(`ID`,`Room`,`PNumber`,`FullNames`,`Gender`,`Age`,`Date`,`LabResults`,`Doctor`,`TotalCharges`) VALUES
(1,'Laboratory','P132','JohnDenver','Male','24','12/1/2016','Malaria + 050\r\nTyphoid -100\r\n\r\nfound the two bacteria','Select Here','240'),
(2,'Laboratory','P12','FelixKiprono','Male','21','12/15/2016','gfytuhjkljiuyhgtre4w34retyghjk','Select Here','200');
/*!40000 ALTER TABLE `patient_lab_diagnosis` ENABLE KEYS */;

-- 
-- Definition of patient_lab_test
-- 

DROP TABLE IF EXISTS `patient_lab_test`;
CREATE TABLE IF NOT EXISTS `patient_lab_test` (
  `PatientID` varchar(100) NOT NULL,
  `PatientName` varchar(100) NOT NULL,
  `Date` varchar(100) NOT NULL,
  `TestName` varchar(100) NOT NULL,
  `Charges` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table patient_lab_test
-- 

/*!40000 ALTER TABLE `patient_lab_test` DISABLE KEYS */;
INSERT INTO `patient_lab_test`(`PatientID`,`PatientName`,`Date`,`TestName`,`Charges`) VALUES
('P132','JohnDenver','11/30/2016','Malaria','120'),
('P132','JohnDenver','11/30/2016','Typhoid','120'),
('P14','Jane Wamboi','12/1/2016','Malaria','120'),
('P14','Jane Wamboi','12/1/2016','Malaria','120'),
('P14','Jane Wamboi','12/1/2016','Typhoid','120'),
('P14','Jane Wamboi','12/5/2016','B/S FOR MALARIA','100'),
('P14','Jane Wamboi','12/5/2016','WIDAL TEST','100'),
('P14','Jane Wamboi','12/5/2016','Typhoid','120'),
('P12','FelixKiprono','12/15/2016','B/S FOR MALARIA','100'),
('P12','FelixKiprono','12/15/2016','WIDAL TEST','100');
/*!40000 ALTER TABLE `patient_lab_test` ENABLE KEYS */;

-- 
-- Definition of patient_medical_diagnosis
-- 

DROP TABLE IF EXISTS `patient_medical_diagnosis`;
CREATE TABLE IF NOT EXISTS `patient_medical_diagnosis` (
  `ID` int(50) NOT NULL AUTO_INCREMENT,
  `Room` varchar(100) NOT NULL,
  `PNumber` varchar(100) NOT NULL,
  `FullNames` varchar(100) NOT NULL,
  `Gender` varchar(100) NOT NULL,
  `Age` varchar(100) NOT NULL,
  `Date` varchar(100) NOT NULL,
  `RoomResults` varchar(900) NOT NULL,
  `Remarks` varchar(500) NOT NULL,
  `Doctor` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table patient_medical_diagnosis
-- 

/*!40000 ALTER TABLE `patient_medical_diagnosis` DISABLE KEYS */;
INSERT INTO `patient_medical_diagnosis`(`ID`,`Room`,`PNumber`,`FullNames`,`Gender`,`Age`,`Date`,`RoomResults`,`Remarks`,`Doctor`) VALUES
(1,'Consultation','8080','Alan James','Male','25','10/26/2016','pain in Joints and poor apetite','Take alot of fruits \r\nBlood test should be done',''),
(2,'Pharmacy','8080','Alan James','Male','25','10/26/2016','Malaria Present\r\nTyphoid present\r\n','Patient Should use alot of water and avoid sugary drinks',''),
(3,'Consultation','320','MAMA TUPAC','Female','20','10/26/2016','Test Urine','',''),
(4,'Laboratory','320','MAMA TUPAC','Female','20','10/26/2016','Has alot of Chemotherapy\r\nHas fungi in nails\r\n','Requires the Gym',''),
(5,'Eye surgery','P89','Elias Tenai','Male','23','10/26/2016','Short sighted','',''),
(6,'Pharmacy','P12','FelixKiprono','Male','21','10/27/2016','Fever and cold','Need painkillers',''),
(7,'Consultation','P12','FelixKiprono','Male','21','10/28/2016','Headaches and alot of fever a night\r\nCold Legs','Use painkillers and Drink alot of water\r\nPrescribe panadol,Piriton and Phansita',''),
(8,'Dentists','8080','Alan James','Male','25','10/28/2016','Tootache pains\r\nalot of sensitivity\r\n','Prescribe sensodyme',''),
(9,'Consultation','P13','Kennedy Kogei','Male','20','10/28/2016','fever and cold\r\nFrequent Headaches\r\nJoint pains','Test for Malaria',''),
(10,'Laboratory','P13','Kennedy Kogei','Male','20','10/28/2016','Malaria  + 78\r\nTyphoid + 56','Prescribe Panadol,Metakelvin and Amoxyl',''),
(11,'Consultation','P12','FelixKiprono','Male','21','10/29/2016','Headaches and Fever at night','Prescribe Panadol and Aspirin',''),
(12,'Dentists','33025','Samuel Sambili','Male','22','11/1/2016','gbhtt','rgsr',''),
(13,'Pharmacy','P89','Elias Tenai','Male','23','11/2/2016','nfkjs','',''),
(14,'Consultation','P12','FelixKiprono','Male','21','11/5/2016','Frequent Headaches\r\nPain in joints\r\nStress\r\n','Recomend Pain Killers\r\nHedex and alot of water',''),
(15,'Laboratory','P12','FelixKiprono','Male','21','11/5/2016','Malaria  - Ve\r\nTyphoid -Ve\r\nMiagrenes','Recomend Betaphine,Sona Moja and Rest',''),
(16,'Dentists','P12','FelixKiprono','Male','21','11/5/2016','Tooth filling and cleaning','Dont use teeth in opening bottles ',''),
(17,'Dentists','33025','Samuel Sambili','Male','22','11/6/2016','headaches','Recomend Alot of water',''),
(18,'Pharmacy','33025','Samuel Sambili','Male','22','11/6/2016','Give Maramoja,Sona Moja and Betaphine','Recomend Water',''),
(19,'Consultation','PNO131','Derrick Lamar','Male','6','11/6/2016','Some fever at night \r\n','just rest',''),
(20,'Consultation','P132','JohnDenver','Male','24','11/7/2016','hedachendksdfnfksfjd','fwsfersgfwr',''),
(21,'Consultation','PNO358','James','Male','27','11/10/2016','Fever,....','Null',''),
(22,'Consultation','7122205696','CYNTHIA JEMUTAI','Female','65','11/16/2016','Fever headache vomiting, loss of apetite \r\n','Recoments',''),
(23,'Consultation','PNO110','Warui Symon','Male','57','11/24/2016','Dx; Malaria\r\nInv: Bs mps; FHG; Stool OC','','');
/*!40000 ALTER TABLE `patient_medical_diagnosis` ENABLE KEYS */;

-- 
-- Definition of patient_other_bills
-- 

DROP TABLE IF EXISTS `patient_other_bills`;
CREATE TABLE IF NOT EXISTS `patient_other_bills` (
  `PNumber` varchar(100) NOT NULL,
  `FullNames` varchar(100) NOT NULL,
  `Department` varchar(100) NOT NULL,
  `BillName` text NOT NULL,
  `Date` varchar(100) NOT NULL,
  `Quantity` varchar(100) NOT NULL,
  `Total` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table patient_other_bills
-- 

/*!40000 ALTER TABLE `patient_other_bills` DISABLE KEYS */;
INSERT INTO `patient_other_bills`(`PNumber`,`FullNames`,`Department`,`BillName`,`Date`,`Quantity`,`Total`) VALUES
('P13','Kennedy Kogei','Consultation','Swochei','10/23/2016','1','500'),
('P89','Elias Tenai','Eye surgery','Glasses','10/26/2016','1','4500'),
('320','MAMA TUPAC','Laboratory','Lab Fungi test','10/26/2016','1','1000'),
('P89','Elias Tenai','Eye sugery','Eye glasses','10/26/2016','1','2400'),
('8080','Alan James','Dentists','Teeth washing','10/28/2016','1','2500'),
('P13','Kennedy Kogei','Laboratory','Lab Test','10/28/2016','1','150'),
('33025','Samuel Sambili','Dentists','tooth removal','11/1/2016','1','450'),
('33025','Samuel Sambili','Dentists','MX','11/2/2016','1','100'),
('33025','Samuel Sambili','Dentists','MX','11/2/2016','1','100'),
('P132','JohnDenver','Consultation','Book2','11/6/2016','@2','150'),
('P132','JohnDenver','Consultation','Book22','11/6/2016','@2','150'),
('33025','Samuel Sambili','Dentists','Book','11/6/2016','@1','200'),
('33025','Samuel Sambili','Pharmacy','Water','11/6/2016','1','65'),
('PNO131','Derrick Lamar','Consultation','Book','11/6/2016','1','25'),
('PNO358','James','Consultation','Consultation','11/10/2016','1','200'),
('7122205696','CYNTHIA JEMUTAI','Consultation','Book','11/16/2016','1','50');
/*!40000 ALTER TABLE `patient_other_bills` ENABLE KEYS */;

-- 
-- Definition of patient_prescription
-- 

DROP TABLE IF EXISTS `patient_prescription`;
CREATE TABLE IF NOT EXISTS `patient_prescription` (
  `ID` int(50) NOT NULL AUTO_INCREMENT,
  `Date` varchar(100) NOT NULL,
  `PNumber` varchar(100) NOT NULL,
  `FullNames` varchar(100) NOT NULL,
  `Drug` varchar(100) NOT NULL,
  `Quantity` varchar(100) NOT NULL,
  `Prescription` varchar(100) NOT NULL,
  `Price` varchar(100) NOT NULL,
  `Total` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table patient_prescription
-- 

/*!40000 ALTER TABLE `patient_prescription` DISABLE KEYS */;
INSERT INTO `patient_prescription`(`ID`,`Date`,`PNumber`,`FullNames`,`Drug`,`Quantity`,`Prescription`,`Price`,`Total`) VALUES
(1,'10/28/2016','P12','FelixKiprono','MARA MOJA','1','1x1','15','15'),
(2,'10/28/2016','P12','FelixKiprono','Aspirin','1','1x1','15','15'),
(3,'10/28/2016','P12','FelixKiprono','Dawanol','1','1x1','100','100'),
(4,'10/28/2016','P12','FelixKiprono','Amoxyl','1','1x1','6','6'),
(5,'10/28/2016','8080','Alan James','Sona Moja','1','1x1','15','15'),
(6,'10/28/2016','P13','Kennedy Kogei','Metakelvin','1','1x1','150','150'),
(7,'10/28/2016','P13','Kennedy Kogei','Amoxyl','1','1x1','6','6'),
(8,'10/28/2016','P13','Kennedy Kogei','Sona Moja','1','1x1','15','15'),
(9,'10/29/2016','P12','FelixKiprono','Sona Moja','1','1x1','15','15'),
(10,'11/1/2016','33025','Samuel Sambili','Aspirin','2','1x1','15','30'),
(11,'11/2/2016','P12','FelixKiprono','lucozide','1','1x1','60','60'),
(12,'11/2/2016','P12','FelixKiprono','Aspirin','1','1x1','15','15'),
(13,'11/2/2016','','','lucozide','1','1x1','60','60'),
(14,'11/2/2016','P89','Elias Tenai','lucozide','1','1x1','60','60'),
(15,'11/2/2016','P12','FelixKiprono','lucozide','2','1x1','60','120'),
(16,'11/5/2016','P12','FelixKiprono','lucozide','1','1x1','60','60'),
(17,'11/5/2016','P12','FelixKiprono','Betaphine','1','1x1','25','25'),
(18,'11/5/2016','P12','FelixKiprono','Sona Moja','1','1x1','15','15'),
(19,'11/7/2016','P12','FelixKiprono','lucozide','1','1x1','60','60'),
(20,'11/10/2016','PNO358','James','Amoxyl','2','1x1','6','12'),
(21,'11/10/2016','PNO358','James','Betaphine','1','1x1','25','25'),
(22,'11/10/2016','PNO232','josphat mbugua','lucozide','1','1x1','60','60'),
(23,'11/10/2016','PNO232','josphat mbugua','Aspirin','1','1x1','15','15'),
(24,'11/16/2016','7122205696','CYNTHIA JEMUTAI','Aspirin','5','1x1','15','75');
/*!40000 ALTER TABLE `patient_prescription` ENABLE KEYS */;

-- 
-- Definition of purchase_log
-- 

DROP TABLE IF EXISTS `purchase_log`;
CREATE TABLE IF NOT EXISTS `purchase_log` (
  `Date` varchar(100) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Quantity` varchar(100) NOT NULL,
  `Price` varchar(100) NOT NULL,
  `Total` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table purchase_log
-- 

/*!40000 ALTER TABLE `purchase_log` DISABLE KEYS */;
INSERT INTO `purchase_log`(`Date`,`Name`,`Quantity`,`Price`,`Total`) VALUES
('Friday, April 8, 2016','MARA MOJA','20','10','200'),
('Friday, April 8, 2016','HEDEX','3','15','45'),
('Friday, April 8, 2016','Dawanol','50','70','3500'),
('Friday, April 8, 2016','Sona Moja','150','10','1500'),
('Monday, October 17, 2016','Betaphine','50','20','1000'),
('Wednesday, October 19, 2016','Amoxyl','600','3','1800'),
('Wednesday, October 19, 2016','Aspirin','50','3','150'),
('Wednesday, October 19, 2016','Amoxyl','50','3','150'),
('Wednesday, October 26, 2016','Eye drop','50','145','7250'),
('10/28/2016','lucozide','100','50','5000'),
('11/16/2016','Aspirin','3','13','39'),
('11/16/2016','Aspirin','8','14','112');
/*!40000 ALTER TABLE `purchase_log` ENABLE KEYS */;

-- 
-- Definition of queue
-- 

DROP TABLE IF EXISTS `queue`;
CREATE TABLE IF NOT EXISTS `queue` (
  `ID` int(100) NOT NULL AUTO_INCREMENT,
  `PatientID` text NOT NULL,
  `FullNames` text NOT NULL,
  `Department` text NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=91 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table queue
-- 

/*!40000 ALTER TABLE `queue` DISABLE KEYS */;
INSERT INTO `queue`(`ID`,`PatientID`,`FullNames`,`Department`) VALUES
(4,'P21','Don williams','Laboratory'),
(71,'P132','JohnDenver','Pharmacy'),
(72,'P15','Judy Koech','Laboratory'),
(77,'PNO110','Warui Symon','Dentists'),
(78,'P13','Kennedy Kogei','Surgery'),
(79,'P32','ALAN JOHNS','Surgery'),
(80,'33025','Samuel Sambili','Laboratory'),
(83,'PNO131','Derrick Lamar','Laboratory'),
(87,'P14','Jane Wamboi','Pharmacy'),
(90,'P12','FelixKiprono','Pharmacy');
/*!40000 ALTER TABLE `queue` ENABLE KEYS */;

-- 
-- Definition of referform
-- 

DROP TABLE IF EXISTS `referform`;
CREATE TABLE IF NOT EXISTS `referform` (
  `FullNames` varchar(100) NOT NULL,
  `PNumber` varchar(100) NOT NULL,
  `Date` varchar(100) NOT NULL,
  `To` varchar(100) NOT NULL,
  `From` varchar(100) NOT NULL,
  `Reason` varchar(100) NOT NULL,
  `Doctor` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table referform
-- 

/*!40000 ALTER TABLE `referform` DISABLE KEYS */;
INSERT INTO `referform`(`FullNames`,`PNumber`,`Date`,`To`,`From`,`Reason`,`Doctor`) VALUES
('Solomon Johns Juniour','P121212','Thursday, October 20, 2016','Texas District Hospital','Oklahoma Dispensary','Due to critical problems','Dr Johanes Berg'),
('Solomon Johns Juniour','P1','Thursday, October 20, 2016','Texas District Hospital','Oklahoma Dispensary','Due to critical problems','Dr Johanes Berg'),
('Solomon Johns Juniour','P121212','Monday, October 24, 2016','Texas District Hospital','Oklahoma Dispensary','Due to critical problems','Dr Johanes Berg'),
('Solomon Johns Juniour','P121212','Sunday, October 23, 2016','Texas District Hospital','Oklahoma Dispensary','Due to critical problems','Dr Johanes Berg'),
('Solomon Johns Juniour','P121212','Tuesday, October 25, 2016','Texas District Hospital','Oklahoma Dispensary','Due to critical problems','Dr Johanes Berg'),
('Solomon Johns Juniour','P121212','Tuesday, November 1, 2016','Texas District Hospital','Oklahoma Dispensary','Due to critical problems','Dr Johanes Berg'),
('Solomon Johns Juniour','P121212','Thursday, November 3, 2016','Texas District Hospital','Oklahoma Dispensary','Due to critical problems','Dr Johanes Berg');
/*!40000 ALTER TABLE `referform` ENABLE KEYS */;

-- 
-- Definition of sales
-- 

DROP TABLE IF EXISTS `sales`;
CREATE TABLE IF NOT EXISTS `sales` (
  `Worker` text NOT NULL,
  `Date` text NOT NULL,
  `ItemName` text NOT NULL,
  `Quantity` text NOT NULL,
  `Price` text NOT NULL,
  `Total` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table sales
-- 

/*!40000 ALTER TABLE `sales` DISABLE KEYS */;
INSERT INTO `sales`(`Worker`,`Date`,`ItemName`,`Quantity`,`Price`,`Total`) VALUES
('','Monday, October 17, 2016','Marijuana','1','15000','15000'),
('','Monday, October 17, 2016','MARA MOJA','1','15','15'),
('','Monday, October 17, 2016','Sona Moja','1','15','15'),
('','Monday, October 17, 2016','MARA MOJA','1','15','15'),
('','Monday, October 17, 2016','Sona Moja','1','15','15'),
('','Monday, October 17, 2016','Aspirin','5','15','75'),
('','Wednesday, October 19, 2016','HEDEX','1','15','15'),
('','Wednesday, October 19, 2016','Metakelvin','2','200','400'),
('','Wednesday, October 19, 2016','Amoxyl','50','6','300'),
('','Wednesday, October 19, 2016','Amoxyl','50','6','300'),
('','Monday, October 24, 2016','lucozide','1','60','60'),
('','Monday, October 24, 2016','Amoxyl','50','6','300'),
('','Monday, October 24, 2016','Aspirin','1','15','15'),
('','10/26/2016','Marijuana','1','15000','15000'),
('','10/26/2016','Eye drop','1','200','200'),
('','10/26/2016','Marijuana','1','15000','15000'),
('','10/26/2016','Metakelvin','1','150','150'),
('','10/26/2016','Amoxyl','1','6','6'),
('','10/26/2016','Sona Moja','1','15','15'),
('','10/26/2016','HEDEX','1','15','15'),
('','10/26/2016','MARA MOJA','1','15','15'),
('','10/26/2016','Aspirin','1','15','15'),
('','10/26/2016','Aspirin','1','15','15'),
('','10/26/2016','Aspirin','1','15','15'),
('','10/26/2016','Aspirin','1','15','15'),
('','10/26/2016','Aspirin','1','15','15'),
('','10/26/2016','Aspirin','1','15','15'),
('','10/26/2016','Aspirin','1','15','15'),
('','10/26/2016','Aspirin','1','15','15'),
('','10/26/2016','Aspirin','1','15','15'),
('','10/28/2016','MARA MOJA','1','15','15'),
('','10/28/2016','HEDEX','1','15','15'),
('','10/28/2016','Metakelvin','2','150','300'),
('','10/29/2016','Betaphine','5','25','125'),
('','10/29/2016','Sona Moja','5','15','75'),
('','10/29/2016','Metakelvin','2','150','300'),
('','11/1/2016','Sona Moja','1','15','15'),
('','11/7/2016','Betaphine','1','25','25'),
('','11/7/2016','Eye drop','1','200','200'),
('','11/7/2016','Amoxyl','1','6','6'),
('','11/10/2016','Sona Moja','5','15','75'),
('','12/14/2016','HEDEX','5','15','75');
/*!40000 ALTER TABLE `sales` ENABLE KEYS */;

-- 
-- Definition of salessummary
-- 

DROP TABLE IF EXISTS `salessummary`;
CREATE TABLE IF NOT EXISTS `salessummary` (
  `Date` varchar(100) NOT NULL,
  `Amount` bigint(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table salessummary
-- 

/*!40000 ALTER TABLE `salessummary` DISABLE KEYS */;
INSERT INTO `salessummary`(`Date`,`Amount`) VALUES
('10/26/2016',38816),
('10/28/2016',4061),
('10/27/2016',25),
('10/29/2016',3115),
('11/5/2016',210),
('11/7/2016',60);
/*!40000 ALTER TABLE `salessummary` ENABLE KEYS */;

-- 
-- Definition of status
-- 

DROP TABLE IF EXISTS `status`;
CREATE TABLE IF NOT EXISTS `status` (
  `ID` int(50) NOT NULL AUTO_INCREMENT,
  `STATE` varchar(150) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table status
-- 

/*!40000 ALTER TABLE `status` DISABLE KEYS */;
INSERT INTO `status`(`ID`,`STATE`) VALUES
(1,'20-FC-F8-10-00-39-24-47-6C-7E-0C-C1-B2-39-3D-94');
/*!40000 ALTER TABLE `status` ENABLE KEYS */;

-- 
-- Definition of stock
-- 

DROP TABLE IF EXISTS `stock`;
CREATE TABLE IF NOT EXISTS `stock` (
  `ID` int(100) NOT NULL AUTO_INCREMENT,
  `Item Name` text NOT NULL,
  `Formulation` text NOT NULL,
  `Dosage` text NOT NULL,
  `Description` text NOT NULL,
  `Quantity` text NOT NULL,
  `Size` text NOT NULL,
  `PurchaseDate` text NOT NULL,
  `ManufactureDate` text NOT NULL,
  `ExpiryDate` text NOT NULL,
  `BuyingPrice` text NOT NULL,
  `SellingPrice` text NOT NULL,
  `Total` int(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table stock
-- 

/*!40000 ALTER TABLE `stock` DISABLE KEYS */;
INSERT INTO `stock`(`ID`,`Item Name`,`Formulation`,`Dosage`,`Description`,`Quantity`,`Size`,`PurchaseDate`,`ManufactureDate`,`ExpiryDate`,`BuyingPrice`,`SellingPrice`,`Total`) VALUES
(1,'MARA MOJA','Tablet','Null','pain killer','80','','31 March 2016','31 March 2016','31 March 2016','10','15',0),
(2,'HEDEX','Tablet','Null','Pain Killer','12','','31 March 2016','31 March 2016','31 March 2016','10','15',0),
(3,'lucozide','Syrup','null','description','76','','01 April 2016','01 April 2016','01 April 2016','50','60',0),
(6,'Aspirin','Tablet','null','Pain killer','68','','Thursday, April 7, 2016','Thursday, April 7, 2016','Thursday, April 7, 2016','12','15',2400),
(7,'Dawanol','Syrup','1','for flue','96','MiliMetres','Friday, April 8, 2016','Friday, April 8, 2016','Friday, April 8, 2016','80','100',4000),
(8,'Sona Moja','Tablet','2','Pain killer for extreme headache','110','MiliGrams','Friday, April 8, 2016','Friday, April 8, 2016','Friday, April 8, 2016','10','15',1500),
(9,'Metakelvin','Tablet','1x1','For malaria','84','default','Monday, October 17, 2016','Monday, October 17, 2016','Monday, October 17, 2016','100','150',10000),
(10,'Betaphine','Tablet','1 x 1','For headaches','39','Grams','Monday, October 17, 2016','Monday, October 17, 2016','Monday, October 17, 2016','20','25',1000),
(11,'Amoxyl','Capsules','3Times','n/a','472','MiliGrams','Wednesday, October 19, 2016','Wednesday, October 19, 2016','Wednesday, October 19, 2016','3','6',1800),
(12,'Eye drop','Liquid','1','Apply the drops in both eyes','31','MiliMetres','Wednesday, October 26, 2016','Wednesday, October 26, 2016','Wednesday, October 26, 2016','145','200',7250);
/*!40000 ALTER TABLE `stock` ENABLE KEYS */;

-- 
-- Definition of stockcounter
-- 

DROP TABLE IF EXISTS `stockcounter`;
CREATE TABLE IF NOT EXISTS `stockcounter` (
  `ID` int(11) DEFAULT NULL,
  `ItemName` mediumtext,
  `Quantity` mediumtext,
  `Type` mediumtext,
  `Status` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table stockcounter
-- 

/*!40000 ALTER TABLE `stockcounter` DISABLE KEYS */;
INSERT INTO `stockcounter`(`ID`,`ItemName`,`Quantity`,`Type`,`Status`) VALUES
(NULL,'Betaphine','50','Tablet','Optimum'),
(NULL,'Amoxyl','600','Capsules','Optimum'),
(NULL,'Eye drop','50','Liquid','Optimum');
/*!40000 ALTER TABLE `stockcounter` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2016-12-17 20:27:06
-- Total time: 0:0:0:0:467 (d:h:m:s:ms)
