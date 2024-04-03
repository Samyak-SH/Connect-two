using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] players;

    public float health;
    public float damage;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        players[0] = GameObject.FindGameObjectWithTag("Player1").transform;
        players[1] = GameObject.FindGameObjectWithTag("Player2").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Player follow
        if(Vector2.Distance(transform.position,players[0].position)< Vector2.Distance(transform.position, players[1].position))
        {                        
            transform.position = Vector2.MoveTowards(transform.position, players[0].position, speed * Time.deltaTime);            
        }
        if (Vector2.Distance(transform.position, players[0].position) > Vector2.Distance(transform.position, players[1].position))
        {
            transform.position = Vector2.MoveTowards(transform.position, players[1].position, speed * Time.deltaTime);
        }

        //Health system
        if(health <= 0)
        {
            players[0].GetComponent<Player_1_Movement>().score += 1f;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        //Player damage
        if (collision.CompareTag("Player1"))
        {
            collision.gameObject.GetComponent<Player_1_Movement>().health -= damage;
            collision.gameObject.GetComponent<Player_1_Movement>().hitAudio.Play();
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player2"))
        {
            collision.gameObject.GetComponent<Player_2_Movement>().health -= damage;
            collision.gameObject.GetComponent<Player_2_Movement>().hitAudio.Play();
            Destroy(gameObject);
        }
    }
}
