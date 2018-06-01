-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.1.73-community - MySQL Community Server (GPL)
-- Server OS:                    Win32
-- HeidiSQL Version:             9.3.0.4984
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping database structure for spindlesoftdb
CREATE DATABASE IF NOT EXISTS `spindlesoftdb` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `spindlesoftdb`;


-- Dumping structure for table spindlesoftdb.alteration
CREATE TABLE IF NOT EXISTS `alteration` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerID` int(11) NOT NULL DEFAULT '0',
  `PromisedDate` date NOT NULL,
  `TotalPrice` int(11) NOT NULL DEFAULT '0',
  `CurrentPayment` int(11) DEFAULT '0',
  `Status` int(1) NOT NULL DEFAULT '0',
  `ModifieddDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table spindlesoftdb.alterationitems
CREATE TABLE IF NOT EXISTS `alterationitems` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Alteration_ID` int(11) DEFAULT '0',
  `DateOfUpdate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Name` varchar(50) NOT NULL DEFAULT '0',
  `Price` double DEFAULT '0',
  `Quantity` int(11) NOT NULL DEFAULT '0',
  `Comment` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK_AlterationItems_alteration` (`Alteration_ID`),
  CONSTRAINT `FK_AlterationItems_alteration` FOREIGN KEY (`Alteration_ID`) REFERENCES `alteration` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table spindlesoftdb.bank
CREATE TABLE IF NOT EXISTS `bank` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Name` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table spindlesoftdb.customer
CREATE TABLE IF NOT EXISTS `customer` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Mobile_No` varchar(10) NOT NULL,
  `Phone_No` varchar(10) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `ReferralID` int(11) DEFAULT NULL,
  `UpdatedTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table spindlesoftdb.expense
CREATE TABLE IF NOT EXISTS `expense` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `DateOfExpense` datetime NOT NULL,
  `TotalAmount` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table spindlesoftdb.expenseitem
CREATE TABLE IF NOT EXISTS `expenseitem` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ExpenseID` int(11) NOT NULL DEFAULT '0',
  `Name` varchar(50) NOT NULL DEFAULT '0',
  `Type` varchar(10) NOT NULL DEFAULT '0',
  `Amount` int(11) NOT NULL DEFAULT '0',
  `Comment` varchar(150) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK_expenseItem_expense` (`ExpenseID`),
  CONSTRAINT `FK_expenseItem_expense` FOREIGN KEY (`ExpenseID`) REFERENCES `expense` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table spindlesoftdb.orderitem
CREATE TABLE IF NOT EXISTS `orderitem` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `OrderID` int(11),
  `Name` varchar(50) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `Price` int(11) NOT NULL,
  `Length` varchar(10) DEFAULT NULL,
  `Waist` varchar(10) DEFAULT NULL,
  `Chest` varchar(10) DEFAULT NULL,
  `Shoulder` varchar(10) DEFAULT NULL,
  `Hip` varchar(10) DEFAULT NULL,
  `D` varchar(10) DEFAULT NULL,
  `Front` varchar(10) DEFAULT NULL,
  `Back` varchar(10) DEFAULT NULL,
  `BottomLength` varchar(10) DEFAULT NULL,
  `BottomLoose` varchar(10) DEFAULT NULL,
  `BottomWaist` varchar(10) DEFAULT NULL,
  `BottomHip` varchar(10) DEFAULT NULL,
  `SleeveArmHole` varchar(10) DEFAULT NULL,
  `SleeveLength` varchar(10) DEFAULT NULL,
  `SleeveLoose` varchar(10) DEFAULT NULL,
  `Comment` text,
  `DateUpdated` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `FK_orderitem_orders` (`OrderID`),
  CONSTRAINT `FK_orderitem_orders` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table spindlesoftdb.orderitemdocument
CREATE TABLE IF NOT EXISTS `orderitemdocument` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(20) NOT NULL,
  `OrderItemID` int(11) NOT NULL,
  `DateUpdated` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `FK__orderitem` (`OrderItemID`),
  CONSTRAINT `FK__orderitem` FOREIGN KEY (`OrderItemID`) REFERENCES `orderitem` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table spindlesoftdb.orders
CREATE TABLE IF NOT EXISTS `orders` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerID` int(11) NOT NULL DEFAULT '0',
  `TotalPrice` int(11) NOT NULL DEFAULT '0',
  `Status` int(1) NOT NULL DEFAULT '0',
  `CurrentPayment` int(11) DEFAULT '0',
  `PromisedDate` date NOT NULL,
  `ModifieddDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `FK_orders_customer` (`CustomerID`),
  CONSTRAINT `FK_orders_customer` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table spindlesoftdb.salary
CREATE TABLE IF NOT EXISTS `salary` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `DateOfSalary` datetime NOT NULL,
  `TotalSalaryAmount` decimal(10,0) NOT NULL DEFAULT '0',
  `ExpenseID` int(11) NOT NULL,
  `UpdatedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table spindlesoftdb.salaryitem
