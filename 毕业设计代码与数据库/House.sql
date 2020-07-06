drop database House
go
create database House
go
use House
go
--用户表
create table Userd
(
UserID int identity(1,1) primary key not null,--编号
UserName nvarchar(20) not null,--姓名
UserSex int default(0),--性别，0为男，1为女
UserPhone nvarchar(20) not null,--电话
UserdEmail nvarchar(20) not null,--邮箱
UserdVX nvarchar(20) not null,--微信
UserPassword nvarchar(50) not null,--密码
Photo nvarchar(20),--销售头像
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
SalesmanEmail nvarchar(20) not null,--邮箱 
SalesmanVX nvarchar(20) not null,--微信
SalesmanPassword nvarchar(50) not null,--密码
Photo nvarchar(20),--销售头像
UState int default(0),--状态，0默认存在
)

--出售信息表
create table Sell
(
SellID int identity(1,1) primary key not null,--编号
SellAddress nvarchar(50),--所在城市
SellVillage nvarchar(50),--所在小区
SellFloor int,--楼层
SellArea int,--面积
SellAreaTo decimal(12,2) ,--实际面积
SellPrice decimal(12,2) ,--每平价格
SellPriceTo decimal(12,2) ,--总价格
SellAType int,--建筑类型（1板塔结构2其他）
SellBStructure int,--建筑结构（1钢混结构2其他）
SellHStructurechar nvarchar(20),--房屋类型（3室1厅）
SellRenovation int,--装修情况(1精装，2毛坯)
SellScale nvarchar(20),--梯户情况（1梯1户）
SellHeating int,--供暖方式（1集中供暖，2自给自足）
SellOrientation int,--房屋朝向
SellTime int,--看房时间
TransactionStatus int default(0),--交易状态状态，0默认审核待售，1表示出售，2表示下架
NewTime nvarchar(20),--提交时间
Phone nvarchar(20),--联系方式
UserID int foreign key (UserID) references Userd (UserID),--房主
SalesmanID int foreign key (SalesmanID) references Salesman (SalesmanID),--销售
UState int default(0),--状态，0默认存在
)

--出售卖点表
create table Selling
(
SellingID int identity(1,1) primary key not null,--编号
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
TransactionTime nvarchar(20) ,--上架时间
TransactionCommodity int,--交易权属（是否为商品房）
TransactionOldTransaction nvarchar(20),--上次交易信息
TransactionPurpose nvarchar(20),--房屋用途（住房、店铺）
TransactionYears nvarchar(20),--房屋年限
TransactionPropertyright nvarchar(2000),--产权所有
TransactionMortgage int,--抵押信息
TransactionPOC int,--房本备份
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
LeaseArea  decimal(12,2),--面积
LeaseMaintain nvarchar(20),--维护时间
LeaseHStructure nvarchar(20),--房屋类型
LeasePrice decimal(12,2),--租金
LeaseLease int,--租赁方式  1整租，2合租
LeaseCheckin int,--入住情况(1精装，2毛坯)
LeaseParkinglot int,--车位1有 2无
LeaseOrientation int,--朝向
LeaseElevator int default(1),--电梯（1表示存在,2）
LeaseWaterint int,--用水
LeaseElectric int,--用电
LeaseGas int,--燃气(1天然气，2液化气，3电气)
LeaseHeating int,--供暖
LeaseLeaseTerm int,--租期
LeaseTime int,--看房时间
TransactionStatus int default(0),--交易状态状态，0默认审核待售，1表示出售，2表示下架
NewTime nvarchar(20),--提交时间
Phone nvarchar(20),--联系方式
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
FacilitiesHeater int default(0),--热水器，0默认存在
FacilitiesHeating int default(0),--暖气，0默认存在
LeaseID int foreign key (LeaseID) references Lease (LeaseID),--出租信息外键
)
--出租图片表
create table LImg
(
ID int identity(1,1) primary key not null,--编号
LeaseID int foreign key (LeaseID) references Lease (LeaseID),--出租信息外键
Photo nvarchar(50),--照片
)
--收藏表
create table LCollection
(
ID int identity(1,1) primary key not null,--编号
LeaseID int foreign key (LeaseID) references Lease (LeaseID),--出租信息外键
UserID int foreign key (UserID) references Userd (UserID),--房主
)
go

