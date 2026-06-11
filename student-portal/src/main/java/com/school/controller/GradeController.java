package com.school.controller;

import com.school.model.Grade;
import com.school.service.GradeService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/grades")
public class GradeController {
    
    @Autowired
    private GradeService gradeService;
    
    @GetMapping("/{id}")
    public ResponseEntity<Grade> getGradeById(@PathVariable Long id) {
        var grade = gradeService.getGradeById(id);
        if (grade.isPresent()) {
            return ResponseEntity.ok(grade.get());
        }
        return ResponseEntity.notFound().build();
    }
    
    @PostMapping
    public ResponseEntity<Grade> createGrade(@RequestBody Grade grade) {
        Grade savedGrade = gradeService.createGrade(grade);
        return new ResponseEntity<>(savedGrade, HttpStatus.CREATED);
    }
    
    @PutMapping("/{id}")
    public ResponseEntity<Grade> updateGrade(@PathVariable Long id, @RequestBody Grade grade) {
        var existingGrade = gradeService.getGradeById(id);
        if (existingGrade.isPresent()) {
            grade.setId(id);
            Grade updatedGrade = gradeService.updateGrade(grade);
            return ResponseEntity.ok(updatedGrade);
        }
        return ResponseEntity.notFound().build();
    }
    
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteGrade(@PathVariable Long id) {
        var grade = gradeService.getGradeById(id);
        if (grade.isPresent()) {
            gradeService.deleteGrade(id);
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.notFound().build();
    }
}
