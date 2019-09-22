USE [student]
GO

/****** Object:  Table [dbo].[Student]    Script Date: 9/22/2019 11:30:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [nvarchar](256) NULL,
	[StudentSurName] [nvarchar](256) NULL,
	[mr_mrs] [nvarchar](256) NULL,
	[StudentSchool] [nvarchar](256) NULL,
	[StudentBirthDate] [nvarchar](256) NULL,
	[StudentBirthPlace] [nvarchar](256) NULL,
	[StudentExtraInfo] [nvarchar](max) NULL,
	[Adres] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[PhoneNumber] [nvarchar](256) NULL,
	[CreateDate] [datetime] NULL CONSTRAINT [DF_Student_Create]  DEFAULT (getdate()),
	[StudentPrice] [int] NULL,
	[StudentRestPrice] [int] NULL,
	[Active] [bit] NOT NULL CONSTRAINT [DF_Student_Active]  DEFAULT ((1)),
	[StudentPapier] [bit] NOT NULL CONSTRAINT [DF_Student_StudentPapier]  DEFAULT ((0)),
	[AdresPLZ] [nvarchar](50) NULL,
	[AdresCity] [nvarchar](50) NULL,
 CONSTRAINT [PK__Student__3214EC07A0460A69] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


