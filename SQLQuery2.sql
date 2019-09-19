CREATE TABLE [dbo].[Student] (
    [Id]                    int NOT NULL ,
    [Adres]				   NVARCHAR (MAX) NULL,
    [Email]                NVARCHAR (256) NULL,
    [PhoneNumber]          NVARCHAR (256) NULL,
    [Create]			   DATETIME       NULL,
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
    PRIMARY KEY (Id));

CREATE TABLE [dbo].[Student_Payments] (
    [Id]                    int NOT NULL,
    [StudentId]            NVARCHAR (128) NOT NULL,
    [Create]			   DATETIME  NOT NULL,
	[Payment]			   INT NOT NULL,
    PRIMARY KEY (Id)
);
