using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EndingPlatform : MonoBehaviour
{

    public UnityEvent onFinish;
    bool triggered = false;
    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Player" && gameObject.GetComponent<MovingPlatform>().enabled == true){
            if (triggered == false){
                triggered = true;
                other.gameObject.GetComponent<PlayerMovement>().runSpeed = 0;
                onFinish.Invoke();
                GameObject.Find("Fade").GetComponent<Animator>().SetBool("FadeOut", true);
            }
        }
    }
}
