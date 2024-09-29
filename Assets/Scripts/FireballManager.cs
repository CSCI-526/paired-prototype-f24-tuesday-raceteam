using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballManager : MonoBehaviour
{
    public TextMesh fireballTextMesh;  // Reference to the TextMesh component
    public int fireballCount = 0;  // Start with 0 fireballs

    void Start()
    {
        UpdateFireballText();  // Initialize the fireball count on start
    }

    // Function to update the text in TextMesh
    void UpdateFireballText()
    {
        fireballTextMesh.text = "Fireballs: " + fireballCount;  // Update the TextMesh content
    }

    // Function to increase the fireball count
    public void AddFireball()
    {
        fireballCount++;  // Increase fireball count
        UpdateFireballText();  // Update the displayed count
    }

    // Call this function to release a fireball
    public void ReleaseFireball()
    {
        if (fireballCount > 0)
        {
            fireballCount--;  // Reduce fireball count
            UpdateFireballText();  // Update the displayed count
            // Add logic to launch the fireball if needed
        }
        else
        {
            Debug.Log("No more fireballs!");
        }
    }

    // Example: If using the spacebar to release a fireball
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReleaseFireball();
        }
    }
}