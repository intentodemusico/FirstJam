using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [Header("Enemigo a spawnear")] public GameObject enemy;
    private float randX;
    //private bool canSpawn = true;
    
    
    //[Header("Spawn limit")] [Tooltip("Se debe ingresar la cantidad máxima de enemigos a spawnear.")] 
    //private int spawnLimit=100;
    
    private Vector2 whereToSpawn;
    // [Header("Spawn rate")] [Tooltip("Se debe ingresar la velocidad de spawneo de los enemigos.")] 
    private float spawnRate = 1.5f;
    
   // [Header("Spawn range X")] [Tooltip("Se debe ingresar el rango en X de spawneo de los enemigos.")]
    //private float randRange = 50f;
    private int spawned;
    private float nexSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nexSpawn)//canSpawn && Time.time > nexSpawn)
        {
            nexSpawn = Time.time + spawnRate;
            randX = Random.Range(-18, 97);
            whereToSpawn=new Vector2(randX,transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
            //spawned++;
            //if (spawned==spawnLimit)
                //canSpawn = false;
        }
    }
}
