using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnandDestroy : MonoBehaviour
{
    public GameObject Cube;
    private GameObject CurrentInstaCube;
    public float DelayBetweenSpawns = 2f;
    public Vector3 SpawnPos;
    private bool Ready = true;
    public bool LoopSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
       //Spawn(); 
    }

    // Update is called once per frame
    void Update()
    {
      if (CurrentInstaCube == null){
        if (Ready && LoopSpawn == true){
          Ready = false;
          StartCoroutine(BoxDelay());     
        }
        
      }else if(CurrentInstaCube.transform.position.y <= -50){
        Destroy(CurrentInstaCube);
      }
    }
    

    public void Spawn()
    {
        if (CurrentInstaCube != null){
          Destroy(CurrentInstaCube);
        }
        CurrentInstaCube = Instantiate(Cube, SpawnPos, Quaternion.identity);
    }

    private IEnumerator BoxDelay(){
        yield return new WaitForSeconds(2f);
        Spawn();
        Ready = true;
    }
}
