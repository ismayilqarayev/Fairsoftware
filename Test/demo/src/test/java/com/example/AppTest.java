package com.example;

import java.io.ByteArrayOutputStream;
import java.io.PrintStream;

import static org.junit.Assert.assertTrue;
import static org.junit.Assert.assertEquals;

import org.junit.Test;

/**
 * Unit test for simple App.
 */
public class AppTest 
{
    /**
     * Rigorous Test :-)
     */
    @Test
    public void shouldAnswerWithTrue()
    {
        assertTrue( true );
    }

    /**
     * Test for the main method to ensure it prints "Hello World!".
     */
    @Test
    public void mainShouldPrintHelloWorld() {
        // Capture System.out
        ByteArrayOutputStream outContent = new ByteArrayOutputStream();
        PrintStream originalOut = System.out;
        System.setOut(new PrintStream(outContent));

        // Call the main method
        App.main(new String[]{});

        // Assert the output
        assertEquals("Hello World!\n", outContent.toString());
        System.setOut(originalOut); // Restore System.out
    }
}
