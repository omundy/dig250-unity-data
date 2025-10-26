using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// Base object for all NPCs
public class NPCObject : MonoBehaviour
{
    // fields
    public int id;
    public string Name;
    public bool GoodGuy;
    public int encounters; // number of encounters 

    // managers
    CharacterController controller;
    GameObject NPCManager;
    NPCRelationshipManager NPCRelationshipManager;
    public GameObject textObject;
    TMP_Text textComponent;
    public Material material;

    // constructor
    public void Initialize(int _id, string _Name, bool _GoodGuy)
    {
        if (material == null)
            material = GetComponent<Renderer>().material;
        id = _id;
        Name = _Name;
        GoodGuy = _GoodGuy;
        gameObject.name = Name;
        encounters = 0;
    }

    void Awake()
    {
        // get references
        controller = GetComponent<CharacterController>();
        textComponent = textObject.GetComponent<TMP_Text>();
        NPCManager = GameObject.Find("NPCManager");
        NPCRelationshipManager = NPCManager.GetComponent<NPCRelationshipManager>();
    }

    void Update()
    {
        // update text
        textComponent.text = Name + ": " + encounters.ToString();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // ignore self collision
        if (hit.gameObject.GetInstanceID() == gameObject.GetInstanceID()) return;

        // if we touched an NPC
        if (hit.gameObject.tag == "NPC")
        {
            // print(gameObject.name + " hit " + hit.gameObject.name);

            // update encounters 
            encounters++;

            if (encounters == 0) material.color = Color.white;
            else if (encounters % 13 == 1) material.color = Color.aliceBlue;
            else if (encounters % 13 == 2) material.color = Color.antiqueWhite;
            else if (encounters % 13 == 3) material.color = Color.aquamarine;
            else if (encounters % 13 == 4) material.color = Color.azure;
            else if (encounters % 13 == 5) material.color = Color.beige;
            else if (encounters % 13 == 6) material.color = Color.bisque;
            else if (encounters % 13 == 7) material.color = Color.blanchedAlmond;
            else if (encounters % 13 == 8) material.color = Color.mistyRose;
            else if (encounters % 13 == 9) material.color = Color.moccasin;
            else if (encounters % 13 == 10) material.color = Color.paleTurquoise;
            else if (encounters % 13 ==  11) material.color = Color.peachPuff;
            else if (encounters % 13 ==  12) material.color = Color.pink;


            // let relationship manager handle data
            NPCRelationshipManager.UpdateRelationship(gameObject, hit.gameObject);
        }
    }


}
