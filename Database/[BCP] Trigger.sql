--1/ 2 book details (BookDetails table) can't have the same name
-------------------------------------------------------------------------------------
CREATE TRIGGER DuplicateName_BookDetails
ON BookDetails
FOR UPDATE,INSERT
AS
	BEGIN
	DECLARE @InsertedBookName nvarchar(300), @NumberOfDuplication INT
	SELECT @InsertedBookName = name FROM inserted
	SELECT @NumberOfDuplication = COUNT(*) FROM BookDetails WHERE name = @InsertedBookName
	IF (@NumberOfDuplication > 1)
	BEGIN
		PRINT('Duplicated Book name. Two Book cannot have the same name !!! ')
		ROLLBACK TRAN
	END
	END
-------------------------------------------------------------------------------------

##############################################################################################################################
--2/ 2 menu (Food table) can't have the same name
-------------------------------------------------------------------------------------
CREATE TRIGGER DuplicateName_Food
ON Food
FOR UPDATE,INSERT
AS
	BEGIN
	DECLARE @InsertedFoodName nvarchar(300), @NumberOfDuplication INT
	SELECT @InsertedFoodName = name FROM inserted
	SELECT @NumberOfDuplication = COUNT(*) FROM Food WHERE name = @InsertedFoodName
	IF (@NumberOfDuplication > 1)
	BEGIN
		PRINT('Duplicated Food name. Two Food cannot have the same name !!!')
		ROLLBACK TRAN
	END
	END
-------------------------------------------------------------------------------------

##############################################################################################################################
--3/ Khi 1 menu dc tạo (Food) hay update, nếu số nguyên liệu cần thiết không đủ trong kho thì status 
--sẽ chuyển thành unavailable (trả về lỗi là: Because this menu item doesn't
--have enough ingredient in stock, so its status will be changed to "Unavailable")
-------------------------------------------------------------------------------------
--Note: 1/ ko biết rõ Ingredient tối thiểu bao nhiêu, hiện t cho là cứ 0 thì unavailable
--2/ Food insert cái foodID là primary key, kẹt vl làm sao t test -_-, cần thì viết sau nhá, ez mòa
CREATE TRIGGER CheckAvailableIngredient
ON Ingredient
FOR UPDATE, INSERT
AS
	BEGIN
	DECLARE @InsertedQuantity int, @InsertedIngredientID int
	SELECT @InsertedQuantity = quantity FROM inserted
	IF (@InsertedQuantity  < 1)
		BEGIN
		PRINT('Because this menu item doesn''thave enough ingredient in stock, so its status will be changed to "Unavailable"')
		SELECT @InsertedIngredientID = ingredientID FROM inserted
		UPDATE Food set foodStatusID = 2 WHERE foodID IN 
		(
			SELECT foodID FROM IngredientsInFood WHERE @InsertedIngredientID = ingredientID
		)
		END
	IF (@InsertedQuantity  > 0) --Food status tự chuyển lại thành Available
		BEGIN
		SELECT @InsertedIngredientID = ingredientID FROM inserted
		UPDATE Food set foodStatusID = 1 WHERE foodID IN 
		(
			SELECT foodID FROM IngredientsInFood WHERE @InsertedIngredientID = ingredientID
		)
		END
	END
-------------------------------------------------------------------------------------

