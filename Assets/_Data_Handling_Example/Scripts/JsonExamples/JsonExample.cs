using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


/**
 *  Deserialize external JSON file using Newtonsoft.Json 
 *  - File is located in Assets/ and referenced using TextAsset in Inspector
 *  - JSON is an object of objects so code uses JObject
 *  - Stores objects in Dictionary for later use
 */


// define a custom class to hold each JSON object in the data returned
[System.Serializable]
public class GradientDataPoint {
    public int mid { get; set; }
    public string hex1 { get; set; }
    public string hex2 { get; set; }
    public int tier1 { get; set; }
}


public class JsonExample : MonoBehaviour {

    // text asset in inspector
    public TextAsset gradientsFile;

    // dictionary to store all results
    public Dictionary<string, GradientDataPoint> gradientDict;


    void Start ()
    {
        // dict to hold gradient data
        gradientDict = new Dictionary<string, GradientDataPoint> ();


        // parse the string as JObject
        JObject jsonData = JObject.Parse (gradientsFile.text);

        // if data is not null 
        if (jsonData == null) {
            print ("---------------- NO DATA ----------------");
        } else {
            print ("---- JsonExample.cs -> jsonData.Count: " + jsonData.Count);

            // loop through each, accessing it as a string:JToken
            foreach (KeyValuePair<string, JToken> item in jsonData) {
                //// the key and value
                //Debug.Log ("key/val = " + item.Key + " -->" + item.Value);
                //// access a value on the object
                //Debug.Log (jsonData [item.Key].Value<string> ("hex1"));

                // store the value in a dict
                gradientDict.Add (item.Key, item.Value.ToObject<GradientDataPoint> ());
            }

        }
    }
}
