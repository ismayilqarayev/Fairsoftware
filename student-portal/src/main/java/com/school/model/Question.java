package com.school.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Entity
@Table(name = "questions")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Question {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    
    @ManyToOne
    @JoinColumn(name = "quiz_id")
    private Quiz quiz;
    
    @Column(columnDefinition = "TEXT", nullable = false)
    private String questionText;
    
    @Column(name = "question_type") // MULTIPLE_CHOICE, TRUE_FALSE, SHORT_ANSWER
    private String questionType;
    
    @Column(columnDefinition = "TEXT")
    private String optionA;
    
    @Column(columnDefinition = "TEXT")
    private String optionB;
    
    @Column(columnDefinition = "TEXT")
    private String optionC;
    
    @Column(columnDefinition = "TEXT")
    private String optionD;
    
    @Column(columnDefinition = "TEXT")
    private String correctAnswer;
    
    @Column(name = "marks")
    private Double marks;
    
    @Column(name = "question_number")
    private Integer questionNumber;
}
