CREATE TABLE `Books` (`id` INTEGER PRIMARY KEY AUTOINCREMENT,`Title` MEDIUMTEXT UNIQUE NULL DEFAULT NULL,`ISBN` MEDIUMTEXT NULL DEFAULT NULL,`Publisher` MEDIUMTEXT INT NULL DEFAULT NULL,`Rating` INT NULL DEFAULT NULL,`DatePublication` MEDIUMTEXT NULL DEFAULT NULL,`Genres` MEDIUMTEXT NULL DEFAULT NULL,`Pages` INT NULL DEFAULT NULL,`Description` MEDIUMTEXT NULL DEFAULT NULL,`UserRating` INT NULL DEFAULT NULL,`LibraryThingRating` INT NULL DEFAULT NULL,`Authors` INT NULL DEFAULT NULL)
CREATE TABLE `Authors` (`id` INTEGER PRIMARY KEY AUTOINCREMENT,`AuthorName` MEDIUMTEXT UNIQUE NULL DEFAULT NULL)
CREATE TABLE `BookAuthors` (`id` INTEGER  PRIMARY KEY AUTOINCREMENT,`BookId` INT NULL DEFAULT NULL,`AuthorId` INT NULL DEFAULT NULL)