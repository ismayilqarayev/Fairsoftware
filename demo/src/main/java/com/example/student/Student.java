package com.example.student;

import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.Max;
import jakarta.validation.constraints.Min;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.Pattern;

public class Student {
    private Long id;

    @NotBlank(message = "Ad bos ola bilmez")
    private String firstName;

    @NotBlank(message = "Soyad bos ola bilmez")
    private String lastName;

    @Email(message = "Email duzgun formatda deyil")
    @NotBlank(message = "Email bos ola bilmez")
    private String email;

    @NotBlank(message = "Telefon bos ola bilmez")
    @Pattern(regexp = "^\\+?[0-9\\-\\s]{7,20}$", message = "Telefon nomresi duzgun deyil")
    private String phone;

    @NotBlank(message = "Ixtisas bos ola bilmez")
    private String major;

    @Min(value = 1, message = "Kurs minimum 1 olmalidir")
    @Max(value = 6, message = "Kurs maksimum 6 ola biler")
    private int year = 1;

    public Student() {
    }

    public Student(Long id, String firstName, String lastName, String email, String phone, String major, int year) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.phone = phone;
        this.major = major;
        this.year = year;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public String getMajor() {
        return major;
    }

    public void setMajor(String major) {
        this.major = major;
    }

    public int getYear() {
        return year;
    }

    public void setYear(int year) {
        this.year = year;
    }
}
