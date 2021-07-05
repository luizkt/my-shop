IF db_id('my-shop-db') IS NOT NULL
BEGIN
SELECT 'database does exist'
END
ELSE
BEGIN
CREATE DATABASE [my-shop-db]
END
