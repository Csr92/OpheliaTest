 --Obtener la lista de precios de todos los productos
SELECT PName, Price FROM Product;
--Obtener la lista de productos cuya existencia en el inventario haya llegado al mínimo permitido (5 unidades)
SELECT Id, PName, Price, Stock FROM Product WHERE Stock <= 5
-- Obtener una lista de clientes no mayores de 35 años que hayan realizado compras entre el 1 de febrero de 2000 y el 25 de mayo de 2000
SELECT * FROM Clients CLI WITH (NOLOCK)
INNER JOIN BILL B WITH (NOLOCK) ON (CLI.Id = B.IdClient)
WHERE (cast(datediff(dd,CLI.BirthDate,GETDATE()) / 365.25 as int))  <= 35
AND B.PurchaseDate BETWEEN '2000-02-01' AND '2000-05-25'
-- Obtener el valor total vendido por cada producto en el año 2000
SELECT PName, B.Total FROM Product P WITH (NOLOCK)
INNER JOIN BillDetail BD WITH (NOLOCK) ON (P.ID = BD.IdProduct)
INNER JOIN Bill B WITH (NOLOCK) ON (B. Id = BD.IdBill)
WHERE YEAR(B.PurchaseDate) = 2000