--添加用户表
insert into Userd values('何浪',0,'18711761803','hrl727273603@163.com','helang2000','123456','a1.jpg',0,0),
('杨满吉多',0,'17742538888','wdnmd163@163.com','ymjd12138','123456','a2.jpg',0,0),
('李清照',1,'18711762222','lqz163@163.com','lqz12138','123456','a3.jpg',0,0),
('大乔',1,'17742536666','dq163@163.com','dq12138','123456','a2.jpg',0,0),
('爱德华',0,'18711767777','adh727273603@163.com','adh12138','123456','a1.jpg',1,0)

--添加销售表
insert into Salesman values('旭旭宝宝',0,'18711769999','xxbb12138@163.com','xxbb12138','123456','a1.jpg',0),
('狂人',0,'15642538888','kr12138@163.com','kr12138','123456','a1.jpg',0),
('大硕',1,'18711764562','ds163@163.com','ds12138','123456','a1.jpg',0),
('李勇',1,'17442536666','ly163@163.com','ly12138','123456','a1.jpg',0)

--添加卖房信息表
insert into Sell values('长沙','丹桂苑',5,145,120.8,7800,904800,1,1,'三室一厅',1,'一梯一户',2,1,3,1,'2020-7-1',18711761803,1,1,0),
('长沙','丹桂苑',4,120,110.8,7800,748800,1,1,'三室一厅',1,'一梯一户',2,1,3,1,'2020-7-1',18711761803,2,2,0),
('长沙','翠竹苑',5,115,100.8,6900,634800,2,2,'三室一厅',1,'一梯一户',2,1,3,1,'2020-7-2',18711761803,3,3,0),
('长沙','翠竹苑',3,155,130.8,6900,717600,2,2,'三室一厅',2,'一梯一户',2,1,3,1,'2020-7-3',18711761803,4,4,0),
('长沙','玉兰苑',6,132,118.8,7800,904800,1,1,'三室一厅',2,'一梯一户',1,1,3,1,'2020-7-4',18711761803,2,2,0),
('长沙','玉兰苑',8,146,126.8,7800,904800,1,1,'三室一厅',1,'一梯一户',1,1,3,1,'2020-7-5',18711761803,4,1,0),
('长沙','香樟苑',3,129,109.8,7800,904800,2,2,'三室一厅',1,'一梯一户',1,1,3,1,'2020-7-1',18711761803,3,2,0),
('长沙','香樟苑',4,121,112.8,7800,904800,2,2,'三室一厅',2,'一梯一户',1,1,3,1,'2020-7-1',18711761803,1,1,0)

