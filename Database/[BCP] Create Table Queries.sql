
create table Parameter
(
	parameterID int IDENTITY(1,1),
	parameterName nvarchar(150) ,
	value nvarchar(300),
	primary key (parameterID)
)


create table VIPStatus
(
	vipStatusCode int IDENTITY(1,1),
	name nvarchar(150) ,
	primary key (vipStatusCode)
)


create table Occupation
(
	occupationCode int IDENTITY(1,1),
	name nvarchar(150) ,
	primary key (occupationCode)
)


create table VIP
(
	vipID nvarchar(100) not null,
	personalDetailsID int not null,
	occupationCode int not null,
	registerDate date,
	endDate date,
	vipStatusCode int not null,
	primary key (vipID),
)


create table VIPOrder
(
	vipID nvarchar(100) not null,
	orderID nvarchar(100) not null,
	primary key(orderID,vipID),

)


create table Gender
(
	genderCode int IDENTITY(1,1),
	name nvarchar(150) ,
	primary key (genderCode)
)


create table StaffStatus
(
	staffStatusCode int IDENTITY(1,1),
	name nvarchar(150) ,
	primary key (staffStatusCode)
)


create table StaffPosition
(
	positionCode int IDENTITY(1,1),
	name nvarchar(150) ,
	primary key (positionCode)
)


create table PersonalDetails
(
	personalDetailsID int IDENTITY(1,1),
	address nvarchar(300) ,
	cilivianID nvarchar(100) ,
	contactNumber nvarchar(100),
	dateOfBirth date,
	fullName nvarchar(200),
	genderCode int not null,
	primary key (personalDetailsID),
)


create table StaffAccount
(
	staffID nvarchar(100) not null,
	username nvarchar(200),
	password nvarchar (300) ,
	primary key (staffID)
)



create table StaffDetails
(
	staffID nvarchar(100) not null,
	personalDetailsID int not null,
	positionCode int not null,
	currentSalaryPerHour float ,
	workingHour float ,
	staffStatusCode int not null,
	occupationCode int not null,
	description nvarchar(1000)
	primary key (staffID),
)


create table WorkingCashier
(
	staffID nvarchar(100) not null,
	scheduleID int not null,
	primary key (staffID,scheduleID),
)


create table WorkingManager
(
	staffID nvarchar(100) not null,
	scheduleID int not null,
	primary key (staffID,scheduleID),
)


create table WorkingWarehouseManager
(
	staffID nvarchar(100) not null,
	scheduleID int not null,
	primary key (staffID,scheduleID),
)


create table WorkingRegularStaff
(
	staffID nvarchar(100) not null,
	scheduleID int not null,
	primary key (staffID,scheduleID),
)



create table WorkingShiftInfo
(
	workingShiftID int IDENTITY(1,1),
	workingShift nvarchar(100),
	startTime time ,
	endTime time ,
	effectiveDate date ,
	dueDate date ,
	primary key (workingShiftID)
)


create table Schedule
(
	scheduleID int IDENTITY(1,1),
	date date,
	workingShiftID int not null,
	primary key (scheduleID),
)


create table Publisher
(
	publisherID int IDENTITY(1,1),
	name nvarchar(300),
	description nvarchar(1000),
	primary key (publisherID)
)


create table Author
(
	authorID int IDENTITY(1,1),
	name nvarchar(300),
	description nvarchar(1000),
	primary key (authorID)
)


create table BookWishlist 
(
	recommendBookDetailsID int not null,
	primary key (recommendBookDetailsID)
)


create table BookDetails 
(
	bookDetailsID int IDENTITY(1,1),
	name nvarchar(300),
	price float ,
	publishDate date,
	publisherID int not null,
	authorID int not null,
	primary key (bookDetailsID),
)


create table BookStatus
(
	bookStatusCode int IDENTITY(1,1),
	name nvarchar(300),
	primary key (bookStatusCode),
)


