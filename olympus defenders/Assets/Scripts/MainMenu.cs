using UnityEngine;
using UnityEngine.SceneManagement;
//
public class MainMenu : MonoBehaviour
{
    public string leveltoload = "Main scene"; //loading main scene 
    public void Play()
    {
        SceneManager.LoadScene(leveltoload); //soft coded loading main scene when Play button is pressed
    }
    public void Quit() //Quit button
    {
        Debug.Log("QUITING...");
        Application.Quit(); //application quit
        UnityEditor.EditorApplication.isPlaying = false; //unity player quit
    }
}
