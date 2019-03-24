INSERT INTO PARAMETER(parameterName, value) VALUES
('VIPMembershipIncreasement', '10'),
('shiftHour', '8'),
('bookBorrowFee', '50'),
('maxBookBorrowDay', '7'),
('vipDiscount', '5'),
('latefee_1', '2000'),
('latefee_2', '4000'),
('latefee_3', '7000'),
('latefee_range_1', '300000'),
('latefee_range_2', '700000'),
('latefee_range_3', '10000000');

--------------------------------------------------				INSERT BOOKS

INSERT INTO Author(name,description) VALUES
('Dan Brown', null),
('John Green', null);


INSERT INTO Publisher(name,description) VALUES
('VIET NAM',null),
('NXB Kim Dong',null);





INSERT INTO BookDetails(name,price,publishDate,publisherID,authorID) VALUES
('Angels & Demons',30000,'4/30/2016',1,1), 
('The Da Vinci Code',40000,'4/30/2016',1,1),	
('The Faults In Our Stars',35000,'4/30/2016',2,2);




INSERT INTO BookStatus(name) VALUES
('Available'),
('Unavailable');



INSERT INTO Book(bookID, bookDetailsID, location, bookStatusCode) VALUES
(1,1,'ROW 1 COL 1', 1),
(2,2,'ROW 1 COL 2', 1),
(3,3,'ROW 1 COL 3', 1);




----------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------				INSERT FOODS/DRINKS

INSERT INTO FoodStatus(name) VALUES
('Available'),
('Unavailable');


-------------------INSERT VOUCHER/DISCOUNT 

INSERT INTO Discount(discountID,type) VALUES
('d1',1),
('d2',2),
('d3',3);

INSERT INTO DiscountType1(discountID,description,discountRate) VALUES
('d1','you got a discount at rate : ', 50);

INSERT INTO DiscountType2(discountID,description,buyFoodID,freeFoodID) VALUES
('d2','you can get a free food according to the food you bought', '1','5');

INSERT INTO DiscountType3(discountID,description,numOfBroughtFood,freeFoodID) VALUES
('d3','According to the number of bought food, you will be gifted a food ', 10,'10');


INSERT INTO Voucher(voucherID,expireDate,publishDate,discountID) VALUES
('v1','5/1/2018','5/1/2017','d1'),
('v2','5/1/2018','10/5/2017','d2'),
('v3','5/2/2017','5/1/2017','d3');

------------------------------INSERT STAFF
INSERT INTO Gender(name) VALUES
('Male'),
('Female'),
('Others');

INSERT INTO PersonalDetails(address,cilivianID,contactNumber,dateOfBirth,fullName, genderCode) VALUES
(N'43 Trần Hưng Đạo','583745','912345673','4/5/1990',N'Phạm Trần Phú',1),
(N'45 Trần Hưng Đạo','589745','912345678','4/5/1990',N'Phạm Trần Phú Quốc',1),
(N'12/4 Cô Giang','873858','923456789','7/11/1987',N'Nguyễn Thị Hoàng Yến',2),
(N'89/4 Lý Tự trọng','845784','934567891','5/12/1992',N'Đặng Mai Huỳnh',2);


INSERT INTO StaffPosition(name) VALUES
('Cashier'),
('Manger'),
('Stock Manager'),
('Regular Staff');

INSERT INTO StaffStatus(name) VALUES
('Working'),
('Not Working'),
('Quit');


INSERT INTO Occupation(name) VALUES
('Doctor'),
('Dentis'),
('Teacher');

INSERT INTO StaffDetails(staffID, personalDetailsID,positionCode,currentSalaryPerHour,workingHour,staffStatusCode, occupationCode) VALUES
(1,1,1,12000,13,2,1),
(2,2,2,15000,20,1,2),
(3,3,3,15000,11,1,2),
(4,4,4,20000,30,1,1);

INSERT INTO StaffAccount(staffID,username,password) VALUES
(1,'quocptp','ujJTh2rta8ItSm/1PYQGxq2GQZXtFEq1yHYhtsIztUi66uaVbfNG7IwX9eoQ817jy8UUeX7X3dMUVGTioLq0Ew=='),
(2,'yennth','ujJTh2rta8ItSm/1PYQGxq2GQZXtFEq1yHYhtsIztUi66uaVbfNG7IwX9eoQ817jy8UUeX7X3dMUVGTioLq0Ew=='),
(3,'huynhdm','ujJTh2rta8ItSm/1PYQGxq2GQZXtFEq1yHYhtsIztUi66uaVbfNG7IwX9eoQ817jy8UUeX7X3dMUVGTioLq0Ew=='),
(4,'quocpt','ujJTh2rta8ItSm/1PYQGxq2GQZXtFEq1yHYhtsIztUi66uaVbfNG7IwX9eoQ817jy8UUeX7X3dMUVGTioLq0Ew==');


