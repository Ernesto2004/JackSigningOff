using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCounter : MonoBehaviour
{
    public int EntitiesInCollider = 0;
    public GameObject Ladder1, Ladder2, Ladder3, Lift;

    void Update(){
        if (EntitiesInCollider == 1){
            Ladder1.transform.position = new Vector2(-18.83f, -7.15f);
            Lift.GetComponent<MovingPlatform>().destinations[0] = new Vector3(-11.718f, 0.43f, 0);
            Lift.GetComponent<MovingPlatform>().Activated = false;
        }else if(EntitiesInCollider == 2){
            Lift.GetComponent<MovingPlatform>().destinations[0] = new Vector3(-11.718f, 6.49f, 0);
            Ladder2.transform.position = new Vector2(-18.83f, -4.23f);
        }else if(EntitiesInCollider == 3){
            Ladder3.transform.position = new Vector2(-18.83f, -1.41f);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Box"){
            EntitiesInCollider = EntitiesInCollider + 1;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Box"){
            EntitiesInCollider = EntitiesInCollider - 1;
        }
    }
}
