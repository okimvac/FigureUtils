CREATE TABLE Product
(
  Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Category
(
  Id INT  IDENTITY(1,1) NOT NULL PRIMARY KEY,
  Name NVARCHAR(100) NOT NULL
);

CREATE TABLE ProductCategory
(
  ProductId INT NOT NULL,
  CategoryId INT NOT NULL
);

INSERT INTO Product 
  (Id, Name) VALUES
  (1, 'product 1'),
  (2, 'product 2'),
  (3, 'product 3'),
  (4, 'product 4')
;

INSERT INTO Category 
  (Id, Name) VALUES
  (1, 'category 1'),
  (2, 'category 2'),
  (3, 'category 3')
;

INSERT INTO ProductCategory 
  (ProductId, CategoryId) VALUES
  (1, 1),
  (2, 1),
  (2, 2),
  (3, 2),
  (3, 3)
;

SELECT p.Name as 'Product Name', c.Name as 'Category Name'
FROM Product p
LEFT JOIN ProductCategory pc ON p.Id=pc.ProductId
LEFT JOIN Category c ON pc.CategoryId=c.Id