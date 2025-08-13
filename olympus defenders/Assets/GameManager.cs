using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool gameEnded = false;
    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
            return; // if the game has ended do not run the rest of the code
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over!");
    }
}
