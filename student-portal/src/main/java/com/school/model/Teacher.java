package com.school.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Entity
@Table(name = "teachers")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Teacher {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    
    @OneToOne
    @JoinColumn(name = "user_id")
    private User user;
    
    @Column(name = "teacher_id", unique = true)
    private String teacherId;
    
    @Column(name = "department")
    private String department;
    
    @Column(name = "subject")
    private String subject;
    
    @Column(name = "qualification")
    private String qualification;
}
