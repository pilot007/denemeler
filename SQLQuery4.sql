USE [student]
GO

/****** Object:  Table [dbo].[setting]    Script Date: 9/22/2019 11:30:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[setting](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[value_name] [nvarchar](50) NOT NULL,
	[value_desc] [nvarchar](255) NOT NULL
) ON [PRIMARY]

GO


