use master;
if exists(select * from sys.databases where name = 'MyOA')
	drop database MyOA
go
create database MyOA
on primary 
(
	name=MyOA_Data,
	filename='D:\Sql\MSSQL12.MSSQLSERVER\MSSQL\DATA\MyOA_Data.mdf',
	size=5mb,
	maxsize=unlimited,
	filegrowth=10%
)
log on (
    name=MyOA_Log,
    filename='D:\Sql\MSSQL12.MSSQLSERVER\MSSQL\DATA\MyOA_Log.ldf',
    size=3MB,
    maxsize=20mb,
    filegrowth=1MB
)
go
use MyOA;

--用户表
create table Users(
	U_ID int primary key identity(1,1),		--用户ID
	U_Name nvarchar(50) not null,			--用户名称
	U_Account nvarchar(20) not null,		--用户账户
	U_Password nvarchar(25) not null,		--用户密码
	U_JobTitle nvarchar(50) not null		--用户职位
	--U_D_ID int not null					--用户所属部门
)
insert into Users values('默认系统管理员','admin','123','管理员')
					   ,('秦风','QingFeng','123','默认分案人')
					   ,('王洋','WangYang','123','默认分案人')
					   ,('宋阳','SongYang','123','主管')
					   ,('李明','LiMing','123','担当')


--流程执行人表
create table FlowExecutor(
	Fe_ID int primary key identity(1,1),	--ID
	Fe_F_ID int not null,					--流程ID
	Fe_U_Account nvarchar(20) not null		--执行人
)

--流程表(基本信息)
create table Flow(
	F_ID int primary key identity(1,1),				--流程ID
	F_Title nvarchar(50) not null,					--流程标题
	F_UrgencyLeavel int default(1) not null,		--流程紧急程度(1：正常,2：重要,3:紧急)
	F_U_ID int not null,							--流程申请用户
	F_State bit default(0) not null,				--流程状态
	F_FlowInstanceID nvarchar(100) not null,		--流程关联持久化ID
	F_CurrentInfo nvarchar(100) not null,			--流程当前信息
	F_CreateTime datetime not null,					--流程创建日期
	F_EndTime datetime								--流程截止日期
)

--流程记录表
create table FlowLog(
	Fl_ID int primary key identity(1,1),	--流程记录ID
	Fl_F_ID int not null,					--流程ID
	Fl_Date datetime not null,				--流程记录时间
	Fl_Title nvarchar(150) not null			--流程记录标题
)

select * from Flow as F join FlowExecutor as Fe on Fe.Fe_F_ID = F.F_ID join FlowLog as Fl on F.F_ID = Fl.FL_F_ID

select * from Flow where F_Title like '%分案%' and Datediff(d,F_CreateTime,'2020-03-04') = 0 and( Datediff(d,F_EndTime,'2020-03-04') = '0' or F_EndTime is null )

--案件表
create table LawCase(
	Lc_ID int primary key identity(1,1),	--案件ID
	Lc_Title nvarchar(50) not null,			--案件名称
	Lc_Allocate nvarchar(50),				--分案人
	Lc_Charge nvarchar(50),					--主管
	Lc_Undertake nvarchar(50)				--担当
)

insert into LawCase values('华为商标纠纷案',NULL,NULL,NULL)
						 ,('百度商标侵权案',NULL,NULL,NULL)
						 ,('百度商标侵权案2',NULL,NULL,NULL)
						 ,('百度商标侵权案3',NULL,NULL,NULL)
						 ,('百度商标侵权案4',NULL,NULL,NULL)
						 ,('百度商标侵权案5',NULL,NULL,NULL)

update LawCase set Lc_Charge = Null,Lc_Undertake = NULL

select * from LawCase

select @@identity