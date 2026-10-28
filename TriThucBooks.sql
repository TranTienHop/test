-- Database: TriThucBooks — Nhà sách mini Tri Thức Books
IF DB_ID(N'TriThucBooks') IS NULL
    CREATE DATABASE TriThucBooks;
GO

USE TriThucBooks;
GO

IF OBJECT_ID(N'dbo.TheLoaiSach', N'U') IS NOT NULL
    DROP TABLE dbo.TheLoaiSach;
GO

CREATE TABLE dbo.TheLoaiSach
(
    MaTL        INT IDENTITY(1,1) PRIMARY KEY,
    TenTheLoai  NVARCHAR(100) NOT NULL UNIQUE,
    MoTa        NVARCHAR(255) NULL,
    SoLuongSach INT NOT NULL CONSTRAINT DF_TheLoaiSach_SoLuongSach DEFAULT (0),
    NgayTao     DATETIME NOT NULL CONSTRAINT DF_TheLoaiSach_NgayTao DEFAULT (GETDATE())
);
GO

INSERT INTO dbo.TheLoaiSach (TenTheLoai, MoTa, SoLuongSach) VALUES
(N'Tiểu thuyết', N'Truyện dài hư cấu', 1),
(N'Kỹ năng sống', N'Sách phát triển bản thân', 15),
(N'Thiếu nhi', N'Sách dành cho trẻ em', 2),
(N'Sách giáo khoa', N'Sách học phổ thông', 2),
(N'Truyện tranh', N'Comic / manga', 1);
GO
