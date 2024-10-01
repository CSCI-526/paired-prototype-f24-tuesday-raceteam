using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public TextMesh gameOverTextMesh;  

    void Start()
    {
        // hide the Game Over sign at the start
        gameOverTextMesh.gameObject.SetActive(false);
    }

    public void TriggerGameOver()
    {
        // show the Game Over sign
        gameOverTextMesh.gameObject.SetActive(true);

        Time.timeScale = 0; 
    }
}