using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    [Header("Escena a dirigir: ")]
    public string cadena;
   
    public AudioClip Sound;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        StartCoroutine(waiting());
    }
    private IEnumerator waiting()
    {
        Sound = (AudioClip)Resources.Load("Audio/win", typeof(AudioClip));
        source.PlayOneShot(Sound, 2f);
        yield return new WaitWhile(() => source.isPlaying);
      
        SceneManager.LoadScene(cadena);

    
    }

    // Update is called once per frame
    void Update()
    {
        
        SceneManager.LoadScene(cadena);
    }
}
