using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOtherScene : MonoBehaviour {
    // first, load the other scene
    private void Awake ()
    {
        SceneManager.LoadSceneAsync ("AdditiveSceneTest", LoadSceneMode.Additive);
    }

}
