using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool GameIsOver;

    public GameObject gameOverUI;

    void Start()
    {
        GameIsOver = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return; // if the game has ended do not run the rest of the code

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if (PlayerStats.Lives <= 0) // if the player loses their 3 lives it runs the end game function
        {
            EndGame();
        }
    }

    void EndGame() // game over function
    {
        GameIsOver = true;
        gameOverUI.SetActive(true); 
    }
}
