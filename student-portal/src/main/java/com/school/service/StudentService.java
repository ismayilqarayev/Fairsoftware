package com.school.service;

import com.school.model.Student;
import com.school.repository.StudentRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import java.util.List;
import java.util.Optional;

@Service
public class StudentService {
    
    @Autowired
    private StudentRepository studentRepository;
    
    public Student createStudent(Student student) {
        return studentRepository.save(student);
    }
    
    public Optional<Student> getStudentById(Long id) {
        return studentRepository.findById(id);
    }
    
    public Optional<Student> getStudentByStudentId(String studentId) {
        return studentRepository.findByStudentId(studentId);
    }
    
    public Student updateStudent(Student student) {
        return studentRepository.save(student);
    }
    
    public void deleteStudent(Long id) {
        studentRepository.deleteById(id);
    }
    
    public List<Student> getAllStudents() {
        return studentRepository.findAll();
    }
}
