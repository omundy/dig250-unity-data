using UnityEngine;

[CreateAssetMenu (fileName = "Data", menuName = "ScriptableObjects/RandomEventScriptableObject", order = 1)]
public class RandomEventScriptableObject : ScriptableObject {

    public string eventTitle;
    public string eventPolicy;
    public int lifeExpectency;

}