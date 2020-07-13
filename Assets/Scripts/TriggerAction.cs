using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerAction : MonoBehaviour
{

    public bool Triggered;
    public string currentEntityStanding;
    private bool TriggeredOldValue;
    public UnityEvent actionOnTrigger;
    void Start()
    {
        TriggeredOldValue = Triggered;
    }

    void Update()
    {
        if (Triggered != TriggeredOldValue){
            TriggeredOldValue = Triggered;
            actionOnTrigger.Invoke();
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Box"){
            if(currentEntityStanding == ""){
                Triggered = true;
                currentEntityStanding = other.gameObject.name;
            }
        }
    }

    void OnCollisionExit2D(Collision2D other){
        if (other.gameObject.tag == "Player"  || other.gameObject.tag == "Box"){
            if (currentEntityStanding == other.gameObject.name){
                Triggered = false;
                currentEntityStanding = "";
            }
        }
    }
}