##############################################################################################################################
--4/ BookID sẽ được khởi tạo tự động theo tiêu chí (BK_CácChữCáiĐầuCủaSách_STT)
--(STT=số sách (BookIDin Book table) cùng trỏ tới BookDetailsID (BookDetailsTable)) khi tạo 1 sách (Book table)
-------------------------------------------------------------------------------------
--Note: "CácChữCáiĐầuCủaSách" nghe mông lung v~, thích bao nhiêu thì tự đổi giá trị @LengthOfSubstring nhá
create trigger AutoGenerateBookID
on Book
for insert
as
	begin
		declare @GeneratedBookID nvarchar(100), @insertedBookID nvarchar(100),
				@insertedBookDetailID int, @linkedBookName nvarchar(300),
				@LengthOfSubstring int, @oldBookID nvarchar(100)
		select @LengthOfSubstring = 5
		select @insertedBookID = Count(bookID) + 1 from Book
		select @insertedBookDetailID = bookDetailsID from inserted
		select @oldBookID = bookID from inserted
		select @linkedBookName = name from BookDetails where @insertedBookDetailID = bookDetailsID
		select @GeneratedBookID = 'BK_' + SUBSTRING(CAST(@linkedBookName as nvarchar(100)),1,@LengthOfSubstring) 
				+ '_' + CAST(@insertedBookID as nvarchar(5)) + CAST(@insertedBookDetailID as nvarchar(5)) + cast(@oldBookID as nvarchar(2))
		update Book set bookID = @GeneratedBookID where bookID = @oldBookID
	end
-------------------------------------------------------------------------------------

##############################################################################################################################
--5/ không tồn tại 2 người (PersonalDetail Table) có cùng civilianID
-------------------------------------------------------------------------------------
--NOTE--Nhớ sửa cilivianID thành civilianID
CREATE TRIGGER DuplicateCilivianID_PersonalDetails
ON PersonalDetails
FOR UPDATE,INSERT
AS
	BEGIN
	DECLARE @InsertedCilivianID nvarchar(100), @NumberOfDuplication INT
	SELECT @InsertedCilivianID = CilivianID FROM inserted
	SELECT @NumberOfDuplication = COUNT(*) FROM PersonalDetails WHERE @InsertedCilivianID = cilivianID
	IF (@NumberOfDuplication > 1)
	BEGIN
		PRINT('Duplicated CilivianID . Two person cannot have the same CilivianID !!!')
		ROLLBACK TRAN
	END
	END
-------------------------------------------------------------------------------------

##############################################################################################################################
--6/ 2 nguyên liệu (IngredientDetails Table) can't have the same name
-------------------------------------------------------------------------------------
CREATE TRIGGER DuplicateName_IngredientDetails
ON IngredientDetails
FOR UPDATE,INSERT
AS
	BEGIN
	DECLARE @InsertedIngredientName nvarchar(200), @NumberOfDuplication INT
	SELECT @InsertedIngredientName = name FROM inserted
	SELECT @NumberOfDuplication = COUNT(*) FROM IngredientDetails WHERE @InsertedIngredientName = name
	IF (@NumberOfDuplication > 1)
	BEGIN
		PRINT('Duplicated ingredient name. Two ingredient cannot have the same name !!!')
		ROLLBACK TRAN
	END
	END
-------------------------------------------------------------------------------------

##############################################################################################################################
--7/ VIP ID dc tạo tự động khi insert (VIP table) với cấu trúc (VIP_CivilianID) 
-------------------------------------------------------------------------------------
--Note: khi viết query insert VIP, VIP mặc định cho = 0, ID được tạo sẽ cập nhật sau khi insert
--Ví dụ: insert into VIP (vipID,personalDetailsID, occupationCode, registerDate, endDate, vipStatusCode)
--       values (99,3, 1, '5/13/2017', '12/12/2017', 1)
create trigger AutoGenerate_VipID
on VIP
for insert
as
	begin
	declare @insertedPersonalDetailsID int, @generated_VIPID nvarchar(100), @linkedcilivianID int
	select @insertedPersonalDetailsID = personalDetailsID from inserted
	select @linkedcilivianID = cilivianID from PersonalDetails where @insertedPersonalDetailsID = personalDetailsID
	select @generated_VIPID = 'VIP_' + CAST(@linkedcilivianID as nvarchar(100))
	update VIP set vipID = @generated_VIPID where @insertedPersonalDetailsID = personalDetailsID
	end
