using UnityEngine;
using UnityEngine.SceneManagement;

/**
 *  Makes sure another scene is loaded alongside this one
 *  - Every world scene has one (on the LoadGameManager prefab) that loads Global_SceneManager
 *  - Global_SceneManager has one that loads Global_GameUI
 *  - So you can press Play in ANY scene and everything the game needs gets loaded
 *
 *  To add a new world scene (e.g. World_3):
 *  1. Add the LoadGameManager prefab to it
 *  2. Add a Camera and remove its Audio Listener (Global_SceneManager already has one)
 *  3. Add the scene to File > Build Profiles > Scene List (scenes can't load by name otherwise)
 *  4. Add a button for it in Global_GameUI (see AdditiveSceneManager)
 */
public class LoadSceneManager : MonoBehaviour
{
    [Tooltip("The scene to load alongside this one")]
    public string additiveScene = "Global_SceneManager";

    void Awake()
    {
        // only load it if it isn't loaded yet (otherwise we would get two copies)
        if (!SceneManager.GetSceneByName(additiveScene).isLoaded)
        {
            // Additive = add the scene to the ones already open (instead of replacing them)
            SceneManager.LoadSceneAsync(additiveScene, LoadSceneMode.Additive);
        }
    }
}
