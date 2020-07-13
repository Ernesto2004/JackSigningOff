using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public bool dead = false;
	public float runSpeed = 40f;

	float horizontalMove = 0f;
	float defaultGravity;
	public bool canMove = true;
	bool jump = false;
	bool crouch = false;
	
	// Update is called once per frame
	void Update () {
		if (dead){
			gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
		}
		if(canMove){
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

			if (Input.GetButtonDown("Jump"))
			{
				jump = true;
			}

			// if (Input.GetButtonDown("Crouch"))
			// {
			// 	crouch = true;
			// } else if (Input.GetButtonUp("Crouch"))
			// {
			// 	crouch = false;
			// }
		}
		

	}

	void FixedUpdate ()
	{
		if (canMove){
			controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
			jump = false;
		}
		// Move our character
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Destroy"){
			dead = true;
			GameObject.Find("LevelManager").GetComponent<LevelManager>().Restart();
		}
	}

    void OnTriggerExit2D(Collider2D collision){
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ladder")
        {
            GetComponent<Rigidbody2D>().gravityScale = 2f;
			canMove = true;
            //GetComponent<CircleCollider2D>().enabled = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder" && Input.GetKey(KeyCode.W))
        {
        
            
            GetComponent<Rigidbody2D>().gravityScale = 0f;

            
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5f);

        }
        else if (collision.gameObject.tag == "Ladder" && Input.GetKey(KeyCode.S))
        {
            
            
            GetComponent<Rigidbody2D>().gravityScale = 0f;

            
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5f);
        }
        else
        {
            if (collision.gameObject.tag == "Ladder")
            {
                
                
                GetComponent<Rigidbody2D>().gravityScale = 0f;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }

}
