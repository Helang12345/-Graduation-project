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
UserIdentity nvarchar(20) not null,--身份证
UserLoginName nvarchar(20) not null,--登录名
UserPassword nvarchar(20) not null,--密码
UState int default(0),--状态，0默认存在
)
--销售表
create table Salesman
(
SalesmanID int identity(1,1) primary key not null,--编号
SalesmanPhoto nvarchar(20),--销售头像
UState int default(0),--状态，0默认存在
)
--销售用户关系表
create table Relationship
(
RelationshipID int identity(1,1) primary key not null,
UserID int foreign key (UserID) references Userd (UserID),
SalesmanID int foreign key (SalesmanID) references Salesman (SalesmanID),
UState int default(0),--状态，0默认存在
)
--出售信息表
create table Sell
(
SellID int identity(1,1) primary key not null,--编号
SellAddress nvarchar(20),--所在城市
SellVillage nvarchar(20),--所在小区
SellArea  nvarchar(20),--面积
SellAreaTo nvarchar(20),--实际面积
SellPrice nvarchar(20),--每平价格
SellPriceTo nvarchar(20),--总价格
SellFloor int,--楼层
SellAType nvarchar(20),--建筑类型
SellBStructure nvarchar(20),--建筑结构
SellHStructurechar nvarchar(20),--房屋类型
SellRenovation nvarchar(20),--装修情况
SellScale nvarchar(20),--梯户情况
SellPhoto nvarchar(20),--实景图
SellHeating nvarchar(20),--供暖方式
SellOrientation nvarchar(20),--房屋朝向
SellTime Date,--看房时间
SellTraffic nvarchar(20),--交通出行
SellInfrastructure nvarchar(20),--周边配套
SellTaxation nvarchar(20),--税费服务
SellIntroduce nvarchar(20),--户型介绍
SellCore nvarchar(50),--核心卖点
SellLabel nvarchar(20),--标签
UserID int foreign key (UserID) references Userd (UserID),--房主
SalesmanID int foreign key (SalesmanID) references Salesman (SalesmanID),--销售
UState int default(0),--状态，0默认存在
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
TransactionPropertyright nvarchar(20),--产权所有
TransactionMortgage nvarchar(20),--抵押信息
TransactionPOC nvarchar(20),--房本备份
SellID int foreign key (SellID) references Sell (SellID),--销售
)
--出租信息表
create table Lease
(
LeaseID int identity(1,1) primary key not null,--编号
LeaseArea nvarchar(20),--面积
LeaseAddress nvarchar(20),--地址
LeaseMaintain nvarchar(20),--维护时间
LeaseHStructure nvarchar(20),--房屋类型
LeasePrice nvarchar(20),--租金
LeaseLease nvarchar(20),--租赁方式
LeaseCheckin nvarchar(20),--入住情况
LeaseParkinglot nvarchar(20),--车位
LeaseFloor int,--楼层
LeaseOrientation nvarchar(20),--朝向
LeasePhoto nvarchar(20),--实景图
LeaseElevator int default(0),--电梯（0表示存在）
LeaseWaterint nvarchar(20),--用水
LeaseElectric nvarchar(20),--用电
LeaseGas nvarchar(20),--燃气
LeaseHeating nvarchar(20),--供暖
LeaseLeaseTerm nvarchar(20),--租期
LeaseTime Date,--看房时间
LeaseTraffic nvarchar(20),--交通出行
LeaseInfrastructure nvarchar(50),--周边配套
LeaseVillage nvarchar(50),--小区介绍
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
LeaseID int foreign key (LeaseID) references Lease (LeaseID),--房主
)