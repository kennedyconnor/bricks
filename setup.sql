-- CREATE TABLE sets
-- (
--   id INT AUTO_INCREMENT,
--   title VARCHAR(255) NOT NULL,
--   info VARCHAR(255),
--   genreId INT NOT NULL,

--   INDEX (genreId),

--   FOREIGN KEY (genreId)
--     REFERENCES genres(id)
--     ON DELETE CASCADE,

--   PRIMARY KEY (id)
-- )
-- CREATE TABLE bricksets
-- (
--   id INT AUTO_INCREMENT,
--   setId INT NOT NULL,
--   brickId INT NOT NULL,

--   INDEX (setId),

--   FOREIGN KEY (setId)
--     REFERENCES sets(id)
--     ON DELETE CASCADE,

--      FOREIGN KEY (brickId)
--     REFERENCES bricks(id)
--     ON DELETE CASCADE,

--   PRIMARY KEY (id)
-- )


