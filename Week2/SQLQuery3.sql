-- Use the correct database
USE sampledb;
GO

-- Drop tables if they already exist (optional)
IF OBJECT_ID('Employees', 'U') IS NOT NULL DROP TABLE Employees;
IF OBJECT_ID('Departments', 'U') IS NOT NULL DROP TABLE Departments;
GO

-- Create Departments table
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);
GO

-- Create Employees table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);
GO

-- Insert sample departments
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'Human Resources'),
(2, 'Accounting'),
(3, 'Engineering'),
(4, 'Sales');
GO

-- Insert sample employees
INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
(1, 'Arjun', 'Mehta', 1, 5000.00, '2020-01-15'),
(2, 'Neha', 'Kapoor', 2, 6000.00, '2019-03-22'),
(3, 'Kabir', 'Verma', 3, 7000.00, '2018-07-30'),
(4, 'Anjali', 'Rao', 4, 5500.00, '2021-11-05');
GO

-- Create stored procedure to get employee count by department
CREATE PROCEDURE GetEmployeeCountByDepartment
    @DeptID INT
AS
BEGIN
    SELECT 
        D.DepartmentName,
        COUNT(E.EmployeeID) AS TotalEmployees
    FROM Employees E
    INNER JOIN Departments D ON E.DepartmentID = D.DepartmentID
    WHERE E.DepartmentID = @DeptID
    GROUP BY D.DepartmentName;
END;
GO

-- Execute the stored procedure for Engineering department (DepartmentID = 3)
EXEC GetEmployeeCountByDepartment @DeptID = 3;
GO
