using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;




// define a custom class to hold each JSON object in the data returned
[System.Serializable]
public class GradientDataPoint {
    public int mid { get; set; }
    public string hex1 { get; set; }
    public string hex2 { get; set; }
    public int tier1 { get; set; }
}


/**
 *  Example with UnityWebRequest + Newtonsoft.Json
 */

public class JsonExample : MonoBehaviour {

    // text asset in inspector
    public TextAsset gradientsFile;

    // dictionary to store all results
    public Dictionary<string, GradientDataPoint> gradientDict;


    void Start ()
    {
        // dict to hold gradient data
        gradientDict = new Dictionary<string, GradientDataPoint> ();

        StartCoroutine (RequestWebService ());
    }

    IEnumerator RequestWebService ()
    {
        // local or remote path for JSON file
        string uri = "file:///Users/owenmundy/Documents/_code/Unity/dig250-game-art-dev/sample-unity-data/Assets/Data_Handling/Data/gradients-by-mid.json";
        print (uri);

        // create new UnityWebRequest and get URI
        using (UnityWebRequest webRequest = UnityWebRequest.Get (uri)) {

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest ();

            // error check 
            if (webRequest.isNetworkError || webRequest.isHttpError) {
                print ("Error: " + webRequest.error);
            } else {
                // if request is done
                if (webRequest.isDone) {

                    // parse the string as JObject
                    JObject jsonData = JObject.Parse (webRequest.downloadHandler.text);

                    // if data is not null 
                    if (jsonData == null) {
                        print ("---------------- NO DATA ----------------");
                    } else {
                        print ("---------------- JSON DATA ----------------");
                        print ("jsonData.Count:" + jsonData.Count);

                        // loop through each, accessing it as a string:JToken
                        foreach (KeyValuePair<string, JToken> item in jsonData) {
                            // the key and value
                            Debug.Log ("key/val = " + item.Key + " -->" + item.Value);
                            // access a value on the object
                            Debug.Log (jsonData [item.Key].Value<string> ("hex1"));

                            // store the value in a dict
                            gradientDict.Add (item.Key, item.Value.ToObject<GradientDataPoint> ());
                        }

                    }
                }
            }
        }
    }
}