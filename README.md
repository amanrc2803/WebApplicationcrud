CRUD (Create, Read, Update, Delete) application using Visual Studio 2022, MySQL database, and Web Forms project template without using Entity Framework.

For UI index.aspx file & index.aspx.cs file is imortant for devlopment:

DB Setup:

Install MySQL DB Connector for your DotNet project based on Framework version compatibility.
In the NuGet Package Manager, install the Mysql.data package according to your Framework configuration.

Sample Query for Creating a Product DB in Mysql :

CREATE TABLE product (
    productid INT AUTO_INCREMENT PRIMARY KEY,
    product VARCHAR(45),
    price DECIMAL(18, 2),
    count INT,
    description VARCHAR(250)
);
INSERT INTO new_product (product, price, count, description)
SELECT product, price, count, description
FROM product;

2nd step For Doing a CRUD operation inside Product DB we have to add 4 Stored Procedures file inside MySql - Product DB: 

1.  ProductAddOrEdit :
   
   CREATE DEFINER=`root`@`localhost` PROCEDURE `ProductAddOrEdit`(
    _productid Int,
    _product varchar(45),
    _price decimal(18,2),
    _count int,
    _description varchar(250)
)
BEGIN
    if _productid = 0 then
        -- Assuming productid is auto-incremented, let the database handle it.
        Insert Into product(product,price,count,description) values(_product,_price,_count,_description);
    else
        -- Update existing record
        UPDATE product
        SET 
            product = _product,
            price = _price,
            count = _count,
            description = _description
        WHERE productid = _productid;
    end if;

 2. ProductDeleteByID :
   
   CREATE DEFINER=`root`@`localhost` PROCEDURE `ProductDeleteByID`(
_productid int
)
BEGIN
 delete from product
 where productid= _productid;
END

 3.  ProductViewAll : 

  CREATE DEFINER=`root`@`localhost` PROCEDURE `ProductViewAll`()
BEGIN
select * from Product;
END   

4.  ProductViewByID :
   
CREATE DEFINER=`root`@`localhost` PROCEDURE `ProductViewByID`(
_productid int
)
BEGIN
  select * from product
  where productid=_productid;
END


And last but not least, add our credential settings inside our config file. If we are using the same Web Application template for a Webform without an MVC Core project, then we can include these DB credentials in the Web.Config file :

 <connectionStrings>
			<add name="DefaultConnection" connectionString="Server=127.0.0.1;Database=aspcruddb;Username=root;Password=ourpassword;SslMode=None;persistsecurityinfo=True;" providerName="MySql.Data.MySqlClient" />
  </connectionStrings>

  If not then we can add this file starup.cs file for core project strucure.





 
