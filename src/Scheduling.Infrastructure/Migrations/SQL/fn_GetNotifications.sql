CREATE OR ALTER   FUNCTION [dbo].[fn_GetNotifications](@CompanyId UNIQUEIDENTIFIER, @EndDate DATETIME) 
RETURNS TABLE  
AS  
RETURN  
SELECT DateData
FROM [dbo].[fn_GetDates] (dbo.fn_GetCompanyScheduleStartDate(@CompanyId), @EndDate)
WHERE DAY(DateData) IN 
	(SELECT ScheduleDate.Date
	FROM dbo.Company
		JOIN dbo.Schedule ON Company.MarketId = Schedule.MarketId
		JOIN dbo.ScheduleType ON Company.TypeId = ScheduleType.TypeId
		JOIN dbo.ScheduleDate ON Schedule.ScheduleId = ScheduleType.ScheduleId
	WHERE CompanyId = @CompanyId)
GO


