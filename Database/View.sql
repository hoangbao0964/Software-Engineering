create view View_Salaries
as
select PD.fullName, SD.workingHour * SD.currentSalaryPerHour as TotalSalary
from StaffDetails as SD join PersonalDetails as PD on SD.personalDetailsID = PD.personalDetailsID

create view View_OrderIncome
as
select DATEPART(yy, OB.dateCreated) as Year, DATEPART(MM, OB.dateCreated) as Month, sum(OB.totalPayment) as TotalIncome
from OrderBasicInfo as OB
group by DATEPART(yy, OB.dateCreated), DATEPART(MM, OB.dateCreated)

create view View_StockOutcome
as
select DATEPART(yy, SO.dateCreated) as Year, DATEPART(MM, SO.dateCreated) as Month, sum(SO.totalPayment) as TotalStockPayment
from StockOrder as SO
group by DATEPART(yy, SO.dateCreated), DATEPART(MM, SO.dateCreated)

create view View_TotalIncome
as
select ISNULL(OI.Year, SO.Year) as Year, ISNULL(OI.Month, SO.Month) as Month, ISNULL(OI.TotalIncome, 0) - ISNULL(SO.TotalStockPayment, 0) as TotalMoney, ISNULL(OI.TotalIncome, 0) as OrderIncome, ISNULL(TotalStockPayment, 0) as StockPayment
from (select * from View_OrderIncome) as OI full outer join (select * from View_StockOutcome) as SO on OI.Year = SO.Year and OI.Month = SO.Month
