create database House
use House
go
--�û���
create table Userd
(
UserID int identity(1,1) primary key not null,--���
UserName nvarchar(20) not null,--����
UserSex int default(0),--�Ա�0Ϊ�У�1ΪŮ
UserPhone nvarchar(20) not null,--�绰
UserLoginName nvarchar(50) not null,--��¼��
UserPassword nvarchar(50) not null,--����
[Role] int ,--��ɫ 0��ͨ�û� 1��������Ա
UState int default(0),--״̬��0Ĭ�ϴ���
)
--���۱�
create table Salesman
(
SalesmanID int identity(1,1) primary key not null,--���
SalesmanName nvarchar(20) not null,--����
SalesmanSex int default(0),--�Ա�0Ϊ�У�1ΪŮ
SalesmanPhone nvarchar(20) not null,--�绰
SalesmanLoginName nvarchar(50) not null,--��¼��
SalesmanPassword nvarchar(50) not null,--����
SalesmanPhoto nvarchar(20),--����ͷ��
UState int default(0),--״̬��0Ĭ�ϴ���
)

--������Ϣ��
create table Sell
(
SellID int identity(1,1) primary key not null,--���
SellAddress nvarchar(50),--���ڳ���
SellVillage nvarchar(50),--����С��
SellFloor int,--¥��
SellArea  nvarchar(20),--���
SellAreaTo nvarchar(20),--ʵ�����
SellPrice nvarchar(20),--ÿƽ�۸�
SellPriceTo nvarchar(20),--�ܼ۸�
SellAType nvarchar(20),--�������ͣ������ṹ��
SellBStructure nvarchar(20),--�����ṹ���ֻ�ṹ��
SellHStructurechar nvarchar(20),--�������ͣ�3��1����
SellRenovation nvarchar(20),--װ�����
SellScale nvarchar(20),--�ݻ������1��1����
SellHeating nvarchar(20),--��ů��ʽ
SellOrientation nvarchar(20),--���ݳ���
SellTime Date,--����ʱ��
UserID int foreign key (UserID) references Userd (UserID),--����
SalesmanID int foreign key (SalesmanID) references Salesman (SalesmanID),--����
UState int default(0),--״̬��0Ĭ�ϴ���
)
--���������
create table Selling
(
SellingTraffic nvarchar(200),--��ͨ����
SellingInfrastructure nvarchar(200),--�ܱ�����
SellingTaxation nvarchar(200),--˰�ѷ���
SellingIntroduce nvarchar(200),--���ͽ���
SellingVillage nvarchar(200),--С������
SellID int foreign key (SellID) references Sell (SellID),--������Ϣ���
)
--�������Ա�
create table Transactions
(
TransactionID int identity(1,1) primary key not null,--���
TransactionTime Date ,--�ϼ�ʱ��
TransactionCommodity nvarchar(20),--����Ȩ�����Ƿ�Ϊ��Ʒ����
TransactionOldTransaction nvarchar(20),--�ϴν�����Ϣ
TransactionPurpose nvarchar(20),--������;��ס�������̣�
TransactionYears int,--��������
TransactionPropertyright nvarchar(2000),--��Ȩ����
TransactionMortgage nvarchar(200),--��Ѻ��Ϣ
TransactionPOC nvarchar(200),--��������
SellID int foreign key (SellID) references Sell (SellID),--������Ϣ���
)
--����ͼƬ��
create table SImg
(
ID int identity(1,1) primary key not null,--���
SellID int foreign key (SellID) references Sell (SellID),--������Ϣ���
Photo nvarchar(50),--��Ƭ��
)
--�ղر�
create table SCollection
(
ID int identity(1,1) primary key not null,--���
SellID int foreign key (SellID) references Sell (SellID),--������Ϣ���
UserID int foreign key (UserID) references Userd (UserID),--����
)
--������Ϣ��
create table Lease
(
LeaseID int identity(1,1) primary key not null,--���
LeaseAddress nvarchar(50),--���ڳ���
LeaseVillage nvarchar(50),--����С��
LeaseFloor int,--¥��
LeaseArea nvarchar(20),--���
LeaseMaintain nvarchar(20),--ά��ʱ��
LeaseHStructure nvarchar(20),--��������
LeasePrice nvarchar(20),--���
LeaseLease nvarchar(20),--���޷�ʽ
LeaseCheckin nvarchar(20),--��ס���
LeaseParkinglot nvarchar(20),--��λ
LeaseOrientation nvarchar(20),--����
LeaseElevator int default(0),--���ݣ�0��ʾ���ڣ�
LeaseWaterint nvarchar(20),--��ˮ
LeaseElectric nvarchar(20),--�õ�
LeaseGas nvarchar(20),--ȼ��
LeaseHeating nvarchar(20),--��ů
LeaseLeaseTerm nvarchar(20),--����
LeaseTime Date,--����ʱ��
UserID int foreign key (UserID) references Userd (UserID),--����
SalesmanID int foreign key (SalesmanID) references Salesman (SalesmanID),--����
UState int default(0),--״̬��0Ĭ�ϴ���
)
--������ʩ
create table Facilities
(
FacilitiesID int identity(1,1) primary key not null,--���
FacilitiesWashing int default(0),--ϴ�»���0Ĭ�ϴ���
Facilitiesairconditioner int default(0),--�յ���0Ĭ�ϴ���
Facilitieswardrobe int default(0),--�¹�0Ĭ�ϴ���
FacilitiesTV int default(0),--���ӣ�0Ĭ�ϴ���
FacilitiesRefrigerator int default(0),--���䣬0Ĭ�ϴ���
FacilitiesBed int default(0),--����0Ĭ�ϴ���
FacilitiesWIFI int default(0),--WiFi��0Ĭ�ϴ���
FacilitiesNaturalgas int default(0),--��Ȼ����0Ĭ�ϴ���
FacilitiesHeating int default(0),--ů����0Ĭ�ϴ���
LeaseID int foreign key (LeaseID) references Lease (LeaseID),--������Ϣ���
)
--����ͼƬ��
create table LImg
(
ID int identity(1,1) primary key not null,--���
LeaseID int foreign key (LeaseID) references Lease (LeaseID),--������Ϣ���
Photo nvarchar(50),--��Ƭ��
)
--�ղر�
create table LCollection
(
ID int identity(1,1) primary key not null,--���
LeaseID int foreign key (LeaseID) references Lease (LeaseID),--������Ϣ���
UserID int foreign key (UserID) references Userd (UserID),--����
)