package com.school.controller;

import com.school.model.Quiz;
import com.school.service.QuizService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/quizzes")
public class QuizController {
    
    @Autowired
    private QuizService quizService;
    
    @GetMapping
    public ResponseEntity<List<Quiz>> getAllQuizzes() {
        List<Quiz> quizzes = quizService.getAllQuizzes();
        return ResponseEntity.ok(quizzes);
    }
    
    @GetMapping("/active")
    public ResponseEntity<List<Quiz>> getActiveQuizzes() {
        List<Quiz> quizzes = quizService.getActiveQuizzes();
        return ResponseEntity.ok(quizzes);
    }
    
    @GetMapping("/{id}")
    public ResponseEntity<Quiz> getQuizById(@PathVariable Long id) {
        var quiz = quizService.getQuizById(id);
        if (quiz.isPresent()) {
            return ResponseEntity.ok(quiz.get());
        }
        return ResponseEntity.notFound().build();
    }
    
    @GetMapping("/teacher/{teacherId}")
    public ResponseEntity<List<Quiz>> getQuizzesByTeacher(@PathVariable Long teacherId) {
        List<Quiz> quizzes = quizService.getQuizzesByTeacherId(teacherId);
        return ResponseEntity.ok(quizzes);
    }
    
    @PostMapping
    public ResponseEntity<Quiz> createQuiz(@RequestBody Quiz quiz) {
        Quiz savedQuiz = quizService.createQuiz(quiz);
        return new ResponseEntity<>(savedQuiz, HttpStatus.CREATED);
    }
    
    @PutMapping("/{id}")
    public ResponseEntity<Quiz> updateQuiz(@PathVariable Long id, @RequestBody Quiz quiz) {
        var existingQuiz = quizService.getQuizById(id);
        if (existingQuiz.isPresent()) {
            quiz.setId(id);
            Quiz updatedQuiz = quizService.updateQuiz(quiz);
            return ResponseEntity.ok(updatedQuiz);
        }
        return ResponseEntity.notFound().build();
    }
    
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteQuiz(@PathVariable Long id) {
        var quiz = quizService.getQuizById(id);
        if (quiz.isPresent()) {
            quizService.deleteQuiz(id);
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.notFound().build();
    }
}
