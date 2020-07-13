using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeScript : MonoBehaviour
{
    public string Code;
    public Text Input;
    public Button Try;
    public GameObject endingPlatform;
    void Start(){
        Try.onClick.AddListener(onClick);
    }
    void onClick(){
        if ("075" == Input.text){
            endingPlatform.GetComponent<MovingPlatform>().enabled = true;
        }
    }
}
