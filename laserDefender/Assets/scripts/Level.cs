using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadStartMenu() 
    {
        //implementation for lading scene
        //load the first scene in the build
        SceneManager.LoadScene(0);

    }

    public void LoadGame() 
    {
        //load the scene named "LazerDefender"
        SceneManager.LoadScene("LazerDefender");
    }

    public void LoadGameOver() 
    {
        //load the scene named "GameOver"
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame() 
    {
        //quit the application
        Application.Quit();
    }
}
