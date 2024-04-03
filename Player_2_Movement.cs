using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_2_Movement : MonoBehaviour
{
    public float speed;
    public float health;

    public Text Player2Health;

    public GameObject player1;

    Rigidbody2D rb;

    public AudioSource hitAudio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement on X-axis
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Movement on Y-axis       

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, speed * Time.deltaTime);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        //Health system
        Player2Health.text = health.ToString();

        if(health <= 0)
        {
            player1.GetComponent<Player_1_Movement>().enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            player1.GetComponent<LineRenderer>().enabled = false;
            Destroy(gameObject);
        }
    }
}
