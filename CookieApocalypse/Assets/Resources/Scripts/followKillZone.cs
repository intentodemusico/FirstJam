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
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        camPosition = new Vector3(followObject.transform.position.x-2f , -5.55f, 0f);
        transform.position = camPosition;
        anim.SetFloat("Speed", Mathf.Abs(followObject.transform.position.x));
      
       
    }
}
