CREATE TABLE course
(
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    description TEXT NOT NULL,
    price INTEGER NOT NULL,
    number_of_students INTEGER DEFAULT 0
);

CREATE TABLE unit
(
    id SERIAL PRIMARY KEY,
    course_id INTEGER NOT NULL,
    name VARCHAR(100) NOT NULL,
    number_of_lessons INTEGER NOT NULL,
    FOREIGN KEY (course_id) REFERENCES course(id) ON DELETE CASCADE
);

CREATE TABLE lesson
(
    id SERIAL PRIMARY KEY,
    unit_id INTEGER NOT NULL,
    name VARCHAR(100) NOT NULL,
    content TEXT NOT NULL,
    FOREIGN KEY (unit_id) REFERENCES unit(id) ON DELETE CASCADE
);

CREATE TABLE subject
(
    id SERIAL PRIMARY KEY,
    name VARCHAR(50)
);

CREATE TABLE course_to_subject
(
    course_id INTEGER NOT NULL,
    subject_id INTEGER NOT NULL,
    FOREIGN KEY (course_id) REFERENCES course(id) ON DELETE CASCADE,
    FOREIGN KEY (subject_id) REFERENCES subject(id) ON DELETE CASCADE
);

CREATE TABLE users
(
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    password VARCHAR(20) NOT NULL,
    registration_date DATE NOT NULL,
    number_of_courses INTEGER DEFAULT 0
);

CREATE TABLE users_to_course
(
    users_id INTEGER NOT NULL,
    course_id INTEGER NOT NULL,
    FOREIGN KEY (users_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (course_id) REFERENCES course(id) ON DELETE CASCADE
);

CREATE TABLE comment
(
    id SERIAL PRIMARY KEY,
    course_id INTEGER NOT NULL,
    users_id INTEGER NOT NULL,
    comment_text TEXT NOT NULL,
    creation_date DATE NOT NULL,
    FOREIGN KEY (course_id) REFERENCES course(id) ON DELETE CASCADE,
    FOREIGN KEY (users_id) REFERENCES users(id) ON DELETE CASCADE
);

CREATE TABLE purchase
(
    id SERIAL PRIMARY KEY,
    users_id INTEGER NOT NULL,
    course_id INTEGER NOT NULL,
    purchase_date TIMESTAMP NOT NULL,
    price INTEGER NOT NULL,
    FOREIGN KEY (users_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (course_id) REFERENCES course(id) ON DELETE CASCADE
);