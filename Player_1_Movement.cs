using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_1_Movement : MonoBehaviour
{
    public float speed;
    public float connectDistance;
    public float health;
    public float score = 0f;

    public Text playerHealth;
    public Text scoretxt;

    public LineRenderer lr;

    public GameObject player2;

    public Transform p2Pos;

    Rigidbody2D rb;

    public AudioSource hitAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement on X-axis
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Movement on Y-axis       
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, speed * Time.deltaTime);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        //RayCasting
        if(Vector2.Distance(transform.position, p2Pos.position) < connectDistance)
        {
            raycast();
        }
        else
        {
            lr.enabled = false;
        }

        //Health System
        playerHealth.text = health.ToString();
        if(health <= 0)
        {
            player2.GetComponent<Player_2_Movement>().enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            lr.enabled = false;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }

        //Scoring
        scoretxt.text = score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");
            hitAudio.Play();    
        }
    }

    void raycast()
    {
        
        lr.enabled = true;
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, p2Pos.position);
    }

    public void kill()
    {
        Destroy(gameObject);
    }
}
