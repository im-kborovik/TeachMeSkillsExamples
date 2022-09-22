create table Users_Grouping
(
    Id    int           not null identity (1, 1) primary key,
    Name  nvarchar(100) null,
    Email nvarchar(100) not null,
    Age   int           not null,
);

insert into Users_Grouping
values ('Ivan', 'ivan1@gmail.com', 18),
       ('Anton', 'anton@gmail.com', 20),
       ('Ivan', 'ivan2@gmail.com', 31),
       ('Irina', 'irina@gmail.com', 18);

select *
from Users_Grouping;

-- Для группировки используется group by
select Name
from Users_Grouping
group by Name;

-- в group by должны быть указаны все выходные колонки, иначе sql запрос не сработает
select Name, Age
from Users_Grouping
group by Name, Age;

-- при грппировке очень часто применяют агрегатные функции
-- в этом случае такие функции применяются к конкретным группам
-- колонки для агрегатных функций не надо указывать в секции группировки
select Name, Age, count(*) as GroupedCount
from Users_Grouping
group by Name, Age;

-- однако у группировки есть и ещё одно отличие
-- мы не можем использовать where для уже сгруппированных данных
-- для этой цели используется having
-- только помните, что в having мы не можем использовать переименованные колонки, только реальные имена
select Name, count(*) as GroupedCount, max(Age)
from Users_Grouping
group by Name
having count(*) > 2;

select Name, count(*) as GroupedCount, max(Age)
from Users_Grouping
group by Name
having max(Age) > 18