using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraFollow : MonoBehaviour
{
    [Header("Objeto a seguir con la camara: ")]
    public GameObject followObject;
    private Vector3 camPosition;
    public float offsetX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        camPosition = new Vector3(followObject.transform.position.x + offsetX, followObject.transform.position.y, -20f);
        transform.position = camPosition;
    }
}