--添加卖点信息
insert into Selling values('公交:快3、运通117、417、 430、432、 464、465、 517、 620、 621、 751、848、966、 984等20多条公交线路供你选择。地铁: 5号线、13号线。',
'小区位置繁华，有龙德广场、翠微百货、百安居、家乐福、各大银行还有小吃街，有红黄蓝幼儿园，旁边有东小口森林公园和立水桥公园。医院：清华长庚医院（三级甲等医院），距离2000米。距离立水桥地铁站500米，5号线13号线换乘站。',
'商品房，房本满五年，家庭名下一套房子，首套购房1.5%契税，二套购房3%契税，5元印花税，免征个税和增值税。',
'进门大客厅客厅朝南带有落地阳台，厨房朝北，朝北带有朝北的窗户，主卧室朝南带有飘窗，主卧室正对次卧室，和客厅并排朝南的是小次卧，朝南带飘窗',
'小区里有网球场，有小溪和凉亭，车子都在地上停着，充足的停车位，并且停车是免费的，每天都有保洁在打扫小区卫生，保安很负责，站岗轮流，还有巡查，小区里住的都是素质很高的上班族和老人,还有小孩。',1),
('距离立水桥地铁站500米，地铁13号线和5号线交汇，还有432，快3等公交线，出行很方便.',
'公园：立水桥公园、东小口森林公园 医院：清华长庚医院（三级甲等医院），距离2000米 商场：龙德广场、明珠百货、翠微百货、家乐福超市、万达影院 银行：中国银行、中国农业银行、中国工商银行、中国建设银行、民生银行、农商银行、邮政储蓄银行',
' 房子为商品房，满五年，免增值税，也是业主家庭名下一套住房，首套购房1%契税，二套3%契税。',
' 小区2008年建成，房龄新环境好 ，高楼层，无遮挡采光好，钢筋混凝土结构 ，板塔结合，两梯四户。客厅挑空朝西向带落地阳台，楼下一间卧室一间厨房一间卫生间，空间利用合理；楼上两个卧室，一个卫生间。',
' 小区是2008年建成的小区，环境优美，绿化好，树木花草丰富。小区有小溪、喷泉、凉亭、网球场、滑板场、乒乓球桌和娱乐健身器材',2),
('距离立水桥地铁站500米，地铁13号线和5号线交汇，还有432，快3等公交线，出行很方便.',
'公园：立水桥公园、东小口森林公园 医院：清华长庚医院（三级甲等医院），距离2000米 商场：龙德广场、明珠百货、翠微百货、家乐福超市、万达影院 银行：中国银行、中国农业银行、中国工商银行、中国建设银行、民生银行、农商银行、邮政储蓄银行',
' 房子为商品房，满五年，免增值税，也是业主家庭名下一套住房，首套购房1%契税，二套3%契税。',
' 小区2008年建成，房龄新环境好 ，高楼层，无遮挡采光好，钢筋混凝土结构 ，板塔结合，两梯四户。客厅挑空朝西向带落地阳台，楼下一间卧室一间厨房一间卫生间，空间利用合理；楼上两个卧室，一个卫生间。',
' 小区是2008年建成的小区，环境优美，绿化好，树木花草丰富。小区有小溪、喷泉、凉亭、网球场、滑板场、乒乓球桌和娱乐健身器材',3),
('公交:快3、运通117、417、 430、432、 464、465、 517、 620、 621、 751、848、966、 984等20多条公交线路供你选择。地铁: 5号线、13号线。',
'小区位置繁华，有龙德广场、翠微百货、百安居、家乐福、各大银行还有小吃街，有红黄蓝幼儿园，旁边有东小口森林公园和立水桥公园。医院：清华长庚医院（三级甲等医院），距离2000米。距离立水桥地铁站500米，5号线13号线换乘站。',
'商品房，房本满五年，家庭名下一套房子，首套购房1.5%契税，二套购房3%契税，5元印花税，免征个税和增值税。',
'进门大客厅客厅朝南带有落地阳台，厨房朝北，朝北带有朝北的窗户，主卧室朝南带有飘窗，主卧室正对次卧室，和客厅并排朝南的是小次卧，朝南带飘窗',
'小区里有网球场，有小溪和凉亭，车子都在地上停着，充足的停车位，并且停车是免费的，每天都有保洁在打扫小区卫生，保安很负责，站岗轮流，还有巡查，小区里住的都是素质很高的上班族和老人,还有小孩。',4),
('公交:快3、运通117、417、 430、432、 464、465、 517、 620、 621、 751、848、966、 984等20多条公交线路供你选择。地铁: 5号线、13号线。',
'小区位置繁华，有龙德广场、翠微百货、百安居、家乐福、各大银行还有小吃街，有红黄蓝幼儿园，旁边有东小口森林公园和立水桥公园。医院：清华长庚医院（三级甲等医院），距离2000米。距离立水桥地铁站500米，5号线13号线换乘站。',
'商品房，房本满五年，家庭名下一套房子，首套购房1.5%契税，二套购房3%契税，5元印花税，免征个税和增值税。',
'进门大客厅客厅朝南带有落地阳台，厨房朝北，朝北带有朝北的窗户，主卧室朝南带有飘窗，主卧室正对次卧室，和客厅并排朝南的是小次卧，朝南带飘窗',
'小区里有网球场，有小溪和凉亭，车子都在地上停着，充足的停车位，并且停车是免费的，每天都有保洁在打扫小区卫生，保安很负责，站岗轮流，还有巡查，小区里住的都是素质很高的上班族和老人,还有小孩。',5),
('公交:快3、运通117、417、 430、432、 464、465、 517、 620、 621、 751、848、966、 984等20多条公交线路供你选择。地铁: 5号线、13号线。',
'小区位置繁华，有龙德广场、翠微百货、百安居、家乐福、各大银行还有小吃街，有红黄蓝幼儿园，旁边有东小口森林公园和立水桥公园。医院：清华长庚医院（三级甲等医院），距离2000米。距离立水桥地铁站500米，5号线13号线换乘站。',
'商品房，房本满五年，家庭名下一套房子，首套购房1.5%契税，二套购房3%契税，5元印花税，免征个税和增值税。',
'进门大客厅客厅朝南带有落地阳台，厨房朝北，朝北带有朝北的窗户，主卧室朝南带有飘窗，主卧室正对次卧室，和客厅并排朝南的是小次卧，朝南带飘窗',
'小区里有网球场，有小溪和凉亭，车子都在地上停着，充足的停车位，并且停车是免费的，每天都有保洁在打扫小区卫生，保安很负责，站岗轮流，还有巡查，小区里住的都是素质很高的上班族和老人,还有小孩。',6),
('公交:快3、运通117、417、 430、432、 464、465、 517、 620、 621、 751、848、966、 984等20多条公交线路供你选择。地铁: 5号线、13号线。',
'小区位置繁华，有龙德广场、翠微百货、百安居、家乐福、各大银行还有小吃街，有红黄蓝幼儿园，旁边有东小口森林公园和立水桥公园。医院：清华长庚医院（三级甲等医院），距离2000米。距离立水桥地铁站500米，5号线13号线换乘站。',
'商品房，房本满五年，家庭名下一套房子，首套购房1.5%契税，二套购房3%契税，5元印花税，免征个税和增值税。',
'进门大客厅客厅朝南带有落地阳台，厨房朝北，朝北带有朝北的窗户，主卧室朝南带有飘窗，主卧室正对次卧室，和客厅并排朝南的是小次卧，朝南带飘窗',
'小区里有网球场，有小溪和凉亭，车子都在地上停着，充足的停车位，并且停车是免费的，每天都有保洁在打扫小区卫生，保安很负责，站岗轮流，还有巡查，小区里住的都是素质很高的上班族和老人,还有小孩。',7),
('公交:快3、运通117、417、 430、432、 464、465、 517、 620、 621、 751、848、966、 984等20多条公交线路供你选择。地铁: 5号线、13号线。',
'小区位置繁华，有龙德广场、翠微百货、百安居、家乐福、各大银行还有小吃街，有红黄蓝幼儿园，旁边有东小口森林公园和立水桥公园。医院：清华长庚医院（三级甲等医院），距离2000米。距离立水桥地铁站500米，5号线13号线换乘站。',
'商品房，房本满五年，家庭名下一套房子，首套购房1.5%契税，二套购房3%契税，5元印花税，免征个税和增值税。',
'进门大客厅客厅朝南带有落地阳台，厨房朝北，朝北带有朝北的窗户，主卧室朝南带有飘窗，主卧室正对次卧室，和客厅并排朝南的是小次卧，朝南带飘窗',
'小区里有网球场，有小溪和凉亭，车子都在地上停着，充足的停车位，并且停车是免费的，每天都有保洁在打扫小区卫生，保安很负责，站岗轮流，还有巡查，小区里住的都是素质很高的上班族和老人,还有小孩。',8)

