create database Module20_StoreFunctions;
go
use Module20_StoreFunctions;
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

-- скалярные функции
create function GetAvgPriceByManufacturer(@manufacturer nvarchar(100))
    returns money
begin
    declare @result money;
    select @result = avg(Price) from Products where Manufacturer = @manufacturer;
    return @result;
end
go

select dbo.GetAvgPriceByManufacturer('Samsung');

-- табличные функции
create function GetManufacturerNameAndPriceByPrice(@price money)
    returns table
        return
            (
                select Manufacturer, Name, Price
                from Products
                where Price = @price
            );
go

select *
from dbo.GetManufacturerNameAndPriceByPrice(38000);

-- многооператорные функции
create function GetManufacturerNameAndPriceByPriceV2(@price money)
    returns @result table
                    (
                        Manufacturer nvarchar(100),
                        Name         nvarchar(100),
                        Price        money
                    )
begin 
    insert into @result
    select Manufacturer, Name, Price
    from Products
    where Price = @price;
    
    return
end
go

select *
from dbo.GetManufacturerNameAndPriceByPriceV2(38000);
