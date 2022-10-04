create database Module20_SubQueries;
go;
use Module20_SubQueries;

-- Подзапросы позволяют нам составлять сложные запросы на основе более простых или вложенных запросов
-- Для демонстрации их работы создадим три таблицы, которые будут связаны как многие-ко-многим.
create table Products
(
    Id       int           not null identity primary key,
    Name     nvarchar(100) not null,
    Manufacturer nvarchar(100) not null,
    Quantity int           not null default 0,
    Price    money         not null
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

-- Тут ничего интересного, просто заполним таблицу с продуктами
insert into Products
values ('iPhone 6', 'Apple', 2, 36000),
       ('iPhone 6S', 'Apple', 2, 41000),
       ('iPhone 7', 'Apple', 5, 52000),
       ('Galaxy S8', 'Samsung', 2, 46000),
       ('Galaxy S8 Plus', 'Samsung', 1, 56000),
       ('Mi 5X', 'Xiaomi', 2, 26000),
       ('OnePlus 5', 'OnePlus', 6, 38000)

-- Тут тоже
insert into Customers
values ('Tom'),
       ('Bob'),
       ('Sam')

-- А вот в этом примере классический пример использования под запросов
-- Обратите внимание, что мы используем select запросы, чтобы заполнить значения колонок таблицы Orders в основном запросе insert
-- Важно понимать следующее:
-- 1. Подзапросы всегда должны заключаться в скобки
-- 2. При использовании подзапросов для добавление, оновления или сравнения тип возвращаемого значение подзапроса и тип колонки,
-- к которой относится подзапрос должны совпадать, а также вы должны быть точно уверены, что вернётся не более одного значения,
-- потому что мы не можем, к примеру, добавить несколько значений в одну ячейку колонки. В случае, если колонка not null, 
-- то подзапрос должен вернуть ровно одно значение иначе будет ошибка.
insert into Orders
values ((select Id from Products where Name = 'Galaxy S8'), -- здесь мы, например, по условию достаём значение колонки Id таблицы Products и кладём его в ProductId
        (select Id from Customers where FirstName = 'Tom'), -- и похожее дествие мы делаем в каждом из подзапросов
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

-- Однако подзапросы вы будете использовать в основном не для добавления или удаления данных,
-- а как раз в более широких выборках, например как эта:
select *
from Products
where Price = (select min(Price) from Products)

-- А здесь рассматриваются так называемые коррелирующиеся запросы.
-- Это когда мы используем данные из основного запроса в подзапросах.
-- Например, в следующем запросе мы дополнительно выводим название продукта из таблицы Products
SELECT  Price,
        (SELECT Name FROM Products
         WHERE Products.Id = Orders.ProductId) AS Product -- Обратите внимание на условие, таким образом мы как бь связываем две таблицы.
FROM Orders