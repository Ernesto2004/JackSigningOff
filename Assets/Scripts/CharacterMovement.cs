using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 5f;
    public float jumpPower = 5f;
    public bool canWalk = true;
    public bool canJump = false;
    public bool IsGrounded;
    private Vector2 startPos;
    private Rigidbody2D rb2d;
    private float defaultGravity;
    void Start()
    {
       rb2d = gameObject.GetComponent<Rigidbody2D>();
       startPos = gameObject.transform.position;
       defaultGravity = rb2d.gravityScale;
    }


    void FixedUpdate()
    {
        canJump = IsGrounded;

        if (canWalk){
            Jump();
            float movement = Input.GetAxis("Horizontal");
          //  transform.position += movement * Time.deltaTime * moveSpeed; 
            rb2d.velocity = new Vector2(movement*moveSpeed, rb2d.velocity.y);

        }
        if (gameObject.transform.position.y <= -25){
            gameObject.transform.position = startPos;
        }
    }

    
    
    void Jump(){
        if (Input.GetButtonDown("Jump") && canJump){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
        }
    }

    //  private bool IsGrounded(){
    //     // if (rb2d.velocity.y >= -2.0f && rb2d.velocity.y <= 0f){
    //     //     return true;
    //     // }else
    //     // {
    //     //     return false;
    //     // }//
    //     if ()
    // }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.layer == 8 && IsGrounded){
            canJump = true;
        }else{
            canJump = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ladder"){
           // GetComponent<CircleCollider2D>().enabled = false;
        }else if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Box"){
            IsGrounded = true;
        }
    }


    void OnTriggerExit2D(Collider2D collision){
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ladder")
        {
            GetComponent<Rigidbody2D>().gravityScale = defaultGravity;
            //GetComponent<CircleCollider2D>().enabled = true;
        }else if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Box"){
            IsGrounded = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder" && Input.GetKey(KeyCode.W))
        {
            canJump = false;
            
            GetComponent<Rigidbody2D>().gravityScale = 0f;

            
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5f);

        }
        else if (collision.gameObject.tag == "Ladder" && Input.GetKey(KeyCode.S))
        {
            canJump = false;
            
            GetComponent<Rigidbody2D>().gravityScale = 0f;

            
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5f);
        }
        else
        {
            if (collision.gameObject.tag == "Ladder")
            {
                canJump = false;
                
                GetComponent<Rigidbody2D>().gravityScale = 0f;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }


}
