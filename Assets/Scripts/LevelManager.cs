using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    
    public GameObject StartingPlatform, EndingPlatform, player;
    public string NextLevelName;
    public void NextLevel(){StartCoroutine(Transition(NextLevelName));player.GetComponent<PlayerMovement>().canMove = false;}
    
    IEnumerator Transition(string SceneName){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }
    void Start()
    {
       player.GetComponent<PlayerMovement>().canMove = false;

       player.transform.position = new Vector2(StartingPlatform.transform.position.x, StartingPlatform.transform.position.y + 5f);
       StartingPlatform.GetComponent<MovingPlatform>().Move();
    }

    // Update is called once per frame
    void Update()
    {
       if (StartingPlatform.GetComponent<MovingPlatform>().Activated == true && player.GetComponent<PlayerMovement>().canMove == false){
           player.GetComponent<PlayerMovement>().canMove = true;
       } 
    }

    public void Restart(){
        GameObject Fade = GameObject.Find("Fade");
        Fade.GetComponent<Animator>().SetBool("FadeOut", true);
        StartCoroutine(Transition(SceneManager.GetActiveScene().name));
    }
}
