﻿CREATE TABLE [dbo].[CONDUTOR] (
    [ID]              UNIQUEIDENTIFIER NOT NULL,
    [NOME]            VARCHAR (MAX)    NOT NULL,
    [CPF]             VARCHAR (MAX)    NOT NULL,
    [CNH]             VARCHAR (MAX)    NOT NULL,
    [VALIDADECNH]     DATETIME         NOT NULL,
    [TELEFONE]        VARCHAR (MAX)    NOT NULL,
    [EMAIL]           VARCHAR (MAX)    NOT NULL,
    [ENDERECO]        VARCHAR (MAX)    NOT NULL,
    [CONDUTORCLIENTE] BIT              NOT NULL,
    [CLIENTE_ID]      UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_CONDUTOR_1] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_CONDUTOR_CLIENTE] FOREIGN KEY ([CLIENTE_ID]) REFERENCES [dbo].[CLIENTE] ([ID])
);

