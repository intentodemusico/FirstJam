using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followKillZone : MonoBehaviour
{
    [Header("Objeto a seguir : ")]
    public GameObject followObject;
    private Vector3 camPosition;
    private Animator anim;
    private Rigidbody2D rb;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = followObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, 2f * Time.deltaTime);
        
        anim.SetFloat("Speed", Mathf.Abs(transform.position.x));
      
       
    }
}
