-- Active: 1717530365593@@bs6ofdvohg74iuka869a-mysql.services.clever-cloud.com@3306@bs6ofdvohg74iuka869a

CREATE TABLE `Owners` (
  `OwnerId` INT AUTO_INCREMENT PRIMARY KEY,
  `Names` VARCHAR(50) NOT NULL,
  `LastNames` VARCHAR(50) NOT NULL,
  `Email` VARCHAR(100) UNIQUE NOT NULL,
  `Address` VARCHAR(100) NOT NULL,
  `Phone` VARCHAR(25) NOT NULL
);

CREATE TABLE `Vets` (
  `VetId` INT AUTO_INCREMENT PRIMARY KEY,
  `Name` VARCHAR(120) NOT NULL,
  `Phone` VARCHAR(25) NOT NULL,
  `Addres` VARCHAR(30),
  `Email` VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE `Pets` (
  `PetId` INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
  `Name` VARCHAR(25),
  `Specie` ENUM('Perro', 'Gato', 'Conejo', 'Hamsters', 'Pajaro', 'Caballo', 'Vaca') NOT NULL,
  `Race` ENUM('Pastor Aleman', 'BullDog', 'Siames', 'Fold Escoces', 'Ruso', 'Roborowski', 'Periquitos', 'Canarios', 'Pura Sangre Ingles', 'Frison', 'Holstein', 'Hereford') NOT NULL,
  `DateBirth` DATE,
  `OwnerId` INT NOT NULL,
  `Photo` TEXT,
  FOREIGN KEY (`OwnerId`) REFERENCES `Owners`(`OwnerId`)
);

CREATE TABLE `Quotes` (
  `QouteId` INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
  `Date` DATETIME NOT NULL,
  `PetId` INT NOT NULL,
  `VetId` INT NOT NULL,
  `Description` TEXT,
  FOREIGN KEY (`PetId`) REFERENCES `Pets`(`PetId`),
  FOREIGN KEY (`VetId`) REFERENCES `Vets`(`VetId`)
);

-- Insertar datos en las tablas

INSERT INTO `Owners` (`OwnerId`, `Names`, `LastNames`, `Email`, `Address`, `Phone`) VALUES
(1, 'Santiago', 'Giraldo Herrera', 's.giraldo@example.com','Poblado', '3100000215'),
(2, 'Ana Maria', 'Restrepo Marin', 'ana.marin@example.com', 'Aranjuez' , '3150000405'),
(3, 'Juan Felipe', 'Montoya Restrepo', 'felipe.montoya@example.com', 'Manrique' , '3001235260'),
(4, 'Angelica', 'Martinez', 'angelica@example.com', 'Envigado' ,'3100000000'),
(5, 'Mateo', 'Velez Toro', 'mateo.velez@example.com', 'Calazans' ,'3501230000');

INSERT INTO `Vets` (`VetId`, `Name`, `Phone`, `Addres`, `Email`) VALUES
(1, 'Veterinaria La Huellita', '650-000-00', 'Oulet de Moda', 'lahuellita@example.com'),
(2, 'Veterinaria El Maullido', '650-123-00', 'Jardin Botanico', 'elmaullido@example.com'),
(3, 'Veterinaria Hogar Animal', '401-123-00', 'Parque la Floresta', 'hogaranimal@example.com'),
(4, 'Veterinaria Sonrisa Animal', '402-125-00', 'Estadio Atanasio Girardot', 'sonrisanimal@example.com'),
(5, 'Veterinaria Patita’s', '650-123-12', 'Llano Grande', 'patita´s@example.com');

INSERT INTO `Pets` (`PetId`,`Name`, `Specie`, `Race`, `DateBirth`, `OwnerId`, `Photo`) VALUES
(1,'Luna', 'Perro', 'Pastor Aleman', '2020-01-15', 1 ,'https://www.google.com/url?sa=i&url=https%3A%2F%2Ftucachorrotienda.com%2Fproduct%2Fpastor-aleman%2F&psig=AOvVaw3dtaO4gLTUDUCeNPYSMCMP&ust=1717620817081000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCKCutKfqwoYDFQAAAAAdAAAAABAJ'),
(2,'Pelusa', 'Gato', 'Siames', '2021-03-22', 2 ,'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.purina.es%2Fencuentra-mascota%2Frazas-de-gato%2Fsiames&psig=AOvVaw2mOtiifzMa5fdSd4PXgsXu&ust=1717620848509000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCKDOprbqwoYDFQAAAAAdAAAAABAE'),
(3,'Conejito', 'Conejo', 'Roborowski', '2022-05-10', 3 , 'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.alamy.es%2Fimagenes%2Fh%25C3%25A1mster-roborovski.html&psig=AOvVaw34YXQzQeiybieLIf3nTFGq&ust=1717620885554000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCJiw7cfqwoYDFQAAAAAdAAAAABAE'),
(4,'Periquito', 'Pajaro', 'Periquitos', '2023-07-01', 4 , 'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.informacion.es%2Fvida-y-estilo%2Fmascotas%2F2022%2F05%2F10%2Fperiquito-cuanto-vive-curiosidades-59589784.html&psig=AOvVaw0kPlTxP_EIZy_w2e6yzVGq&ust=1717620922426000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCIi4xNnqwoYDFQAAAAAdAAAAABAR'),
(5,'Tornado', 'Caballo', 'Pura Sangre Ingles', '2019-12-24', 5, 'https://www.google.com/url?sa=i&url=https%3A%2F%2Frfeagas.es%2Frazas%2Fequino-caballar%2Fpura-sangre-ingles%2F&psig=AOvVaw0q957kSUzqlD6uSOnXQS3a&ust=1717620971981000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCOjrivHqwoYDFQAAAAAdAAAAABAE');

INSERT INTO `Quotes` (`QouteId`, `Date`, `PetId`, `VetId`, `Description`) VALUES
(1,'2024-06-04', 1, 2, 'Descripcion.........'),
(2,'2024-05-05', 2, 4, 'Descripcion.........'),
(3,'2023-12-01', 3, 5, 'Descripcion.........'),
(4,'2024-08-15', 4, 1, 'Descripcion.........'),
(5,'2024-02-24', 5, 3, 'Descripcion.........');

DROP TABLE `Owners`;
DROP TABLE `Vets`;
DROP TABLE `Pets`;
DROP TABLE `Quotes`; 