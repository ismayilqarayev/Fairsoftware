package com.example.student;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Optional;
import java.util.concurrent.atomic.AtomicLong;

import org.springframework.stereotype.Service;

@Service
public class StudentService {
    private final List<Student> students = new ArrayList<>();
    private final AtomicLong idGenerator = new AtomicLong(4);

    public StudentService() {
        students.add(new Student(1L, "Aysel", "Aliyeva", "aysel@example.com", "+994 50 111 22 33", "Computer Science", 2));
        students.add(new Student(2L, "Murad", "Huseynov", "murad@example.com", "+994 55 222 33 44", "Information Security", 3));
        students.add(new Student(3L, "Nigar", "Mammadova", "nigar@example.com", "+994 70 333 44 55", "Software Engineering", 1));
    }

    public List<Student> findAll() {
        return students.stream()
                .sorted(Comparator.comparing(Student::getId))
                .toList();
    }

    public List<Student> search(String query) {
        if (query == null || query.isBlank()) {
            return findAll();
        }

        String normalizedQuery = query.trim().toLowerCase();
        return students.stream()
                .filter(student -> contains(student.getFirstName(), normalizedQuery)
                        || contains(student.getLastName(), normalizedQuery)
                        || contains(student.getEmail(), normalizedQuery)
                        || contains(student.getPhone(), normalizedQuery)
                        || contains(student.getMajor(), normalizedQuery))
                .sorted(Comparator.comparing(Student::getId))
                .toList();
    }

    public long count() {
        return students.size();
    }

    public long countMajors() {
        return students.stream()
                .map(Student::getMajor)
                .map(String::toLowerCase)
                .distinct()
                .count();
    }

    public double averageYear() {
        return students.stream()
                .mapToInt(Student::getYear)
                .average()
                .orElse(0);
    }

    public Optional<Student> findById(Long id) {
        return students.stream()
                .filter(student -> student.getId().equals(id))
                .findFirst();
    }

    public Student create(Student student) {
        student.setId(idGenerator.getAndIncrement());
        students.add(student);
        return student;
    }

    public void update(Long id, Student updatedStudent) {
        Student student = findById(id).orElseThrow();
        student.setFirstName(updatedStudent.getFirstName());
        student.setLastName(updatedStudent.getLastName());
        student.setEmail(updatedStudent.getEmail());
        student.setPhone(updatedStudent.getPhone());
        student.setMajor(updatedStudent.getMajor());
        student.setYear(updatedStudent.getYear());
    }

    public void delete(Long id) {
        students.removeIf(student -> student.getId().equals(id));
    }

    private boolean contains(String value, String query) {
        return value != null && value.toLowerCase().contains(query);
    }
}
