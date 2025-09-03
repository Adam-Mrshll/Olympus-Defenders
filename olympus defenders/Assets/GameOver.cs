using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    void OnEnable() // runs when the game over object is enabled (set to active true in gamemanager script) 
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // LOADS A SCENE (in this case reloads the scene)
    }

    public void Menu()
    {
        Debug.Log("Loading menu..."); // LOAD JAMIES MENU SCENE HERE
    }

}


