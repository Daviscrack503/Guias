

SELECT [Id]
      ,[Nombre]
      ,[Apellido]
      ,[Foto]
  FROM [dbo].[empleados]

  INSERT INTO [dbo].[empleados]
           ([Nombre]
           ,[Apellido]
           ,[Foto])
     VALUES
           ('David'
           ,'Estrada'
           ,'XD')

UPDATE [dbo].[empleados]
   SET [Nombre] = 'Davis'
      ,[Apellido] = 'Guevara'
      ,[Foto] = 'XD'
 WHERE id = 1


DELETE FROM [dbo].[empleados]
      WHERE id = 1