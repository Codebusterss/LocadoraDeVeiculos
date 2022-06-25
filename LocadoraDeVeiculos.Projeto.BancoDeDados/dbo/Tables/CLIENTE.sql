﻿CREATE TABLE [dbo].[CLIENTE] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [NOME]        VARCHAR (300) NOT NULL,
    [CPF]         VARCHAR (300) NULL,
    [CNPJ]        VARCHAR (300) NULL,
    [ENDERECO]    VARCHAR (300) NOT NULL,
    [CNH]         VARCHAR (300) NULL,
    [TELEFONE]    VARCHAR (300) NOT NULL,
    [TIPOCLIENTE] BIT           NOT NULL,
    [EMAIL]       VARCHAR (300)  NOT NULL, 
    CONSTRAINT [PK_CLIENTE] PRIMARY KEY CLUSTERED ([ID] ASC)
);

