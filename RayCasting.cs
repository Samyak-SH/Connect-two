using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    public Transform p2Pos;
    float angle;
    public float connectDistance;
    Camera cam;
    public LayerMask enemy;
    RaycastHit2D[] hit;
    public AudioSource hitAudio;
    public GameObject deathPartcle;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, p2Pos.position) < connectDistance)
        {
            hit = Physics2D.LinecastAll(transform.position, p2Pos.position, enemy);
            for (int i = 0; i <= hit.Length - 1; i++)
            {
                hit[i].collider.GetComponent<EnemyController>().health -= 10f;
                hitAudio.Play();
                Instantiate(deathPartcle, hit[i].collider.GetComponent<Transform>().position, Quaternion.identity);
                cam.GetComponent<Animator>().SetTrigger("Shake");
                gameObject.GetComponent<Player_1_Movement>().score += 1f;
            }
        }
    }
}
