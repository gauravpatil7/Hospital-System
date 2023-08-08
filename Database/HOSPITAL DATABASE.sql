﻿USE MASTER
GO
-----------
DROP DATABASE HOSPITAL
GO

CREATE DATABASE HOSPITAL
GO

use HOSPITAL

-----------

DROP TABLE APPONTMENTS
DROP TABLE DOCTORS
DROP TABLE HOSPITAL
DROP TABLE USERS

-----------
create table HOSPITAL(
HOSPITALID INT CONSTRAINT PK_HOSPITALID PRIMARY KEY,
HOSPITALNAME varchar(50) NOT NULL,
HOSPITALADDRESS VARCHAR(50) NOT NULL,
CONTACT BIGINT NOT NULL,
HOSPITALIMAGE VARCHAR(50) CONSTRAINT HI_DEFAULT DEFAULT '../../'
)
GO

CREATE TABLE DOCTORS(
DID INT CONSTRAINT PK_DID PRIMARY KEY,
DNAME VARCHAR(30) NOT NULL,
DEGREE VARCHAR(10) NOT NULL,
EXPERIENCE TINYINT DEFAULT 0,
WORKSIN INT CONSTRAINT FK_WORKSIN REFERENCES HOSPITAL(HOSPITALID),
DIMAGE VARCHAR(20) DEFAULT '../../../'
)
GO


CREATE TABLE USERS(
MAILID VARCHAR(30) CONSTRAINT PK_MAIL PRIMARY KEY,
USERNAME VARCHAR(20) NOT NULL,
GENDER VARCHAR(6) NOT NULL CONSTRAINT CK_GENDER CHECK (GENDER IN('MALE', 'FEMALE')) ,  ------CHECK MALE OR FEMALE
PASTPROBLEMS VARCHAR(50),
CONTACTUMBER BIGINT NOT NULL,
USERADDRESS VARCHAR(50) NOT NULL,
)
GO

CREATE TABLE APPONTMENTS(
APPONTMENTID INT CONSTRAINT PK_APPONTMENTID PRIMARY KEY,
HOSPITALID INT CONSTRAINT FK_HOSPITALID REFERENCES HOSPITAL(HOSPITALID),
USERID VARCHAR(30) CONSTRAINT FK_USERID REFERENCES USERS(MAILID),
DOCTORID INT CONSTRAINT FK_DOCTORID REFERENCES DOCTORS(DID),
APPOINTMENTTIME DATETIME CONSTRAINT CK_DATETIME CHECK (APPOINTMENTTIME >= GETDATE())
)
GO


INSERT INTO HOSPITAL VALUES (1001,'PATIL HOSPITAL','HINJEWADI PUNE', 1234567890, '../../../PATILHOSPITAL.JPG')
INSERT INTO HOSPITAL VALUES (1002,'APPLE HOSPITAL','WAKAD BRIDGE PUNE', 7865467890, '../../../PATILHOSPITAL.JPG')
INSERT INTO HOSPITAL VALUES (1003,'SANCHETI HOSPITAL','SHIVAJI NAGAR PUNE', 9876543212, '../../../PATILHOSPITAL.JPG')
INSERT INTO HOSPITAL VALUES (1004,'RUBY HOSPITAL','DANGE CHOWK PUNE', 8796543267, '../../../PATILHOSPITAL.JPG')
INSERT INTO HOSPITAL VALUES (1005,'AMRUTA CLINIC','PRAKASH TALKIES DHULE', 9087890987, '../../../PATILHOSPITAL.JPG')
GO

INSERT INTO DOCTORS VALUES (101,'Vidyu Gaurav Patil',    'MBBS', 2,    1001,'../../../vidyu.jpg')
INSERT INTO DOCTORS VALUES (102,'Shailesh Ramlal Deore', 'MRD',  4,    1002,'../../../vidyu.jpg')
INSERT INTO DOCTORS VALUES (103,'Devendra Nagraj Patil', 'MBBS', 8,    1002,'../../../vidyu.jpg')
INSERT INTO DOCTORS VALUES (104,'Hitesh Patil',          'MBBS', 10,   1003,'../../../vidyu.jpg')
INSERT INTO DOCTORS VALUES (105,'Amol Wagh',             'MBBS', 19,   1004,'../../../vidyu.jpg')
INSERT INTO DOCTORS VALUES (106,'Akshay  Girase',        'MBBS', null, 1005,'../../../vidyu.jpg')
GO


