using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 *  Switches between "world" scenes (StartScreen, World_1, World_2, Credits)
 *  - Lives on the SceneSwitcher object in Global_GameUI, next to the buttons
 *    (Inspector references can't point to objects in a different scene)
 *  - UI Buttons call SwitchToScene("World_1") from their On Click () event
 *    To add a button: duplicate one, then type the new scene name in its On Click () box
 *  - Loads the new scene first, then unloads the old one
 *  - Scenes whose names start with "Global_" are never unloaded
 */
public class AdditiveSceneManager : MonoBehaviour
{
    // true while a switch is happening, so extra button clicks are ignored
    private bool isSwitching = false;

    // call this from a Button (type the scene name in the On Click () box)
    public void SwitchToScene(string sceneName)
    {
        // ignore the click if we are busy, or if that scene is already open
        if (isSwitching || SceneManager.GetSceneByName(sceneName).isLoaded)
            return;

        StartCoroutine(SwitchRoutine(sceneName));
    }

    // a coroutine can wait (yield) for loading to finish before doing the next step
    IEnumerator SwitchRoutine(string sceneName)
    {
        isSwitching = true;

        // 1. remember the scene we are leaving (the "active" scene)
        Scene oldScene = SceneManager.GetActiveScene();

        // 2. load the new scene next to the others, and wait until it is done
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        // 3. make the new scene active (its lighting is used, new objects are created in it)
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

        // 4. unload the old scene, unless it is a global one
        if (!oldScene.name.StartsWith("Global_"))
        {
            yield return SceneManager.UnloadSceneAsync(oldScene);
        }

        isSwitching = false;
    }
}
