USE [student]
GO

/****** Object:  Table [dbo].[Student_Payments]    Script Date: 9/22/2019 11:30:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student_Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[CreateDate] [datetime] NULL CONSTRAINT [DF_Student_Payments_Create]  DEFAULT (getdate()),
	[Payment] [int] NULL,
	[PaymentDesc] [nvarchar](255) NULL,
	[isDeleted] [bit] NOT NULL CONSTRAINT [DF_Student_Payments_isDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK__Student___3214EC07EB347E07] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


