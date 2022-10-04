create table Products_Aggregate
(
    Id    int           not null identity (1, 1) primary key,
    Name  nvarchar(100) null,
    Price money         not null
);

insert into Products_Aggregate
values (N'Картоха', 2.96),
       (N'Макароны', 4.9),
       (N'Молоко', 2.6),
       (N'Хлеб', 1.6);

select *
from Products_Aggregate;

-- aгрегатные функции выполняют вычисления над значениями в наборе строк
-- существует достаточно много таких функций, но наоболее часто используемые:
-- AVG: находит среднее значение
select avg(Price)
from Products_Aggregate;

-- SUM: находит сумму значений
select sum(Price)
from Products_Aggregate;

-- MIN: находит наименьшее значение
select min(Price)
from Products_Aggregate;

-- MAX: находит наибольшее значение
select max(Price)
from Products_Aggregate;

-- COUNT: находит количество строк в запросе
select count(*)
from Products_Aggregate;

-- все эти функции можно применять в совокупности:
select avg(Price) as avg_price,
       sum(Price) as sum_price,
       count(*) as products_count
from Products_Aggregate