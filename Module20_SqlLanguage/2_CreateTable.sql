-- Чтобы создать таблицу используется команда create table
create table Users(
    -- существует два способа определений ограничений, первый через конкретные колонки, как это сделано с первичным ключом
    Id int not null identity(1, 1) constraint PK_Users_Id primary key, 
    Name nvarchar(100) null,
    Email nvarchar(100) not null,
    Age int not null constraint DF_Users_Age default 18,
--     ещё одна форма назначения ограничений - сразу после опредения колонок
--     constraint PK_Users_Id primary key(Id, Name)
--     constraint UQ_Users_Name_Email unique(Name, Email)
--     constraint CK_Users_Age_Email check(Age > 18 and Email is not null)
);
--  стоит отметить, что эти способы отличаются не просто так,
--  ограничения, навешенные в рамках одной колонки, будут действовать только в рамках неё
--  после определения колонок, мы можем указать на уровне таблицы ограничения, использующие любые колонки

create table Addresses(
    Id int not null identity(1, 1) primary key,
    Country nvarchar(50) not null,
    City nvarchar(100) not null,
    Street nvarchar(500) not null,
    UserId int not null references Users(Id), -- внешний ключ мы тоже можем определять как на уровне колонки
--     так и на уровне таблицы
    constraint FK_Addresses_Users_UserId foreign key(UserId) references Users(Id)
                      on delete cascade -- а здесь мы определяем действия при удалении основный записи, на которую ссылается внешний ключ
);

-- Чтобы удалить таблицу используется команда drop table
drop table Addresses;
drop table Users;