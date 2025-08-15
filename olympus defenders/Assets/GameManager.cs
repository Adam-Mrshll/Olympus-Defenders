using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool GameIsOver = false;

    public GameObject gameOverUI;
    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return; // if the game has ended do not run the rest of the code

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true); 
    }
}
