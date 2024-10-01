using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    private GameOverManager gameOverManager;

    void Start()
    {
        // find the GameOverManager 
        gameOverManager = FindObjectOfType<GameOverManager>();
        if (gameOverManager == null)
        {
            Debug.LogError("GameOverManager not found in the scene.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        // ignore collisions with the walls
        if (collision.gameObject.name == "floor" || collision.gameObject.name == "left wall" || collision.gameObject.name == "right wall")
        {
            return;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with obstacle!");

            // trigger the game over event to start
            if (gameOverManager != null)
            {
                gameOverManager.TriggerGameOver();
            }
            else
            {
                Debug.LogError("GameOverManager is not assigned.");
            }

        }
    }
}