-------------------------------------------------------------------------------------
##############################################################################################################################
--8/ Order dc tạo ra quá 5p thì không dc phép xóa (Trigger đặt trong FoodCalled table(vì cái đó xóa trc))
-------------------------------------------------------------------------------------

create trigger DenyCancelOrder
on FoodCalled
for delete
as
	begin
	declare @insertedOrderID nvarchar(100), @currentTime datetime, @linkedOrderDateCreated datetime
	select @currentTime = GETDATE()
	select @insertedOrderID = orderID from deleted
	select @linkedOrderDateCreated = dateCreated from OrderBasicInfo where @insertedOrderID = orderID
	if ((DATEPART(yy, @currentTime) != DATEPART(yy,@linkedOrderDateCreated))
		or (DATEPART(mm, @currentTime) != DATEPART(mm,@linkedOrderDateCreated))
		or (DATEPART(dd, @currentTime) != DATEPART(dd,@linkedOrderDateCreated)))
		begin
			PRINT('Unable to delete order. 5 minutes has passed')
			rollback tran
		end
	if (ABS(DATEPART(hh,@currentTime) - DATEPART(hh,@linkedOrderDateCreated)) = 0)
		begin
			if (ABS(DATEPART(mi,@currentTime) - DATEPART(mi,@linkedOrderDateCreated)) >= 5)
			begin
				PRINT('Unable to delete order. 5 minutes has passed')
				rollback tran
			end
		end
	if (ABS(DATEPART(hh,@currentTime) - DATEPART(hh,@linkedOrderDateCreated)) = 1)
		begin
			if (ABS(DATEPART(mi,@currentTime) + 60 - DATEPART(mi,@linkedOrderDateCreated)) >= 5)
			begin
				PRINT('Unable to delete order. 5 minutes has passed')
				rollback tran
			end
		end
	end

create trigger DenyCancelOrderBKBorrow
on BookCalled
for delete
as
	begin
	declare @insertedOrderID nvarchar(100), @currentTime datetime, @linkedOrderDateCreated datetime
	select @currentTime = GETDATE()
	select @insertedOrderID = orderID from deleted
	select @linkedOrderDateCreated = dateCreated from OrderBasicInfo where @insertedOrderID = orderID
	if ((DATEPART(yy, @currentTime) != DATEPART(yy,@linkedOrderDateCreated))
		or (DATEPART(mm, @currentTime) != DATEPART(mm,@linkedOrderDateCreated))
		or (DATEPART(dd, @currentTime) != DATEPART(dd,@linkedOrderDateCreated)))
		begin
			PRINT('Unable to delete order. 5 minutes has passed')
			rollback tran
		end
	if (ABS(DATEPART(hh,@currentTime) - DATEPART(hh,@linkedOrderDateCreated)) = 0)
		begin
			if (ABS(DATEPART(mi,@currentTime) - DATEPART(mi,@linkedOrderDateCreated)) >= 5)
			begin
				PRINT('Unable to delete order. 5 minutes has passed')
				rollback tran
			end
		end
	if (ABS(DATEPART(hh,@currentTime) - DATEPART(hh,@linkedOrderDateCreated)) = 1)
		begin
			if (ABS(DATEPART(mi,@currentTime) + 60 - DATEPART(mi,@linkedOrderDateCreated)) >= 5)
			begin
				PRINT('Unable to delete order. 5 minutes has passed')
				rollback tran
			end
		end
	end