------------------INSERT ORDER
INSERT INTO OrderStatus(name) VALUES
('Processing'),
('Completed');

INSERT INTO OrderBasicInfo(orderID,dateCreated,priorityNumber,totalPayment,charge,orderStatusCode,cashierID) VALUES
(1,'5/1/2017',1,35000,1400,2,1),
(2,'5/1/2017',2,14000,325,1,1),
(3,'5/1/2017',3,50000,35000,1,1);

----------------------------INSERT FOODS
INSERT INTO Food(description,name,foodStatusID,price) VALUES
('Coffee','Espresso (Short Black)', 1, 50000),
('Coffee','Double Expresso (Doppio)', 1, 50000),
('Coffee','Short Macchiato', 1, 50000);


INSERT INTO FoodOrder(orderID,voucherID) VALUES
(1,'v1'),
(2,'v2'),
(3,'v3');

INSERT INTO FoodCalled(orderID,foodID) VALUES
(1,1),
(2,1),
(3,2);


----------------------------------------------------------------------------------------------------------------------------------------------------

-------------------------------------INSERT VIP
INSERT INTO VIPStatus(name) VALUES
('Prenium'),
('Expired');




INSERT INTO VIP(vipID,personalDetailsID,occupationCode,registerDate,endDate,vipStatusCode) VALUES
(1,1,2,'5/13/2017','6/13/2017',1);

INSERT INTO VIPOrder(vipID,orderID) VALUES
(1,1),
(1,2);






---------------------------------- INSERT WORKING SHIFT 
INSERT INTO WorkingShiftInfo(workingShift,startTime,endTime,effectiveDate,dueDate) VALUES
('Morning','7:00','14:00','5/1/2017','5/1/2018'),
('Evening','14:00','21:00','5/1/2017','5/1/2018')


INSERT INTO Schedule(date,workingShiftID) VALUES
('5/2/2017',1),
('5/2/2017',2)

INSERT INTO WorkingCashier(scheduleID,staffID) VALUES 
(1,1);
INSERT INTO WorkingManager(scheduleID,staffID) VALUES 
(1,2);
INSERT INTO WorkingWarehouseManager(scheduleID,staffID) VALUES 
(1,3);
INSERT INTO WorkingRegularStaff(scheduleID,staffID) VALUES 
(1,4);



---------------INSERT BOROW/ RETURN BOOK

INSERT INTO BookBorrowOrder(orderID) VALUES
(1),(2),(3);

INSERT INTO BookCalled(orderID,bookID) VALUES
(1,1), (2,2) ,(3,3);



INSERT INTO BookReturned(orderID,bookID) VALUES
(1,1), (2,2) ,(3,3);

INSERT INTO BookReturnOrder(orderID,bookBorrowOrderID,lateDays) VALUES
(1,1,3),
(2,2,1);

-------------------INSERT INGREDIENT
INSERT INTO IngredientDetails(name,description) VALUES 
('Tea','Fried'),
('Coffee','Spinned'),
('Color','Fused');

INSERT INTO Ingredient(ingredientDetailsID,quantity) VALUES 
(1,3),
(2,10),
(3,2);

INSERT INTO IngredientsInFood(foodID, ingredientID) VALUES 
(1, 2),(1, 3),(3, 3);



-------------------INSERT STOCK
INSERT INTO Producer(name,description) VALUES 
('Coffee Inc (spin coffe)',''),
('Tea Inc (frie tea)',''),
('Coffee Inc (capuchino)','');

INSERT INTO IngredientInStockDetails(ingredientDetailsID, producerID, quantity) VALUES 
(1, 1, 100),(2, 2, 500), (3, 2, 200);

INSERT INTO StockOrder(stockOrderID,charge,chargedWarehouseManager,totalPayment,dateCreated) VALUES 
('so1',30000,3,50000,'5/1/2017'),
('so2',15000,3,75000,'5/1/2017'),
('so3',5000,3,23000,'5/1/2017');

INSERT INTO	StockOrderDetails(stockOrderID,stockItemDetailsID,quantity) VALUES 
('so1',1,3),
('so2',2,5),
('so3',3,10);



