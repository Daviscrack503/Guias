Create Database clinicaDB;

create table Citas (
Fechacita date,
HoraCita datetime,
IdPaciente  int foreign key references Pacientes(PacienteID),
IdMedico int
);

Create Table Tratamientos (
IdMedicamento int Primary Key,
Nombre_Del_Medicamento Varchar (50),
IDPaciente Int IdPaciente  int foreign key references Pacientes(PacienteID),
IdFactura Int
);

Create Table Facturas
( IdFactura int primary key,
  IdPaciente int,
  FechadeFactura Date,


);