-- Работа со строками
-- len(str)
-- ltrim(str)
-- rtrim(str)
-- concat(str1, str2 ...)
-- lower(str)
-- upper(str)

-- Работа со числами
-- square(num)
-- sqrt(num)
-- round(num, scale)
--abs(num)

-- Работа со датами и временем
-- getdate()
-- getutcdate()
-- day(datetime)
-- month(datetime)
-- year(datetime)

create database Module20_NativeFunctions;
go
use Module20_NativeFunctions;
go

create table Cars
(
    Id           int           not null identity primary key,
    Manufacturer int           not null,
    Model        nvarchar(100) not null, -- 1 = Audi, 2 = Nissan, 3 = Opel
    Year         int           not null check (Year >= 1900 and Year <= year(getdate())) default 1900,
    Price        money         not null                                                  default 0,
);

insert into Cars
values (1, '80', 1980, 3000),
       (2, 'Sentra', 2000, 4000),
       (1, 'Q4', 2020, 30000),
       (3, 'Astra', 2010, 8000);

select *
from Cars;

select Id,
       case Manufacturer -- первый способ использования case - это передать в него конкретную колонку
           when 1 then 'Audi'
           when 2 then 'Nissan'
           when 3 then 'Opel'
           end as Manufacturer,
       Model,
       Year,
       Price,
       case -- второй способ  - не передавать ничего, а использовать просто условия в секции when
           when Price <= 3000 then 'A'
           when Price > 3000 and Price <= 10000 then 'B'
           when Price > 10000 then 'C'
           else 'Unknown'
           end as Category
from Cars

select Id,
       iif(Manufacturer = 1, 'It is Audi', 'It is not Audi, cap.') as IsAudiMessage, -- есть ещё конструкция iif
       Model,
       Year,
       Price
from Cars

-- Проверки на null
-- isnull(val1, val2) - if val1 is not null then return val1 else val2
-- coalesce(val1, val2, val3 ...) - возвращает первое не null значение в последовательности