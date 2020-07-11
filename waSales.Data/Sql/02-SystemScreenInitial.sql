SET IDENTITY_INSERT SystemScreen ON
INSERT [dbo].[SystemScreen] ([Id], [Description], [Enabled], [IsDefault], [ParentId], [Orden], [Entity], [Path], [Icon]) VALUES (1, N'Menú', 1, 1, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[SystemScreen] ([Id], [Description], [Enabled], [IsDefault], [ParentId], [Orden], [Entity], [Path], [Icon]) VALUES (2, N'Configuraciones', 1, 1, NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[SystemScreen] ([Id], [Description], [Enabled], [IsDefault], [ParentId], [Orden], [Entity], [Path], [Icon]) VALUES (3, N'SYS', 1, 1, NULL, 3, NULL, NULL, NULL)
INSERT [dbo].[SystemScreen] ([Id], [Description], [Enabled], [IsDefault], [ParentId], [Orden], [Entity], [Path], [Icon]) VALUES (9, N'Tipificaciones', 1, 1, 2, 1, NULL, NULL, N'mdi mdi-keyboard')
INSERT [dbo].[SystemScreen] ([Id], [Description], [Enabled], [IsDefault], [ParentId], [Orden], [Entity], [Path], [Icon]) VALUES (24, N'Perfiles', 1, 1, 2, 2, NULL, NULL, N'mdi mdi-lock')
INSERT [dbo].[SystemScreen] ([Id], [Description], [Enabled], [IsDefault], [ParentId], [Orden], [Entity], [Path], [Icon]) VALUES (25, N'Roles', 1, 1, 24, 1, N'SecurityRole', N'/security/role', NULL)
INSERT [dbo].[SystemScreen] ([Id],  [Description], [Enabled], [IsDefault], [ParentId], [Orden], [Entity], [Path], [Icon]) VALUES (26, N'Usuarios', 1, 1, 24, 2, N'SecurityUser', N'/security/user', NULL)
INSERT [dbo].[SystemScreen] ( [Id], [Description], [Enabled], [IsDefault], [ParentId], [Orden], [Entity], [Path], [Icon]) VALUES (27, N'Sistema', 1, 1, 2, 3, NULL, N'/system', N'mdi mdi-settings-box')
INSERT [dbo].[SystemScreen] ([Id], [Description], [Enabled], [IsDefault], [ParentId], [Orden], [Entity], [Path], [Icon]) VALUES (28, N'Configuraciones', 1, 1, 3, 1, NULL, N'/system/configuration', N'mdi mdi-apps')
INSERT [dbo].[SystemScreen] ([Id], [Description], [Enabled], [IsDefault], [ParentId], [Orden], [Entity], [Path], [Icon]) VALUES (41, N'Empresas', 1, 1, 3, 2, NULL, N'/system/companies', N'mdi mdi-city-variant-outline')
SET IDENTITY_INSERT SystemScreen OFF

SET IDENTITY_INSERT ConfigScreen ON
insert into ConfigScreen (Id,CompanyId,SystemScreenId,Description,Enabled,Orden,Icon) values (1,1,1, N'Menú',1,1,null)
insert into ConfigScreen (Id,CompanyId,SystemScreenId,Description,Enabled,Orden,Icon) values (2,1,2, N'Configuraciones',1,2,null)
insert into ConfigScreen (Id,CompanyId,SystemScreenId,Description,Enabled,Orden,Icon) values (3,1,3, N'SYS',1,3,null)
insert into ConfigScreen (Id,CompanyId,SystemScreenId,Description,Enabled,Orden,Icon) values (4,1,9,  N'Tipificaciones',1,1,N'mdi mdi-keyboard')
insert into ConfigScreen (Id,CompanyId,SystemScreenId,Description,Enabled,Orden,Icon) values (5,1,24, N'Perfiles',1,2,N'mdi mdi-lock')
insert into ConfigScreen (Id,CompanyId,SystemScreenId,Description,Enabled,Orden,Icon) values (6,1,25, N'Roles',1,1,null)
insert into ConfigScreen (Id,CompanyId,SystemScreenId,Description,Enabled,Orden,Icon) values (7,1,26, N'Usuarios',1,2,null)
insert into ConfigScreen (Id,CompanyId,SystemScreenId,Description,Enabled,Orden,Icon) values (8,1,27, N'Sistema',1,3, N'mdi mdi-settings-box')
insert into ConfigScreen (Id,CompanyId,SystemScreenId,Description,Enabled,Orden,Icon) values (9,1,28, N'Configuraciones',1,1, N'mdi mdi-apps')
insert into ConfigScreen (Id,CompanyId,SystemScreenId,Description,Enabled,Orden,Icon) values (10,1,41, N'Empresas',1,2, N'mdi mdi-city-variant-outline')
SET IDENTITY_INSERT ConfigScreen OFF


insert into SystemRoleScreen (SystemScreenId,SystemRoleId) values (1,1)
insert into SystemRoleScreen (SystemScreenId,SystemRoleId) values (2,1)
insert into SystemRoleScreen (SystemScreenId,SystemRoleId) values (3,1)
insert into SystemRoleScreen (SystemScreenId,SystemRoleId) values (9,1)
insert into SystemRoleScreen (SystemScreenId,SystemRoleId) values (24,1)
insert into SystemRoleScreen (SystemScreenId,SystemRoleId) values (25,1)
insert into SystemRoleScreen (SystemScreenId,SystemRoleId) values (26,1)
insert into SystemRoleScreen (SystemScreenId,SystemRoleId) values (27,1)
insert into SystemRoleScreen (SystemScreenId,SystemRoleId) values (28,1)
insert into SystemRoleScreen (SystemScreenId,SystemRoleId) values (41,1)


insert into SecurityRoleScreen (SecurityRoleId, ConfigScreenId) values (1,1)
insert into SecurityRoleScreen (SecurityRoleId, ConfigScreenId) values (1,2)
insert into SecurityRoleScreen (SecurityRoleId, ConfigScreenId) values (1,3)
insert into SecurityRoleScreen (SecurityRoleId, ConfigScreenId) values (1,4)
insert into SecurityRoleScreen (SecurityRoleId, ConfigScreenId) values (1,5)
insert into SecurityRoleScreen (SecurityRoleId, ConfigScreenId) values (1,6)
insert into SecurityRoleScreen (SecurityRoleId, ConfigScreenId) values (1,7)
insert into SecurityRoleScreen (SecurityRoleId, ConfigScreenId) values (1,8)
insert into SecurityRoleScreen (SecurityRoleId, ConfigScreenId) values (1,9)
insert into SecurityRoleScreen (SecurityRoleId, ConfigScreenId) values (1,10)

