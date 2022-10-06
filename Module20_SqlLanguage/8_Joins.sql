create database Module20_Joins;
go;
use Module20_Joins;
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
    ProductId  int   not null,
    CustomerId int   not null,
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
        90,
        1,
        (select Price from Products where Name = 'iPhone 6S'));

-- Для начала рассмотрим неявное соединение таблиц.
-- При выполнении данного примера у нас получится перекрёстное соединение, 
-- т.е. каждая строка из левой таблицы будет совмещаться с каждой из правой. В итоге для данного примера получим 9 записей.
select *
from Orders,
     Customers

-- В большинстве случаев нам нужно нам нужно соединить таблицы по какому-то ключу.
-- При неявной выборке нам нужно написать условие равенства первичного ключа основной таблицы и внешнего ключа зависимой:
select *
from Orders,
     Customers
where Orders.CustomerId = Customers.Id

-- Так мы можем сузить выборку только необходимыми колонками:
select Orders.Quantity, Customers.FirstName
from Orders,
     Customers
where Orders.CustomerId = Customers.Id

-- Явное соединение:
-- 1. inner join
select *
from Orders O -- слово inner можно опустить, потому что оно используется по умолчанию
         join Customers C on O.CustomerId = C.Id


-- 2. left join
select *
from Orders o
         left join Customers C on C.Id = o.CustomerId

select *
from Customers c
         left join Orders O on c.Id = O.CustomerId

-- 3. right join
select *
from Orders o
         right join Customers C on C.Id = o.CustomerId

-- 4. full join = inner + left + right
select *
from Orders o
         full join Customers C on C.Id = o.CustomerId