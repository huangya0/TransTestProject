
---20190403: 加入对Common_Authen_User维护的菜单与分配权限给予admin
INSERT [dbo].[Common_SiteMap_Menu] ([MenuID], [ParentID], [ResourceKey], [Area], [Controller], [ActionName], [RouteValues], [IsSkip], [DisplayOrder], [IsShow]) VALUES (11, 4, N'User Maint', NULL, N'VmTblUsers', N'Index', NULL, 0, 4, 1)

INSERT [dbo].[Common_Authen_ControllerActions] ([ID], [PermissionLevelID], [Area], [Controller], [ActionName], [HasActionPermission], [Description]) VALUES (1001012, 10010, N'', N'VmTblUsers', N'', 0, N'Admin')