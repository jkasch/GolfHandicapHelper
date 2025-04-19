-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 19, 2025 at 08:50 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `golf_handicap_helper`
--

-- --------------------------------------------------------

--
-- Table structure for table `golfers`
--

CREATE TABLE `golfers` (
  `golfer_id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `handicap` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `golfers`
--

INSERT INTO `golfers` (`golfer_id`, `name`, `handicap`) VALUES
(1, 'Jennifer', 12),
(2, 'Jake', 16),
(3, 'Jessica', 13),
(4, 'Bob', 12),
(5, 'Bill', 14),
(6, 'Gary', 13),
(7, 'Jon', 12),
(8, 'Mary', 15),
(9, 'Jason', 12),
(10, 'Barb', 16),
(11, 'Daryl', 16);

-- --------------------------------------------------------

--
-- Table structure for table `handicaps`
--

CREATE TABLE `handicaps` (
  `hole_id` int(11) NOT NULL,
  `scorecard_id` int(11) NOT NULL,
  `hole_number` int(11) NOT NULL,
  `hole_handicap` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `handicaps`
--

INSERT INTO `handicaps` (`hole_id`, `scorecard_id`, `hole_number`, `hole_handicap`) VALUES
(1, 2, 1, 2),
(2, 2, 2, 4),
(3, 2, 3, 6),
(4, 2, 4, 8),
(5, 2, 5, 1),
(6, 2, 6, 3),
(7, 2, 7, 5),
(8, 2, 8, 7),
(9, 2, 9, 9),
(10, 3, 1, 9),
(11, 3, 2, 8),
(12, 3, 3, 7),
(13, 3, 4, 6),
(14, 3, 5, 5),
(15, 3, 6, 1),
(16, 3, 7, 2),
(17, 3, 8, 3),
(18, 3, 9, 4),
(19, 4, 1, 1),
(20, 4, 2, 2),
(21, 4, 3, 3),
(22, 4, 4, 4),
(23, 4, 5, 5),
(24, 4, 6, 6),
(25, 4, 7, 9),
(26, 4, 8, 7),
(27, 4, 9, 8),
(28, 5, 1, 1),
(29, 5, 2, 2),
(30, 5, 3, 3),
(31, 5, 4, 4),
(32, 5, 5, 5),
(33, 5, 6, 6),
(34, 5, 7, 7),
(35, 5, 8, 8),
(36, 5, 9, 9),
(37, 6, 1, 1),
(38, 6, 2, 2),
(39, 6, 3, 3),
(40, 6, 4, 4),
(41, 6, 5, 5),
(42, 6, 6, 6),
(43, 6, 7, 7),
(44, 6, 8, 8),
(45, 6, 9, 9),
(46, 7, 1, 1),
(47, 7, 2, 3),
(48, 7, 3, 2),
(49, 7, 4, 4),
(50, 7, 5, 5),
(51, 7, 6, 6),
(52, 7, 7, 7),
(53, 7, 8, 9),
(54, 7, 9, 8),
(55, 8, 1, 2),
(56, 8, 2, 1),
(57, 8, 3, 4),
(58, 8, 4, 3),
(59, 8, 5, 6),
(60, 8, 6, 5),
(61, 8, 7, 8),
(62, 8, 8, 7),
(63, 8, 9, 9),
(64, 9, 1, 6),
(65, 9, 2, 7),
(66, 9, 3, 8),
(67, 9, 4, 9),
(68, 9, 5, 1),
(69, 9, 6, 2),
(70, 9, 7, 3),
(71, 9, 8, 4),
(72, 9, 9, 5),
(73, 10, 1, 9),
(74, 10, 2, 8),
(75, 10, 3, 7),
(76, 10, 4, 1),
(77, 10, 5, 2),
(78, 10, 6, 3),
(79, 10, 7, 4),
(80, 10, 8, 5),
(81, 10, 9, 6);

-- --------------------------------------------------------

--
-- Table structure for table `scorecards`
--

CREATE TABLE `scorecards` (
  `scorecard_id` int(11) NOT NULL,
  `course_name` varchar(255) NOT NULL,
  `number_of_holes` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `scorecards`
--

INSERT INTO `scorecards` (`scorecard_id`, `course_name`, `number_of_holes`) VALUES
(1, 'Edgewood', 9),
(2, 'Edgewood', 9),
(3, 'Green Acres', 9),
(4, 'golfer paradise', 9),
(5, 'Valleyview', 9),
(6, 'beautiful golf', 9),
(7, 'Wedgewood', 9),
(8, 'Green Ridge', 9),
(9, 'Rolling Meadows', 9),
(10, 'Massive Hills', 9);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `golfers`
--
ALTER TABLE `golfers`
  ADD PRIMARY KEY (`golfer_id`);

--
-- Indexes for table `handicaps`
--
ALTER TABLE `handicaps`
  ADD PRIMARY KEY (`hole_id`),
  ADD KEY `scorecard_id` (`scorecard_id`);

--
-- Indexes for table `scorecards`
--
ALTER TABLE `scorecards`
  ADD PRIMARY KEY (`scorecard_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `golfers`
--
ALTER TABLE `golfers`
  MODIFY `golfer_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `handicaps`
--
ALTER TABLE `handicaps`
  MODIFY `hole_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=82;

--
-- AUTO_INCREMENT for table `scorecards`
--
ALTER TABLE `scorecards`
  MODIFY `scorecard_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `handicaps`
--
ALTER TABLE `handicaps`
  ADD CONSTRAINT `handicaps_ibfk_1` FOREIGN KEY (`scorecard_id`) REFERENCES `scorecards` (`scorecard_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