INSERT INTO USERS VALUES ('GAURAVPATIL2360@GMAIL.COM','Gaurav Patil'   ,'MALE',   'HEART DESEASE', 8788874025, 'NEAR SHIVAJI MAHARAJ STATUE, FAGNE')
INSERT INTO USERS VALUES ('abcd@gmail.COM'           ,'Jack Martin'    ,'FEMALE', 'HEART DESEASE', 8788874025, 'NEAR SHIVAJI MAHARAJ STATUE, FAGNE')
INSERT INTO USERS VALUES ('gcfsucyfc@GMAIL.COM'      ,'Gitesh Pawar'   ,'MALE',   'HEART DESEASE', 8788874025, 'NEAR SHIVAJI MAHARAJ STATUE, FAGNE')
INSERT INTO USERS VALUES ('kajalagrawal@GMAIL.COM'   ,'Kamlesh Gel'    ,'MALE',   'HEART DESEASE', 8788874025, 'NEAR SHIVAJI MAHARAJ STATUE, FAGNE')
INSERT INTO USERS VALUES ('deorenilesh232@GMAIL.COM'  ,'lAKIRCHAND Ojha','MALe',  'HEART DESEASE', 8788874025, 'NEAR SHIVAJI MAHARAJ STATUE, FAGNE')
INSERT INTO USERS VALUES ('noneofjacck@GMAIL.COM'    ,'Rakesh Mahajan' ,'MALE', 'HEART DESEASE', 8788874025, 'NEAR SHIVAJI MAHARAJ STATUE, FAGNE')
INSERT INTO USERS VALUES ('masterofall@GMAIL.COM'    ,'Master Of All'  ,'MALE', 'HEART DESEASE', 8788874025, 'NEAR SHIVAJI MAHARAJ STATUE, FAGNE')
INSERT INTO USERS VALUES ('makeshurebeloved@GMAIL.COM','Mukesh Loved'  ,'MALE', 'HEART DESEASE', 8788874025, 'NEAR SHIVAJI MAHARAJ STATUE, FAGNE')
INSERT INTO USERS VALUES ('ajitbhamare5678@GMAIL.COM','Ajit Bhamare'   ,'MALE', 'HEART DESEASE', 8788874025, 'NEAR SHIVAJI MAHARAJ STATUE, FAGNE')
GO

INSERT INTO APPONTMENTS VALUES (10001, 1001, 'GAURAVPATIL2360@GMAIL.COM', 101, (CAST('2023-10-03 15:32:06' AS DateTime)))
INSERT INTO APPONTMENTS VALUES (10002, 1004, 'ajitbhamare5678@GMAIL.COM', 102, (CAST('2023-10-04 15:32:06' AS DateTime)))
INSERT INTO APPONTMENTS VALUES (10003, 1003, 'deorenilesh23@GMAIL.COM', 103, (CAST('2023-10-05 15:32:06' AS DateTime)))
INSERT INTO APPONTMENTS VALUES (10004, 1002, 'noneofjacck@GMAIL.COM', 104, (CAST('2023-10-06 15:32:06' AS DateTime)))
INSERT INTO APPONTMENTS VALUES (10005, 1001, 'masterofall@GMAIL.COM', 105, (CAST('2023-10-12 15:32:06' AS DateTime)))
INSERT INTO APPONTMENTS VALUES (10006, 1004, 'gcfsucyfc@GMAIL.COM', 103, (CAST('2023-10-03 25:32:06' AS DateTime)))
INSERT INTO APPONTMENTS VALUES (10007, 1002, 'kajalagrawal@GMAIL.COM', 104, (CAST('2023-10-13 15:32:06' AS DateTime)))
GO

------------------------------------------------------------


select * from HOSPITAL
select * from USERS
select * from DOCTORS
select * from APPONTMENTS