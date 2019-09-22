USE [student]
GO

/****** Object:  Table [dbo].[student_files]    Script Date: 9/22/2019 11:30:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[student_files](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[studentId] [int] NOT NULL,
	[filepath] [nvarchar](250) NOT NULL,
	[create_date] [date] NULL,
	[fileName] [nvarchar](50) NULL,
	[fileNameOld] [nvarchar](50) NULL,
 CONSTRAINT [PK_student_files] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


