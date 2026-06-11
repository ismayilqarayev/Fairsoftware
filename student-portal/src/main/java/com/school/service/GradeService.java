package com.school.service;

import com.school.model.Grade;
import com.school.model.Quiz;
import com.school.model.Student;
import com.school.repository.GradeRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import java.util.List;
import java.util.Optional;

@Service
public class GradeService {
    
    @Autowired
    private GradeRepository gradeRepository;
    
    public Grade createGrade(Grade grade) {
        // Calculate grade based on percentage
        if (grade.getPercentage() >= 90) {
            grade.setGrade("A");
        } else if (grade.getPercentage() >= 80) {
            grade.setGrade("B");
        } else if (grade.getPercentage() >= 70) {
            grade.setGrade("C");
        } else if (grade.getPercentage() >= 60) {
            grade.setGrade("D");
        } else {
            grade.setGrade("F");
        }
        return gradeRepository.save(grade);
    }
    
    public Optional<Grade> getGradeById(Long id) {
        return gradeRepository.findById(id);
    }
    
    public Grade updateGrade(Grade grade) {
        return gradeRepository.save(grade);
    }
    
    public void deleteGrade(Long id) {
        gradeRepository.deleteById(id);
    }
    
    public List<Grade> getGradesByStudent(Student student) {
        return gradeRepository.findByStudent(student);
    }
    
    public List<Grade> getGradesByQuiz(Quiz quiz) {
        return gradeRepository.findByQuiz(quiz);
    }
    
    public Optional<Grade> getStudentQuizGrade(Student student, Quiz quiz) {
        return gradeRepository.findByStudentAndQuiz(student, quiz);
    }
}
