using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


/**
 *  Example getting external JSON into Unity with UnityWebRequest + Newtonsoft.Json
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

    public int numberResults;


    void Start ()
    {
        // dict to hold data
        feedDict = new Dictionary<DateTime, FeedDataPoint> ();

        // local or remote path for JSON file - local paths will break on other machines
        StartCoroutine (GetRequest ("https://tallysavestheinternet.com/api/feed/recent"));

        // error test
        // StartCoroutine(GetRequest("https://error.html"));
    }



    // do a get request for JSON data at url
    public IEnumerator GetRequest (string uri)
    {
        // wait a second 
        yield return new WaitForSeconds (1.0f);

        // create new UnityWebRequest and get URI
        using (UnityWebRequest webRequest = UnityWebRequest.Get (uri)) {

            //DebugManager.Instance.UpdateDisplay ("DataManager.GetRequest() uri = " + uri);

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest ();

            //string [] pages = uri.Split ('/');
            //int page = pages.Length - 1;

            // error check
            if (webRequest.result == UnityWebRequest.Result.ConnectionError) {
                print ("Error: " + webRequest.error);
            } else {

                // if request is done
                if (webRequest.isDone) {

                    //Debug.Log ("DataManager.GetRequest() " + webRequest.downloadHandler.text);

                    // handle the response
                    HandleJsonResponse (webRequest.downloadHandler.text);
                }
            }
        }
    }



    /// <summary>
    /// Handle JSON data 
    /// </summary>
    /// <param name="text">JSON data as string</param>
    public void HandleJsonResponse (string text)
    {


        // parse the string as JArray
        JArray jsonData = JArray.Parse (text);

        numberResults = jsonData.Count;

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





