--Datos de Inicio
--Rol
insert into [dbo].[SystemRole] (Name,Description,Enabled) values ('Administrador','Superusuario',1)
--Compania
insert into [dbo].[Company] (Name,ContactName,ContactLastName,CreationDate,Enabled,InitialDate,Email,Website)
values ('GbSoftware','Nicolas','Blasco',getdate(),1,null,'nblasco@gbsoftware.com.ar','www.gbsoftware.com.ar');

--Rol Compania
insert into [dbo].[SecurityRole] (Name,Description,Enabled,CompanyId,SystemRoleId)
values ('Administrador','Superusuario',1,1,1)

--Usuario
--El usuario se da de alta cuando se loguea con  nblasco@gbsoftware.com.ar y Sofre673
--Una vez Logueado Ejecutar el paseo 2