CREATE
OR ALTER
VIEW request.vw_RequestProperties AS
SELECT Id,
       RequestId,
       PropertyType,
       BuildingType,
       SellingPrice
FROM request.RequestProperties