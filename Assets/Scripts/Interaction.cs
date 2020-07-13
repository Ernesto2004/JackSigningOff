using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    public bool isInRange = false;
    public bool oneTimeUse;
    public GameObject InteractButton;
    private Animator InteractButtonAnimator;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    private Vector3 _positionOffset;

    void Start(){
        InteractButtonAnimator = InteractButton.GetComponent<Animator>();
    }
    void Update()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
    
        //gameObject.GetComponent<Rigidbody2D>().transform.position = Player.transform.position;
        InteractButtonAnimator.SetBool("Up", isInRange);
        if (isInRange){
            if (Input.GetKeyDown(interactKey)){
                interactAction.Invoke();
                if (oneTimeUse == true){
                    gameObject.GetComponent<Interaction>().enabled = false;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D something){
        if (something.gameObject.CompareTag("Player")){
            isInRange = true;
        }else if(something.gameObject.CompareTag("InteractedWIth")){
            isInRange = false;
        }
    }

     void OnTriggerExit2D(Collider2D something){
        if (something.gameObject.tag == "Player" || something.gameObject.tag == "InteractedWIth"){
            isInRange = false;
        }
    }
}
