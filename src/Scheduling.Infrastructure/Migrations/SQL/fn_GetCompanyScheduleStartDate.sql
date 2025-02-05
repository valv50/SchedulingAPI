CREATE OR ALTER   FUNCTION [dbo].[fn_GetCompanyScheduleStartDate]
(
	 @CompanyId uniqueidentifier
)
RETURNS date
AS
BEGIN
	DECLARE @DateStart DATETIME

	SELECT @DateStart = MAX(Schedule.CreationDate)
	FROM dbo.Company
		JOIN dbo.Schedule ON Company.MarketId = Schedule.MarketId
		JOIN dbo.ScheduleType ON Company.TypeId = ScheduleType.TypeId
	WHERE Company.CompanyId = @CompanyId

	RETURN @DateStart
END
GO


