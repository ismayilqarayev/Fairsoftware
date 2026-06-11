package com.school.repository;

import com.school.model.Message;
import com.school.model.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface MessageRepository extends JpaRepository<Message, Long> {
    List<Message> findByReceiver(User receiver);
    List<Message> findBySender(User sender);
    List<Message> findByReceiverAndIsReadFalse(User receiver);
}
