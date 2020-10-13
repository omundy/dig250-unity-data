using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


/**
 *  Example getting externa JSON into Unity with UnityWebRequest + Newtonsoft.Json
 *  - The JSON is an array of objects so code uses JArray
 *  - Stores objects in Dictionary for later use
 */


// a custom class to hold each JSON object in the data returned
[System.Serializable]
public class FeedDataPoint {
    public string username { get; set; }
    public string eventType { get; set; }
    public DateTime createdAt { get; set; }
}




public class JsonWebRequestExample : MonoBehaviour {

    // dictionary to store all results
    public Dictionary<DateTime, FeedDataPoint> feedDict;


    void Start ()
    {
        // dict to hold data
        feedDict = new Dictionary<DateTime, FeedDataPoint> ();

        StartCoroutine (RequestWebService ());
    }

    IEnumerator RequestWebService ()
    {
        // local or remote path for JSON file - local paths will break on other machines
        string uri = "https://tallysavestheinternet.com/api/feed/recent";
        //print (uri);

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

                    // parse the string as JArray
                    JArray jsonData = JArray.Parse (webRequest.downloadHandler.text);

                    // if data is not null 
                    if (jsonData == null) {
                        print ("---------------- NO DATA ----------------");
                    } else {
                        print ("---- JsonWebRequestExample.cs -> jsonData.Count: " + jsonData.Count);

                        // loop through JArray
                        foreach (JObject item in jsonData) {

                            // create a new FeedDataPoint object
                            FeedDataPoint feedData = new FeedDataPoint {
                                username = (string)item ["username"],
                                eventType = (string)item ["eventType"],
                                createdAt = DateTime.Parse ((string)item ["createdAt"], null, System.Globalization.DateTimeStyles.RoundtripKind)
                            };

                            // log the key and value
                            //Debug.Log (feedData.createdAt.ToString () + " - " + feedData.eventType.ToString ());

                            // check to see if the object has already been added
                            FeedDataPoint val;
                            feedDict.TryGetValue (feedData.createdAt, out val);
                            // if not
                            if (val == null)
                                // store the value in the dict
                                feedDict.Add (feedData.createdAt, feedData);
                        }

                    }
                }
            }
        }
    }
}
