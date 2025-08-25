using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string leveltoload = "Main scene";
    public void Play()
    {
        SceneManager.LoadScene(leveltoload);
    }
    public void Quit()
    {
        Debug.Log("QUITING...");
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
