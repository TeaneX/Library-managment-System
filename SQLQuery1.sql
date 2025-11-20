create database Library_managment_system  

use Library_managment_system

create table Student
(
s_Id int PRIMARY KEY NOT NULL,
s_Name varchar (20) null,
s_Contact varchar (20) null,
s_Email varchar (20) null,
s_Birthday varchar (20) null,
s_Address varchar (20) null,
);

create table book
(
b_Id int primary key not null,
b_name varchar (30) null,
b_Author varchar (30) null,
b_publication varchar (30) null,
b_purchase varchar (30) null,
b_Price varchar (30) null,
b_quantity varchar (30) null,
);
drop table Return_Books 

create table Issue_Books 
(
s_Id int PRIMARY KEY NOT NULL,
s_Name varchar (20) null,
b_Id int NOt null,
b_name varchar (20) null,
b_Issue varchar (20) null,
b_End varchar (20) null,
FOREIGN KEY (s_Id) REFERENCES Student (s_Id),
FOREIGN KEY (b_Id) REFERENCES book (b_Id),
) ;

create table Return_Books 
(
s_Id int PRIMARY KEY NOT NULL,
s_Name varchar (20) null,
b_Id int NOt null,
b_name varchar (20) null,
b_Issue varchar (20) null,
b_Return varchar (20) null,
FOREIGN KEY (s_Id) REFERENCES Student (s_Id),
FOREIGN KEY (b_Id) REFERENCES book (b_Id),
) ;