create table Book 
(	
	bookID nvarchar(100) not null,
	bookDetailsID int not null,
	location nvarchar(100),
	bookStatusCode int not null,
	primary key (bookID),
)


create table BookReturned
(
	orderID	 nvarchar(100) not null,
	bookID nvarchar(100) not null,
	primary key (orderID, bookID),
)


create table OrderStatus
(
	orderStatusCode int IDENTITY(1,1),
	name nvarchar(200),
	primary key (orderStatusCode)
)


create table OrderBasicInfo
(
	orderID nvarchar(100) not null,
	dateCreated datetime,
	priorityNumber int,
	totalPayment float,
	charge float,
	orderStatusCode int not null,
	cashierID nvarchar(100) not null,
	primary key (orderID),
)



create table BookBorrowOrder
(
	orderID nvarchar(100) not null,
	primary key (orderID),
)
create table BookCalled 
(
	orderID	 nvarchar(100) not null,
	bookID nvarchar(100) not null,
	primary key (orderID, bookID),
)
create table BookReturnOrder
(
	orderID nvarchar(100) not null,
	bookBorrowOrderID nvarchar(100) not null,
	lateDays int ,
	primary key (orderID),
)


create table FoodStatus
(	
	foodStatusID int IDENTITY(1,1),
	name nvarchar(300),
	primary key (foodStatusID)
)

create table FoodOrder
(
	orderID nvarchar(100) not null,
	voucherID nvarchar(100) not null,
	primary key (orderID),
)


create table Food 
(
	foodID int IDENTITY(1,1),
	description nvarchar(300),
	name nvarchar(300),
	foodStatusID int not null,
	price float,
	primary key (foodID),

)


create table FoodCalled
(
	orderID nvarchar(100) not null,
	foodID int not null,
	quantity int not null,
	primary key (orderID, foodID),

)

create table Voucher 
(
	voucherID nvarchar(100) not null,
	expireDate date,
	publishDate date,
	discountID nvarchar(100) not null,
	primary key (voucherID),
)

create table Discount
(
	discountID nvarchar(100) not null,
	type int,
	primary key (discountID),
)
create table DiscountType1
(
	discountID nvarchar(100) not null,
	description nvarchar(300),
	discountRate float,
	primary key (discountID),
)
create table DiscountType2
(
	discountID nvarchar(100) not null,
	description nvarchar(300),
	buyFoodID int ,
	freeFoodID int ,
	primary key (discountID),
)
create table DiscountType3
(
	discountID nvarchar(100) not null,
	description nvarchar(300),
	numOfBroughtFood int,
	freeFoodID int,
	primary key (discountID),
)

create table IngredientDetails
(
	ingredientDetailsID int IDENTITY(1,1),
	name nvarchar(200),
	description nvarchar(300),
	primary key (ingredientDetailsID)
)
create table Ingredient
(
	ingredientID int IDENTITY(1,1),
	ingredientDetailsID int not null,
	quantity int,
	primary key (ingredientID),
)
create table IngredientsInFood
(
	foodID int not null,
	ingredientID int not null ,
	primary key (foodID, ingredientID),
)

create table StockOrder
(
	stockOrderID nvarchar(100) not null,
	charge float ,
	chargedWarehouseManager nvarchar(100) ,
	totalPayment float ,
	dateCreated date,
	primary key (stockOrderID),
)

create table Producer
(
	producerID int IDENTITY(1,1),
	name nvarchar(300),
	description nvarchar(300),
	primary key (producerID)
)
create table IngredientInStockDetails
(
	ingredientDetailsID int not null,
	producerID int not null,
	quantity int not null,
	primary key (ingredientDetailsID),
)

create table StockOrderDetails
(
	stockOrderID nvarchar(100) not null,
	stockItemDetailsID int not null,
	quantity int,
	primary key (stockOrderID,stockItemDetailsID),
)
