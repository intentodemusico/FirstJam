using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

   

    [Header("Enemigo a spawnear")] public GameObject enemy;


    private float randX;
    private bool canSpawn = true;
    
    
    [Header("Spawn limit")] [Tooltip("Se debe ingresar la cantidad máxima de enemigos a spawnear.")] 
    public int spawnLimit=20;
    
    private Vector2 whereToSpawn;
    [Header("Spawn rate")] [Tooltip("Se debe ingresar la velocidad de spawneo de los enemigos.")] public float spawnRate = 10f;
    
    [Header("Spawn range X")] [Tooltip("Se debe ingresar el rango en X de spawneo de los enemigos.")] public float randRange = 6f;
    private int spawned;
    private float nexSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn && Time.time > nexSpawn)
        {
            nexSpawn = Time.time + spawnRate;
            randX = Random.Range(-randRange, randRange);
            whereToSpawn=new Vector2(randX,transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
            spawned++;
            if (spawned==spawnLimit)
                canSpawn = false;
        }

    }
}
