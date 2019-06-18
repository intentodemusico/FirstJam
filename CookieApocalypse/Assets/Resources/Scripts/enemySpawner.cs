using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [Header("Enemigo a spawnear")] //Esto se debe quitar y se debe tener privada pero no sekepedo
    public GameObject enemy; //= GameObject.Find("zombie_stand");

    private float randX;
    
    private Vector2 whereToSpawn;
    [Header("Spawn rate")] [Tooltip("Se debe ingresar la velocidad de spawneo de los enemigos.")] public float spawnRate = 2f;
    
    [Header("Spawn range X")] [Tooltip("Se debe ingresar el rango en X de spawneo de los enemigos.")] public float randRange = 4f;

    private float nexSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nexSpawn)
        {
            nexSpawn = Time.time + spawnRate;
            randX = Random.Range(-randRange, randRange);
            whereToSpawn=new Vector2(randX,transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }

    }
}
