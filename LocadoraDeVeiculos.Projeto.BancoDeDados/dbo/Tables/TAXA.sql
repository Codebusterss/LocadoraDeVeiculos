﻿CREATE TABLE [dbo].[TAXA] (
    [ID]        UNIQUEIDENTIFIER NOT NULL,
    [VALOR]     FLOAT (53)       NOT NULL,
    [DESCRICAO] VARCHAR (300)    NOT NULL,
    [TIPO]      VARCHAR (10)     NOT NULL,
    CONSTRAINT [PK_TAXA_1] PRIMARY KEY CLUSTERED ([ID] ASC)
);

