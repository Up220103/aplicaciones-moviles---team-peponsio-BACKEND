

CREATE DATABASE IF NOT EXISTS pokedex_db;
USE pokedex_db;

CREATE TABLE IF NOT EXISTS pokemon (
    id      INT AUTO_INCREMENT PRIMARY KEY,  -- llave propia de la tabla
    numero  INT          NOT NULL UNIQUE,    -- numero de la pokedex (no se repite)
    nombre  VARCHAR(50)  NOT NULL,
    tipo    VARCHAR(50)  NOT NULL,           -- ej. 'grass, poison'
    altura  DECIMAL(5,2) NOT NULL,           -- en metros
    peso    DECIMAL(6,2) NOT NULL,           -- en kilos
    imagen  VARCHAR(255) NULL                -- NULL = registro creado sin imagen
);
