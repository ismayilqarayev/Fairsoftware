package com.example.student;

import jakarta.validation.Valid;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

@Controller
@RequestMapping("/")
public class StudentController {
    private final StudentService studentService;

    public StudentController(StudentService studentService) {
        this.studentService = studentService;
    }

    @GetMapping
    public String home(@RequestParam(name = "q", required = false) String q, Model model) {
        model.addAttribute("students", studentService.search(q));
        model.addAttribute("query", q == null ? "" : q);
        model.addAttribute("totalStudents", studentService.count());
        model.addAttribute("majorCount", studentService.countMajors());
        model.addAttribute("averageYear", studentService.averageYear());
        return "students";
    }

    @GetMapping("/students/new")
    public String newStudent(Model model) {
        model.addAttribute("student", new Student());
        model.addAttribute("formTitle", "Yeni telebe");
        model.addAttribute("action", "/students");
        return "student-form";
    }

    @PostMapping("/students")
    public String createStudent(@Valid @ModelAttribute("student") Student student, BindingResult bindingResult, Model model,
            RedirectAttributes redirectAttributes) {
        if (bindingResult.hasErrors()) {
            model.addAttribute("formTitle", "Yeni telebe");
            model.addAttribute("action", "/students");
            return "student-form";
        }

        studentService.create(student);
        redirectAttributes.addFlashAttribute("message", "Telebe elave olundu");
        return "redirect:/";
    }

    @GetMapping("/students/{id}/edit")
    public String editStudent(@PathVariable("id") Long id, Model model) {
        Student student = studentService.findById(id).orElseThrow();
        model.addAttribute("student", student);
        model.addAttribute("formTitle", "Telebeni redakte et");
        model.addAttribute("action", "/students/" + id);
        return "student-form";
    }

    @PostMapping("/students/{id}")
    public String updateStudent(@PathVariable("id") Long id, @Valid @ModelAttribute("student") Student student,
            BindingResult bindingResult, Model model, RedirectAttributes redirectAttributes) {
        if (bindingResult.hasErrors()) {
            model.addAttribute("formTitle", "Telebeni redakte et");
            model.addAttribute("action", "/students/" + id);
            return "student-form";
        }

        studentService.update(id, student);
        redirectAttributes.addFlashAttribute("message", "Telebe melumatlari yenilendi");
        return "redirect:/";
    }

    @PostMapping("/students/{id}/delete")
    public String deleteStudent(@PathVariable("id") Long id, RedirectAttributes redirectAttributes) {
        studentService.delete(id);
        redirectAttributes.addFlashAttribute("message", "Telebe silindi");
        return "redirect:/";
    }
}
