-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.40 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.8.0.6908
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Volcando datos para la tabla crud.producto: ~9 rows (aproximadamente)
DELETE FROM `producto`;
INSERT INTO `producto` (`id`, `Nombre`, `Precio`, `Fecha`) VALUES
	(1, 'Pasta', 2000, '2025-06-17 13:42:26'),
	(2, 'carne', 5000, '2025-06-17 00:00:00'),
	(3, 'Arroz', 3000, '2025-06-17 00:00:00'),
	(4, 'Papa', 12000, '2002-09-16 00:00:00'),
	(5, 'lapiz', 15000, '2001-09-11 00:00:00'),
	(6, 'esfero', 15000, '1973-06-05 00:00:00'),
	(9, 'Chocolate mrbeast', 15000, '2025-06-25 17:54:16'),
	(10, 'Balon', 100, '2025-06-25 17:58:55'),
	(11, 'Bom bom bum', 5000, '2019-11-18 14:50:00');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
