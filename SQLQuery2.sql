CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    ProductId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(id),
    FOREIGN KEY (ProductId) REFERENCES Product(ProductId)
);
