using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public TextMesh materialTextMesh;  // Reference to the TextMesh component
    private Dictionary<string, int> materialCounts = new Dictionary<string, int>();  // Track counts of different materials

    void Start()
    {
        UpdateMaterialsText();  // Initialize the power-up count on start
    }

    // Function to update the text in TextMesh
    void UpdateMaterialsText()
    {
        materialTextMesh.text = "Materials: \n";  // Clear the text
        // print the powerups collected in a debug log
        Debug.Log("Powerups collected: ");
        foreach (KeyValuePair<string, int> entry in materialCounts)
        {
            Debug.Log(entry.Key + ": " + entry.Value);
        }

        foreach (KeyValuePair<string, int> entry in materialCounts)
        {
            materialTextMesh.text += entry.Key + ": " + entry.Value + "\n";  // Display each power-up and its count
        }
    }

    // Function to increase the count of a power-up
    public void AddMaterial(string materialName)
    {
      Debug.Log("In MaterialManager AddMaterial");
        if (materialCounts.ContainsKey(materialName))
        {
            Debug.Log("Material already exists: " + materialName);
            materialCounts[materialName]++;  // Increase the count if the power-up already exists
        }
        else
        {
            Debug.Log("New power-up: " + materialName);
            materialCounts[materialName] = 1;  // Add a new power-up to the dictionary
        }
         Debug.Log("Material added successfully");
        UpdateMaterialsText();  // Update the displayed counts
    }

    // Call this function to release a power-up (decrease its count)
    public void ReleaseMaterial(string materialName)
    {
        if (materialCounts.ContainsKey(materialName) && materialCounts[materialName] > 0)
        {
            materialCounts[materialName]--;  // Reduce the count for the given power-up
            if (materialCounts[materialName] == 0)
            {
                materialCounts.Remove(materialName);  // Remove the power-up if the count reaches 0
            }

            UpdateMaterialsText();  // Update the displayed counts
        }
        else
        {
            Debug.Log("No more " + materialName + "s!");
        }
    }

    // Example: If using the spacebar to release a fireball or any power-up
    void Update()
    {
    }
}
