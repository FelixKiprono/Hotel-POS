-- MySqlBackup.NET 2.0.9.2
-- Dump Time: 2017-03-08 10:07:58
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
-- Definition of account
-- 

DROP TABLE IF EXISTS `account`;
CREATE TABLE IF NOT EXISTS `account` (
  `AccountNumber` varchar(150) NOT NULL,
  `AccountName` varchar(150) NOT NULL,
  `Bank` varchar(150) NOT NULL,
  `DateOpened` varchar(150) NOT NULL,
  `Signitory` varchar(150) NOT NULL,
  `Accounttype` varchar(150) NOT NULL,
  `Amount` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table account
-- 

/*!40000 ALTER TABLE `account` DISABLE KEYS */;
INSERT INTO `account`(`AccountNumber`,`AccountName`,`Bank`,`DateOpened`,`Signitory`,`Accounttype`,`Amount`) VALUES
('12345','RAFIKI','CHASE BANK','12/17/2016','FILEX KIPRONO','Cooperate',551600),
('123321','SUNGURA','EQUITY','12/17/2016','Felix','Limited',1000),
('09123','WAKAWAKA','I&M BANK','12/17/2016','Samuel','Limited',90000);
/*!40000 ALTER TABLE `account` ENABLE KEYS */;

-- 
-- Definition of categories
-- 

DROP TABLE IF EXISTS `categories`;
CREATE TABLE IF NOT EXISTS `categories` (
  `CategoryName` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table categories
-- 

/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories`(`CategoryName`) VALUES
('Cereals'),
('Grains'),
('Vegetables'),
('Juices'),
('Bevarages');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;

-- 
-- Definition of itemcategories
-- 

DROP TABLE IF EXISTS `itemcategories`;
CREATE TABLE IF NOT EXISTS `itemcategories` (
  `ItemName` varchar(100) NOT NULL,
  `Image` mediumblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table itemcategories
-- 

/*!40000 ALTER TABLE `itemcategories` DISABLE KEYS */;
INSERT INTO `itemcategories`(`ItemName`,`Image`) VALUES
('BreakFast',''),
('Supper',''),
('Lunch',''),
('Dinner',''),
('Drinks',''),
('Snacks',''),
('Take Away Snacks',''),
('Bevarages','');
/*!40000 ALTER TABLE `itemcategories` ENABLE KEYS */;

-- 
-- Definition of itemsmenu
-- 

DROP TABLE IF EXISTS `itemsmenu`;
CREATE TABLE IF NOT EXISTS `itemsmenu` (
  `Name` varchar(150) NOT NULL,
  `Quantity` varchar(150) NOT NULL,
  `Price` varchar(150) NOT NULL,
  `Type` varchar(100) NOT NULL,
  `Details` varchar(150) NOT NULL,
  `Availability` varchar(100) NOT NULL,
  `Status` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table itemsmenu
-- 

/*!40000 ALTER TABLE `itemsmenu` DISABLE KEYS */;
INSERT INTO `itemsmenu`(`Name`,`Quantity`,`Price`,`Type`,`Details`,`Availability`,`Status`) VALUES
('Coffee','1','54','BreakFast','','Morning','Cooked'),
('Burger','1','200','Snacks','Also a take away snack','Everytime','UnCooked'),
('Coke','1','65','Drinks','','Everytime','Cooked'),
('Chapati','1','15','Snacks','Also a take away snack','Everytime','Cooked'),
('Cocktail','1','60','Drinks','Also a take away snack','Everytime','Cooked'),
('Wine','1','500','Drinks','','Everytime','Cooked'),
('Chips','1','100','Lunch','Also a take away snack','Everytime','Cooked'),
('Poridge','1','40','BreakFast','','Morning','Cooked'),
('Plain Pilau','1','180','Lunch','1 Plate','Noon','Cooked'),
('Ndazi','1','15','Take Away Snacks','','Everytime',''),
('Samosa','1','30','Take Away Snacks','','Everytime',''),
('Smokey','1','45','Take Away Snacks','','Everytime',''),
('Bun','1','45','Take Away Snacks','','Everytime',''),
('Egg','1','20','Take Away Snacks','','Everytime',''),
('Mahamri','1','30','Take Away Snacks','','Everytime',''),
('Wine','1','500','Drinks','','Everytime','');
/*!40000 ALTER TABLE `itemsmenu` ENABLE KEYS */;

-- 
-- Definition of login2
-- 

DROP TABLE IF EXISTS `login2`;
CREATE TABLE IF NOT EXISTS `login2` (
  `ID` int(100) NOT NULL AUTO_INCREMENT,
  `Username` varchar(100) NOT NULL,
  `Role` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table login2
-- 

/*!40000 ALTER TABLE `login2` DISABLE KEYS */;
INSERT INTO `login2`(`ID`,`Username`,`Role`,`Password`) VALUES
(1,'Admin','Admin','1234'),
(3,'Waiter','Waiter','1234'),
(6,'Kitchen','Kitchen','1234'),
(7,'Cashier','Cashier','1234');
/*!40000 ALTER TABLE `login2` ENABLE KEYS */;

-- 
-- Definition of mailmaster
-- 

DROP TABLE IF EXISTS `mailmaster`;
CREATE TABLE IF NOT EXISTS `mailmaster` (
  `To` varchar(100) NOT NULL,
  `From` varchar(100) NOT NULL,
  `Date` varchar(100) NOT NULL,
  `Subject` varchar(100) NOT NULL,
  `Message` varchar(900) NOT NULL,
  `Attachments` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table mailmaster
-- 

/*!40000 ALTER TABLE `mailmaster` DISABLE KEYS */;
INSERT INTO `mailmaster`(`To`,`From`,`Date`,`Subject`,`Message`,`Attachments`) VALUES
('infor@Manager.com','infor@admin.com','12/21/2016 1:55:21 PM','Sales Progress','This is the sales progress from sep to dec 2016\r\nby Admin Kagia',1);
/*!40000 ALTER TABLE `mailmaster` ENABLE KEYS */;

-- 
-- Definition of openingbalance
-- 

DROP TABLE IF EXISTS `openingbalance`;
CREATE TABLE IF NOT EXISTS `openingbalance` (
  `FullNames` varchar(100) NOT NULL,
  `Date` varchar(100) NOT NULL,
  `Amount` int(100) NOT NULL,
  `Status` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table openingbalance
-- 

/*!40000 ALTER TABLE `openingbalance` DISABLE KEYS */;
INSERT INTO `openingbalance`(`FullNames`,`Date`,`Amount`,`Status`) VALUES
('Samuel Maina','Tuesday, December 6, 2016',2000,''),
('KennedyKogei','12/6/2016',2000,'Cleared'),
('FelixKiprono','12/6/2016',1000,'Cleared'),
('ViginiaWambui','12/6/2016',1000,''),
('Samuel Maina','12/6/2016',1000,''),
('JudyShiro','12/6/2016',5000,''),
('KennedyKogei','12/7/2016',2000,'Cleared'),
('KennedyKogei','12/7/2016',2000,'Cleared'),
('KennedyKogei','12/7/2016',2000,'Cleared'),
('FelixKiprono','12/11/2016',1000,'Cleared'),
('ViginiaWambui','12/11/2016',2000,''),
('JudyShiro','12/11/2016',2000,''),
('MagdaleneKebut','12/11/2016',2000,''),
('KennedyKogei','12/11/2016',2000,'Cleared'),
('KennedyKogei','12/24/2016',2000,'Cleared'),
('FelixKiprono','12/24/2016',1000,'Cleared'),
('Samuel Maina','12/24/2016',1000,'Cleared'),
('JudyShiro','12/24/2016',4500,'Pending'),
('FelixKiprono','12/29/2016',1700,'Pending'),
('KennedyKogei','12/29/2016',1200,'Pending'),
('Samuel Maina','12/29/2016',1200,'Pending'),
('ViginiaWambui','12/29/2016',1200,'Pending'),
('JaneWanjiru','12/29/2016',1200,'Pending'),
('MichaelWatiko','12/29/2016',1200,'Pending'),
('JudyShiro','12/29/2016',1000,'Cleared'),
('MaryKiprop','12/29/2016',1200,'Pending'),
('MagdaleneKebut','12/29/2016',1200,'Pending'),
('MagdaleneKebut','1/3/2017',400,'Cleared'),
('ViginiaWambui','1/16/2017',700,'Cleared');
/*!40000 ALTER TABLE `openingbalance` ENABLE KEYS */;

-- 
-- Definition of orderinfor
-- 

DROP TABLE IF EXISTS `orderinfor`;
CREATE TABLE IF NOT EXISTS `orderinfor` (
  `OrderNumber` varchar(100) NOT NULL,
  `ItemName` varchar(100) NOT NULL,
  `Quantity` varchar(100) NOT NULL,
  `Price` varchar(100) NOT NULL,
  `Total` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table orderinfor
-- 

/*!40000 ALTER TABLE `orderinfor` DISABLE KEYS */;
INSERT INTO `orderinfor`(`OrderNumber`,`ItemName`,`Quantity`,`Price`,`Total`) VALUES
('47587','Burger','1','200','200'),
('47587','Chapati','2','50','100'),
('47587','Coffee','3','50','150'),
('46067','Plain Pilau','1','150','150'),
('46067','Chips','1','100','100'),
('25150','Poridge','1','40','40'),
('25150','Coffee','1','50','50'),
('48282','Chips','1','100','100'),
('48282','Plain Pilau','1','150','150'),
('48282','Chips','1','100','100'),
('39725','Chips','1','100','100'),
('39725','Plain Pilau','1','150','150'),
('15647','Poridge','1','40','40'),
('15647','Coffee','10','50','500'),
('15647','Chapati','2','50','100'),
('19312','Cocktail','1','50','50'),
('19312','Wine','1','550','550'),
('19312','Coke','2','50','100'),
('7573','Wine','5','550','2750'),
('30751','Poridge','2','40','80'),
('30751','Chapati','6','50','300'),
('19072','Coke','1','50','50'),
('19072','Wine','1','550','550'),
('10570','Wine','1','550','550'),
('1614','Coke','1','50','50'),
('11752','Coke','2','50','100'),
('33198','Coffee','1','50','50'),
('46134','Coffee','1','54','54'),
('33444','Cocktail','1','50','50'),
('33444','Coke','2','50','100'),
('47091','Cocktail','5','50','250'),
('47091','Plain Pilau','1','150','150'),
('9183','Chips','2','100','200'),
('9708','Chips','1','100','100'),
('15421','Plain Pilau','1','180','180'),
('1046','Coffee','2','54','108'),
('37907','Coke','1','65','65'),
('37907','Wine','1','500','500'),
('32768','Chapati','1','45','45'),
('32768','Wine','1','500','500'),
('32768','Poridge','1','40','40'),
('32768','Plain Pilau','1','180','180'),
('32768','Burger','1','200','200'),
('32768','Coke','1','65','65'),
('32768','Cocktail','1','50','50'),
('34232','Burger','1','200','200'),
('34232','Chapati','1','45','45'),
('25153','Chapati','1','45','45'),
('25153','Burger','1','200','200'),
('19058','Smokey','1','45','45'),
('19058','Egg','1','20','20'),
('19058','Ndazi','2','15','30'),
('19058','Mahamri','6','30','180'),
('5971','Wine','1','500','500'),
('5971','Cocktail','1','60','60'),
('9505','Coke','1','65','65'),
('9505','Chips','1','100','100'),
('38679','Coke','1','65','65'),
('38679','Chips','1','100','100'),
('48513','Coke','1','65','65'),
('48513','Chips','1','100','100'),
('37123','Burger','1','200','200'),
('37123','Chips','1','100','100'),
('2923','Coke','1','65','65'),
('2923','Cocktail','1','60','60'),
('22256','Poridge','4','40','160'),
('22256','Chapati','1','15','15'),
('30564','Poridge','2','40','80'),
('4932','Plain Pilau','1','180','180'),
('37561','Bun','1','45','45'),
('35472','Chips','1','100','100'),
('33727','Chapati','1','15','15'),
('45048','Chips','1','100','100'),
('17144','Samosa','1','30','30'),
('17144','Smokey','4','45','180'),
('17144','Egg','11','20','220'),
('4890','Chapati','4','15','60'),
('15509','Cocktail','1','60','60');
/*!40000 ALTER TABLE `orderinfor` ENABLE KEYS */;

-- 
-- Definition of orders
-- 

DROP TABLE IF EXISTS `orders`;
CREATE TABLE IF NOT EXISTS `orders` (
  `OrderNumber` int(100) NOT NULL,
  `Date` varchar(100) NOT NULL,
  `Status` varchar(100) NOT NULL,
  `Total` varchar(100) NOT NULL,
  `Waiter` varchar(100) NOT NULL,
  `TableNumber` varchar(100) NOT NULL,
  `OrderStatus` varchar(100) DEFAULT 'Not Seen',
  PRIMARY KEY (`OrderNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table orders
-- 

/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders`(`OrderNumber`,`Date`,`Status`,`Total`,`Waiter`,`TableNumber`,`OrderStatus`) VALUES
(4890,'08/03/2017','Open','60','Admin','','Not Seen'),
(4932,'1/22/2017','Open','180','','1','Not Seen'),
(15509,'08/03/2017','Open','60','Admin','1','Not Seen'),
(17144,'2/6/2017','Open','430','','','Not Seen'),
(33727,'1/22/2017','Closed','15','John Denver','2','Seen'),
(35472,'1/22/2017','Open','100','Admin','','Not Seen'),
(37561,'1/22/2017','Closed','45','Admin','','Seen'),
(45048,'1/23/2017','Open','100','Waiter','','Not Seen');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;

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
('12/11/2016','Maize','100','2500','250000'),
('12/12/2016','Potatoes','5','150','750'),
('12/12/2016','Rice','24','135','3240'),
('12/12/2016','Maize','7','2400','16800'),
('1/17/2017','Maize','85','8200','697000');
/*!40000 ALTER TABLE `purchase_log` ENABLE KEYS */;

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
('Admin','12/11/2016','Burger','1','200','200'),
('Admin','12/11/2016','Chapati','2','50','100'),
('Admin','12/11/2016','Coffee','3','50','150'),
('Felix','12/12/2016','Plain Pilau','1','150','150'),
('Felix','12/12/2016','Chips','1','100','100'),
('Admin','12/12/2016','Poridge','1','40','40'),
('Admin','12/12/2016','Coffee','1','50','50'),
('Admin','12/13/2016','Chips','1','100','100'),
('Admin','12/13/2016','Plain Pilau','1','150','150'),
('Admin','12/13/2016','Chips','1','100','100'),
('Admin','12/13/2016','Chips','1','100','100'),
('Admin','12/13/2016','Plain Pilau','1','150','150'),
('FelixKiprono','12/13/2016','Poridge','1','40','40'),
('FelixKiprono','12/13/2016','Coffee','10','50','500'),
('FelixKiprono','12/13/2016','Chapati','2','50','100'),
('Samuel Maina','12/13/2016','Wine','5','550','2750'),
('KennedyKogei','12/13/2016','Coke','1','50','50'),
('KennedyKogei','12/13/2016','Wine','1','550','550'),
('550','12/13/2016','Wine','1','550','550'),
('Samuel Maina','12/14/2016','Coke','2','50','100'),
('Samuel Maina','12/18/2016','Cocktail','1','50','50'),
('Samuel Maina','12/18/2016','Coke','2','50','100'),
('FelixKiprono','12/21/2016','Chips','2','100','200'),
('MaryKiprop','12/24/2016','Chips','1','100','100'),
('KennedyKogei','12/25/2016','Coffee','2','54','108'),
('ViginiaWambui','12/28/2016','Burger','1','200','200'),
('ViginiaWambui','12/28/2016','Chapati','1','45','45'),
('FelixKiprono','1/16/2017','Coke','1','65','65'),
('FelixKiprono','1/16/2017','Cocktail','1','60','60'),
('','1/16/2017','Poridge','4','40','160'),
('','1/16/2017','Chapati','1','15','15'),
('FelixKiprono','1/21/2017','Smokey','1','45','45'),
('FelixKiprono','1/21/2017','Egg','1','20','20'),
('FelixKiprono','1/21/2017','Ndazi','2','15','30'),
('FelixKiprono','1/21/2017','Mahamri','6','30','180'),
('FelixKiprono','1/21/2017','Poridge','2','40','80'),
('Admin','1/22/2017','Bun','1','45','45'),
('John Denver','1/22/2017','Chapati','1','15','15');
/*!40000 ALTER TABLE `sales` ENABLE KEYS */;

-- 
-- Definition of shift
-- 

DROP TABLE IF EXISTS `shift`;
CREATE TABLE IF NOT EXISTS `shift` (
  `IDNumber` varchar(100) NOT NULL,
  `FullNames` varchar(100) NOT NULL,
  `Date` varchar(100) NOT NULL,
  `StartTime` varchar(100) NOT NULL,
  `StopTime` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table shift
-- 

/*!40000 ALTER TABLE `shift` DISABLE KEYS */;
INSERT INTO `shift`(`IDNumber`,`FullNames`,`Date`,`StartTime`,`StopTime`) VALUES
('32541012','MichaelWatiko','12/27/2016','3:07 PM',''),
('33125855','ViginiaWambui','12/27/2016','3:07 PM',''),
('33125854','Samuel Maina','12/27/2016','3:07 PM',''),
('32128107','KennedyKogei','12/27/2016','3:07 PM','4:28 PM'),
('32128106','FelixKiprono','12/27/2016','3:07 PM',''),
('32120520','MaryKiprop','12/27/2016','3:07 PM',''),
('32120545','MagdaleneKebut','12/27/2016','3:07 PM',''),
('32120520','MaryKiprop','12/29/2016','5:37 PM',''),
('32128106','FelixKiprono','12/29/2016','5:37 PM',''),
('32128107','KennedyKogei','1/16/2017','4:28 PM','4:28 PM');
/*!40000 ALTER TABLE `shift` ENABLE KEYS */;

-- 
-- Definition of stock
-- 

DROP TABLE IF EXISTS `stock`;
CREATE TABLE IF NOT EXISTS `stock` (
  `Code` varchar(100) NOT NULL,
  `ItemName` varchar(100) NOT NULL,
  `Quantity` varchar(100) NOT NULL,
  `Categories` varchar(100) NOT NULL,
  `Units` varchar(100) NOT NULL,
  `BuyingPrice` varchar(100) NOT NULL,
  `Supplier` varchar(100) NOT NULL,
  `PurchaseDate` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table stock
-- 

/*!40000 ALTER TABLE `stock` DISABLE KEYS */;
INSERT INTO `stock`(`Code`,`ItemName`,`Quantity`,`Categories`,`Units`,`BuyingPrice`,`Supplier`,`PurchaseDate`) VALUES
('2','Sugar','2','Ingeridients','KGS','100','Market','12/4/2016'),
('3','Maize','105','Cereals','Kgs','2400','Market','12/12/2016'),
('4','Potatoes','1','Vegetables','Kgs','150','Market','12/11/2016'),
('ITEM228','Rice','18','Grains','Kgs','135','Market','12/12/2016');
/*!40000 ALTER TABLE `stock` ENABLE KEYS */;

-- 
-- Definition of stockout
-- 

DROP TABLE IF EXISTS `stockout`;
CREATE TABLE IF NOT EXISTS `stockout` (
  `Code` varchar(100) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Date` varchar(100) NOT NULL,
  `QuantityOut` varchar(100) NOT NULL,
  `Notes` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table stockout
-- 

/*!40000 ALTER TABLE `stockout` DISABLE KEYS */;
INSERT INTO `stockout`(`Code`,`Name`,`Date`,`QuantityOut`,`Notes`) VALUES
('4','Potatoes','12/15/2016 10:27:50 AM','4',''),
('3','Maize','1/16/2017 4:42:41 PM','2',''),
('ITEM228','Rice','1/17/2017 12:30:05 AM','0',''),
('ITEM228','Rice','1/17/2017 12:30:14 AM','3',''),
('ITEM228','Rice','1/17/2017 12:30:24 AM','3','');
/*!40000 ALTER TABLE `stockout` ENABLE KEYS */;

-- 
-- Definition of suppliers
-- 

DROP TABLE IF EXISTS `suppliers`;
CREATE TABLE IF NOT EXISTS `suppliers` (
  `Company` varchar(100) NOT NULL,
  `Location` varchar(100) NOT NULL,
  `FullNames` varchar(100) NOT NULL,
  `OfficeTel` varchar(100) NOT NULL,
  `Mobile` varchar(100) NOT NULL,
  `Date` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table suppliers
-- 

/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers`(`Company`,`Location`,`FullNames`,`OfficeTel`,`Mobile`,`Date`) VALUES
('Green Labs','Nakuru','FelixKiprono','450','0700828948','12/4/2016'),
('Blue Change','Nairobi','Samuel Makori','100','0721828948','12/4/2016'),
('Fourth Generation','Nairobi','Mr Nandi','0500645870','0701254321','12/21/2016');
/*!40000 ALTER TABLE `suppliers` ENABLE KEYS */;

-- 
-- Definition of table
-- 

DROP TABLE IF EXISTS `table`;
CREATE TABLE IF NOT EXISTS `table` (
  `TableNumber` varchar(100) NOT NULL,
  `TableName` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table table
-- 

/*!40000 ALTER TABLE `table` DISABLE KEYS */;
INSERT INTO `table`(`TableNumber`,`TableName`) VALUES
('1','Table1'),
('2','Table2'),
('3','Table3'),
('4','Table4'),
('5','Table5');
/*!40000 ALTER TABLE `table` ENABLE KEYS */;

-- 
-- Definition of transactionlog
-- 

DROP TABLE IF EXISTS `transactionlog`;
CREATE TABLE IF NOT EXISTS `transactionlog` (
  `Date` varchar(100) NOT NULL,
  `Time` varchar(100) NOT NULL,
  `BankName` varchar(100) NOT NULL,
  `AccountNumber` varchar(100) NOT NULL,
  `AccountName` varchar(100) NOT NULL,
  `TransferedAmount` varchar(100) NOT NULL,
  `Username` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table transactionlog
-- 

/*!40000 ALTER TABLE `transactionlog` DISABLE KEYS */;
INSERT INTO `transactionlog`(`Date`,`Time`,`BankName`,`AccountNumber`,`AccountName`,`TransferedAmount`,`Username`) VALUES
('12/17/2016','6:56:49','CHASE BANK','RAFIKI','12345','500000','Admin'),
('12/17/2016','7:5:49','','','','25000','Admin'),
('12/17/2016','7:6:15','CHASE BANK','RAFIKI','12345','600','Admin'),
('12/27/2016','2:43:4','I&M BANK','WAKAWAKA','09123','20000','Admin'),
('12/27/2016','2:43:34','CHASE BANK','RAFIKI','12345','1000','Admin'),
('12/29/2016','5:35:49','I&M BANK','WAKAWAKA','09123','50000','Admin'),
('1/1/2017','','I&M BANK','WAKAWAKA','09123','6000','Admin'),
('1/1/2017','','BORESHA','DRAWER','1200012','100','Admin'),
('1/1/2017','4:15:34','EQUITY','SUNGURA','123321','8000','Admin'),
('1/1/2017','4:18:38','BORESHA','DRAWER','1200012','500000','Admin'),
('1/1/2017','4:22:1','CHASE BANK','RAFIKI','12345','400','Admin'),
('1/1/2017','4:25:4','COOPERATIVE','GREENCARE','700828948','500','Admin'),
('1/1/2017','4:25:27','COOPERATIVE','BLUE','7008289480155','4500','Admin'),
('1/5/2017','2:48:35','CHASE BANK','RAFIKI','12345','1500','Admin');
/*!40000 ALTER TABLE `transactionlog` ENABLE KEYS */;

-- 
-- Definition of units
-- 

DROP TABLE IF EXISTS `units`;
CREATE TABLE IF NOT EXISTS `units` (
  `UnitName` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table units
-- 

/*!40000 ALTER TABLE `units` DISABLE KEYS */;
INSERT INTO `units`(`UnitName`) VALUES
('Kgs'),
('Grams'),
('Litres'),
('Tonnes'),
('MiliLitres'),
('MiliGrams'),
('Joules'),
('ML'),
('ML');
/*!40000 ALTER TABLE `units` ENABLE KEYS */;

-- 
-- Definition of workers
-- 

DROP TABLE IF EXISTS `workers`;
CREATE TABLE IF NOT EXISTS `workers` (
  `FirstName` varchar(150) NOT NULL,
  `LastName` varchar(150) NOT NULL,
  `IDNumber` varchar(150) NOT NULL,
  `Gender` varchar(150) NOT NULL,
  `Telephone` varchar(150) NOT NULL,
  `Residence` varchar(100) NOT NULL,
  `WorkPosition` varchar(100) NOT NULL,
  `Salary` varchar(100) NOT NULL,
  `PaymentMode` varchar(100) NOT NULL,
  `WorkingDuration` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table workers
-- 

/*!40000 ALTER TABLE `workers` DISABLE KEYS */;
INSERT INTO `workers`(`FirstName`,`LastName`,`IDNumber`,`Gender`,`Telephone`,`Residence`,`WorkPosition`,`Salary`,`PaymentMode`,`WorkingDuration`) VALUES
('Felix','Kiprono','32128106','Male','0700828948','Nakuru','Manager','45000','Daily','10'),
('Kennedy','Kogei','32128107','Male','0700828975','Nakuru','Waiter','5000','Daily','8'),
('Samuel ','Maina','33125854','Male','0712546852','Nakuru','Caterer','10000','Weekly','5'),
('Viginia','Wambui','33125855','Female','0711456987','Nakuru','Waitress','15000','Monthly','8'),
('Jane','Wanjiru','12548008','Female','07200548751','Nakuru','Waitress','15000','Monthly','8'),
('Michael','Watiko','32541012','Male','072005400','Nakuru','Waiter','15000','Monthly','8'),
('Judy','Shiro','31254000','Female','07100231654','Nakuru','Waitress','15000','Monthly','8'),
('Mary','Kiprop','32120520','Female','0732131654','Nakuru','Waitress','15000','Monthly','8'),
('Magdalene','Kebut','32120545','Female','0702213165','Nakuru','Waitress','15000','Monthly','8');
/*!40000 ALTER TABLE `workers` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2017-03-08 10:07:59
-- Total time: 0:0:0:0:875 (d:h:m:s:ms)
