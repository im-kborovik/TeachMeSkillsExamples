create database Module20_SimpleConstructions;
go;
use Module20_SimpleConstructions;

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
go;

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

-- Определение переменной
declare @minPrice money;
set @minPrice = 35000;

-- использование в запросах
select *
from Products
where Price > @minPrice;

-- условные выражения
if (select count(*)
    from Products
    where Price > @minPrice) > 0
    print 'Yeap'
else
    print 'Nope';

if (select count(*)
    from Products
    where Price > @minPrice) > 0
    begin
        print 'Yeap'
    end;
else
    begin
        print 'Nope';
    end;

-- цикл всего один - while

declare @counter int;
set @counter = 0;

while @counter < 10
    begin
        print 'Here is ' + convert(nvarchar(2), @counter) + ' iteration'
        set @counter = @counter + 1;
    end;
    
-- у цикл while также как и в c# есть break и continue