CREATE TABLE IF NOT EXISTS `salaryitem` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `StaffID` int(11) NOT NULL DEFAULT '0',
  `SalaryID` int(11) NOT NULL DEFAULT '0',
  `Amount` int(11) NOT NULL,
  `UpdatedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `FK_salaryitem_staff` (`StaffID`),
  KEY `FK_salaryitem_salary` (`SalaryID`),
  CONSTRAINT `FK_salaryitem_salary` FOREIGN KEY (`SalaryID`) REFERENCES `salary` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_salaryitem_staff` FOREIGN KEY (`StaffID`) REFERENCES `staff` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table spindlesoftdb.sale
CREATE TABLE IF NOT EXISTS `sale` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerID` int(11) NOT NULL DEFAULT '0',
  `DateOfSale` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `TotalPrice` int(11) NOT NULL,
  `AmountPaid` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK_sale_customer` (`CustomerID`),
  CONSTRAINT `FK_sale_customer` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table spindlesoftdb.saleitem
CREATE TABLE IF NOT EXISTS `saleitem` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `SKUID` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL DEFAULT '1',
  `Price` int(11) NOT NULL,
  `DateOfUpdate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `SaleID` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `FK_saleitem_sale` (`SaleID`),
  KEY `FK_saleitem_skuitem` (`SKUID`),
  CONSTRAINT `FK_saleitem_sale` FOREIGN KEY (`SaleID`) REFERENCES `sale` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_saleitem_skuitem` FOREIGN KEY (`SKUID`) REFERENCES `skuitem` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table spindlesoftdb.securitydocument
CREATE TABLE IF NOT EXISTS `securitydocument` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(20) NOT NULL,
  `StaffID` int(11) NOT NULL,
  `DateUpdated` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `FK__staff` (`StaffID`),
  CONSTRAINT `FK__staff` FOREIGN KEY (`StaffID`) REFERENCES `staff` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table spindlesoftdb.skuitem
CREATE TABLE IF NOT EXISTS `skuitem` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) NOT NULL,
  `ProductCode` varchar(20) NOT NULL,
  `Description` text,
  `Color` varchar(20) NOT NULL,
  `Size` varchar(20) NOT NULL,
  `Material` varchar(20) NOT NULL,
  `CostPrice` int(11) DEFAULT NULL,
  `SellingPrice` int(11) DEFAULT NULL,
  `Quantity` int(11) DEFAULT '0',
  `VendorID` int(11) DEFAULT '0',
  `IsSelfMade` tinyint(4) NOT NULL DEFAULT '1',
  `UpdatedTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Name` (`Name`),
  UNIQUE KEY `ProductCode` (`ProductCode`),
  KEY `FK_skuitem_vendor` (`VendorID`),
  CONSTRAINT `FK_skuitem_vendor` FOREIGN KEY (`VendorID`) REFERENCES `vendor` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table spindlesoftdb.staff
CREATE TABLE IF NOT EXISTS `staff` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text NOT NULL,
  `Mobile_No` varchar(10) NOT NULL,
  `Phone_No` varchar(10) DEFAULT NULL,
  `Address` text,
  `Designation` varchar(50) NOT NULL,
  `type` int(11) NOT NULL DEFAULT '1',
  `payCycle` int(11) NOT NULL DEFAULT '1',
  `BankID` int(11) DEFAULT NULL,
  `BankUserName` varchar(20) DEFAULT NULL,
  `AccNo` varchar(20) DEFAULT '',
  `IfscCode` varchar(30) DEFAULT '',
  `UpdatedTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table spindlesoftdb.vendor
CREATE TABLE IF NOT EXISTS `vendor` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL DEFAULT '',
  `MobileNo` varchar(10) NOT NULL DEFAULT '0',
  `Address` text NOT NULL,
  `OfferingType` varchar(100) NOT NULL,
  `IsProduct` tinyint(4) NOT NULL,
  `BankID` int(11) DEFAULT NULL,
  `BankUserName` varchar(50) NOT NULL DEFAULT '0',
  `AccNo` varchar(20) NOT NULL DEFAULT '',
  `IfscCode` varchar(30) NOT NULL DEFAULT '',
  `UpdatedTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `FK_vendor_bank` (`BankID`),
  CONSTRAINT `FK_vendor_bank` FOREIGN KEY (`BankID`) REFERENCES `bank` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
