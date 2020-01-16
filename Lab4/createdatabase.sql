create database RockMusic;
use RockMusic

CREATE TABLE `albums` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` text COLLATE utf8_bin
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

CREATE TABLE `artists` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` text COLLATE utf8_bin,
  `surname` text COLLATE utf8_bin
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

INSERT INTO `artists` (`id`, `name`, `surname`) VALUES
(1, 'Serj', 'Tankian'),
(2, 'Shavo', 'Odadjian')
(3, 'Daron', 'Malakian');

CREATE TABLE `artists_songs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `artist_id` int(11) NOT NULL,
  `song_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

CREATE TABLE `descriptions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `content` text COLLATE utf8_bin,
  `artist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

CREATE TABLE `songs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` text COLLATE utf8_bin,
  `albums_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

ALTER TABLE `albums`
  ADD PRIMARY KEY (`id`);
  
ALTER TABLE `artists`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `artists_songs`
  ADD PRIMARY KEY (`id`),
  ADD KEY `artist_id` (`artist_id`),
  ADD KEY `song_id` (`song_id`);

ALTER TABLE `descriptions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `artist_id` (`artist_id`);

ALTER TABLE `songs`
  ADD PRIMARY KEY (`id`),
  ADD KEY `albums_id` (`albums_id`);

ALTER TABLE `artists_songs`
  ADD KEY `artist_id` (`artist_id`),
  ADD KEY `song_id` (`song_id`);
  
ALTER TABLE `descriptions`
  ADD KEY `artist_id` (`artist_id`);
  
ALTER TABLE `songs`
  ADD KEY `albums_id` (`albums_id`);
  
ALTER TABLE `artists_songs`
  ADD CONSTRAINT `artists_songs_ibfk_1` FOREIGN KEY (`artist_id`) REFERENCES `artists` (`id`),
  ADD CONSTRAINT `artists_songs_ibfk_2` FOREIGN KEY (`song_id`) REFERENCES `songs` (`id`);
  
ALTER TABLE `descriptions`
  ADD CONSTRAINT `descriptions_ibfk_1` FOREIGN KEY (`artist_id`) REFERENCES `artists` (`id`);
  
ALTER TABLE `songs`
  ADD CONSTRAINT `songs_ibfk_1` FOREIGN KEY (`albums_id`) REFERENCES `albums` (`id`);