create database House
use House
go
--用户表
create table Userd
(
UserID int identity(1,1) primary key not null,--编号
UserName nvarchar(20) not null,--姓名
UserSex int default(0),--性别，0为男，1为女
UserPhone nvarchar(20) not null,--电话
UserLoginName nvarchar(50) not null,--登录名
UserPassword nvarchar(50) not null,--密码
[Role] int ,--角色 0普通用户 1超级管理员
UState int default(0),--状态，0默认存在
)
--销售表
create table Salesman
(
SalesmanID int identity(1,1) primary key not null,--编号
SalesmanName nvarchar(20) not null,--姓名
SalesmanSex int default(0),--性别，0为男，1为女
SalesmanPhone nvarchar(20) not null,--电话
SalesmanLoginName nvarchar(50) not null,--登录名
SalesmanPassword nvarchar(50) not null,--密码
SalesmanPhoto nvarchar(20),--销售头像
UState int default(0),--状态，0默认存在
)

--出售信息表
create table Sell
(
SellID int identity(1,1) primary key not null,--编号
SellAddress nvarchar(50),--所在城市
SellVillage nvarchar(50),--所在小区
SellFloor int,--楼层
SellArea  nvarchar(20),--面积
SellAreaTo nvarchar(20),--实际面积
SellPrice nvarchar(20),--每平价格
SellPriceTo nvarchar(20),--总价格
SellAType nvarchar(20),--建筑类型（板塔结构）
SellBStructure nvarchar(20),--建筑结构（钢混结构）
SellHStructurechar nvarchar(20),--房屋类型（3室1厅）
SellRenovation nvarchar(20),--装修情况
SellScale nvarchar(20),--梯户情况（1梯1户）
SellHeating nvarchar(20),--供暖方式
SellOrientation nvarchar(20),--房屋朝向
SellTime Date,--看房时间
UserID int foreign key (UserID) references Userd (UserID),--房主
SalesmanID int foreign key (SalesmanID) references Salesman (SalesmanID),--销售
UState int default(0),--状态，0默认存在
)
--出售卖点表
create table Selling
(
SellingTraffic nvarchar(200),--交通出行
SellingInfrastructure nvarchar(200),--周边配套
SellingTaxation nvarchar(200),--税费服务
SellingIntroduce nvarchar(200),--户型介绍
SellingVillage nvarchar(200),--小区介绍
SellID int foreign key (SellID) references Sell (SellID),--出售信息外键
)
--交易属性表
create table Transactions
(
TransactionID int identity(1,1) primary key not null,--编号
TransactionTime Date ,--上架时间
TransactionCommodity nvarchar(20),--交易权属（是否为商品房）
TransactionOldTransaction nvarchar(20),--上次交易信息
TransactionPurpose nvarchar(20),--房屋用途（住房、店铺）
TransactionYears int,--房屋年限
TransactionPropertyright nvarchar(2000),--产权所有
TransactionMortgage nvarchar(200),--抵押信息
TransactionPOC nvarchar(200),--房本备份
SellID int foreign key (SellID) references Sell (SellID),--出售信息外键
)
--出售图片表
create table SImg
(
ID int identity(1,1) primary key not null,--编号
SellID int foreign key (SellID) references Sell (SellID),--出售信息外键
Photo nvarchar(50),--照片名
)
--收藏表
create table SCollection
(
ID int identity(1,1) primary key not null,--编号
SellID int foreign key (SellID) references Sell (SellID),--出售信息外键
UserID int foreign key (UserID) references Userd (UserID),--房主
)
--出租信息表
create table Lease
(
LeaseID int identity(1,1) primary key not null,--编号
LeaseAddress nvarchar(50),--所在城市
LeaseVillage nvarchar(50),--所在小区
LeaseFloor int,--楼层
LeaseArea nvarchar(20),--面积
LeaseMaintain nvarchar(20),--维护时间
LeaseHStructure nvarchar(20),--房屋类型
LeasePrice nvarchar(20),--租金
LeaseLease nvarchar(20),--租赁方式
LeaseCheckin nvarchar(20),--入住情况
LeaseParkinglot nvarchar(20),--车位
LeaseOrientation nvarchar(20),--朝向
LeaseElevator int default(0),--电梯（0表示存在）
LeaseWaterint nvarchar(20),--用水
LeaseElectric nvarchar(20),--用电
LeaseGas nvarchar(20),--燃气
LeaseHeating nvarchar(20),--供暖
LeaseLeaseTerm nvarchar(20),--租期
LeaseTime Date,--看房时间
UserID int foreign key (UserID) references Userd (UserID),--房主
SalesmanID int foreign key (SalesmanID) references Salesman (SalesmanID),--销售
UState int default(0),--状态，0默认存在
)
--配套设施
create table Facilities
(
FacilitiesID int identity(1,1) primary key not null,--编号
FacilitiesWashing int default(0),--洗衣机，0默认存在
Facilitiesairconditioner int default(0),--空调，0默认存在
Facilitieswardrobe int default(0),--衣柜，0默认存在
FacilitiesTV int default(0),--电视，0默认存在
FacilitiesRefrigerator int default(0),--冰箱，0默认存在
FacilitiesBed int default(0),--床，0默认存在
FacilitiesWIFI int default(0),--WiFi，0默认存在
FacilitiesNaturalgas int default(0),--天然气，0默认存在
FacilitiesHeating int default(0),--暖气，0默认存在
LeaseID int foreign key (LeaseID) references Lease (LeaseID),--出租信息外键
)
--出租图片表
create table LImg
(
ID int identity(1,1) primary key not null,--编号
LeaseID int foreign key (LeaseID) references Lease (LeaseID),--出租信息外键
Photo nvarchar(50),--照片明
)
--收藏表
create table LCollection
(
ID int identity(1,1) primary key not null,--编号
LeaseID int foreign key (LeaseID) references Lease (LeaseID),--出租信息外键
UserID int foreign key (UserID) references Userd (UserID),--房主
)