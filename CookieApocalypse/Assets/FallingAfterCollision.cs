using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingAfterCollision : MonoBehaviour
{
    private bool isFalling = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFalling)
        {
            transform.position=new Vector2(transform.position.x,transform.position.y-0.2f);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Personaje")){
            StartCoroutine(waiting());
        }
    }
    
    void OnBecameInvisible() {
        if(transform.position.y<-8)
            Destroy(gameObject);
    }

    private IEnumerator waiting()
    {
        yield return new WaitForSeconds(1f);
        isFalling = true;
    }
}
