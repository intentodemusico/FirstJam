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
    [Header("Maxima velocidad: ")]
    public float maxSpeed;

    private Rigidbody2D rb;
    
    private Animator anim;
    private bool isOnGround;
    private AudioSource source;
    public float distGround;
    public AudioClip Sound;
    //Reloj
    bool timerReached;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        timer = 0;
        anim = GetComponent<Animator>();
        
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
        
        // Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.CompareTag("Hider") )
        {
            var obj = GameObject.FindWithTag("Texto");
            if (obj != null)
            {
                obj.SetActive(false);
            }

        }*/
        if (collision.CompareTag("KillZone"))
        {
            StartCoroutine(waiting());

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
        anim.SetFloat("Speed",Mathf.Abs( rb.velocity.x));
        anim.SetBool("Grounded", isOnGround);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        Vector2 movimiento = new Vector2(movHorizontal, 0f);
        rb.AddForce(movimiento * speed * 2f);
        float limitSpeed = Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
        rb.velocity = new Vector2(limitSpeed, rb.velocity.y);

       // rb.rotation -= movHorizontal*speed;
        if (Input.GetButtonDown("Jump") && isOnGround) //Devuelve verdadero en  el frame que se oprimió
        {
            Sound = (AudioClip)Resources.Load("Audio/jump", typeof(AudioClip));
            source.PlayOneShot(Sound, 2f);
           
            rb.AddForce(Vector2.up*jump*50f,ForceMode2D.Force);
        }
        if (movHorizontal > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (movHorizontal < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
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
