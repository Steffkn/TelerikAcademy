(function (){
	var students = [{
		firstName: 'Georgi',
		lastName: 'Stefanov',
		age: 16,
		marks: {
			html: 5,
			js: 6,
			csharp: 5
		}
	},{
		firstName: 'Stefan',
		lastName: 'Atanasov',
		age: 25,
		marks: {
			html: 6,
			js: 3,
			csharp: 4
		}
	},{
		firstName: 'Ivan',
		lastName: 'Georgiev',
		age: 24,
		marks: {
			html: 5.5,
			js: 4.5,
			csharp: 5.5
		}
	},{
		firstName: 'Gustav',
		lastName: 'Nikolov',
		age: 23,
		marks: {
			html: 6,
			js: 5,
			csharp: 5
		}
	},{
		firstName: 'Nikola',
		lastName: 'Aleksandrov',
		age: 18,
		marks: {
			html: 3,
			js: 3,
			csharp: 3
		}
	},{
		firstName: 'Aleksandar',
		lastName: 'Gustavson',
		age: 17,
		marks: {
			html: 3,
			js: 4,
			csharp: 5
		}
	},{
		firstName: 'Martin',
		lastName: 'Ivanov',
		age: 18,
		marks: {
			html: 5,
			js: 4,
			csharp: 2
		}
	},{
		firstName: 'Todor',
		lastName: 'Zedov',
		age: 23,
		marks: {
			html: 6,
			js: 6,
			csharp: 6
			}
	}]
	
	function displayFullname(student){
		console.log(student.firstName + ' ' + student.lastName);
	}
	
	function isFirstNameBeforeLastName(student){
		return student.firstName < student.lastName;
	}
	
	function isBetween18And24(student){
		return student.age >= 18 && student.age <= 24;
	}
	
	function addAvarageMark(student){
		var sum = 0;
		sum = student.marks['html'] + student.marks['js'] + student.marks['csharp'];
		student['avarageScore'] = sum / 3;
		return student;
	}
	
	function showAllStudents(students){
		console.log("All students");
		_.chain(students)
			.each(displayFullname);
	}
	
	function showStudentsFirstNameBeforeLastName(students){
		console.log("\nStudents with first name before their last name (alphabetically)");
		_.chain(students)
			.filter(isFirstNameBeforeLastName)
			.each(displayFullname);
	}
	
	function showStudentsWithAgeBetween18And24(students){
		console.log("\nStudents with age between 18 and 24");
		_.chain(students)
			.filter(isBetween18And24)
			.each(function(student){
					displayFullname(student); 
					console.log("Age: " + student.age);
				});
	}
	
	function showBestStudent(students){
		console.log("\nStudent with highest mark");
		var bestStudent = _.chain(students)
			.map(addAvarageMark)
			.sortBy(function(student){ return student.avarageScore * (-1);})
			.first()
			.value();
			
		displayFullname(bestStudent);
		console.log("With score: " + bestStudent.avarageScore);
	}
	
	showAllStudents(students);
	showStudentsFirstNameBeforeLastName(students);
	showStudentsWithAgeBetween18And24(students);
	showBestStudent(students);
}());