select name, physical_name From sys.master_files where type_desc = 'log';

create database Semana8 On (
NAME = 'Semana8_Primario',
FILENAME = 'C:\SEMANA8\prueba.mdf',
SIZE =50MB, MAXSIZE = 500MB, FILEGROWTH = 10MB
)
LOG ON
(
NAME = 'Prueba_log',
FILENAME = 'C:\SEMANA8\prueba.ldf',
SIZE = 20MB, MAXSIZE =200MB, FILEGROWTH =5MB
)

DBCC SHRINKFILE (Prueba_log, 10);

Create Partition Function rangofechaParticion(Date)
As Range left for values ('2024-01-01','2024-06-01', '2024-12-31');

create partition scheme particionBDprueba
As Partition rangofechaparticion
ALL to ([PRIMARY]);


create table reservas (
IDreservas INT ,
fechaReservas Date,
IDcliente Int, 
primary key (fechareservas,IDreservas)
)ON particionDBprueba(Fechareserva);

