-- --------------------------------------------------------
-- Host:                         localhost
-- Server version:               8.1.0 - MySQL Community Server - GPL
-- Server OS:                    Win64
-- HeidiSQL Version:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for lps
CREATE DATABASE IF NOT EXISTS `lps` /*!40100 DEFAULT CHARACTER SET latin1 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `lps`;

-- Dumping structure for table lps.produk
CREATE TABLE IF NOT EXISTS `produk` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nama_barang` varchar(200) NOT NULL DEFAULT '',
  `kode_barang` varchar(50) NOT NULL DEFAULT '',
  `jumlah_barang` int NOT NULL DEFAULT '0',
  `tanggal` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 COMMENT='table produk ';

-- Dumping data for table lps.produk: ~4 rows (approximately)
/*!40000 ALTER TABLE `produk` DISABLE KEYS */;
INSERT INTO `produk` (`id`, `nama_barang`, `kode_barang`, `jumlah_barang`, `tanggal`) VALUES
	(2, 'TAS', 'T001', 23, '2023-10-10 22:21:54'),
	(3, 'SEPATU', 'S001', 20, '2023-10-10 22:22:12'),
	(4, 'Gadget', 'G001', 50, '2023-10-10 14:00:45'),
	(6, 'Tissue', 'T002', 123, '2023-10-11 01:26:00');
/*!40000 ALTER TABLE `produk` ENABLE KEYS */;

-- Dumping structure for procedure lps.usp_delete_produk
DELIMITER //
CREATE PROCEDURE `usp_delete_produk`(
	IN `p_id` INT(10)
)
    COMMENT 'delete produk'
BEGIN
	DELETE FROM produk WHERE id = p_id;
END//
DELIMITER ;

-- Dumping structure for procedure lps.usp_getall_produk
DELIMITER //
CREATE PROCEDURE `usp_getall_produk`()
    COMMENT 'get produk'
BEGIN
	SELECT * FROM produk;
END//
DELIMITER ;

-- Dumping structure for procedure lps.usp_get_produk_byid
DELIMITER //
CREATE PROCEDURE `usp_get_produk_byid`(
	IN `p_id` INT(10)
)
BEGIN
	SELECT * FROM produk WHERE id = p_id;
END//
DELIMITER ;

-- Dumping structure for procedure lps.usp_insert_produk
DELIMITER //
CREATE PROCEDURE `usp_insert_produk`(
	IN `p_nama_barang` VARCHAR(200),
	IN `p_kode_barang` VARCHAR(50),
	IN `p_jumlah_barang` INT,
	IN `p_tanggal` DATETIME
)
    COMMENT 'add produk'
BEGIN
	insert into produk(nama_barang, kode_barang, jumlah_barang, tanggal) 
	values (p_nama_barang, p_kode_barang, p_jumlah_barang, p_tanggal);
END//
DELIMITER ;

-- Dumping structure for procedure lps.usp_search_produk
DELIMITER //
CREATE PROCEDURE `usp_search_produk`(
	IN `p_search_value` VARCHAR(50)
)
BEGIN
   SELECT * FROM produk WHERE 
   nama_barang LIKE CONCAT('%', p_search_value , '%') OR 
   kode_barang LIKE CONCAT('%', p_search_value , '%') OR 
	jumlah_barang LIKE CONCAT('%', p_search_value , '%') OR 
	tanggal LIKE CONCAT('%', p_search_value , '%');
END//
DELIMITER ;

-- Dumping structure for procedure lps.usp_update_produk
DELIMITER //
CREATE PROCEDURE `usp_update_produk`(
	IN `p_id` INT(10),
	IN `p_nama_barang` VARCHAR(200),
	IN `p_kode_barang` VARCHAR(50),
	IN `p_jumlah_barang` INT(10),
	IN `p_tanggal` DATETIME
)
    COMMENT 'update produk'
BEGIN
	update produk 
	set nama_barang = p_nama_barang, 
	    kode_barang = p_kode_barang, 
		 jumlah_barang = p_jumlah_barang, 
		 tanggal = p_tanggal
   WHERE id = p_id;
END//
DELIMITER ;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
