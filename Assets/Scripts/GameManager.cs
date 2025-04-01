using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public PackData SelectedPack { get; private set; } // Which pack the player chose

    void Awake()
    {
        // Singleton pattern: Ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scene loads
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManagers
        }
    }

    public void SelectPackAndLoadOpeningScene(PackData packToOpen)
    {
        SelectedPack = packToOpen;
        // Replace "PackOpeningScene" with the actual name of your next scene
        SceneManager.LoadScene("PackOpeningScene");
    }
}