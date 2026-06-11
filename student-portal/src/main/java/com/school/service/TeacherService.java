package com.school.service;

import com.school.model.Teacher;
import com.school.repository.TeacherRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import java.util.List;
import java.util.Optional;

@Service
public class TeacherService {
    
    @Autowired
    private TeacherRepository teacherRepository;
    
    public Teacher createTeacher(Teacher teacher) {
        return teacherRepository.save(teacher);
    }
    
    public Optional<Teacher> getTeacherById(Long id) {
        return teacherRepository.findById(id);
    }
    
    public Optional<Teacher> getTeacherByTeacherId(String teacherId) {
        return teacherRepository.findByTeacherId(teacherId);
    }
    
    public Teacher updateTeacher(Teacher teacher) {
        return teacherRepository.save(teacher);
    }
    
    public void deleteTeacher(Long id) {
        teacherRepository.deleteById(id);
    }
    
    public List<Teacher> getAllTeachers() {
        return teacherRepository.findAll();
    }
}
