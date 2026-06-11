package com.school.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import java.time.LocalDateTime;

@Entity
@Table(name = "quizzes")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Quiz {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    
    @Column(nullable = false)
    private String title;
    
    @Column(columnDefinition = "TEXT")
    private String description;
    
    @ManyToOne
    @JoinColumn(name = "teacher_id")
    private Teacher teacher;
    
    @Column(name = "total_questions")
    private Integer totalQuestions;
    
    @Column(name = "duration_minutes")
    private Integer durationMinutes;
    
    @Column(name = "passing_score")
    private Double passingScore;
    
    @Column(name = "created_at")
    private LocalDateTime createdAt;
    
    @Column(name = "is_active")
    private Boolean isActive = true;
}
