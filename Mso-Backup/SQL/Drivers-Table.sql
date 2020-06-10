CREATE TABLE "Drivers" (
	"id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"pnpdeviceid"	TEXT NOT NULL,
	"model"	TEXT NOT NULL,
	"serialnumber"	TEXT NOT NULL,
	"driveletter"	TEXT NOT NULL,
	"size"	INTEGER NOT NULL,
	"freespace"	INTEGER NOT NULL,
	"state"	INTEGER,
	"createdatetime"	TEXT NOT NULL,
	"updatedatetime"	TEXT,
	"deletedatetime"	TEXT,
	"userid"	INTEGER NOT NULL
);