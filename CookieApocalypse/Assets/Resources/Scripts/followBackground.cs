using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followBackground : MonoBehaviour
{
    [Header("Objeto a seguir con la camara: ")]
    public GameObject followObject;
    private Vector3 camPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camPosition = new Vector3(followObject.transform.position.x , followObject.transform.position.y, 0f);
        transform.position = camPosition;
    }
}
