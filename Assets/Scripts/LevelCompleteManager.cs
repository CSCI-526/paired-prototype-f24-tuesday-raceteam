using UnityEngine;

public class LevelCompleteManager : MonoBehaviour
{
    public TextMesh levelCompleteTextMesh;  
    private PlayerController playerController;

    void Start()
    {
        // hide the "Level Complete" sign at the start of the game
        levelCompleteTextMesh.gameObject.SetActive(false);

        playerController = FindObjectOfType<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("PlayerController not found in the scene.");
        }
    }

    public void TriggerLevelComplete()
    {
        // show the level complete sign
        levelCompleteTextMesh.gameObject.SetActive(true);

        // stop the player's movement
        if (playerController != null)
        {
            playerController.StopMovement();
        }
        else
        {
            Debug.LogError("PlayerController is not assigned.");
        }

        Time.timeScale = 0; 
    }
}