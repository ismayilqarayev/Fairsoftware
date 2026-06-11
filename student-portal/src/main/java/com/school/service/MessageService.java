package com.school.service;

import com.school.model.Message;
import com.school.model.User;
import com.school.repository.MessageRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import java.time.LocalDateTime;
import java.util.List;
import java.util.Optional;

@Service
public class MessageService {
    
    @Autowired
    private MessageRepository messageRepository;
    
    public Message sendMessage(Message message) {
        message.setSentAt(LocalDateTime.now());
        return messageRepository.save(message);
    }
    
    public Optional<Message> getMessageById(Long id) {
        return messageRepository.findById(id);
    }
    
    public List<Message> getReceivedMessages(User receiver) {
        return messageRepository.findByReceiver(receiver);
    }
    
    public List<Message> getSentMessages(User sender) {
        return messageRepository.findBySender(sender);
    }
    
    public List<Message> getUnreadMessages(User receiver) {
        return messageRepository.findByReceiverAndIsReadFalse(receiver);
    }
    
    public void markAsRead(Long messageId) {
        Optional<Message> message = messageRepository.findById(messageId);
        if (message.isPresent()) {
            message.get().setIsRead(true);
            messageRepository.save(message.get());
        }
    }
    
    public void deleteMessage(Long id) {
        messageRepository.deleteById(id);
    }
}
