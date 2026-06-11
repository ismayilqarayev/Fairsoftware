package com.school.repository;

import com.school.model.Grade;
import com.school.model.Quiz;
import com.school.model.Student;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface GradeRepository extends JpaRepository<Grade, Long> {
    List<Grade> findByStudent(Student student);
    List<Grade> findByQuiz(Quiz quiz);
    Optional<Grade> findByStudentAndQuiz(Student student, Quiz quiz);
}
