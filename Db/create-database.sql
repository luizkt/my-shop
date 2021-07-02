IF db_id('product-database') IS NOT NULL
BEGIN
SELECT 'database does exist'
END
ELSE
BEGIN
CREATE DATABASE [product-database]
END
