USE blazordemo;

CREATE TABLE IF NOT EXISTS Produits (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nom VARCHAR(100) NOT NULL,
    Description VARCHAR(500) NULL,
    Prix DECIMAL(10,2) NOT NULL,
    Categorie VARCHAR(50) NOT NULL,
    Stock INT NOT NULL DEFAULT 0,
    EstActif BOOLEAN NOT NULL DEFAULT TRUE,
    DateCreation DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    INDEX idx_categorie (Categorie),
    INDEX idx_nom (Nom)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;


INSERT INTO Produits (Nom, Description, Prix, Categorie, Stock, EstActif) VALUES
('Laptop Pro 15', 'Ordinateur portable haute performance avec écran 15 pouces', 1299.99, 'Informatique', 25, TRUE),
('Souris Gaming RGB', 'Souris gaming avec éclairage RGB et 7 boutons programmables', 59.99, 'Accessoires', 150, TRUE),
('Clavier Mécanique', 'Clavier mécanique avec switches Cherry MX Blue', 129.99, 'Accessoires', 80, TRUE),
('Écran 27" 4K', 'Moniteur 27 pouces résolution 4K UHD', 449.99, 'Informatique', 30, TRUE),
('Casque Audio Pro', 'Casque sans fil avec réduction de bruit active', 249.99, 'Audio', 45, TRUE),
('Webcam HD 1080p', 'Webcam Full HD avec microphone intégré', 79.99, 'Accessoires', 0, FALSE);


SELECT '✅ Base de données initialisée avec succès!' AS Status;
SELECT COUNT(*) AS 'Nombre de produits' FROM Produits;