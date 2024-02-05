//  13


/*UPDATE shop_products
SET unit_price = unit_price * 1.1
FROM product_titles
WHERE shop_products.product_title_id = product_titles.product_title_id
      AND product_titles.product_category_id IN (
          SELECT category_id
          FROM product_categories
          WHERE category_name = 'grocery'
      )
RETURNING *;*/

//  13

//  14 

/*SELECT
    persons.person_first_name  '   '  persons.person_last_name AS fullname,
    AVG((customer_order_details.price_with_discount::decimal) * customer_order_details.product_amount) AS avg_sum
FROM
    customer_order_details
INNER JOIN
    customer_orders ON customer_order_details.customer_order_id = customer_orders.customer_order_id
INNER JOIN
    customers ON customer_orders.customer_id = customers.customer_id
INNER JOIN
    persons ON customers.customer_id = persons.person_id
GROUP BY
    persons.person_id, fullname
HAVING
    AVG((customer_order_details.price_with_discount::decimal) * customer_order_details.product_amount) > 200000
ORDER BY
    avg_sum DESC, fullname ASC;
*/

//  14


// 15


/*SELECT
    customer_orders.customer_order_id,
    persons.person_first_name,
    persons.person_last_name,
    persons.person_birth_date
FROM
    customer_orders
JOIN
    persons ON customer_orders.customer_id = persons.person_id
WHERE
    EXTRACT(YEAR FROM persons.person_birth_date) BETWEEN 2000 AND 2005;


*/


// 15


// 17 



/*insert into product_categories(category_id, category_name) values(19,'unusual')

insert into product_titles(product_title_id, product_title, product_category_id) values(365,'zor narsa bu',19)

insert into product_suppliers(supplier_id, supplier_name) values(27,'Elyor')

insert into product_manufacturers(manufacturer_id, manufacturer_name) values(39,'Sirdaryolik')

insert into shop_products(product_id, product_title_id, product_manufacturer_id, product_supplier_id, unit_price, comment) 
values(99001,365,39,27,'$200000','menimcha qoshildi')

*/

// 17






// 18 

/*SELECT
  product_title_id,
  comment,
  CASE
    WHEN unit_price::decimal < 300 THEN 'very cheap'
    WHEN unit_price::decimal > 300 AND unit_price::decimal <= 750 THEN 'affordable'
    ELSE 'expensive'
  END AS type
FROM  shop_products;*/

// 18 


//  19


/*select supermarket_id, supermarket_name, count(distinct product_id)
from supermarkets
join supermarket_locations using (supermarket_id)
    join customer_orders using (supermarket_location_id)
    join customer_order_details using (customer_order_id)
    group by(supermarket_id)
*/

// 19








// 20

/*CREATE or replace FUNCTION GETPRODUCTLISTBYOPERATIONDATE11(OPERATIONDATE date) RETURNS TABLE (P VARCHAR(255)) LANGUAGE PlpgSql AS $$
begin
return query select product_titles.product_title from customer_order_details
inner join customer_orders using (customer_order_id)
    inner join product_titles on product_titles.product_title_id= customer_order_details.product_id
where DATE(operation_time)=operationDate;
end; $$;

select* from GETPRODUCTLISTBYOPERATIONDATE11('2011-03-24');*/

// 20



// 21


/*CREATE OR REPLACE FUNCTION getCustomerListForManufacturer1(manufacturer_name1 VARCHAR) 
RETURNS TABLE (P VARCHAR(255)) LANGUAGE PlpgSql AS $$
BEGIN
    RETURN QUERY 
        SELECT product_titles.product_title 
        FROM product_manufacturers
        INNER JOIN shop_products ON product_manufacturers.manufacturer_id = shop_products.product_manufacturer_id
        INNER JOIN product_titles ON shop_products.product_title_id = product_titles.product_title_id
        WHERE product_manufacturers.manufacturer_name = manufacturer_name1;
END;
$$;


SELECT* FROM getCustomerListForManufacturer1('OFS Capital Corporation');

*/


// 21



//  23

/*
CREATE VIEW Checkout1 AS
SELECT
    pe.person_first_name || ' ' || pe.person_last_name AS customer_full_name,
    pt.product_title,
    cos.price_with_discount,
    cos.product_amount,
    cos.price_with_discount / cos.product_amount AS for_per_product
FROM
    customer_order_details AS cos
    INNER JOIN customer_orders AS co ON cos.customer_order_id = co.customer_order_id
    INNER JOIN persons AS pe ON pe.person_id = co.customer_id
    INNER JOIN shop_products AS sp ON sp.product_id = cos.product_id
    INNER JOIN product_titles AS pt ON pt.product_title_id = sp.product_title_id
WHERE
    cos.product_amount > 1;*/


// 23










// 24 


/*create view product_details  as
select pt.product_title, pc.category_name, sup.supplier_name, pm.manufacturer_name  
from shop_products as sp inner join product_titles as pt
on sp.product_title_id=pt.product_title_id inner join product_categories as pc
on pt.product_category_id = pc.category_id inner join product_suppliers as sup on 
sp.product_supplier_id=sup.supplier_id inner join product_manufacturers as pm on
sp.product_manufacturer_id = pm.manufacturer_id*/

//24


// 25 

/*create view Customer_details as
select person_first_name|| ' ' || person_last_name as Full_name,
person_birth_date, cu.card_number
from persons inner join customers as cu on person_id=customer_id*/

// 25