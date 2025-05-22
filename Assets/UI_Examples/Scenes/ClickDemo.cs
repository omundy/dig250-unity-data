using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDemo : MonoBehaviour
{


    public void OnClick(){
        Debug.Log(123);
    }

    public void OnClickWithParam(string str){
        Debug.Log(str);
    }


}
