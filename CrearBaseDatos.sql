-- Script para crear base de datos del sistema de pedidos del restaurante
-- Ejecutar en SQL Server Management Studio

CREATE DATABASE RestaurantePedidos;
GO

USE RestaurantePedidos;
GO

-- Tabla de Combos
CREATE TABLE Combos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Descripcion NVARCHAR(200) NOT NULL,
    Tipo NVARCHAR(20) NOT NULL
);
GO

-- Tabla de Porciones Adicionales
CREATE TABLE PorcionesAdicionales (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Tipo NVARCHAR(20) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL
);
GO

-- Tabla de Pedidos
CREATE TABLE Pedidos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FechaPedido DATETIME NOT NULL DEFAULT GETDATE(),
    ComboId INT NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ComboId) REFERENCES Combos(Id)
);
GO

-- Tabla intermedia para relacionar pedidos con porciones adicionales
CREATE TABLE PedidoPorciones (
    PedidoId INT NOT NULL,
    PorcionId INT NOT NULL,
    Cantidad INT NOT NULL DEFAULT 1,
    PRIMARY KEY (PedidoId, PorcionId),
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id),
    FOREIGN KEY (PorcionId) REFERENCES PorcionesAdicionales(Id)
);
GO

-- Insertar datos iniciales de combos
INSERT INTO Combos (Nombre, Precio, Descripcion, Tipo) VALUES
('Combo Básico', 5000.00, 'Hamburguesa simple, papas chicas, gaseosa', 'Basico'),
('Combo Familiar', 12000.00, 'Hamburguesas x2, papas grandes, gaseosas x2, nuggets', 'Familiar'),
('Combo Especial', 8000.00, 'Hamburguesa premium, papas medianas, gaseosa, postre', 'Especial');
GO

-- Insertar datos iniciales de porciones adicionales
INSERT INTO PorcionesAdicionales (Tipo, Precio) VALUES
('Tomate', 500.00),
('Papas', 1000.00),
('Carne', 2000.00),
('Queso', 800.00);
GO

-- Verificar datos insertados
SELECT * FROM Combos;
GO

SELECT * FROM PorcionesAdicionales;
GO