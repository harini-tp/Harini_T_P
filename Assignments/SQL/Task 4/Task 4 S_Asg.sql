SELECT * FROM Students

SELECT * FROM Teacher

SELECT * FROM Courses

SELECT * FROM Enrollments

SELECT * FROM Payments




--1 average number of students in each course

SELECT AVG(counts) 'Average' FROM
                   (
                       SELECT COUNT(student_id) 'counts' FROM Enrollments
                       GROUP BY course_id
					)
					AS [count of students]





--2 student with the highest payment

SELECT * FROM Students
WHERE student_id =
				(
					SELECT student_id FROM Payments 
					WHERE amount = 
								(
									SELECT MAX(amount) FROM Payments
								)
				)





--3 courses with maximum no of enrollments

SELECT TOP 1 course_name 'Max Enrollment in' FROM Courses
JOIN(
	SELECT course_id, COUNT(course_id) 'Counts' FROM Enrollments
	GROUP BY course_id
	) AS [Max enrollment]
	ON Courses.course_id = [Max enrollment].course_id 
ORDER BY Counts DESC






--4 total payment made to courses taught by each teacher

SELECT first_name + ' ' + last_name AS 'Name', 
    (	
		SELECT SUM(Payments.amount) FROM Payments  
		WHERE Payments.student_id IN 
							(
								SELECT Enrollments.student_id FROM Enrollments 
								JOIN Courses ON Enrollments.course_id = Courses.course_id  
								WHERE Courses.teacher_id = Teacher.teacher_id													
							)
    ) AS Total_Payment
FROM Teacher 






--5 students who enrolled in all available courses

SELECT (first_name + ' ' + last_name) 'Name' FROM Students 
WHERE student_id = 
				(
					SELECT student_id FROM
					(
						SELECT COUNT(course_id) 'Counts', student_id FROM Enrollments 
						GROUP BY student_id 
					) AS [Course count]
					WHERE Counts = 
								(
									SELECT COUNT(course_id) FROM Courses
								)
				) 
				--Returns no name as no student has registered to all courses






--6 names of teacher who have not been assigned to any course

SELECT (first_name + ' ' + last_name) 'Name' FROM Teacher
WHERE teacher_id NOT IN
						(	
							SELECT teacher_id FROM Courses
						)






--7 Average age of all student

SELECT AVG(Age) 'Average age' FROM
				(
				SELECT DATEDIFF(YEAR, date_of_birth, GETDATE()) 'Age' FROM Students 
				)
				AS Ages






--8 course with no enrollment

SELECT course_name 'No Enrollments in' FROM Courses
WHERE course_id NOT IN 
					(
						SELECT course_id FROM Enrollments
					)







--9 total payment in each course by each student

SELECT 
    (
		SELECT Students.first_name + ' ' + Students.last_name FROM Students 
		WHERE Students.student_id = Enrollments.student_id
	) 'Name', 
    (	
		SELECT Courses.course_name FROM Courses  
		WHERE Courses.course_id = Enrollments.course_id
	) 'Course', 
    (
		SELECT SUM(Payments.amount) FROM Payments  
		WHERE Payments.student_id = Enrollments.student_id
	) 'Total Payment'
FROM Enrollments






--10 students who made more than one payment

SELECT (first_name + ' ' + last_name) 'Name' FROM Students
WHERE student_id = 
				(
					SELECT student_id FROM
					(
						SELECT student_id, COUNT(student_id) 'No of Enrollments' FROM Payments 
						GROUP BY student_id
					) AS [Counts] 
					WHERE [No of Enrollments] > 1
				)  
				--Returns no name as no student made more than one payment






--11 total payment made by each student

SELECT (first_name + ' ' + last_name) 'Name', SUM(amount) 'Toatal Payment' FROM Students
JOIN Payments ON Students.student_id = Payments.student_id
GROUP BY Students.first_name, Students.last_name 





--12 list of course names with count of students enrolled in each

SELECT course_name 'Course name', COUNT(student_id) 'Number of Enrollment' FROM Courses
LEFT JOIN Enrollments ON Courses.course_id = Enrollments.course_id
GROUP BY course_name 
ORDER BY 'Number of Enrollment' DESC






--13 average payments made by students

SELECT (first_name + ' ' + last_name) 'Name', AVG(amount) 'Average Payment' FROM Students
JOIN Payments ON Students.student_id = Payments.student_id
GROUP BY Students.first_name, Students.last_name 

