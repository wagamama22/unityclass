using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;
    public void LoadStartMenu() 
    {
        //implementation for lading scene
        //load the first scene in the build
        SceneManager.LoadScene(0);

    }

    IEnumerator WaitAndLoad() 
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("LazerDefender");
    }

    public void LoadGame() 
    {
        //load the scene named "LazerDefender"
        SceneManager.LoadScene("LazerDefender");
    }

    public void LoadGameOver() 
    {
        //load the scene named "GameOver"
        StartCoroutine(WaitAndLoad());
    }

    public void QuitGame() 
    {
        //quit the application
        Application.Quit();
        print("quit game");
       // EditorApplication.isPlaying = false;
    }
}
