-- Creacion de DB y asignacion de logs---
CREATE DATABASE Semana10
ON PRIMARY
(   NAME = Semana10_Datos,
    FILENAME = 'C:\Semana10\Semana10.mdf',
    SIZE = 50MB,
    MAXSIZE = 500MB,
    FILEGROWTH = 10MB )
LOG ON
(   NAME = Semana10_Log,
    FILENAME = 'C:\Semana10\Semana10.ldf',
    SIZE = 20MB,
    MAXSIZE = 200MB,
    FILEGROWTH = 5MB );
GO

-- se establece un espacio exclusivo para tempdb
ALTER DATABASE tempdb MODIFY FILE (NAME = tempdev, FILENAME = 'C:\Semana10_1\Semana10.mdf', SIZE = 2GB, FILEGROWTH = 100MB);
ALTER DATABASE tempdb MODIFY FILE (NAME = templog, FILENAME = 'C:\Semana10_1\Semana10.ldf', SIZE = 1GB, FILEGROWTH = 100MB);
GO



-- se crea la tabla empleados--
CREATE TABLE Empleados (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Cargo NVARCHAR(50),
    Departamento NVARCHAR(50),
    Salario DECIMAL(10,2)
);

-- se crea un indice para la optimizacion de la busqueda
CREATE INDEX IDX_Empleados_Departamento
ON Empleados (Departamento);

-- se define espacios exclusivos para almecanar indices 

ALTER DATABASE Semana10
ADD FILEGROUP Semana10_Indices;
GO

ALTER DATABASE Semana10
ADD FILE (
    NAME = Semana10_Indices,
    FILENAME = 'C:\SQLIndex\Semana10_Indices.ndf',
    SIZE = 100MB,
    MAXSIZE = 500MB,
    FILEGROWTH = 50MB
) 
GO
CREATE UNIQUE NONCLUSTERED INDEX IDX_Empleados_ID
ON Empleados (ID)
WITH (DATA_COMPRESSION = PAGE)
ON Semana10_Indices;

-- monitero del uso del espacio 
EXEC sp_spaceused;
EXEC sp_helpfile;

