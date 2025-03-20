
SELECT * FROM Students

SELECT * FROM Teacher

SELECT * FROM Courses

SELECT * FROM Enrollments

SELECT * FROM Payments

--Inserting a new student into student table
INSERT INTO Students VALUES
(11, 'John', 'Doe', '1995-08-15', 'john.doe@example.com', '1234567890')

--Enrolling a student
INSERT INTO Enrollments VALUES
(11, 11, 10, '2023-09-03')

--updating email for a teacher
UPDATE Teacher SET email = 'totowolff@gmail.com' WHERE first_name = 'Toto'

--delete an enrollment
DELETE FROM enrollments WHERE enrollment_id = 11

--assign a specific teacher to a course
UPDATE Courses SET teacher_id = 4 WHERE course_id = 2

--delete a student from  students table
DELETE FROM Students WHERE student_id = 11

--updating payment amount for a student
UPDATE Payments SET amount = 9000000 WHERE student_id = 5

