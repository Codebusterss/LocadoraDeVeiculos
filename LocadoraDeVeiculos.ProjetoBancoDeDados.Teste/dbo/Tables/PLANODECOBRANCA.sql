﻿CREATE TABLE [dbo].[PLANODECOBRANCA] (
    [ID]                 UNIQUEIDENTIFIER NOT NULL,
    [GRUPODEVEICULOS_ID] UNIQUEIDENTIFIER NOT NULL,
    [DIARIOVALORDIA]     FLOAT (53)       NOT NULL,
    [DIARIOVALORKM]      FLOAT (53)       NOT NULL,
    [LIVREVALORDIA]      FLOAT (53)       NOT NULL,
    [CONTROLADOVALORDIA] FLOAT (53)       NOT NULL,
    [CONTROLADOLIMITEKM] FLOAT (53)       NOT NULL,
    [CONTROLADOVALORKM]  FLOAT (53)       NOT NULL,
    CONSTRAINT [PK_PLANODECOBRANCA_1] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_PLANODECOBRANCA_GRUPODEVEICULOS] FOREIGN KEY ([GRUPODEVEICULOS_ID]) REFERENCES [dbo].[GRUPODEVEICULOS] ([ID])
);

