CREATE TABLE orderitem
(
	id BIGSERIAL PRIMARY KEY,
	orderid BIGINT,
	productid BIGINT,
	CONSTRAINT fk_orderid FOREIGN KEY (orderid) REFERENCES orderdata(id)
);