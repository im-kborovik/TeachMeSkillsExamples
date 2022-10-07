create database Module20_StoreProcedures;
go
use Module20_StoreProcedures;
go

create table Products
(
    Id           int           not null identity primary key,
    Name         nvarchar(100) not null,
    Manufacturer nvarchar(100) not null,
    Quantity     int           not null default 0,
    Price        money         not null
);
go

insert into Products
values ('iPhone 6', 'Apple', 2, 36000),
       ('iPhone 6S', 'Apple', 2, 41000),
       ('iPhone 7', 'Apple', 5, 52000),
       ('Galaxy S8', 'Samsung', 2, 46000),
       ('Galaxy S8 Plus', 'Samsung', 1, 56000),
       ('Mi 5X', 'Xiaomi', 2, 26000),
       ('OnePlus 5', 'OnePlus', 6, 38000)
go

-- создание процедуры
CREATE PROCEDURE ProductSummary AS
SELECT Name AS Product, Manufacturer, Price
FROM Products
go

CREATE or alter PROC ProductSummary AS
BEGIN
    SELECT Name AS Product, Manufacturer, Price
    FROM Products
END;
go

-- выполнение процедуры
execute ProductSummary;
exec ProductSummary;

drop procedure ProductSummary;

-- параметры в процедурах

CREATE PROCEDURE AddProduct @name NVARCHAR(100),
                            @manufacturer NVARCHAR(100),
                            @quantity INT = 1, -- необязательный
                            @price MONEY
AS
INSERT INTO Products(Name, Manufacturer, Quantity, Price)
VALUES (@name, @manufacturer, @quantity, @price);
go

DECLARE @prodName NVARCHAR(20), @company NVARCHAR(20);
DECLARE @prodCount INT, @price MONEY
SET @prodName = 'Galaxy C7'
SET @company = 'Samsung'
SET @price = 22000
SET @prodCount = 5;

EXEC AddProduct @prodName, @company, @prodCount, @price;

-- выходные параметры
CREATE PROCEDURE GetPriceStats @minPrice MONEY OUTPUT,
                               @maxPrice MONEY OUTPUT
AS
SELECT @minPrice = MIN(Price), @maxPrice = MAX(Price)
FROM Products
go

DECLARE @minPrice MONEY, @maxPrice MONEY

EXEC GetPriceStats @minPrice OUTPUT, @maxPrice OUTPUT

-- оператор return
CREATE PROCEDURE GetAvgPrice AS
DECLARE @avgPrice MONEY
SELECT @avgPrice = AVG(Price)
FROM Products
    RETURN @avgPrice;
go

DECLARE @result MONEY

EXEC @result = GetAvgPrice
PRINT @result