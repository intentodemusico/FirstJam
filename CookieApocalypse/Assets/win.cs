using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    [Header("Escena a dirigir: ")]
    public string cadena;
    private AudioSource source;
    public AudioClip Sound;
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Personaje"))
        {
            Debug.Log("entrando");
            StartCoroutine(waiting());
        }
       
       
    }
    private IEnumerator waiting()
    {
        Sound = (AudioClip)Resources.Load("Audio/Win", typeof(AudioClip));
        source.PlayOneShot(Sound, 2f);
        yield return new WaitWhile(() => source.isPlaying);
      
        SceneManager.LoadScene(cadena);

    
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
