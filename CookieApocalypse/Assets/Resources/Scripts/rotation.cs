using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.forward * -1);
        //suelo.transform.rotation = new Quaternion(0f, 0, change, 0);
        //change += 20;
    }
}
