SET IDENTITY_INSERT [dbo].[Banch] ON
INSERT INTO [dbo].[Banch] ([BranchID], [BranchName], [Address], [OpeningTime], [CloseingTime]) VALUES (1, N'Auckland', N'Takanini Auckland', N'2021-01-27 08:00:00', N'2021-01-27 17:00:00')
INSERT INTO [dbo].[Banch] ([BranchID], [BranchName], [Address], [OpeningTime], [CloseingTime]) VALUES (2, N'Chrishchurch', N'83 waterside Dr', N'2021-01-27 09:00:00', N'2021-01-27 17:00:00')
INSERT INTO [dbo].[Banch] ([BranchID], [BranchName], [Address], [OpeningTime], [CloseingTime]) VALUES (3, N'Wellington', N'55 maitland street', N'2021-01-27 08:00:00', N'2021-01-27 16:00:00')
INSERT INTO [dbo].[Banch] ([BranchID], [BranchName], [Address], [OpeningTime], [CloseingTime]) VALUES (4, N'Thames', N'34 tearoha', N'2021-01-27 09:30:00', N'2021-01-27 17:00:00')
SET IDENTITY_INSERT [dbo].[Banch] OFF

SET IDENTITY_INSERT [dbo].[BikeSale] ON
INSERT INTO [dbo].[BikeSale] ([ID], [PurchaserID], [BanchID]) VALUES (1, 1, 1)
INSERT INTO [dbo].[BikeSale] ([ID], [PurchaserID], [BanchID]) VALUES (2, 2, 2)
INSERT INTO [dbo].[BikeSale] ([ID], [PurchaserID], [BanchID]) VALUES (3, 3, 3)
INSERT INTO [dbo].[BikeSale] ([ID], [PurchaserID], [BanchID]) VALUES (4, 1, 4)
SET IDENTITY_INSERT [dbo].[BikeSale] OFF

SET IDENTITY_INSERT [dbo].[Purchaser] ON
INSERT INTO [dbo].[Purchaser] ([PurchaserID], [FirstName], [LastName], [Address], [Phone], [DOB]) VALUES (1, N'Denny', N'Emmy', N'83 waterside Dr', N'0221007473', N'9/07/1999')
INSERT INTO [dbo].[Purchaser] ([PurchaserID], [FirstName], [LastName], [Address], [Phone], [DOB]) VALUES (2, N'Pari', N'jenny', N'10 te aroha street', N'0213456789', N'3/05/1998')
INSERT INTO [dbo].[Purchaser] ([PurchaserID], [FirstName], [LastName], [Address], [Phone], [DOB]) VALUES (3, N'Rose', N'Mary', N'33 memorial drive', N'0223456787', N'9/10/1992')
INSERT INTO [dbo].[Purchaser] ([PurchaserID], [FirstName], [LastName], [Address], [Phone], [DOB]) VALUES (4, N'kerall', N'Murry', N'84 Lakeroad', N'0223452435', N'1/01/2000')
SET IDENTITY_INSERT [dbo].[Purchaser] OFF

SET IDENTITY_INSERT [dbo].[SaleMan] ON
INSERT INTO [dbo].[SaleMan] ([SaleManId], [SaleManName], [BikeAmount], [SaleDate]) VALUES (1, N'Manik', 30000, N'2021-01-27 00:00:00')
INSERT INTO [dbo].[SaleMan] ([SaleManId], [SaleManName], [BikeAmount], [SaleDate]) VALUES (2, N'Joy', 40000, N'2021-01-07 00:00:00')
INSERT INTO [dbo].[SaleMan] ([SaleManId], [SaleManName], [BikeAmount], [SaleDate]) VALUES (3, N'Ammy', 20000, N'2021-01-12 00:00:00')
INSERT INTO [dbo].[SaleMan] ([SaleManId], [SaleManName], [BikeAmount], [SaleDate]) VALUES (4, N'Jack', 35000, N'2021-01-16 00:00:00')
SET IDENTITY_INSERT [dbo].[SaleMan] OFF

