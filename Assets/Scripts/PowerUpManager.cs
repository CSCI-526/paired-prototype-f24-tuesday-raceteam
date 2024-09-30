using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public TextMesh powerUpTextMesh;  // Reference to the TextMesh component
    private Dictionary<string, int> powerUpCounts = new Dictionary<string, int>();  // Track counts of different power-ups

    void Start()
    {
        UpdatePowerUpText();  // Initialize the power-up count on start
    }

    // Function to update the text in TextMesh
    void UpdatePowerUpText()
    {
        powerUpTextMesh.text = "Power-Ups: \n";  // Clear the text
        // print the powerups collected in a debug log
        Debug.Log("Powerups collected: ");
        foreach (KeyValuePair<string, int> entry in powerUpCounts)
        {
            Debug.Log(entry.Key + ": " + entry.Value);
        }

        foreach (KeyValuePair<string, int> entry in powerUpCounts)
        {
            powerUpTextMesh.text += entry.Key + ": " + entry.Value + "\n";  // Display each power-up and its count
        }
    }

    // Function to increase the count of a power-up
    public void AddPowerUp(string powerUpName)
    {
        if (powerUpCounts.ContainsKey(powerUpName))
        {
            powerUpCounts[powerUpName]++;  // Increase the count if the power-up already exists
        }
        else
        {
            Debug.Log("New power-up: " + powerUpName);
            powerUpCounts[powerUpName] = 1;  // Add a new power-up to the dictionary
        }

        UpdatePowerUpText();  // Update the displayed counts
    }

    // Call this function to release a power-up (decrease its count)
    public void ReleasePowerUp(string powerUpName)
    {
        if (powerUpCounts.ContainsKey(powerUpName) && powerUpCounts[powerUpName] > 0)
        {
            powerUpCounts[powerUpName]--;  // Reduce the count for the given power-up
            if (powerUpCounts[powerUpName] == 0)
            {
                powerUpCounts.Remove(powerUpName);  // Remove the power-up if the count reaches 0
            }

            UpdatePowerUpText();  // Update the displayed counts
        }
        else
        {
            Debug.Log("No more " + powerUpName + "s!");
        }
    }

    // Example: If using the spacebar to release a fireball or any power-up
    void Update()
    {
    }
}
