-- Use the correct database
USE sampledb;
GO

-- Drop existing procedures if they exist
IF OBJECT_ID('sp_GetEmployeesByDepartment', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetEmployeesByDepartment;
IF OBJECT_ID('sp_InsertEmployee', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertEmployee;
GO

-- Drop existing tables if they exist
IF OBJECT_ID('Employees', 'U') IS NOT NULL
    DROP TABLE Employees;
IF OBJECT_ID('Departments', 'U') IS NOT NULL
    DROP TABLE Departments;
GO

-- =========================
-- Create Departments Table
-- =========================
CREATE TABLE Departments (
    DepartmentID   INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);
GO

-- =========================
-- Create Employees Table
-- =========================
CREATE TABLE Employees (
    EmployeeID   INT IDENTITY(1,1) PRIMARY KEY,
    FirstName    VARCHAR(50),
    LastName     VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary       DECIMAL(10,2),
    JoinDate     DATE
);
GO

-- =========================
-- Insert Sample Departments
-- =========================
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'Human Resources'),
(2, 'Accounting'),
(3, 'Engineering'),
(4, 'Sales');
GO

-- =========================
-- Insert Sample Employees
-- =========================
INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
('Arjun', 'Mehta', 1, 5000.00, '2020-01-15'),
('Neha', 'Kapoor', 2, 6000.00, '2019-03-22'),
('Kabir', 'Verma', 3, 7000.00, '2018-07-30'),
('Anjali', 'Rao', 4, 5500.00, '2021-11-05');
GO

-- ==========================================
-- Procedure: Get Employees by Department
-- ==========================================
CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DeptID INT
AS
BEGIN
    SELECT 
        EmployeeID     AS [ID],
        FirstName      AS [First Name],
        LastName       AS [Last Name],
        DepartmentID   AS [Dept ID],
        Salary,
        JoinDate
    FROM Employees
    WHERE DepartmentID = @DeptID;
END;
GO

-- ======================================
-- Procedure: Insert New Employee (Safe)
-- ======================================
CREATE PROCEDURE sp_InsertEmployee
    @FirstName    VARCHAR(50),
    @LastName     VARCHAR(50),
    @DepartmentID INT,
    @Salary       DECIMAL(10,2),
    @JoinDate     DATE
AS
BEGIN
    BEGIN TRY
        INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
        VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
    END TRY
    BEGIN CATCH
        PRINT 'Error inserting employee: ' + ERROR_MESSAGE();
    END CATCH
END;
GO

-- ====================================
-- TEST CASES
-- ====================================

-- Test: Insert a new employee
EXEC sp_InsertEmployee 
    @FirstName = 'Meera', 
    @LastName = 'Iyer', 
    @DepartmentID = 3, 
    @Salary = 7200.00, 
    @JoinDate = '2022-06-01';
GO

-- Test: Retrieve employees from Accounting department (DepartmentID = 2)
EXEC sp_GetEmployeesByDepartment @DeptID = 2;
GO
