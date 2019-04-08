-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Apr 08, 2019 at 06:20 PM
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
  `opis` varchar(350) NOT NULL,
  PRIMARY KEY (`id_akcija`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `akcija`
--

INSERT INTO `akcija` (`id_poduzece`, `id_akcija`, `id_oglas`, `naziv_akcija`, `datum_pocetka`, `datum_zavrsetka`, `opis`) VALUES
(0, 2, 0, 'Televizori', '2019-04-08', '2019-04-12', 'Televizori u Elipso ponudi su savršeni spoj performansi, dizajna i prihvatljive cijene. Uz velik izbor televizora razlicitih dijagonala, boja i performansa svatko ce pronaci svoj model.'),
(6, 8, 0, 'Svježe voce', '2019-02-13', '2019-02-11', 'Sniženo svježe voce.'),
(0, 9, 0, 'Svježe voce', '2019-02-13', '2019-02-11', 'Sniženo svježe voce.'),
(6, 10, 0, 'NOvo', '2019-02-13', '2019-02-11', 'sniženjeeee'),
(0, 11, 0, 'Ajd', '2019-03-02', '2019-03-03', 'sniženjeeee'),
(0, 13, 0, 'Veliko sniženje', '2019-03-01', '2019-03-02', 'sniženjeeee'),
(1, 14, 0, 'Svježe voce', '2019-04-11', '2019-04-06', 'Svježe voce kaufland!');

-- --------------------------------------------------------

--
-- Table structure for table `artikl`
--

DROP TABLE IF EXISTS `artikl`;
CREATE TABLE IF NOT EXISTS `artikl` (
  `id_artikl` int(11) NOT NULL AUTO_INCREMENT,
  `naziv_artikl` varchar(45) CHARACTER SET cp1250 COLLATE cp1250_croatian_ci NOT NULL,
  `cijena_artikl` double NOT NULL,
  PRIMARY KEY (`id_artikl`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data for table `artikl`
--

INSERT INTO `artikl` (`id_artikl`, `naziv_artikl`, `cijena_artikl`) VALUES
(1, 'Lopta', 100),
(2, 'Novi', 100),
(3, 'novii', 100);

-- --------------------------------------------------------

--
-- Table structure for table `kategorija`
--

DROP TABLE IF EXISTS `kategorija`;
CREATE TABLE IF NOT EXISTS `kategorija` (
  `id_kategorija` int(11) NOT NULL AUTO_INCREMENT,
  `naziv_kategorije` varchar(50) NOT NULL,
  PRIMARY KEY (`id_kategorija`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `kategorija`
--

INSERT INTO `kategorija` (`id_kategorija`, `naziv_kategorije`) VALUES
(1, 'Sportn'),
(2, 'Prehrana'),
(3, 'Tehnicka roba'),
(4, 'Odjeca'),
(6, 'sport'),
(12, 'Školski pribor'),
(13, 'nova');

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
(1, 3, 'Novi', 'Korinsik', 'marker.vt@gmail.com', '12345');

-- --------------------------------------------------------

--
-- Table structure for table `oglas`
--

DROP TABLE IF EXISTS `oglas`;
CREATE TABLE IF NOT EXISTS `oglas` (
  `id_oglas` int(11) NOT NULL AUTO_INCREMENT,
  `id_akcija` int(11) NOT NULL,
  `osnovna_cijena` double DEFAULT NULL,
  `mjerna_jedinica` varchar(15) DEFAULT NULL,
  `postotak_popusta` int(11) DEFAULT NULL,
  `akcijska_cijena` double DEFAULT NULL,
  `kratki_opis` varchar(100) DEFAULT NULL,
  `dugi_opis` varchar(300) DEFAULT NULL,
  `slika_proizvoda` varchar(255) DEFAULT NULL,
  `id_poduzece` int(11) DEFAULT NULL,
  `id_kategorija` int(11) DEFAULT NULL,
  `id_artikl` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_oglas`),
  KEY `id_kategorija` (`id_kategorija`),
  KEY `id_artikl` (`id_artikl`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `oglas`
--

INSERT INTO `oglas` (`id_oglas`, `id_akcija`, `osnovna_cijena`, `mjerna_jedinica`, `postotak_popusta`, `akcijska_cijena`, `kratki_opis`, `dugi_opis`, `slika_proizvoda`, `id_poduzece`, `id_kategorija`, `id_artikl`) VALUES
(21, 2, 100, 'komad', 50, 50, ' yyxy', 'sa', 'lopta.png', 0, 1, 1),
(22, 2, 100, 'komad', 50, 50.2, 'sdsad', 'sadad', 'neimenovano.png', 0, 1, 1),
(25, 2, 20, 'komad', 10, 18, ' yyxy', 'dsadsa', 'lopta.png', 1, 1, 1),
(27, 2, 12, 'komad', 12, 11, ' yyxy', 'dasdsa', 'lopta.png', 1, 1, 1),
(29, 2, 15, 'komad', 10, 14, ' yyxy', 'xdsad', 'kruh.png', 1, 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `poduzece`
--

DROP TABLE IF EXISTS `poduzece`;
CREATE TABLE IF NOT EXISTS `poduzece` (
  `id_poduzece` int(14) NOT NULL AUTO_INCREMENT,
  `naziv_poduzece` varchar(100) DEFAULT NULL,
  `adresa` varchar(100) DEFAULT NULL,
  `grad` varchar(50) DEFAULT NULL,
  `telefon` varchar(12) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `web_adresa` varchar(100) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_poduzece`),
  UNIQUE KEY `id_poduzece_UNIQUE` (`id_poduzece`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `poduzece`
--

INSERT INTO `poduzece` (`id_poduzece`, `naziv_poduzece`, `adresa`, `grad`, `telefon`, `email`, `web_adresa`) VALUES
(1, 'marker', 'jelkovecka 9', 'Vz.Toplice', '0919449354', 'dvorski.tin@gmail.com', 'www.marker.com'),
(2, 'Marker', 'jelkovecka', 'Vz.Toplice', '22233344', 'matej@gmail.com', 'www.nova.com'),
(3, 'Markeric', 'jelkovecka 9', 'varazdin', '42671023', 'dvorski.tin@gmail.com', 'www.opruge.com');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
