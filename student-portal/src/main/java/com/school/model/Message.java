package com.school.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import java.time.LocalDateTime;

@Entity
@Table(name = "messages")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Message {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    
    @ManyToOne
    @JoinColumn(name = "sender_id")
    private User sender;
    
    @ManyToOne
    @JoinColumn(name = "receiver_id")
    private User receiver;
    
    @Column(columnDefinition = "TEXT", nullable = false)
    private String content;
    
    @Column(name = "sent_at")
    private LocalDateTime sentAt;
    
    @Column(name = "is_read")
    private Boolean isRead = false;
    
    @Column(name = "subject")
    private String subject;
}
