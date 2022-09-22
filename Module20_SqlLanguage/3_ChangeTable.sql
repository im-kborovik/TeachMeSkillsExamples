create table Contacts
(
    Id    int           not null identity (1, 1)
        constraint PK_Users_Id primary key,
    Email nvarchar(100) not null
);

-- Чтобы изменить структуру таблицы используется конструкция alter table
-- этой командой мы можем сделать следуещее:

-- 1. добавить колонку
alter table Contacts -- запомните эту первую часть команды, она всегда остаётся неизменной, менется только то, что следует за ней
    add Phone int null

-- 2. изменить тип и null/not null
alter table Contacts
    alter column Phone float

-- 3. удалить колонку
alter table Contacts
    drop column Phone

-- 4. добавить ограничение
alter table Contacts
    add constraint UQ_Users_Phone unique (Phone)

-- 5. удалить ограничение
alter table Contacts
    drop constraint UQ_Users_Phone