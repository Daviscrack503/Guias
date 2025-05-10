create database ClinicaDB ;

go
use ClinicaDB
go

-- creando tabla pacientes

create table Pacientes (
IdPaciente int primary key identity (1,1),
Nombre Nvarchar (100) Not Null,
Apellido Nvarchar (100) Not Null,
FechaNacimiento Date Not Null,
Telefono Nvarchar (12),
Email Nvarchar (100) unique
);

-- creando la tabla medicos --

create table medicos (
IdMedico Int primary key Identity (1,1),
Nombre Nvarchar (100) not null,
apellido nvarchar (100) not null,
especialidad nvarchar (100) not null,
telefono nvarchar (12) not null,
email nvarchar (100) unique
);

go

-- creando tabla citas y particionando por año --
CREATE PARTITION FUNCTION RangoCitasPartition (DATE)
AS RANGE LEFT FOR VALUES ('2022-12-31', '2023-12-31', '2024-12-31');


-- creando el esquema de particion--

create partition scheme esquemacitaspartition
as partition RangoCitasPartition
ALL to ([Primary]);

--creando la tabla citas--

create table citas (
IdCita int identity  (1,1)  Not null,
IdPaciente Int foreign key references Pacientes (IdPaciente),
IdMedico Int Foreign key references Medicos(IdMedico),
Fechacita Date Not Null,
Motivo Nvarchar (255),
Estado nvarchar (50) Check (Estado in ('Agendada', 'Realizada','Cancelada'))
Primary key (FechaCita, Idcita)
) On  esquemacitaspartition(FechaCita);
go


-- creando tabla tratamiento--

create table tratamientos (
Idtratamiebto Int primary key Identity (1,1),
IdCita int,
FechaCita Date
foreign key (IdCita, FechaCita) References citas (IDCita, FechaCita),
Descripcion Nvarchar (255) Not Null,
Costo decimal (10,2) Not null,

);


-- creando tabla factura --

create table factura (
IdFactura int primary key identity (1,1),
IdTratamiento int foreign key references tratamientos (IdTratamiento),
FechaFactura Date not null Default getdate (),
MontoTatal Decimal (10,2 ) not null,
Estado Nvarchar (50) check (estado in ('Pendiente', 'pagada', 'anulada'))
);
go

-- creando la tabla bitacora--

create table bitacoraTransaccionesClinicaDB (
Idlog int primary key  identity (1,1),
TablaAfectada Nvarchar (50) Not null,
TipoOperacion Nvarchar (10) check (TipoOperacion in ('Insert', 'Update', 'Delete')),
FechaOperacion DateTIME Default getdate(),
Usuario Nvarchar (100) default user_name (),
RegistroAnterior Nvarchar(MAX),
RegistroNuevo Nvarchar (Max)
);
Go

-- creando el triggers para la tabla pacientes
create trigger trg_pacientes_auditoria
on pacientes
after insert, update, delete
as
begin
set nocount on;
declare @TipoOperacion nvarchar(10);
if exists (select * from inserted) and exists (select * from deleted)
set @TipoOperacion = 'update';
else if exists (select * from inserted)
set @TipoOperacion = 'Insert';
else
set @TipoOperacion = 'delete';
insert into bitacoraTransaccionesClinicaDB(TablaAfectada, TipoOperacion, RegistroAnterior, RegistroNuevo)
select 'pacientes',
@TipoOperacion,
(select * from deleted for json auto),
(select * from inserted for json auto);
end;
go
select $partition.rangocitaspartition(FechaCita) as particion, *from citas;

create trigger trg_Citas_auditoria
on citas
after insert, update, delete
as
begin
set nocount on;
declare @TipoOperacion nvarchar(10);
if exists (select * from inserted) and exists (select * from deleted)
set @TipoOperacion = 'update';
else if exists (select * from inserted)
set @TipoOperacion = 'Insert';
else
set @TipoOperacion = 'delete';
insert into bitacoraTransaccionesClinicaDB(TablaAfectada, TipoOperacion, RegistroAnterior, RegistroNuevo)
select 'citas',
@TipoOperacion,
(select * from deleted for json auto),
(select * from inserted for json auto);
end;
go
select $partition.rangocitaspartition(FechaCita) as particion, *from citas;

insert into Pacientes (

);
