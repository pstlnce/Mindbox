SELECT pr.Name, ct.Name
FROM products pr
LEFT JOIN product_and_categories prct
	ON prct.product_id = pr.id
LEFT JOIN categories ct
	ON prct.category_id = ct.id
