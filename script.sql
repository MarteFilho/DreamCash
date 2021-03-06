CREATE TABLE "Admin" (
    "Id" uuid NOT NULL,
    "Email" text NULL,
    "Password" text NULL,
    CONSTRAINT "PK_Admin" PRIMARY KEY ("Id")
);

CREATE TABLE "User" (
    "Id" uuid NOT NULL,
    "Name" text NULL,
    "Document" text NULL,
    "Email" text NULL,
    "Password" text NULL,
    "Phone" text NULL,
    "Birthday" text NULL,
    "Sex" text NULL,
    "Address" text NULL,
    "AlertInvestments" boolean NOT NULL,
    "AlertTransfers" boolean NOT NULL,
    "AccountId" uuid NOT NULL,
    CONSTRAINT "PK_User" PRIMARY KEY ("Id")
);

CREATE TABLE "Account" (
    "Id" uuid NOT NULL,
    "Amount" bigint NOT NULL,
    "UserId" uuid NOT NULL,
    CONSTRAINT "PK_Account" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Account_User_UserId" FOREIGN KEY ("UserId") REFERENCES "User" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Investment" (
    "Id" uuid NOT NULL,
    "Type" text NULL,
    "Description" text NULL,
    "MinimumValue" bigint NOT NULL,
    "UserId" uuid NULL,
    CONSTRAINT "PK_Investment" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Investment_User_UserId" FOREIGN KEY ("UserId") REFERENCES "User" ("Id") ON DELETE RESTRICT
);

CREATE TABLE "Transaction" (
    "Id" uuid NOT NULL,
    "Name" text NULL,
    "UserId" uuid NOT NULL,
    "AccountId" uuid NOT NULL,
    "InvestimentId" uuid NOT NULL,
    "Value" numeric NOT NULL,
    "InvestimentDate" timestamp without time zone NOT NULL,
    "Status" text NULL,
    "Date" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_Transaction" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Transaction_Account_AccountId" FOREIGN KEY ("AccountId") REFERENCES "Account" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Transaction_Investment_InvestimentId" FOREIGN KEY ("InvestimentId") REFERENCES "Investment" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Transaction_User_UserId" FOREIGN KEY ("UserId") REFERENCES "User" ("Id") ON DELETE CASCADE
);

CREATE UNIQUE INDEX "IX_Account_UserId" ON "Account" ("UserId");

CREATE INDEX "IX_Investment_UserId" ON "Investment" ("UserId");

CREATE INDEX "IX_Transaction_AccountId" ON "Transaction" ("AccountId");

CREATE INDEX "IX_Transaction_InvestimentId" ON "Transaction" ("InvestimentId");

CREATE INDEX "IX_Transaction_UserId" ON "Transaction" ("UserId");


