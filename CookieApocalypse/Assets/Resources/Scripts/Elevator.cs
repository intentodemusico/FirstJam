using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    // Start is called before the first frame update
    private bool bandera;
    void Start()
    {
        bandera = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

       
            bandera = true;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (bandera)
        {
          
            GameObject ascensor = GameObject.FindWithTag("Elevator");
            float newY = 5 * Mathf.Sin(Time.time * 1f);
            ascensor.transform.position = new Vector2(ascensor.transform.position.x,   newY);
        }
    }
}