--添加交易属性
insert into Transactions values('2020-5-30',1,'2009-05-25','普通住房','满五年','非公有',1,1,1),
('2020-5-30',1,'2009-05-25','普通住房','满五年','非公有',1,2,2),
('2020-5-30',1,'2009-05-25','普通住房','满五年','非公有',1,1,3),
('2020-5-30',1,'2009-05-25','普通住房','满五年','非公有',1,2,4),
('2020-5-30',1,'2009-05-25','普通住房','满五年','非公有',2,1,5),
('2020-5-30',2,'2009-05-25','普通住房','满五年','非公有',1,1,6),
('2020-5-30',2,'2009-05-25','普通住房','满五年','非公有',2,1,7),
('2020-5-30',1,'2009-05-25','普通住房','满五年','非公有',1,1,8) 

--添加卖房图片
insert into SImg values(1,'a1.jpg'),(1,'a2.jpg'),(1,'a3.jpg'),(1,'a4.jpg'),(1,'a5.jpg'),
(2,'b1.jpg'),(2,'b2.jpg'),(2,'b3.jpg'),(2,'b4.jpg'),(2,'b5.jpg'),
(3,'c1.jpg'),(3,'c2.jpg'),(3,'c3.jpg'),(3,'c4.jpg'),(3,'c5.jpg'),
(4,'b1.jpg'),(4,'b2.jpg'),(4,'b3.jpg'),(4,'b4.jpg'),(4,'b5.jpg'),
(5,'e1.jpg'),(5,'e2.jpg'),(5,'e3.jpg'),(5,'e4.jpg'),(5,'e5.jpg'),
(6,'f1.jpg'),(6,'f2.jpg'),(6,'f3.jpg'),(6,'f4.jpg'),(6,'f5.jpg'),
(7,'g1.jpg'),(7,'g2.jpg'),(7,'g3.jpg'),(7,'g4.jpg'),(7,'g5.jpg'),
(8,'i1.jpg'),(8,'i2.jpg'),(8,'i3.jpg'),(8,'i4.jpg'),(8,'i5.jpg')