create trigger DenyCancelOrderBKReturn
on BookReturned
for delete
as
	begin
	declare @insertedOrderID nvarchar(100), @currentTime datetime, @linkedOrderDateCreated datetime
	select @currentTime = GETDATE()
	select @insertedOrderID = orderID from deleted
	select @linkedOrderDateCreated = dateCreated from OrderBasicInfo where @insertedOrderID = orderID
	if ((DATEPART(yy, @currentTime) != DATEPART(yy,@linkedOrderDateCreated))
		or (DATEPART(mm, @currentTime) != DATEPART(mm,@linkedOrderDateCreated))
		or (DATEPART(dd, @currentTime) != DATEPART(dd,@linkedOrderDateCreated)))
		begin
			PRINT('Unable to delete order. 5 minutes has passed')
			rollback tran
		end
	if (ABS(DATEPART(hh,@currentTime) - DATEPART(hh,@linkedOrderDateCreated)) = 0)
		begin
			if (ABS(DATEPART(mi,@currentTime) - DATEPART(mi,@linkedOrderDateCreated)) >= 5)
			begin
				PRINT('Unable to delete order. 5 minutes has passed')
				rollback tran
			end
		end
	if (ABS(DATEPART(hh,@currentTime) - DATEPART(hh,@linkedOrderDateCreated)) = 1)
		begin
			if (ABS(DATEPART(mi,@currentTime) + 60 - DATEPART(mi,@linkedOrderDateCreated)) >= 5)
			begin
				PRINT('Unable to delete order. 5 minutes has passed')
				rollback tran
			end
		end
	end

-------------------------------------------------------------------------------------

##############################################################################################################################
--9/ Những table có quantity thì quantity không dc < 0 (StockOrderDetails, IngredientInStockDetails, Ingredient)
-------------------------------------------------------------------------------------
----------------------table StockOrderDetails
CREATE TRIGGER InvalidQuantity_StockOrderDetails
ON StockOrderDetails
FOR UPDATE,INSERT
AS
	BEGIN
	DECLARE @InsertedQuantity int
	SELECT @InsertedQuantity = quantity FROM inserted
	IF (@InsertedQuantity < 0)
	BEGIN
		PRINT('Invalid quantity. Quantity must be larger then 0 !!!')
		ROLLBACK TRAN
	END
	END
----------------------table IngredientInStockDetails
CREATE TRIGGER InvalidQuantity_IngredientInStockDetailss
ON IngredientInStockDetails
FOR UPDATE,INSERT
AS
	BEGIN
	DECLARE @InsertedQuantity int
	SELECT @InsertedQuantity = quantity FROM inserted
	IF (@InsertedQuantity < 0)
	BEGIN
		PRINT('Invalid quantity. Quantity must be larger then 0 !!!')
		ROLLBACK TRAN
	END
	END
----------------------table Ingredient
CREATE TRIGGER InvalidQuantity_Ingredient
ON Ingredient
FOR UPDATE,INSERT
AS
	BEGIN
	DECLARE @InsertedQuantity int
	SELECT @InsertedQuantity = quantity FROM inserted
	IF (@InsertedQuantity < 0)
	BEGIN
		PRINT('Invalid quantity. Quantity must be larger then 0 !!!')
		ROLLBACK TRAN
	END
	END
-------------------------------------------------------------------------------------

