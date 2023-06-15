INSERT INTO [dbo].[Orders] ([UserId], [ProductId], [Payment], [Status], [Quantity])
VALUES
    (1, 1, 'Cash on Delivery', 'Pending', 1),
    (2, 2, 'Credit Card', 'Delivered', 2),
    (3, 3, 'Cash on Delivery', 'Pending', 3),
    (4, 4, 'Credit Card', 'Delivered', 4),
    (5, 5, 'Cash on Delivery', 'Pending', 5),
    (1, 2, 'Credit Card', 'Delivered', 6),
    (2, 3, 'Cash on Delivery', 'Pending', 7),
    (3, 4, 'Credit Card', 'Delivered', 8),
    (4, 5, 'Cash on Delivery', 'Pending', 9),
    (5, 1, 'Credit Card', 'Delivered', 10);
