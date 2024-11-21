CREATE DATABASE CNPM
GO
USE CNPM;
GO

-- Table: Admin
CREATE TABLE Admin (
    ID_Admin CHAR(10) NOT NULL PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(20) NOT NULL,
    Password CHAR(10) NOT NULL,
    SDT CHAR(10) NULL,
    Email CHAR(20) NULL
);
GO

-- Table: Bookings
CREATE TABLE Bookings (
    ID_TRIP CHAR(10) NOT NULL,
    ID_User CHAR(10) NOT NULL,
    So_luong_ve INT NOT NULL,
    Tong_tien INT NOT NULL,
    Trang_thai NVARCHAR(15) NULL,
    CONSTRAINT PK_Bookings PRIMARY KEY CLUSTERED (ID_TRIP ASC)
);
GO

-- Table: Location
CREATE TABLE Location (
    NameAddress NVARCHAR(20) NULL,
    Address NVARCHAR(30) NOT NULL,
    TOA_DO VARCHAR(30) NULL,
    CONSTRAINT PK_Location PRIMARY KEY CLUSTERED (Address ASC)
);
GO

-- Table: Payments
CREATE TABLE Payments (
    ID_DAT_CHO CHAR(10) NOT NULL,
    Phuong_Thanh_Toan NVARCHAR(15) NOT NULL,
    Ngay_Thanh_Toan DATE NOT NULL,
    Trang_thai NVARCHAR(10) NOT NULL,
    CONSTRAINT PK_Payments PRIMARY KEY CLUSTERED (ID_DAT_CHO ASC)
);
GO

-- Table: Phuong_thuc_thanh_toan
CREATE TABLE Phuong_thuc_thanh_toan (
    Ten_NH NCHAR(20) NOT NULL,
    Stk CHAR(10) NOT NULL,
    Ten_vi_DT NVARCHAR(10) NOT NULL,
    SDT CHAR(10) NOT NULL
);
GO

-- Table: Phuong_tien
CREATE TABLE Phuong_tien (
    SL_XE_4C INT NOT NULL,
    SL_XE_2C INT NULL
);
GO

-- Table: Trips
CREATE TABLE Trips (
    Diem_di NVARCHAR(40) NOT NULL,
    Diem_den NVARCHAR(40) NOT NULL,
    TG_KH DATETIME NOT NULL,
    TG_KT DATETIME NOT NULL,
    Gia_Ve INT NOT NULL,
    Trang_Thai NVARCHAR(15) NULL,
    CONSTRAINT PK_Trips PRIMARY KEY CLUSTERED (Diem_di ASC)
);
GO

-- Table: User
CREATE TABLE [User] (
    ID_User CHAR(10) NOT NULL PRIMARY KEY,
    Name NVARCHAR(30) NULL,
    Address NVARCHAR(40) NULL,
    SDT CHAR(10) NOT NULL,
    Email CHAR(20) NULL,
    UserName CHAR(20) NOT NULL,
    Password CHAR(15) NOT NULL,
    STK_NH CHAR(10) NOT NULL,
    Ten_NH CHAR(20) NOT NULL
);
GO

-- Table: Xe
CREATE TABLE Xe (
    BSX CHAR(12) NOT NULL PRIMARY KEY,
    TYPE_CAR NVARCHAR(15) NULL,
    HANG_XE NVARCHAR(15) NULL,
    NUMBER_OF_SEATS INT NOT NULL
);
GO
