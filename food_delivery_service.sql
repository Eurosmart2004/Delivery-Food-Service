
DROP SCHEMA food_delivery_service;
CREATE SCHEMA food_delivery_service;
USE food_delivery_service;

CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(256) NOT NULL,
    location POINT NOT NULL,
    email VARCHAR(256) NOT NULL,
    telnum VARCHAR(20) NOT NULL,
    CONSTRAINT user_email_constraint CHECK (email REGEXP '^[[:alnum:]-.]+@([[:alnum:]-]+.)+[[:alnum:]-]{2,4}$'),
    CONSTRAINT user_telnum_constraint CHECK (telnum REGEXP '^[[:digit:]]{10}$')
);

CREATE TABLE restaurants (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(256) NOT NULL,
    description VARCHAR(512),
    location POINT NOT NULL,
    available BOOL NOT NULL
);

CREATE TABLE shippers (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(256) NOT NULL,
    national_id VARCHAR(12) NOT NULL,
    license_plate VARCHAR(12) NOT NULL,
    email VARCHAR(256) NOT NULL,
    telnum VARCHAR(20) NOT NULL,
    available BOOL NOT NULL,
    CONSTRAINT shipper_email_constraint CHECK (email REGEXP '^[[:alnum:]-.]+@([[:alnum:]-]+.)+[[:alnum:]-]{2,4}$'),
    CONSTRAINT shipper_telnum_constraint CHECK (telnum REGEXP '^[[:digit:]]{10}$'),
    CONSTRAINT shipper_national_id_constraint CHECK (national_id REGEXP '^[[:digit:]]{12}$'),
    CONSTRAINT shipper_license_plate_constraint CHECK (license_plate REGEXP '^[[:digit:]]{2}-[[:alpha:]][[:digit:]] [[:digit:]]{3}.[[:digit:]]{2}$')
);

CREATE TABLE categories (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(256) NOT NULL
);

CREATE TABLE foods (
    id INT AUTO_INCREMENT PRIMARY KEY,
    restaurant_id INT NOT NULL,
    category_id INT,
    name VARCHAR(256) NOT NULL,
    description VARCHAR(512),
    price FLOAT(12 , 2 ) NOT NULL,
    FOREIGN KEY (restaurant_id)
        REFERENCES restaurants (id)
        ON DELETE NO ACTION ON UPDATE CASCADE,
    FOREIGN KEY (category_id)
        REFERENCES categories (id)
        ON DELETE SET NULL ON UPDATE CASCADE
);

CREATE TABLE orders (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    shipper_id INT NOT NULL,
    restaurant_id INT NOT NULL,
    date DATETIME NOT NULL,
    delivery_fee FLOAT(12, 2) NOT NULL,
    restaurant_rating int,
    shipper_rating int,
    status ENUM('preparing', 'delivering', 'finished') NOT NULL,
    FOREIGN KEY (user_id)
        REFERENCES users (id)
        ON DELETE NO ACTION ON UPDATE CASCADE,
    FOREIGN KEY (shipper_id)
        REFERENCES shippers (id)
        ON DELETE NO ACTION ON UPDATE CASCADE,
    FOREIGN KEY (restaurant_id)
        REFERENCES restaurants (id)
        ON DELETE NO ACTION ON UPDATE CASCADE
);

CREATE TABLE food_order (
    order_id INT NOT NULL,
    food_id INT NOT NULL,
    count INT NOT NULL,
    PRIMARY KEY (order_id, food_id),
    FOREIGN KEY (order_id)
        REFERENCES orders (id)
        ON DELETE NO ACTION ON UPDATE CASCADE,
    FOREIGN KEY (food_id)
        REFERENCES foods (id)
        ON DELETE NO ACTION ON UPDATE CASCADE
);
