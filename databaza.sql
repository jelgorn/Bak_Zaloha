-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: aspnetbakalarka
-- ------------------------------------------------------
-- Server version	8.0.40

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
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20241116215851_Data','8.0.11');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pouzivatelia`
--

DROP TABLE IF EXISTS `pouzivatelia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pouzivatelia` (
  `PouzivatelId` int NOT NULL AUTO_INCREMENT,
  `Meno` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Priezvisko` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DatumNarodenia` datetime(6) NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `HesloHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RolaId` int NOT NULL,
  PRIMARY KEY (`PouzivatelId`),
  KEY `IX_Pouzivatelia_RolaId` (`RolaId`),
  CONSTRAINT `FK_Pouzivatelia_Rola_RolaId` FOREIGN KEY (`RolaId`) REFERENCES `rola` (`RolaId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pouzivatelia`
--

LOCK TABLES `pouzivatelia` WRITE;
/*!40000 ALTER TABLE `pouzivatelia` DISABLE KEYS */;
INSERT INTO `pouzivatelia` VALUES (1,'Jano','Novak','1995-08-15 00:00:00.000000','jano@school.com','hashed_password',1),(2,'KAKSD','AFASF','1990-05-15 00:00:00.000000','janso@school.com','hashesad_password',1),(3,'KAKsdfSD','AFAddSF','1990-05-15 00:00:00.000000','jandsdso@school.com','hashesdsad_password',1),(4,'KAKsdsfSD','AFAddssSF','1990-05-15 00:00:00.000000','jandssssdso@school.com','hashesdsssssad_password',1),(5,'KAKsddsfSD','AFAddddssSF','1990-05-15 00:00:00.000000','jandddssssdso@schosol.com','hashesdsssssad_password',1),(6,'KAKsasddsfSD','AFAddddasssSF','1990-05-15 00:00:00.000000','jandasddssssdso@schosol.com','hasheasdsssssad_password',1),(7,'KAKsasddssasfSD','AFAddsddasssSF','1990-05-15 00:00:00.000000','jandasddsssssdso@schosol.com','hashesaasdsssssad_password',1),(8,'KAKsasddssasssfSD','AFAddsddasssSF','1990-05-15 00:00:00.000000','jandasddsssssssdso@schosol.com','hashesaasdsssssad_password',1);
/*!40000 ALTER TABLE `pouzivatelia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `predmety`
--

DROP TABLE IF EXISTS `predmety`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `predmety` (
  `PredmetId` int NOT NULL AUTO_INCREMENT,
  `Nazov` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Popis` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`PredmetId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `predmety`
--

LOCK TABLES `predmety` WRITE;
/*!40000 ALTER TABLE `predmety` DISABLE KEYS */;
INSERT INTO `predmety` VALUES (1,'FYZ','...'),(2,'MAT','...');
/*!40000 ALTER TABLE `predmety` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `priradeniapredmetovucitelom`
--

DROP TABLE IF EXISTS `priradeniapredmetovucitelom`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `priradeniapredmetovucitelom` (
  `PriradenieId` int NOT NULL AUTO_INCREMENT,
  `UcitelId` int NOT NULL,
  `PredmetId` int NOT NULL,
  PRIMARY KEY (`PriradenieId`),
  KEY `IX_PriradeniaPredmetovUcitelom_PredmetId` (`PredmetId`),
  KEY `IX_PriradeniaPredmetovUcitelom_UcitelId` (`UcitelId`),
  CONSTRAINT `FK_PriradeniaPredmetovUcitelom_Pouzivatelia_UcitelId` FOREIGN KEY (`UcitelId`) REFERENCES `pouzivatelia` (`PouzivatelId`) ON DELETE CASCADE,
  CONSTRAINT `FK_PriradeniaPredmetovUcitelom_Predmety_PredmetId` FOREIGN KEY (`PredmetId`) REFERENCES `predmety` (`PredmetId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `priradeniapredmetovucitelom`
--

LOCK TABLES `priradeniapredmetovucitelom` WRITE;
/*!40000 ALTER TABLE `priradeniapredmetovucitelom` DISABLE KEYS */;
/*!40000 ALTER TABLE `priradeniapredmetovucitelom` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `priradeniapredmetovziakom`
--

DROP TABLE IF EXISTS `priradeniapredmetovziakom`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `priradeniapredmetovziakom` (
  `PriradenieId` int NOT NULL AUTO_INCREMENT,
  `ZiakId` int NOT NULL,
  `PredmetId` int NOT NULL,
  PRIMARY KEY (`PriradenieId`),
  KEY `IX_PriradeniaPredmetovZiakom_PredmetId` (`PredmetId`),
  KEY `IX_PriradeniaPredmetovZiakom_ZiakId` (`ZiakId`),
  CONSTRAINT `FK_PriradeniaPredmetovZiakom_Pouzivatelia_ZiakId` FOREIGN KEY (`ZiakId`) REFERENCES `pouzivatelia` (`PouzivatelId`) ON DELETE CASCADE,
  CONSTRAINT `FK_PriradeniaPredmetovZiakom_Predmety_PredmetId` FOREIGN KEY (`PredmetId`) REFERENCES `predmety` (`PredmetId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `priradeniapredmetovziakom`
--

LOCK TABLES `priradeniapredmetovziakom` WRITE;
/*!40000 ALTER TABLE `priradeniapredmetovziakom` DISABLE KEYS */;
/*!40000 ALTER TABLE `priradeniapredmetovziakom` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rola`
--

DROP TABLE IF EXISTS `rola`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rola` (
  `RolaId` int NOT NULL AUTO_INCREMENT,
  `Nazov` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`RolaId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rola`
--

LOCK TABLES `rola` WRITE;
/*!40000 ALTER TABLE `rola` DISABLE KEYS */;
INSERT INTO `rola` VALUES (1,'Admin'),(2,'Učiteľ'),(3,'Žiak');
/*!40000 ALTER TABLE `rola` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-24 22:16:41
