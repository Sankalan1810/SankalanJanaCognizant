USE sampledb;

-- Drop table if it already exists (optional safety)
DROP TABLE IF EXISTS Products;

-- Create the Products table with a primary key
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(100),
    Price DECIMAL(10, 2)
);

-- Insert only NEW products from different categories
INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
-- Smartwatches
(1, 'Apple Watch Ultra 2', 'Smartwatches', 799.99),
(2, 'Galaxy Watch 6 Classic', 'Smartwatches', 599.99),
(3, 'Fitbit Sense 2', 'Smartwatches', 299.99),
(4, 'Garmin Fenix 7', 'Smartwatches', 899.99),

-- Gaming Consoles
(5, 'PlayStation 5 Slim', 'Gaming Consoles', 499.99),
(6, 'Xbox Series X', 'Gaming Consoles', 549.99),
(7, 'Nintendo Switch OLED', 'Gaming Consoles', 349.99),
(8, 'Steam Deck OLED', 'Gaming Consoles', 599.99),

-- Monitors
(9, 'Dell UltraSharp 4K U2723QE', 'Monitors', 649.99),
(10, 'LG UltraGear QHD 27GL83A', 'Monitors', 449.99),
(11, 'Samsung Smart Monitor M8', 'Monitors', 699.99),
(12, 'ASUS ROG Swift PG32UQ', 'Monitors', 999.99),

-- Smart Home Devices
(13, 'Amazon Echo Show 10', 'Smart Home Devices', 249.99),
(14, 'Google Nest Hub Max', 'Smart Home Devices', 229.99),
(15, 'Apple HomePod 2', 'Smart Home Devices', 299.99),
(16, 'Ring Video Doorbell Pro 2', 'Smart Home Devices', 199.99);

-- Retrieve top 3 priced products in each category
SELECT *
FROM (
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS TopRow,
        RANK()       OVER (PARTITION BY Category ORDER BY Price DESC) AS TopRank,
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS TopDenseRank
    FROM Products
) ranked
WHERE TopRow <= 3
ORDER BY Category, TopRow;
