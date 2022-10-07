create database Module20_Triggers;
go
use Module20_Triggers;
go

create table Products
(
    Id           int           not null identity primary key,
    Name         nvarchar(100) not null,
    Manufacturer nvarchar(100) not null,
    Quantity     int           not null default 0,
    Price        money         null,
    BasePrice    money         not null
);
go

create or alter trigger UpdatePriceByCoef
    on Products
    after insert, update
    as update Products
       set Price = BasePrice + BasePrice * 0.1
       where Id in (select Id from inserted);
go

insert into Products(name, manufacturer, Quantity, baseprice)
values ('iPhone 6', 'Apple', 2, 36000),
       ('iPhone 6S', 'Apple', 2, 41000),
       ('iPhone 7', 'Apple', 5, 52000),
       ('Galaxy S8', 'Samsung', 2, 46000),
       ('Galaxy S8 Plus', 'Samsung', 1, 56000),
       ('Mi 5X', 'Xiaomi', 2, 26000),
       ('OnePlus 5', 'OnePlus', 6, 38000)
go

select * from Products

-- есть ещё 'instead of'триггер, который по сути подменяет указанную операцию