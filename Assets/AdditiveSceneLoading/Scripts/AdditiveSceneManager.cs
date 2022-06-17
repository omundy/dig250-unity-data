using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 *  Add this to the manager scene to listen for events, keep track of current active scene (non-globals)
 */
public class AdditiveSceneManager : MonoBehaviour {

    // scenes containing this string are not saved as "active scenes
    private string globalPrefix = "Global_";
    // current "world scene"
    private string currentActiveScene = "";


    private void Awake ()
    {
        // if this is the UI scene
        StartCoroutine (UpdateSceneList ());
    }




    void OnEnable ()
    {
        EventManager.StartListening ("UpdateSceneList", UpdateSceneListFromEvent);
    }

    void OnDisable ()
    {
        EventManager.StopListening ("UpdateSceneList", UpdateSceneListFromEvent);
    }

    void UpdateSceneListFromEvent ()
    {
        StartCoroutine (UpdateSceneList ());
    }









    /// <summary>
    /// Check (and load) a specific scene
    /// </summary>
    public void LoadSceneFromEvent (string sceneName)
    {
        CheckLoadAsyncScene (sceneName);
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



    public void CheckUnloadAsyncScene (string sceneName)
    {
        // if this was the "global scene" then do nothing
        if (sceneName.Contains (globalPrefix)) return;

        // if we had another scene loaded
        if (currentActiveScene != "") {
            Debug.Log ("Unloading previous active scene: " + sceneName);
            // unload it
            SceneManager.UnloadSceneAsync (currentActiveScene);
        }
        // save name of new scene
        currentActiveScene = sceneName;
    }









    /// <summary>
    /// Check for existance of a "world scene" and set as the current active scene
    /// </summary>
    IEnumerator UpdateSceneList ()
    {
        // wait a moment
        yield return new WaitForSeconds (0.5f);
        // check if this script instance is inside a scene not
        if (!gameObject.scene.name.Contains (globalPrefix))
            currentActiveScene = gameObject.scene.name;
        yield break;
    }

    /// <summary>
    /// Return names of all the loaded scenes
    /// </summary>
    public string [] ReturnAllLoadedSceneNames ()
    {
        // number loaded
        int countLoaded = SceneManager.sceneCount;
        // new array to store names
        string [] loadedScenes = new string [countLoaded];
        // loop through number loaded
        for (int i = 0; i < countLoaded; i++) {
            // save name
            loadedScenes [i] = SceneManager.GetSceneAt (i).name;
        }
        return loadedScenes;
    }















    //public int sceneCount;              // total scenes loaded
    //public int sceneCountMax;           // max number of scenes allowed to load
    //public string currentActiveScene;   // current "world scene" (not global)

    //private string globalPrefix = "Global_"; // scenes containing this string are loaded just once
    //public List<string> globalScenesToLoad = new List<string> ();
    //public int globalScenesLoaded = 0;      // # global scenes loaded

    //private void Awake ()
    //{
    //    // manager scene, loaded by all others
    //    globalScenesToLoad.Add ("Global_GameManager");
    //    // followed by other global scenes loaded by game manager
    //    globalScenesToLoad.Add ("Global_GameUI");
    //    // assuming there is only one other global scene
    //    sceneCountMax = globalScenesToLoad.Count + 1;

    //    // start checking / loading scenes
    //    StartCoroutine (LoadGlobalScenes ());
    //}

    ///// <summary>
    ///// Check / load all global scenes
    ///// </summary>
    //IEnumerator LoadGlobalScenes ()
    //{
    //    // loop until all global scenes are loaded
    //    while (globalScenesLoaded < globalScenesToLoad.Count) {
    //        Debug.Log ("LoadGlobalScenes() " + globalScenesLoaded + ", " + globalScenesToLoad [globalScenesLoaded]);
    //        // check and load the manager scene
    //        StartCoroutine (CheckLoadAsyncScene (globalScenesToLoad [globalScenesLoaded]));
    //        // wait a bit for it to complete
    //        yield return new WaitForSeconds (0.2f);
    //        // update number of global scenes loaded
    //        globalScenesLoaded = SceneListLoadedCount (globalScenesToLoad);
    //        // update before looping again
    //        sceneCount = SceneManager.sceneCount;
    //    }
    //}




    //public void CheckLoadWorldScene (string sceneName)
    //{
    //    StartCoroutine (CheckLoadAsyncScene (sceneName));


    //    //// if this was the "global scene" then we are done
    //    //if (sceneName.Contains (globalPrefix)) return;
    //    //// otherwise, it is a world scene

    //    // if there was already an active scene
    //    if (currentActiveScene != "") {
    //        Debug.Log ("Unloading previous world scene");
    //        // unload the active scene
    //        SceneManager.UnloadSceneAsync (currentActiveScene);
    //    }
    //    // and save it as the current active scene
    //    currentActiveScene = sceneName;
    //}



    ///// <summary>
    ///// Check (and load) a specific scene
    ///// </summary>
    //public void LoadSceneFromEvent (string sceneName)
    //{
    //    // load scene
    //    StartCoroutine (CheckLoadAsyncScene (sceneName));
    //}

    ///// <summary>
    ///// Load a scene in the background
    ///// </summary>
    //IEnumerator CheckLoadAsyncScene (string sceneName)
    //{
    //    // don't load empty strings
    //    if (sceneName == "") {
    //        Debug.Log ("1 CheckLoadAsyncScene() !!! EMPTY_SCENENAME !!! " + sceneName + ", " + gameObject.scene.name);
    //        yield break;
    //    }
    //    // prevent loading the same scene
    //    if (sceneName == gameObject.scene.name) {
    //        Debug.Log ("2 CheckLoadAsyncScene() !!! SAME_SCENE !!! " + sceneName + ", " + gameObject.scene.name);
    //        yield break;
    //    }
    //    // max is a magic number set ^ above
    //    if (sceneCount >= sceneCountMax) {
    //        Debug.Log ("3 CheckLoadAsyncScene() !!! TOO_MANY_SCENES !!! " + sceneCount + ", " + sceneCountMax);
    //        yield break;
    //    }
    //    // load if sceneName is not already loaded
    //    if (IsSceneLoaded (sceneName)) {
    //        Debug.Log ("4 CheckLoadAsyncScene() !!! SCENE_ALREADY_LOADED !!! " + IsSceneLoaded (sceneName));
    //        yield break;
    //    }
    //    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync (sceneName, LoadSceneMode.Additive);
    //    // Wait until the asynchronous scene fully loads
    //    while (!asyncLoad.isDone) {
    //        yield return "success";
    //    }

    //    //LoadScene (sceneName);
    //}



    //IEnumerator LoadScene (string sceneName)
    //{
    //    yield return null;

    //    //Begin to load the Scene you specify
    //    AsyncOperation asyncOperation = SceneManager.LoadSceneAsync (sceneName);
    //    //Don't let the Scene activate until you allow it to
    //    asyncOperation.allowSceneActivation = false;
    //    Debug.Log ("Pro :" + asyncOperation.progress);
    //    //When the load is still in progress, output the Text and progress bar
    //    while (!asyncOperation.isDone) {
    //        //Output the current progress
    //        Debug.Log ("Loading progress: " + (asyncOperation.progress * 100) + "%");

    //        // Check if the load has finished
    //        if (asyncOperation.progress >= 0.9f) {
    //            //Change the Text to show the Scene is ready
    //            Debug.Log ("Press the space bar to continue");
    //            //Wait to you press the space key to activate the Scene
    //            if (Input.GetKeyDown (KeyCode.Space))
    //                //Activate the Scene
    //                asyncOperation.allowSceneActivation = true;
    //        }

    //        yield return null;
    //    }
    //}




    ///// <summary>
    ///// Returns number of scenes loaded
    ///// </summary>
    //public int SceneListLoadedCount (List<string> _list)
    //{
    //    int _loaded = 0;
    //    foreach (string _scene in _list) {
    //        if (IsSceneLoaded (_scene)) _loaded++;
    //    }
    //    return _loaded;
    //}

    ///// <summary>
    ///// Returns true if the scene is loaded AND valid
    ///// </summary>
    //public bool IsSceneLoaded (string _name)
    //{
    //    Scene scene = SceneManager.GetSceneByName (_name);
    //    //Debug.Log($"IsSceneLoaded('{_name}') scene.isLoaded={scene.isLoaded}, scene.IsValid()={scene.IsValid()}");
    //    return (scene.isLoaded && scene.IsValid ());
    //}






}
