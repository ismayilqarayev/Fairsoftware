package com.school.controller;

import com.school.model.Teacher;
import com.school.service.TeacherService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/teachers")
public class TeacherController {
    
    @Autowired
    private TeacherService teacherService;
    
    @GetMapping
    public ResponseEntity<List<Teacher>> getAllTeachers() {
        List<Teacher> teachers = teacherService.getAllTeachers();
        return ResponseEntity.ok(teachers);
    }
    
    @GetMapping("/{id}")
    public ResponseEntity<Teacher> getTeacherById(@PathVariable Long id) {
        var teacher = teacherService.getTeacherById(id);
        if (teacher.isPresent()) {
            return ResponseEntity.ok(teacher.get());
        }
        return ResponseEntity.notFound().build();
    }
    
    @PostMapping
    public ResponseEntity<Teacher> createTeacher(@RequestBody Teacher teacher) {
        Teacher savedTeacher = teacherService.createTeacher(teacher);
        return new ResponseEntity<>(savedTeacher, HttpStatus.CREATED);
    }
    
    @PutMapping("/{id}")
    public ResponseEntity<Teacher> updateTeacher(@PathVariable Long id, @RequestBody Teacher teacher) {
        var existingTeacher = teacherService.getTeacherById(id);
        if (existingTeacher.isPresent()) {
            teacher.setId(id);
            Teacher updatedTeacher = teacherService.updateTeacher(teacher);
            return ResponseEntity.ok(updatedTeacher);
        }
        return ResponseEntity.notFound().build();
    }
    
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteTeacher(@PathVariable Long id) {
        var teacher = teacherService.getTeacherById(id);
        if (teacher.isPresent()) {
            teacherService.deleteTeacher(id);
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.notFound().build();
    }
}
