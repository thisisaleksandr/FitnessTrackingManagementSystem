CREATE TABLE users(
	id INT PRIMARY KEY IDENTITY(1,1),
	username VARCHAR(MAX) NULL,
	password VARCHAR(MAX) NULL,
	date_create DATE NULL
)

SELECT * FROM users;

CREATE TABLE fitness_log(
	id INT PRIMARY KEY IDENTITY(1,1),
	activity VARCHAR(MAX) NULL,
	duration INT NULL,
	calories INT NULL,
	date_insert DATE NULL
)
SELECT * FROM fitness_log;

CREATE TABLE food_log(
	id INT PRIMARY KEY IDENTITY(1,1),
	meal_name VARCHAR(MAX) NULL,
	calories INT NULL,
	date_insert DATE NULL
)


SELECT * FROM food_log;