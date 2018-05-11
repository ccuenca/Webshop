
CREATE TABLE dbo.Products(
	prdId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	prdName VARCHAR(1000) NOT NULL,
	prdCode VARCHAR(10) NOT NULL,
	prdPrice DECIMAL(18,3) NOT NULL,
	prdCategory INT NOT NULL,
	prdActive BIT
)

GO

CREATE NONCLUSTERED INDEX IX_Products_Code ON dbo.Products (prdCode)  INCLUDE (prdName, prdPrice, prdCategory);  

GO

CREATE NONCLUSTERED INDEX IX_Products_Name ON dbo.Products (prdName)  INCLUDE (prdCode, prdPrice, prdCategory);  

GO  

ALTER TABLE dbo.Products ADD DEFAULT ((0)) FOR prdActive

GO

CREATE TABLE dbo.Categories(
	catId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	catName VARCHAR(1000) NOT NULL,	
	catActive BIT
)

ALTER TABLE dbo.Categories ADD  DEFAULT ((0)) FOR catActive
GO


ALTER TABLE dbo.Products  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY(prdCategory)
REFERENCES dbo.Categories (catId)
GO

CREATE TABLE dbo.Customers(
	cusId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	cusName VARCHAR(1000) NOT NULL,
	cusLastName VARCHAR(1000) NOT NULL,
	cusIdentification VARCHAR(100) NOT NULL,
	cusActive BIT
)

GO

CREATE NONCLUSTERED INDEX IX_Customers_Name ON dbo.Customers (cusName)  INCLUDE (cusLastName, cusIdentification);  

GO  

ALTER TABLE dbo.Customers ADD DEFAULT ((0)) FOR cusActive

GO

CREATE TABLE dbo.Orders(
	ordId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	ordObs VARCHAR(1000) NOT NULL,
	ordTotal VARCHAR(1000) NOT NULL,	
	ordDate SMALLDATETIME NOT NULL,
	ordCustomer INT, 
	ordActive BIT
)


ALTER TABLE dbo.Orders ADD DEFAULT ((0)) FOR ordActive

ALTER TABLE dbo.Orders  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY(ordCustomer)
REFERENCES dbo.Customers (cusId)
GO

Create table dbo.OrdersProducts(
	ordId int NOT NULL,
	prdId int NOT NULL
)

GO

ALTER TABLE OrdersProducts ADD CONSTRAINT PK_OrdersProducts PRIMARY KEY (ordId,prdId);

ALTER TABLE dbo.OrdersProducts  WITH CHECK ADD  CONSTRAINT [FK_OrdersProducts_Products_Product] FOREIGN KEY(prdId)
REFERENCES dbo.Products (prdId)
GO

ALTER TABLE dbo.OrdersProducts  WITH CHECK ADD  CONSTRAINT [FK_OrdersProducts_Products_Order] FOREIGN KEY(ordId)
REFERENCES dbo.Orders (ordId)
GO
