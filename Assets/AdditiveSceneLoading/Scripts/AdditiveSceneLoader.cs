using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 *  Ensure a specific scene is always loaded  
 *  - Add this to every scene (not the manager) to make sure the manager is always loaded
 *  - Add to manager scene to load other required global scenes (e.g. GameUI)
 */
public class AdditiveSceneLoader : MonoBehaviour {

    [Tooltip ("The scene to load. Change only if using in game manager scene")]
    public string additiveScene = "Global_GameManager";

    // on awake
    private void Awake ()
    {
        CheckLoadAsyncScene (additiveScene);
    }

    /// <summary>
    /// Load an additive scene 
    /// </summary>
    public void CheckLoadAsyncScene (string sceneName)
    {
        if (!IsSceneLoaded (sceneName)) {
            SceneManager.LoadSceneAsync (sceneName, LoadSceneMode.Additive);

            // check if a previous scene should be unloaded
            //CheckUnloadAsyncScene (sceneName);
        }
    }

    /// <summary>
    /// Returns true if the scene is loaded AND valid
    /// </summary>
    public bool IsSceneLoaded (string _name)
    {
        Scene scene = SceneManager.GetSceneByName (_name);
        Debug.Log ($"IsSceneLoaded('{_name}') scene.isLoaded={scene.isLoaded}, scene.IsValid()={scene.IsValid ()}");
        return (scene.isLoaded && scene.IsValid ());
    }


}
