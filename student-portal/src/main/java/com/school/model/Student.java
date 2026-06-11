package com.school.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Entity
@Table(name = "students")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Student {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    
    @OneToOne
    @JoinColumn(name = "user_id")
    private User user;
    
    @Column(name = "student_id", unique = true)
    private String studentId;
    
    @Column(name = "class_name")
    private String className;
    
    @Column(name = "roll_number")
    private Integer rollNumber;
    
    @Column(name = "gpa")
    private Double gpa;
}
