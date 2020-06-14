CREATE TABLE "Users" (
	"id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"username"	TEXT NOT NULL UNIQUE,
	"password"	TEXT NOT NULL,
	"firstname"	TEXT NOT NULL,
	"lastname"	TEXT NOT NULL,
	"email" TEXT NOT NULL,
	"attempt"	INTEGER,
	"attemptdatetime"	TEXT,
	"createdatetime"	TEXT NOT NULL,
	"updatedatetime"	TEXT,
	"lastlogin"	TEXT
);