##############################################################################################################################
--10/ Những table có ngày bắt đầu và ngày kết thúc thì ngày bắt đầu ko dc > ngày kết thúc (VIP, WorkingShiftInfo
-------------------------------------------------------------------------------------
--Table VIP
create trigger CheckValidMembershipDuration
on VIP
for insert, update
as
	begin
		declare @insertedRegDate  datetime, @insertedEndDate  datetime
		select @insertedRegDate = registerDate from inserted
		select @insertedEndDate = endDate from inserted
		if (@insertedEndDate < @insertedRegDate)
		begin
			PRINT('registerDate cannot be larger then endDate !!!')
			rollback tran
		end
	end
--Table WorkingShiftInfo
create trigger CheckValidWorkingShift
on WorkingShiftInfo
for insert, update
as
	begin
		declare @insertedEffDate  datetime, @insertedDueDate  datetime
		select @insertedEffDate = effectiveDate from inserted
		select @insertedDueDate = dueDate from inserted
		if (@insertedEffDate > @insertedDueDate)
		begin
			PRINT('registerDate cannot be larger then endDate !!!')
			rollback tran
		end
	end
-------------------------------------------------------------------------------------

##############################################################################################################################
--11/ Food price, book price (Food, BookDetails table) thì price phải > 0
-------------------------------------------------------------------------------------
----------------------table Food
CREATE TRIGGER InvalidPrice_Food
ON Food
FOR UPDATE,INSERT
AS
	BEGIN
	DECLARE @InsertedPrice float
	SELECT @Insertedprice = price FROM inserted
	IF (@InsertedPrice <= 0)
	BEGIN
		PRINT('Invalid price. Price must be larger then 0 !!!')
		ROLLBACK TRAN
	END
	END
----------------------table BookDetails
CREATE TRIGGER InvalidPrice_BookDetails
ON BookDetails
FOR UPDATE,INSERT
AS
	BEGIN
	DECLARE @InsertedPrice float
	SELECT @Insertedprice = price FROM inserted
	IF (@InsertedPrice <= 0)
	BEGIN
		PRINT('Invalid price. Price must be larger then 0 !!!')
		ROLLBACK TRAN
	END
	END
---------------------------------------------------------------------------------	----

##############################################################################################################################
--12/ Stock order tạo ra (StockOrder Table) có id STOCKS_ddmmyy_SoThuTuCuaOrderTrongNgay
-------------------------------------------------------------------------------------
create trigger AutoGenerateStockID
on StockOrder
for insert
as
	begin
		declare @insertedStockOrderID nvarchar(100), @insertedDateCreated date, 
				@GeneratedStockOrderID nvarchar(100), @Index int
		select @insertedDateCreated = dateCreated from inserted
		select @insertedStockOrderID = stockOrderID from inserted
		select @Index = count(*) from StockOrder
		select @GeneratedStockOrderID = 'STOCKS_' + CAST(DATEPART(dd,@insertedDateCreated) as nvarchar(100))
		+ '_' + CAST(DATEPART(mm,@insertedDateCreated) as nvarchar(100))
		+ '_' + CAST(DATEPART(yy,@insertedDateCreated) as nvarchar(100))
		+ '_' + CAST(@Index as nvarchar(100))
		update StockOrder set stockOrderID = @GeneratedStockOrderID where stockOrderID = @insertedStockOrderID
	end
-------------------------------------------------------------------------------------

##############################################################################################################################
--13/ Không dc có 2 username giống nhau (StaffAccount table)
-------------------------------------------------------------------------------------
CREATE TRIGGER DuplicateUsername_StaffAccount
ON StaffAccount
FOR UPDATE,INSERT
AS
	BEGIN
	DECLARE @InsertedUsername nvarchar(200), @NumberOfDuplication int
	SELECT @InsertedUsername = username from inserted
	SELECT @NumberOfDuplication = COUNT(*) from StaffAccount where @InsertedUsername = username
	IF (@NumberOfDuplication > 1)
	BEGIN
		PRINT('Duplicated username. There already exist that username !!!')
		ROLLBACK TRAN
	END
	END
-------------------------------------------------------------------------------------

##############################################################################################################################
--14/ Staff ID dc tạo tự động khi insert (StaffDetails table) với cấu trúc (Staff_CivilianID) 
-------------------------------------------------------------------------------------

create trigger AutoGenerate_StaffID
on StaffDetails
for insert
as
	begin
	declare @insertedPersonalDetailsID int, @generated_StaffID nvarchar(100), @linkedcilivianID int
	select @insertedPersonalDetailsID = personalDetailsID from inserted
	select @linkedcilivianID = cilivianID from PersonalDetails where @insertedPersonalDetailsID = personalDetailsID
	select @generated_StaffID = 'Staff_' + CAST(@linkedcilivianID as nvarchar(100))
	update StaffDetails set staffID = @generated_StaffID where @insertedPersonalDetailsID = personalDetailsID
	end