--添加租房信息
insert into Lease values('长沙','丹桂苑C栋',5,70.5,'2020-06-12','一室一厅',700,1,2,1,1,1,1,1,1,2,1,1,1,'2020-7-1',18711761803,1,1,0),
('长沙','丹桂苑B栋',2,30.5,'2020-06-12','一室一厅',700,1,2,1,2,1,1,1,2,2,1,2,3,'2020-7-1',18711761803,1,2,0),
('长沙','丹桂苑C栋',3,75.5,'2020-06-12','两室一厅',700,1,1,1,2,2,1,1,1,1,1,2,2,'2020-7-1',18711761803,1,3,0),
('长沙','丹桂苑C栋',5,45.5,'2020-06-12','一室一厅',700,1,1,1,2,2,1,1,2,1,1,1,4,'2020-7-1',18711761803,1,4,0),
('长沙','丹桂苑C栋',7,38.5,'2020-06-12','一室一厅',700,1,2,1,2,1,1,1,1,2,1,2,1,'2020-7-1',18711761803,4,2,0),
('长沙','丹桂苑C栋',6,45.5,'2020-06-12','一室一厅',700,1,1,1,2,2,1,1,1,1,1,1,1,'2020-7-1',18711761803,2,1,0),
('长沙','丹桂苑C栋',8,73,'2020-06-12','两室一厅',700,1,1,1,2,2,1,1,1,2,1,1,1,'2020-7-1',18711761803,2,2,0),
('长沙','丹桂苑C栋',1,50,'2020-06-12','一室一厅',700,1,1,1,1,1,1,1,2,2,1,1,1,'2020-7-1',18711761803,2,2,0) 


--添加出租配套设施
insert into Facilities values(1,1,0,1,0,1,0,1,1,1,1),
(1,1,0,0,0,1,0,1,1,1,2),
(1,1,0,0,0,1,0,1,0,0,3),
(1,1,0,0,0,1,0,1,0,0,4),
(1,0,0,1,0,1,0,1,0,1,5),
(1,0,0,0,1,1,0,1,0,0,6),
(1,0,1,0,1,1,0,1,1,1,7),
(1,0,1,0,1,1,0,1,1,1,8)

--添加租房房图片
insert into LImg values(1,'a1.jpg'),(1,'a2.jpg'),(1,'a3.jpg'),(1,'a4.jpg'),(1,'a5.jpg'),
(2,'b1.jpg'),(2,'b2.jpg'),(2,'b3.jpg'),(2,'b4.jpg'),(2,'b5.jpg'),
(3,'c1.jpg'),(3,'c2.jpg'),(3,'c3.jpg'),(3,'c4.jpg'),(3,'c5.jpg'),
(4,'b1.jpg'),(4,'b2.jpg'),(4,'b3.jpg'),(4,'b4.jpg'),(4,'b5.jpg'),
(5,'e1.jpg'),(5,'e2.jpg'),(5,'e3.jpg'),(5,'e4.jpg'),(5,'e5.jpg'),
(6,'f1.jpg'),(6,'f2.jpg'),(6,'f3.jpg'),(6,'f4.jpg'),(6,'f5.jpg'),
(7,'g1.jpg'),(7,'g2.jpg'),(7,'g3.jpg'),(7,'g4.jpg'),(7,'g5.jpg'),
(8,'i1.jpg'),(8,'i2.jpg'),(8,'i3.jpg'),(8,'i4.jpg'),(8,'i5.jpg')

--添加收藏表
insert into SCollection values(1,1),(2,1),(1,3),(1,2)

insert into LCollection values(1,1),(2,1),(1,3),(1,2)

select * from SImg where  SellID=10
select * from Sell
select * from LImg 
select * from SImg 