use registroAlumuno

create table Alumno (
id int identity (1,1) primary key,
Dui varchar (11) not null,
nombre varchar (10) not null,
direccion varchar (255) not null,
edad int not null,
email varchar (50) not null,

);

ALTER TABLE Alumno 
ALTER COLUMN Nombre VARCHAR(100);


create table profesor (
usuario varchar (100) primary key,
pass varchar (20) not null,
nombre varchar (100) not null,
email varchar (100) not null,
);



create table asignatura (
id int identity (1,1) primary key,
nombre varchar (100) not null,
creditos INT DEFAULT 0 NOT NULL,
profesor varchar (100),

foreign key (profesor) references profesor(usuario)
);

create table matricula (
id int identity (1,1) primary key,
alumnoid int not null,
asignaturaid int not null

foreign key (alumnoid) references alumno (id),
foreign key (asignaturaid) references asignatura (id)
);

create table calificaciones (
id int identity (1,1) primary key,
descripcion varchar (100),
nota real not null,
procentaje int not null,
matriculaid int not null,
foreign key (matriculaid) references matricula (id)
);


insert into Alumno
values
('09457890', 'miguel perez', 'calle el paraido pasaje 7', '23', 'migule.perez@gmail.com');
insert into Alumno
values
('09457890', 'Juan Carlos Peña', 'calle el paisnal pasaje 2', '25', 'carlitos.peña@gmail.com'),
('00864389','David Callesa', 'calle el final 3 pasaje 3', '55', 'david.calles@gmail.com' ),
('08768977','Anderson martinez', 'calle el paraiso pasaje 9', '34', 'ander.mar@gmail.com');




/*Tabla profesores*/
INSERT INTO [dbo].[profesor]([usuario],[pass],[nombre],[email]) VALUES ('rocio','1234','Rocio Sánchez Jiménez','rocio@gmail.com');
INSERT INTO [dbo].[profesor]([usuario],[pass],[nombre],[email]) VALUES ('julio','1234','Julio Cerro Garcés','julio@gmail.com');
INSERT INTO [dbo].[profesor]([usuario],[pass],[nombre],[email]) VALUES ('ivan','1234','Ivan Martínez Recio','ivan@gmail.com');

/*Tabla asignaturas*/
INSERT INTO [dbo].[asignatura]([nombre],[creditos],[profesor]) VALUES('Matemáticas',6,'rocio');
INSERT INTO [dbo].[asignatura]([nombre],[creditos],[profesor]) VALUES('Informática',4,'rocio');
INSERT INTO [dbo].[asignatura]([nombre],[creditos],[profesor]) VALUES('Inglés',5,'julio');
INSERT INTO [dbo].[asignatura]([nombre],[creditos],[profesor]) VALUES('Lengua',6,'ivan');

/*Tabla matricula*/
INSERT INTO [dbo].[matricula]([alumnoId],[asignaturaId]) VALUES(12,1);
INSERT INTO [dbo].[matricula]([alumnoId],[asignaturaId]) VALUES(13,2);
INSERT INTO [dbo].[matricula]([alumnoId],[asignaturaId]) VALUES(14,3);
INSERT INTO [dbo].[matricula]([alumnoId],[asignaturaId]) VALUES(15,2);

select * from matricula