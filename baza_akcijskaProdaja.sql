-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Feb 18, 2019 at 10:54 PM
-- Server version: 5.7.24
-- PHP Version: 7.2.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `baza`
--

-- --------------------------------------------------------

--
-- Table structure for table `akcija`
--

DROP TABLE IF EXISTS `akcija`;
CREATE TABLE IF NOT EXISTS `akcija` (
  `id_poduzece` int(11) NOT NULL,
  `id_akcija` int(11) NOT NULL AUTO_INCREMENT,
  `id_oglas` int(11) NOT NULL,
  `naziv_akcija` varchar(60) NOT NULL,
  `datum_pocetka` date NOT NULL,
  `datum_zavrsetka` date NOT NULL,
  `opis` varchar(100) NOT NULL,
  PRIMARY KEY (`id_akcija`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `akcija`
--

INSERT INTO `akcija` (`id_poduzece`, `id_akcija`, `id_oglas`, `naziv_akcija`, `datum_pocetka`, `datum_zavrsetka`, `opis`) VALUES
(2, 1, 1, 'Sniženje sportske opreme', '2019-02-13', '2019-02-17', 'Veliko čišćenje skladišta u svim trgovinama InterSporta.'),
(0, 2, 0, 'Svježe voce', '2019-02-15', '2019-02-16', 'Svježe voce sniženo 30%. '),
(17, 3, 0, 'Svježe voce', '2019-02-13', '2019-02-15', 'Sniženo svježe voce.'),
(2, 4, 0, 'Svježe voce', '2019-02-13', '2019-02-11', 'Sniženo svježe voce.'),
(5, 5, 0, 'Svježe voce', '2019-02-11', '2019-02-10', 'Sniženo svježe voce.'),
(6, 6, 0, 'Svježe voce', '2019-02-13', '2019-02-11', 'Sniženo svježe voce.'),
(8, 7, 0, 'Svježe voce', '2019-02-13', '2019-02-11', 'Sniženo svježe voce.'),
(6, 8, 0, 'Svježe voce', '2019-02-13', '2019-02-11', 'Sniženo svježe voce.'),
(10, 9, 0, 'Svježe voce', '2019-02-13', '2019-02-11', 'Sniženo svježe voce.'),
(6, 10, 0, 'NOvo', '2019-02-13', '2019-02-11', 'sniženjeeee'),
(11, 11, 0, 'Ajd', '2019-02-13', '2019-02-11', 'sniženjeeee'),
(28, 12, 0, 'AJMOO', '2019-02-13', '2019-02-11', 'sniženjeeee'),
(9, 13, 0, 'Veliko sniženje', '2019-02-13', '2019-02-11', 'sniženjeeee'),
(10, 14, 0, 'Dinamo', '2019-02-13', '2019-02-11', 'sniženjeeee'),
(12, 15, 0, 'Dinamo', '2019-02-13', '2019-02-11', 'Sniženo svježe voce.'),
(7, 16, 0, 'Dinamo', '2019-02-13', '2019-02-11', 'ajddee'),
(1, 17, 0, 'daj', '2019-02-13', '2019-02-11', 'radiiiii');

-- --------------------------------------------------------

--
-- Table structure for table `kategorija`
--

DROP TABLE IF EXISTS `kategorija`;
CREATE TABLE IF NOT EXISTS `kategorija` (
  `id_kategorija` int(11) NOT NULL AUTO_INCREMENT,
  `naziv_kategorije` varchar(50) NOT NULL,
  PRIMARY KEY (`id_kategorija`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `kategorija`
--

INSERT INTO `kategorija` (`id_kategorija`, `naziv_kategorije`) VALUES
(1, 'Sport'),
(2, 'Prehrana'),
(3, 'Tehnicka roba'),
(4, 'Odjeca'),
(6, 'sport'),
(7, 'Sport1'),
(12, 'Školski pribor');

-- --------------------------------------------------------

--
-- Table structure for table `korisnik`
--

DROP TABLE IF EXISTS `korisnik`;
CREATE TABLE IF NOT EXISTS `korisnik` (
  `id_poduzece` int(11) NOT NULL,
  `id_korisnik` int(11) NOT NULL AUTO_INCREMENT,
  `ime` varchar(60) NOT NULL,
  `prezime` varchar(60) NOT NULL,
  `email` varchar(45) NOT NULL,
  `lozinka` varchar(20) NOT NULL,
  PRIMARY KEY (`id_korisnik`),
  UNIQUE KEY `id_korisnik_UNIQUE` (`id_korisnik`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `korisnik`
--

INSERT INTO `korisnik` (`id_poduzece`, `id_korisnik`, `ime`, `prezime`, `email`, `lozinka`) VALUES
(0, 1, 'Tin ', 'Dvorski', 'dvorski.tin@gmail.com', '12345'),
(0, 2, 'Matej', 'Krizanec', 'matej.krizanec@gmail.com', '1234'),
(4, 3, 'Novi', 'Korisnik', 'korisnik.novi@gmail.com', '54321');

-- --------------------------------------------------------

--
-- Table structure for table `oglas`
--

DROP TABLE IF EXISTS `oglas`;
CREATE TABLE IF NOT EXISTS `oglas` (
  `id_oglas` int(11) NOT NULL AUTO_INCREMENT,
  `id_akcija` int(11) NOT NULL,
  `naziv_artikla` varchar(60) DEFAULT NULL,
  `osnovna_cijena` double(10,2) DEFAULT NULL,
  `mjerna_jedinica` decimal(10,0) DEFAULT NULL,
  `postotak_popusta` decimal(10,0) DEFAULT NULL,
  `akcijska_cijena` double(10,2) DEFAULT NULL,
  `kratki_opis` varchar(100) DEFAULT NULL,
  `dugi_opis` varchar(300) DEFAULT NULL,
  `slika_proizvoda` varchar(255) DEFAULT NULL,
  `id_poduzece` int(11) DEFAULT NULL,
  `id_kategorija` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_oglas`),
  KEY `id_kategorija` (`id_kategorija`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `oglas`
--

INSERT INTO `oglas` (`id_oglas`, `id_akcija`, `naziv_artikla`, `osnovna_cijena`, `mjerna_jedinica`, `postotak_popusta`, `akcijska_cijena`, `kratki_opis`, `dugi_opis`, `slika_proizvoda`, `id_poduzece`, `id_kategorija`) VALUES
(7, 13, 'Kruh', 15.00, '1', '5', 11.00, 'Kruh', 'Raženi kruh', 'kruh.png', 19, 2);

-- --------------------------------------------------------

--
-- Table structure for table `poduzece`
--

DROP TABLE IF EXISTS `poduzece`;
CREATE TABLE IF NOT EXISTS `poduzece` (
  `id_poduzece` int(11) NOT NULL AUTO_INCREMENT,
  `naziv_poduzece` varchar(100) DEFAULT NULL,
  `adresa` varchar(100) DEFAULT NULL,
  `grad` varchar(50) DEFAULT NULL,
  `telefon` int(11) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `web_adresa` varchar(100) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_poduzece`),
  UNIQUE KEY `id_poduzece_UNIQUE` (`id_poduzece`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `poduzece`
--

INSERT INTO `poduzece` (`id_poduzece`, `naziv_poduzece`, `adresa`, `grad`, `telefon`, `email`, `web_adresa`) VALUES
(1, 'PopUp', 'jelkovecka 4', 'varazdin', 12321321, 'marker.vt@gmail.com', 'www.marker.com'),
(2, 'Marker', 'jelkovecka 3', 'varazdin', 22222, 'marker.vt@gmail.com', 'www.marker.com'),
(3, 'Oprugarna Dvorski', 'Petkovec 37a', 'Vz.Toplice', 42671023, 'oprugarna.dvorski@gmail.com', 'www.opruge.com'),
(4, 'Megaldo', 'Petkovec 68a', 'Varaždinske Toplice', 42671097, 'magaldo.opruge@gmail.com', 'www.megaldo.com'),
(5, 'Marker', 'jelkovecka 9', 'varazdin', 22222, 'marker.vt@gmail.com', 'www.marker.com'),
(6, 'Butik', 'Varazdinska 3', 'Varazdin', 111111111, 'butik.vz@gmail.com', 'www.butik.com'),
(7, 'BornaStore', 'Varazdinska 5', 'Varazdin', 2223232, 'borna.store@gmail.com', 'www.bornastore.com'),
(8, 'Marker', 'Zagrebacka 2', 'varazdin', 22222, 'marker.vt@gmail.com', 'www.marker.com'),
(9, 'Megaldo', 'Petkovec 68', 'Varaždinske Toplice', 42671097, 'magaldo.oprugeee@gmail.com', 'www.megaldo.com'),
(10, 'Novo', 'jelkovecka 4', 'varazdin', 22222, 'marker.vt@gmail.com', 'www.marker.com');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `oglas`
--
ALTER TABLE `oglas`
  ADD CONSTRAINT `oglas_ibfk_1` FOREIGN KEY (`id_kategorija`) REFERENCES `kategorija` (`id_kategorija`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
