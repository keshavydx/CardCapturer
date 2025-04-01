using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management functions

/// <summary>
/// Manages UI interactions, primarily scene loading in this case.
/// Attach this script to a GameObject in your scene (e.g., an empty GameObject named "_UIManager").
/// </summary>
public class UIManager : MonoBehaviour
{
    // --- Public Methods (Callable from UI Buttons) ---

    /// <summary>
    /// Loads the "PackSelection" scene.
    /// Make sure "PackSelection" is added to your Build Settings (File -> Build Settings...).
    /// </summary>
    public void LoadPackSelectionScene()
    {
        Debug.Log("Loading Scene: PackSelection");
        SceneManager.LoadScene("PackSelection");
    }

    /// <summary>
    /// Loads the "FirePack" scene.
    /// Make sure "FirePack" is added to your Build Settings (File -> Build Settings...).
    /// </summary>
    public void LoadFirePackScene()
    {
        Debug.Log("Loading Scene: FirePack");
        SceneManager.LoadScene("FirePack");
    }

    /// <summary>
    /// Loads the "WaterPack" scene.
    /// Make sure "WaterPack" is added to your Build Settings (File -> Build Settings...).
    /// </summary>
    public void LoadWaterPackScene()
    {
        Debug.Log("Loading Scene: WaterPack");
        SceneManager.LoadScene("WaterPack");
    }

    /// <summary>
    /// Loads the "GrassPack" scene.
    /// Make sure "GrassPack" is added to your Build Settings (File -> Build Settings...).
    /// </summary>
    public void LoadGrassPackScene()
    {
        Debug.Log("Loading Scene: GrassPack");
        SceneManager.LoadScene("GrassPack");
    }

    // --- Optional: Add a Quit Function (Common in UIManager) ---
    /*
    public void QuitApplication()
    {
        Debug.Log("Quitting Application...");
        Application.Quit();

        // If running in the editor, stop playing
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    */
}