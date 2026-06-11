package com.school.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import java.time.LocalDateTime;

@Entity
@Table(name = "grades")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Grade {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    
    @ManyToOne
    @JoinColumn(name = "student_id")
    private Student student;
    
    @ManyToOne
    @JoinColumn(name = "quiz_id")
    private Quiz quiz;
    
    @Column(name = "score_obtained")
    private Double scoreObtained;
    
    @Column(name = "total_score")
    private Double totalScore;
    
    @Column(name = "percentage")
    private Double percentage;
    
    @Column(name = "grade")
    private String grade; // A, B, C, D, F
    
    @Column(name = "attempted_at")
    private LocalDateTime attemptedAt;
    
    @Column(name = "is_passed")
    private Boolean isPassed;
}
