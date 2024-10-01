using UnityEngine;

public class EndOfRoadTrigger : MonoBehaviour
{
    private LevelCompleteManager levelCompleteManager;

    void Start()
    {
        // find the LevelCompleteManager 
        levelCompleteManager = FindObjectOfType<LevelCompleteManager>();
        if (levelCompleteManager == null)
        {
            Debug.LogError("LevelCompleteManager not found in the scene.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player reached the end of the road!");

            // trigger the level complete event
            if (levelCompleteManager != null)
            {
                levelCompleteManager.TriggerLevelComplete();
            }
            else
            {
                Debug.LogError("LevelCompleteManager is not assigned.");
            }
        }
    }
}