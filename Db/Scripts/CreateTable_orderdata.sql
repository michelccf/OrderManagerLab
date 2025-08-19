CREATE TABLE orderdata 
(
	id BIGSERIAL PRIMARY KEY ,
	userid bigint ,
	status int, 
	CONSTRAINT fk_userid FOREIGN KEY (userid) REFERENCES "UserData"("Id")
);
