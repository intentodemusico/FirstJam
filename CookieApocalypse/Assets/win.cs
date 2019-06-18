using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    private bool bandera;
    // Start is called before the first frame update
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
        SceneManager.LoadScene("SegundoNivel");
    }
}
