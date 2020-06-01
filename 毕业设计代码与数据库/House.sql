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
UserIdentity nvarchar(20) not null,--���֤
UserLoginName nvarchar(20) not null,--��¼��
UserPassword nvarchar(20) not null,--����
UState int default(0),--״̬��0Ĭ�ϴ���
)
--���۱�
create table Salesman
(
SalesmanID int identity(1,1) primary key not null,--���
SalesmanPhoto nvarchar(20),--����ͷ��
UState int default(0),--״̬��0Ĭ�ϴ���
)
--�����û���ϵ��
create table Relationship
(
RelationshipID int identity(1,1) primary key not null,
UserID int foreign key (UserID) references Userd (UserID),
SalesmanID int foreign key (SalesmanID) references Salesman (SalesmanID),
UState int default(0),--״̬��0Ĭ�ϴ���
)
--������Ϣ��
create table Sell
(
SellID int identity(1,1) primary key not null,--���
SellAddress nvarchar(20),--���ڳ���
SellVillage nvarchar(20),--����С��
SellArea  nvarchar(20),--���
SellAreaTo nvarchar(20),--ʵ�����
SellPrice nvarchar(20),--ÿƽ�۸�
SellPriceTo nvarchar(20),--�ܼ۸�
SellFloor int,--¥��
SellAType nvarchar(20),--��������
SellBStructure nvarchar(20),--�����ṹ
SellHStructurechar nvarchar(20),--��������
SellRenovation nvarchar(20),--װ�����
SellScale nvarchar(20),--�ݻ����
SellPhoto nvarchar(20),--ʵ��ͼ
SellHeating nvarchar(20),--��ů��ʽ
SellOrientation nvarchar(20),--���ݳ���
SellTime Date,--����ʱ��
SellTraffic nvarchar(20),--��ͨ����
SellInfrastructure nvarchar(20),--�ܱ�����
SellTaxation nvarchar(20),--˰�ѷ���
SellIntroduce nvarchar(20),--���ͽ���
SellCore nvarchar(50),--��������
SellLabel nvarchar(20),--��ǩ
UserID int foreign key (UserID) references Userd (UserID),--����
SalesmanID int foreign key (SalesmanID) references Salesman (SalesmanID),--����
UState int default(0),--״̬��0Ĭ�ϴ���
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
TransactionPropertyright nvarchar(20),--��Ȩ����
TransactionMortgage nvarchar(20),--��Ѻ��Ϣ
TransactionPOC nvarchar(20),--��������
SellID int foreign key (SellID) references Sell (SellID),--����
)
--������Ϣ��
create table Lease
(
LeaseID int identity(1,1) primary key not null,--���
LeaseArea nvarchar(20),--���
LeaseAddress nvarchar(20),--��ַ
LeaseMaintain nvarchar(20),--ά��ʱ��
LeaseHStructure nvarchar(20),--��������
LeasePrice nvarchar(20),--���
LeaseLease nvarchar(20),--���޷�ʽ
LeaseCheckin nvarchar(20),--��ס���
LeaseParkinglot nvarchar(20),--��λ
LeaseFloor int,--¥��
LeaseOrientation nvarchar(20),--����
LeasePhoto nvarchar(20),--ʵ��ͼ
LeaseElevator int default(0),--���ݣ�0��ʾ���ڣ�
LeaseWaterint nvarchar(20),--��ˮ
LeaseElectric nvarchar(20),--�õ�
LeaseGas nvarchar(20),--ȼ��
LeaseHeating nvarchar(20),--��ů
LeaseLeaseTerm nvarchar(20),--����
LeaseTime Date,--����ʱ��
LeaseTraffic nvarchar(20),--��ͨ����
LeaseInfrastructure nvarchar(50),--�ܱ�����
LeaseVillage nvarchar(50),--С������
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
LeaseID int foreign key (LeaseID) references Lease (LeaseID),--����
)