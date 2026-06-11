package com.school.service;

import com.school.model.Quiz;
import com.school.repository.QuizRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import java.util.List;
import java.util.Optional;

@Service
public class QuizService {
    
    @Autowired
    private QuizRepository quizRepository;
    
    public Quiz createQuiz(Quiz quiz) {
        return quizRepository.save(quiz);
    }
    
    public Optional<Quiz> getQuizById(Long id) {
        return quizRepository.findById(id);
    }
    
    public Quiz updateQuiz(Quiz quiz) {
        return quizRepository.save(quiz);
    }
    
    public void deleteQuiz(Long id) {
        quizRepository.deleteById(id);
    }
    
    public List<Quiz> getAllQuizzes() {
        return quizRepository.findAll();
    }
    
    public List<Quiz> getQuizzesByTeacherId(Long teacherId) {
        return quizRepository.findByTeacherId(teacherId);
    }
    
    public List<Quiz> getActiveQuizzes() {
        return quizRepository.findByIsActiveTrue();
    }
}
