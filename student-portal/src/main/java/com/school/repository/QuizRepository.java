package com.school.repository;

import com.school.model.Quiz;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface QuizRepository extends JpaRepository<Quiz, Long> {
    List<Quiz> findByTeacherId(Long teacherId);
    List<Quiz> findByIsActiveTrue();
}
