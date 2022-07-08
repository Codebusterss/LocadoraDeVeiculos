﻿CREATE TABLE [dbo].[PLANODECOBRANCA] (
    [ID]                 INT        IDENTITY (1, 1) NOT NULL,
    [GRUPODEVEICULOS_ID] INT        NOT NULL,
    [DIARIOVALORDIA]     FLOAT (53) NOT NULL,
    [DIARIOVALORKM]      FLOAT (53) NOT NULL,
    [LIVREVALORDIA]      FLOAT (53) NOT NULL,
    [CONTROLADOVALORDIA] FLOAT (53) NOT NULL,
    [CONTROLADOLIMITEKM] FLOAT (53) NOT NULL,
    [CONTROLADOVALORKM]  FLOAT (53) NOT NULL,
    CONSTRAINT [PK_PLANODECOBRANCA] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_PLANODECOBRANCA_GRUPODEVEICULOS] FOREIGN KEY ([ID]) REFERENCES [dbo].[GRUPODEVEICULOS] ([ID])
);
