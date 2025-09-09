using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
	public GameObject ui;

void Update () // Checks for input to toggle pause menu
    {
	if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))

{
	Toggle (); // Call Toggle function
        }
}
	public void Toggle () // Toggle pause menu
    {
	ui.SetActive(!ui.activeSelf);

	if (ui.activeSelf)
	{
		Time.timeScale = 0f;
	}else
	{
		Time.timeScale = 1f;
	}
}
public string menutoload = "Main Menu";
public void Retry ()  // Reloads current scene
    {
	Toggle();
	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
	public void menu() // Loads main menu scene
    {
		Debug.Log("Go To Menu.");
		SceneManager.LoadScene(menutoload);
	
}
}
