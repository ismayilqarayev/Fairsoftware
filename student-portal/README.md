# Student Portal Application

A comprehensive Spring Boot application for managing student and teacher interactions, quizzes, grades, and messages.

## Project Structure

```
student-portal/
├── src/main/java/com/school/
│   ├── controller/
│   │   ├── AuthController.java
│   │   ├── StudentController.java
│   │   ├── TeacherController.java
│   │   ├── QuizController.java
│   │   ├── GradeController.java
│   │   └── HomeController.java
│   ├── model/
│   │   ├── User.java
│   │   ├── Student.java
│   │   ├── Teacher.java
│   │   ├── Quiz.java
│   │   ├── Question.java
│   │   ├── Grade.java
│   │   └── Message.java
│   ├── repository/
│   │   ├── UserRepository.java
│   │   ├── StudentRepository.java
│   │   ├── TeacherRepository.java
│   │   ├── QuizRepository.java
│   │   ├── QuestionRepository.java
│   │   ├── GradeRepository.java
│   │   └── MessageRepository.java
│   ├── service/
│   │   ├── UserService.java
│   │   ├── StudentService.java
│   │   ├── TeacherService.java
│   │   ├── QuizService.java
│   │   ├── GradeService.java
│   │   └── MessageService.java
│   ├── security/
│   │   └── SecurityConfig.java
│   └── StudentPortalApplication.java
├── src/main/resources/
│   ├── application.properties
│   └── templates/
│       └── hello.html
├── src/test/java/com/school/
│   └── StudentPortalApplicationTests.java
└── pom.xml
```

## Features

### Authentication & User Management
- User registration and login
- Role-based access control (Student/Teacher)
- Password encryption using BCrypt

### Student Features
- View personal profile
- Attempt quizzes
- View grades and performance
- Receive messages from teachers

### Teacher Features
- Create and manage quizzes
- Add questions to quizzes
- View student performance
- Send messages to students

### Quiz & Assessment
- Create multiple choice and true/false quizzes
- Grade student responses automatically
- View detailed performance metrics

### Messaging
- Send messages between teachers and students
- Mark messages as read
- View message history

### Grading System
- Automatic grade calculation (A, B, C, D, F)
- Performance tracking
- Pass/Fail determination

## Technologies Used

- **Framework**: Spring Boot 3.2.0
- **Language**: Java 17
- **Build Tool**: Maven
- **Database**: H2 (In-memory database for development)
- **ORM**: JPA/Hibernate
- **Security**: Spring Security with BCrypt
- **Template Engine**: Thymeleaf
- **Other**: Lombok for boilerplate reduction

## API Endpoints

### Authentication
```
POST   /api/auth/register       - Register a new user
POST   /api/auth/login          - Login user
GET    /api/auth/user/{id}      - Get user by ID
```

### Students
```
GET    /api/students            - Get all students
GET    /api/students/{id}       - Get student by ID
POST   /api/students            - Create new student
PUT    /api/students/{id}       - Update student
DELETE /api/students/{id}       - Delete student
```

### Teachers
```
GET    /api/teachers            - Get all teachers
GET    /api/teachers/{id}       - Get teacher by ID
POST   /api/teachers            - Create new teacher
PUT    /api/teachers/{id}       - Update teacher
DELETE /api/teachers/{id}       - Delete teacher
```

### Quizzes
```
GET    /api/quizzes             - Get all quizzes
GET    /api/quizzes/active      - Get active quizzes
GET    /api/quizzes/{id}        - Get quiz by ID
GET    /api/quizzes/teacher/{teacherId} - Get quizzes by teacher
POST   /api/quizzes             - Create new quiz
PUT    /api/quizzes/{id}        - Update quiz
DELETE /api/quizzes/{id}        - Delete quiz
```

### Grades
```
GET    /api/grades/{id}         - Get grade by ID
POST   /api/grades              - Record grade
PUT    /api/grades/{id}         - Update grade
DELETE /api/grades/{id}         - Delete grade
```

## Getting Started

### Prerequisites
- Java 17 or higher
- Maven 3.6.0 or higher

### Installation

1. Clone the repository
```bash
cd student-portal
```

2. Build the project
```bash
mvn clean install
```

3. Run the application
```bash
mvn spring-boot:run
```

4. Access the application
```
Home: http://localhost:8080/
API: http://localhost:8080/api/
```

## Database Configuration

The application uses H2 in-memory database by default. To configure a different database:

1. Update `src/main/resources/application.properties`
2. Change the datasource URL and driver class
3. Update the JPA dialect

### Current H2 Configuration
```properties
spring.datasource.url=jdbc:h2:mem:testdb
spring.datasource.driverClassName=org.h2.Driver
spring.h2.console.enabled=true
spring.h2.console.path=/h2-console
```

Access H2 Console: http://localhost:8080/h2-console

## Testing

Run the test suite:
```bash
mvn test
```

## Building for Production

Create a JAR file:
```bash
mvn package
```

Run the JAR:
```bash
java -jar target/student-portal-1.0.0.jar
```

## Security Considerations

- Passwords are encrypted using BCrypt
- Spring Security is configured to protect sensitive endpoints
- CSRF protection is disabled for API endpoints (add CSRF tokens in production)
- Use JWT tokens for better API security

## Future Enhancements

- JWT token-based authentication
- Email notifications
- Student dashboard with analytics
- Attendance tracking
- Assignment submission system
- Real-time notifications using WebSocket

## License

This project is open source and available under the MIT License.

## Support

For issues and questions, please create an issue in the repository.
