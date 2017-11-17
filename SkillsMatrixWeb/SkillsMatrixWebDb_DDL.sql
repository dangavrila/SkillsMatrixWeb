IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Employees] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Telephone] nvarchar(max) NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Projects] (
    [Id] int NOT NULL IDENTITY,
    [Deadline] datetime2 NOT NULL,
    [HoursNeed] int NOT NULL,
    [IsOpen] bit NOT NULL,
    [Location] nvarchar(max) NULL,
    [MinimumSkillLevel] int NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Technologies] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Version] nvarchar(max) NULL,
    CONSTRAINT [PK_Technologies] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Skills] (
    [Id] int NOT NULL IDENTITY,
    [EmployeeId] int NOT NULL,
    [LastYearUsed] int NOT NULL,
    [Level] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [NoOfYears] int NOT NULL,
    [Remarks] nvarchar(max) NULL,
    CONSTRAINT [PK_Skills] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Skills_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Seats] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [PositionName] nvarchar(max) NULL,
    [ProjectId] int NOT NULL,
    CONSTRAINT [PK_Seats] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Seats_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [TechnologysInSkills] (
    [TechnologyId] int NOT NULL,
    [SkillId] int NOT NULL,
    CONSTRAINT [PK_TechnologysInSkills] PRIMARY KEY ([TechnologyId], [SkillId]),
    CONSTRAINT [FK_TechnologysInSkills_Skills_SkillId] FOREIGN KEY ([SkillId]) REFERENCES [Skills] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TechnologysInSkills_Technologies_TechnologyId] FOREIGN KEY ([TechnologyId]) REFERENCES [Technologies] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [JobHistories] (
    [Id] int NOT NULL IDENTITY,
    [Capacity] real NOT NULL,
    [EndDate] datetime2 NULL,
    [SeatId] int NOT NULL,
    [Startdate] datetime2 NOT NULL,
    CONSTRAINT [PK_JobHistories] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_JobHistories_Seats_SeatId] FOREIGN KEY ([SeatId]) REFERENCES [Seats] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [TechnologyStacks] (
    [Id] int NOT NULL IDENTITY,
    [Details] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [SeatId] int NOT NULL,
    CONSTRAINT [PK_TechnologyStacks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TechnologyStacks_Seats_SeatId] FOREIGN KEY ([SeatId]) REFERENCES [Seats] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [EmployeeJobHistories] (
    [EmployeeId] int NOT NULL,
    [JobHistoryId] int NOT NULL,
    CONSTRAINT [PK_EmployeeJobHistories] PRIMARY KEY ([EmployeeId], [JobHistoryId]),
    CONSTRAINT [FK_EmployeeJobHistories_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_EmployeeJobHistories_JobHistories_JobHistoryId] FOREIGN KEY ([JobHistoryId]) REFERENCES [JobHistories] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [TechnologiesInTechnologiesStacks] (
    [TechnologyId] int NOT NULL,
    [TechnologyStackId] int NOT NULL,
    CONSTRAINT [PK_TechnologiesInTechnologiesStacks] PRIMARY KEY ([TechnologyId], [TechnologyStackId]),
    CONSTRAINT [FK_TechnologiesInTechnologiesStacks_Technologies_TechnologyId] FOREIGN KEY ([TechnologyId]) REFERENCES [Technologies] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TechnologiesInTechnologiesStacks_TechnologyStacks_TechnologyStackId] FOREIGN KEY ([TechnologyStackId]) REFERENCES [TechnologyStacks] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_EmployeeJobHistories_JobHistoryId] ON [EmployeeJobHistories] ([JobHistoryId]);

GO

CREATE INDEX [IX_JobHistories_SeatId] ON [JobHistories] ([SeatId]);

GO

CREATE INDEX [IX_Seats_ProjectId] ON [Seats] ([ProjectId]);

GO

CREATE INDEX [IX_Skills_EmployeeId] ON [Skills] ([EmployeeId]);

GO

CREATE INDEX [IX_TechnologiesInTechnologiesStacks_TechnologyStackId] ON [TechnologiesInTechnologiesStacks] ([TechnologyStackId]);

GO

CREATE INDEX [IX_TechnologysInSkills_SkillId] ON [TechnologysInSkills] ([SkillId]);

GO

CREATE INDEX [IX_TechnologyStacks_SeatId] ON [TechnologyStacks] ([SeatId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170921213638_InitialUpdate', N'2.0.0-rtm-26452');

GO

