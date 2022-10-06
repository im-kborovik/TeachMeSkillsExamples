create database Module20_View;
go
use Module20_View;
go

create table Products
(
    Id           int           not null identity primary key,
    Name         nvarchar(100) not null,
    Manufacturer nvarchar(100) not null,
    Quantity     int           not null default 0,
    Price        money         not null
);

create table Customers
(
    Id        int           not null identity primary key,
    FirstName nvarchar(100) not null
);

create table Orders
(
    Id         int   not null identity primary key,
    ProductId  int   not null references Products (Id) on delete cascade,
    CustomerId int   not null references Customers (Id) on delete cascade,
    Quantity   int   not null default 1,
    Price      money not null
);

insert into Products
values ('iPhone 6', 'Apple', 2, 36000),
       ('iPhone 6S', 'Apple', 2, 41000),
       ('iPhone 7', 'Apple', 5, 52000),
       ('Galaxy S8', 'Samsung', 2, 46000),
       ('Galaxy S8 Plus', 'Samsung', 1, 56000),
       ('Mi 5X', 'Xiaomi', 2, 26000),
       ('OnePlus 5', 'OnePlus', 6, 38000)

insert into Customers
values ('Tom'),
       ('Bob'),
       ('Sam')

insert into Orders
values ((select Id from Products where Name = 'Galaxy S8'),
        (select Id from Customers where FirstName = 'Tom'),
        2,
        (select Price from Products where Name = 'Galaxy S8')),

       ((select Id from Products where Name = 'iPhone 6S'),
        (select Id from Customers where FirstName = 'Tom'),
        1,
        (select Price from Products where Name = 'iPhone 6S')),

       ((select Id from Products where Name = 'iPhone 6S'),
        (select Id from Customers where FirstName = 'Bob'),
        1,
        (select Price from Products where Name = 'iPhone 6S'));
go

-- простое создание представления
create view CustomerProducts
as
select c.FirstName, p.Manufacturer, p.Name, o.Price as ItemPrice, o.Quantity as ItemQuantity
from Orders O
         join Customers C on O.CustomerId = C.Id
         join Products P on O.ProductId = P.Id

-- изменение представления
    alter view CustomerProducts
    as
        select c.FirstName,
               p.Manufacturer,
               p.Name,
               p.Quantity,
               p.Price,
               o.Price    as ItemPrice,
               o.Quantity as ItemQuantity
        from Orders O
                 join Customers C on O.CustomerId = C.Id
                 join Products P on O.ProductId = P.Id

-- удаление
drop view CustomerProducts