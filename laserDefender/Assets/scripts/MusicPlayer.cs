using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Awake is the first method in unity before start method
    void Awake()
    {
        SetupSingleton();
    }
    private void SetupSingleton() 
    {
        int numberOfMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;
        //if there is more than one music player, destroy the last one created
        if (numberOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }
   


    // Update is called once per frame
    void Update()
    {
        
    }
}
