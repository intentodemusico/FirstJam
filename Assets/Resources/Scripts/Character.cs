using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [Header("Velocidad de movimiento:")]
    public float speed;
    [Header("Fuerza de salto: ")]
    public float jump;
   
   
    private Rigidbody2D rb;
    public AudioClip Sound;
    public float distGround;
    private AudioSource source;
    private bool isOnGround;
    //Reloj
    bool timerReached;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        timer = 0;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo") )
        {
            isOnGround = true;
        }
    }
    private IEnumerator waiting()
    {
        Sound = (AudioClip)Resources.Load("Audio/morir", typeof(AudioClip));
        source.PlayOneShot(Sound, 2f);
        yield return new WaitWhile(()=>source.isPlaying);
        Scene escena = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escena.name);
        Debug.Log("entro a Done waiting");
        // Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hider") )
        {
            var obj = GameObject.FindWithTag("Texto");
            if (obj != null)
            {
                obj.SetActive(false);
            }

        }
        else if (collision.CompareTag("KillZone"))
        {
            StartCoroutine(waiting());


            //waiting();
            /*
            while (!timerReached)
            {
                timer += Time.deltaTime;
             
                //Debug.Log(timer);
                if (!timerReached && timer > 20000f)
                {
                    Debug.Log("Done waiting");

                    
                    //Set to false so that We don't run this again
                    timerReached = true;
                }

            }*/







        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isOnGround = false;
        }
    }
    private void Update()
    {
       
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        Vector2 movimiento = new Vector2(movHorizontal, 0f);
        rb.AddForce(movimiento * speed * 2f);
        rb.rotation -= movHorizontal*speed;
        if (Input.GetButtonDown("Jump") && isOnGround) //Devuelve verdadero en  el frame que se oprimió
        {
            Sound = (AudioClip)Resources.Load("Audio/saltar", typeof(AudioClip));
            source.PlayOneShot(Sound, 2f);
           
            rb.AddForce(Vector2.up*jump*50f,ForceMode2D.Force);
        }
        /*
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(Vector2.right*speed);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(Vector2.left * speed);
        }
        else if(Input.GetAxis("Vertical") > 0)

        {
            rb.AddForce(Vector2.up * speed*5.0f);
        }
        else if (Input.GetAxis("Vertical") < 0)

        {
            rb.AddForce(Vector2.down * speed * 5.0f);
        }*/

    }
}
