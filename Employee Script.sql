USE [EmployeeDB]
GO
/****** Object:  Table [dbo].[department]    Script Date: 10-05-2023 20:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[department](
	[departmentId] [int] IDENTITY(1,1) NOT NULL,
	[departmentName] [varchar](50) NULL,
 CONSTRAINT [PK_department] PRIMARY KEY CLUSTERED 
(
	[departmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 10-05-2023 20:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[employeeId] [int] IDENTITY(1000,1) NOT NULL,
	[departmentId] [int] NOT NULL,
	[employeeName] [varchar](30) NOT NULL,
	[age] [int] NOT NULL,
	[salary] [float] NOT NULL,
 CONSTRAINT [PK_employeeNew] PRIMARY KEY CLUSTERED 
(
	[employeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[department] ON 
GO
INSERT [dbo].[department] ([departmentId], [departmentName]) VALUES (1, N'IT')
GO
INSERT [dbo].[department] ([departmentId], [departmentName]) VALUES (2, N'HR')
GO
INSERT [dbo].[department] ([departmentId], [departmentName]) VALUES (4, N'Account')
GO
SET IDENTITY_INSERT [dbo].[department] OFF
GO
SET IDENTITY_INSERT [dbo].[employee] ON 
GO
INSERT [dbo].[employee] ([employeeId], [departmentId], [employeeName], [age], [salary]) VALUES (1001, 2, N'RITESH SHINDE', 25, 25000)
GO
INSERT [dbo].[employee] ([employeeId], [departmentId], [employeeName], [age], [salary]) VALUES (1002, 4, N'RAVI', 24, 30000)
GO
SET IDENTITY_INSERT [dbo].[employee] OFF
GO
ALTER TABLE [dbo].[employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([departmentId])
REFERENCES [dbo].[department] ([departmentId])
GO
ALTER TABLE [dbo].[employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[employee]  WITH CHECK ADD  CONSTRAINT [CK_AgeRange] CHECK  (([age]>=(21) AND [age]<=(100)))
GO
ALTER TABLE [dbo].[employee] CHECK CONSTRAINT [CK_AgeRange]
GO
