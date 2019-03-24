--table VIP
	alter table VIP add constraint FK_occupationCode
		foreign key (occupationCode) references Occupation(occupationCode);
	alter table VIP add constraint FK_vipStatusCode
		foreign key (vipStatusCode) references VIPStatus(vipStatusCode);
	alter table VIP add constraint FK_vipPersonalDetailsID
		foreign key (personalDetailsID) references PersonalDetails(personalDetailsID);


--table VIPOrder
	alter table VIPOrder add constraint FK_vipID
		foreign key (vipID) references VIP;
	alter table VIPOrder add constraint FK_VipOrderID
		foreign key (orderID) references OrderBasicInfo;


--table PersonalDetails
alter table PersonalDetails add	constraint FK_genderCode
		foreign key (genderCode) references Gender(genderCode);



--table StaffDetails
	alter table StaffDetails add constraint FK_staffPersonalDetailsID
		foreign key (personalDetailsID) references PersonalDetails(personalDetailsID);
	alter table StaffDetails add constraint FK_positionCode
		foreign key (positionCode) references StaffPosition(positionCode);
	alter table StaffDetails add constraint FK_staffStatusCode
		foreign key (staffStatusCode) references StaffStatus(staffStatusCode);
	alter table StaffDetails add constraint FK_staffOccupationCode
		foreign key (occupationCode) references Occupation(occupationCode);


--table StaffAccount
	alter table StaffAccount add constraint FK_staffAccountStaffID
		foreign key (staffID) references StaffDetails(staffID);


-- table WorkingCashier
	alter table WorkingCashier add constraint FK_workingCashierStaffID
		foreign key (staffID) references StaffDetails(staffID);
	alter table WorkingCashier add constraint FK_workingCashierScheduleID
		foreign key (scheduleID) references Schedule(scheduleID);



-- table WorkingManager

	alter table WorkingManager add constraint FK_workingManagerStaffID
		foreign key (staffID) references StaffDetails(staffID);
	alter table WorkingManager add constraint FK_workingManagerScheduleID
		foreign key (scheduleID) references Schedule(scheduleID);


-- table WorkingWarehouseManager
	alter table WorkingWarehouseManager add constraint FK_workingWarehouseManagerStaffID
		foreign key (staffID) references StaffDetails(staffID);
	alter table WorkingWarehouseManager add constraint FK_workingWarehouseManagerScheduleID
		foreign key (scheduleID) references Schedule(scheduleID);

-- table WorkingRegularStaff
	alter table WorkingRegularStaff add constraint FK_workingRegularStaffStaffID
		foreign key (staffID) references StaffDetails(staffID);
	alter table WorkingRegularStaff add constraint FK_workingRegularStaffScheduleID
		foreign key (scheduleID) references Schedule(scheduleID);


-- table Schedule
	alter table Schedule add constraint FK_workingShiftID
		foreign key (workingShiftID) references WorkingShiftInfo(workingShiftID);



-- table BookDetails
	alter table BookDetails add constraint FK_authorID
		foreign key (authorID) references Author(authorID);
	alter table BookDetails add constraint FK_publisherID
		foreign key (publisherID) references Publisher(publisherID);
-- table BookWishlist
	alter table BookWishlist add constraint FK_bookDetailsID
		foreign key (recommendBookDetailsID) references BookDetails(bookDetailsID);
		--recommendBookDetailsID


-- table Book
	alter table Book add constraint FK_bookBookDetailsID
		foreign key (bookDetailsID) references BookDetails(bookDetailsID);
	alter table Book add constraint FK_bookStatus
		foreign key (bookStatusCode) references BookStatus(bookStatusCode);

--table BookReturned
	alter table BookReturned add constraint FK_bookReturnedBookID
		foreign key (bookID) references Book(bookID);

--table OrderBasicInfo
	alter table OrderBasicInfo add constraint FK_orderStatusCode
		foreign key (orderStatusCode) references OrderStatus(orderStatusCode);
	alter table OrderBasicInfo add constraint FK_cashierID
		foreign key (cashierID) references StaffDetails(staffID);


-- table BookBorrowOrder
	alter table BookBorrowOrder add constraint FK_BorrowOrderID
		foreign key (orderID) references OrderBasicInfo(orderID);

-- table BookCalled
	alter table BookCalled  add constraint FK_bookCalledBookID
		foreign key (bookID) references Book(bookID);
	alter table BookCalled  add constraint FK_bookCalledOrderID
		foreign key (orderID) references BookBorrowOrder(orderID);


-- table BookReturnOrder
	alter table BookReturnOrder add constraint FK_bookBorrowOrderID
		foreign key (bookBorrowOrderID) references BookBorrowOrder(orderID);
	alter table BookReturnOrder add constraint FK_bookReturnOrderID
		foreign key (orderID) references OrderBasicInfo(orderID);

-- table FoodOrder
	alter table FoodOrder add constraint FK_foodOrderID
		foreign key (orderID) references OrderBasicInfo(orderID);
	alter table FoodOrder add constraint FK_voucherID 
		foreign key (voucherID) references Voucher(voucherID);


-- table Food
	alter table Food add constraint FK_foodStatusID
		foreign key (foodStatusID) references FoodStatus(foodStatusID);


-- table FoodCalled 
	alter table FoodCalled add constraint FK_foodCalledorderID
		foreign key (orderID) references OrderBasicInfo(orderID);
	alter table FoodCalled add constraint FK_foodCalledFoodID
		foreign key (foodID) references Food(foodID);



-- table Voucher
	alter table Voucher add constraint FK_discountID
		foreign key (discountID) references Discount;



-- table DiscountType1

	alter table DiscountType1 add constraint FK_discountType1DiscountID
		foreign key (discountID) references Discount;


-- table DiscountType2

	alter table DiscountType2 add constraint FK_discountType2DiscountID
		foreign key (discountID) references Discount;

-- table DiscountType3
	alter table DiscountType3 add constraint FK_discountType3DiscountID
		foreign key (discountID) references Discount;



-- table Ingredient
	alter table Ingredient add constraint FK_ingredientIngredientDetailsID
		foreign key (ingredientDetailsID) references IngredientDetails
 



-- table IngredientsInFood

	alter table IngredientsInFood add constraint FK_ingredientsInFoodFoodID
		foreign key (foodID) references Food;
	alter table IngredientsInFood add constraint FK_ingredientID
		foreign key (ingredientID) references Ingredient;


-- table StockOrder
	alter table StockOrder add constraint FK_chargedWarehouseManager
		foreign key (chargedWarehouseManager) references StaffDetails(staffID)



--alter table IngredientInStockDetails
	alter table IngredientInStockDetails add constraint FK_producerID
		foreign key (producerID) references Producer;
	alter table IngredientInStockDetails add constraint FK_ingredientInStockDetailsIngredientDetailsID
		foreign key (ingredientDetailsID) references IngredientDetails;


-- table StockOrderDetails
	alter table StockOrderDetails add constraint FK_stockOrderID
		foreign key (stockOrderID) references StockOrder(stockOrderID);
	alter table StockOrderDetails add constraint FK_sODIngredientStockItemDetailsID
		foreign key (stockItemDetailsID) references IngredientInStockDetails(IngredientDetailsID);
