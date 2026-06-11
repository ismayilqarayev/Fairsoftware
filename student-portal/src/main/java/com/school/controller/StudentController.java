package com.school.controller;

import com.school.model.Student;
import com.school.service.StudentService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/students")
public class StudentController {
    
    @Autowired
    private StudentService studentService;
    
    @GetMapping
    public ResponseEntity<List<Student>> getAllStudents() {
        List<Student> students = studentService.getAllStudents();
        return ResponseEntity.ok(students);
    }
    
    @GetMapping("/{id}")
    public ResponseEntity<Student> getStudentById(@PathVariable Long id) {
        var student = studentService.getStudentById(id);
        if (student.isPresent()) {
            return ResponseEntity.ok(student.get());
        }
        return ResponseEntity.notFound().build();
    }
    
    @PostMapping
    public ResponseEntity<Student> createStudent(@RequestBody Student student) {
        Student savedStudent = studentService.createStudent(student);
        return new ResponseEntity<>(savedStudent, HttpStatus.CREATED);
    }
    
    @PutMapping("/{id}")
    public ResponseEntity<Student> updateStudent(@PathVariable Long id, @RequestBody Student student) {
        var existingStudent = studentService.getStudentById(id);
        if (existingStudent.isPresent()) {
            student.setId(id);
            Student updatedStudent = studentService.updateStudent(student);
            return ResponseEntity.ok(updatedStudent);
        }
        return ResponseEntity.notFound().build();
    }
    
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteStudent(@PathVariable Long id) {
        var student = studentService.getStudentById(id);
        if (student.isPresent()) {
            studentService.deleteStudent(id);
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.notFound().build();
    }
}
