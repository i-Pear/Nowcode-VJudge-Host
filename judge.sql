CREATE TABLE `main` (
  `submit_author` varchar(10) NOT NULL,
  `submit_time` datetime NOT NULL,
  `submit_problem` varchar(5) NOT NULL,
  `submit_code` text NOT NULL,
  `judge_status` int(11) NOT NULL,
  `judge_time` datetime DEFAULT NULL,
  `judge_remoteid` int(11) DEFAULT NULL,
  `judge_result` varchar(30) DEFAULT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci