using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour


{
    public string menutoload = "Main Menu";
    public Text roundsText;

    void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // LOADS A SCENE (in this case reloads the scene)
    }

    public void Menu()
    {
        Debug.Log("Loading menu...");
        SceneManager.LoadScene(menutoload);
        // LOAD JAMIES MENU SCENE HERE
    }

}


