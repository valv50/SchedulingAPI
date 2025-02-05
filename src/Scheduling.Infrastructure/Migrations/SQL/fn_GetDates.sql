
CREATE OR ALTER   FUNCTION [dbo].[fn_GetDates](@StartDateTime DATE, @EndDateTime DATE)  
RETURNS TABLE  
AS  
RETURN  
WITH DateRange(DateData) AS 
(
    SELECT @StartDateTime as Date
    UNION ALL
    SELECT DATEADD(d,1,DateData)
    FROM DateRange 
    WHERE DateData < @EndDateTime
)
SELECT DateData
FROM DateRange


