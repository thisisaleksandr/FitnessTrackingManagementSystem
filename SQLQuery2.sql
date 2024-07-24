﻿CREATE TABLE users(
	id INT PRIMARY KEY IDENTITY(1,1),
	username VARCHAR(MAX) NULL,
	password VARCHAR(MAX) NULL,
	date_create DATE NULL,
	bmr_calories INT DEFAULT 1800,
	calorie_goal INT DEFAULT 200
);

SELECT * FROM users;


CREATE TABLE fitness_log(
	id INT PRIMARY KEY IDENTITY(1,1),
	user_id INT,
	activity VARCHAR(MAX) NULL,
	duration INT NULL,
	calories INT NULL,
	date_insert DATE NULL
)

SELECT * FROM fitness_log;


CREATE TABLE food_log(
	id INT PRIMARY KEY IDENTITY(1,1),
	user_id INT,
	meal_name VARCHAR(MAX) NULL,
	calories INT NULL,
	date_insert DATE NULL
)
SELECT SUM(calories) from food_log WHERE date_insert = @date_in AND user_id = @user_id

SELECT * FROM food_log;

CREATE TABLE weight_log(
	id INT PRIMARY KEY IDENTITY(1,1),
	user_id INT,
	weight_value FLOAT,
	date_insert DATE NULL
)

DROP TABLE weight_log;

SELECT * FROM weight_log;
