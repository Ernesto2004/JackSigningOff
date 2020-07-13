using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ButtonAction : MonoBehaviour
{

    public UnityEvent buttonactionDown;
     public UnityEvent buttonactionUp;
    public float ClickHoldTime = 2f;
    public bool Click, Ready;
    private Animator animator;
    void Start()
    {
       animator = gameObject.GetComponent<Animator>(); 
    }

    public void ClickFunc(){
        if (Ready){
            Ready = false;
            StartCoroutine(ClickStuff());
        }
    }

    IEnumerator ClickStuff(){
        Click = true;
        animator.SetBool("Click", Click);
        buttonactionDown.Invoke();
        yield return new WaitForSeconds(ClickHoldTime);
        buttonactionUp.Invoke();
        Click = false;
        animator.SetBool("Click", Click);
        Ready = true;
    }
}
