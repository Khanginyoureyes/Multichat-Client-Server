CREATE DATABASE MULTICHAT

USE MULTICHAT

CREATE TABLE NGUOIDUNG
(
	MAND VARCHAR(4) PRIMARY KEY,
	TENND NVARCHAR(30),
	NATIONALITY NVARCHAR(30),
	EMAIL NVARCHAR(MAX),
	MATKHAU VARCHAR(MAX),
	IMAGEUSER VARBINARY(MAX),
)
