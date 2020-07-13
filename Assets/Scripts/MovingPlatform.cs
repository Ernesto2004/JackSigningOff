using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3[] destinations;
    public bool Loop;
    public bool Activated = true;
    public bool ForceStop = false;
    public int Turn = 0;
    public float Speed = 5f;
    public float TurnTimeOut = 1f;
    private bool ready = true;
    
    void Update()
    {

       if (Activated == false && ready){
            if (Turn > (destinations.Length - 1)){
                Turn = 0;
            }
            

            if (transform.position != destinations[Turn]){
                transform.position = Vector3.MoveTowards(transform.position, destinations[Turn], Speed * Time.deltaTime);
            }else{
                ready = false;
                Activated = !Loop;
                Turn = Turn + 1;
                StartCoroutine(TimeOut());
            }
        } 
    }


    public void ForceStopFunc(){
        ForceStop = true;
        Activated = true;

        transform.position = destinations[Turn];
        Turn = Turn + 1;

    }
    public void Move()
    {
        if(!Activated){
            ForceStopFunc();
        }
        Activated = false;
    }

    IEnumerator TimeOut(){
        yield return new WaitForSeconds(TurnTimeOut);
        ready = true;
    }
}
