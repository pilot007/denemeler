DROP TABLE [dbo].[Student] 
DROP TABLE [dbo].[Student_Payments]

CREATE TABLE [dbo].[Student] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Adres]				   NVARCHAR (MAX) NULL,
    [Email]                NVARCHAR (256) NULL,
    [PhoneNumber]          NVARCHAR (256) NULL,
    [Create]			   DATETIME       NULL,
	[CreatedBy]			   NVARCHAR (256) NOT NULL,
    [StudentName]          NVARCHAR (256) NOT NULL,
	[StudentSurName]       NVARCHAR (256) NOT NULL,
	[StudentSchool]        NVARCHAR (256) NOT NULL,
	[StudentBirthDate]     NVARCHAR (256),
	[StudentBirthPlace]    NVARCHAR (256),
	[StudentExtraInfo]     NVARCHAR (MAX),
	[StudentPrice]		   INT,
	[StudentRestPrice]		   INT,
    [Active]			   BIT            NOT NULL,
    [StudentPapier]        BIT            NOT NULL,
    CONSTRAINT [PK_dbo.Student] PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE UNIQUE NONCLUSTERED INDEX [StudentIndex]
    ON [dbo].[Student]([ID] ASC);


CREATE TABLE [dbo].[Student_Payments] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [StudentId]            NVARCHAR (128) NOT NULL,
    [Create]			   DATETIME  NOT NULL,
	[Payment]			   INT NOT NULL,
	[CreatedBy]			   NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.Student_Payments] PRIMARY KEY CLUSTERED ([Id] ASC)
);
