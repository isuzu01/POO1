use master
go

use AdventureWorks2022
go

--******************* Procedimiento del combo **********************
CREATE OR ALTER PROCEDURE usp_formulario_combo
AS
BEGIN
    DECLARE @tabla TABLE (
        indicador VARCHAR(30),
        combo_id INT,
        combo_des NVARCHAR(100)
    )

    INSERT INTO @tabla (indicador, combo_id, combo_des)
    SELECT 'Producto', Product.ProductID, Name
    FROM Production.Product;

    INSERT INTO @tabla (indicador, combo_id, combo_des)
    SELECT 'Vendedor', Person.BusinessEntityID, Person.FirstName + ' ' + Person.LastName
    FROM Sales.SalesPerson
    INNER JOIN Person.Person ON SalesPerson.BusinessEntityID = Person.BusinessEntityID;

 
    SELECT indicador, combo_id, combo_des
    FROM @tabla
    ORDER BY indicador ASC, combo_des ASC;
END;
GO

--************ Procedimiento de consulta*****************

CREATE OR ALTER PROCEDURE usp_consultar_OrdenVenta
    @clienteNombre NVARCHAR(100) = '',  
    @productoID INT = 0,
    @vendedorID INT = 0
AS
BEGIN
    SELECT TOP 1000
        soh.SalesOrderID, 
        CONCAT(p.FirstName, ' ', p.LastName) AS Cliente,
        sp.BusinessEntityID AS VendedorID,
        CONCAT(spPerson.FirstName, ' ', spPerson.LastName) AS Vendedor,
        prod.Name AS Producto,
        soh.OrderDate,
        soh.TotalDue
    FROM Sales.SalesOrderHeader soh
    INNER JOIN Sales.Customer c ON soh.CustomerID = c.CustomerID
    INNER JOIN Person.Person p ON c.PersonID = p.BusinessEntityID
    INNER JOIN Sales.SalesPerson sp ON soh.SalesPersonID = sp.BusinessEntityID
    INNER JOIN Person.Person spPerson ON sp.BusinessEntityID = spPerson.BusinessEntityID
    INNER JOIN Sales.SalesOrderDetail sod ON soh.SalesOrderID = sod.SalesOrderID
    INNER JOIN Production.Product prod ON sod.ProductID = prod.ProductID
    WHERE 
        (@clienteNombre = '' OR CONCAT(p.FirstName, ' ', p.LastName) LIKE '%' + @clienteNombre + '%') AND
        (@productoID = 0 OR prod.ProductID = @productoID) AND
        (@vendedorID = 0 OR sp.BusinessEntityID = @vendedorID);
END;
GO