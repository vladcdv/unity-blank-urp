using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{


    Rigidbody2D rb2D;
    Vector2 vel;

    public int scoreRight = 0;
    public int scoreLeft = 0;

    public TextMeshProUGUI leftPlayerText;
    public TextMeshProUGUI rightPlayerText;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb2D.velocity == Vector2.zero && Input.GetKeyUp(KeyCode.Space))
        {
            RandomiseVelocity();
        }
    }

    void FixedUpdate()
    {
        rb2D.velocity = vel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        vel = Vector2.Reflect(vel, collision.contacts[0].normal);
        rb2D.velocity = vel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0)
        {
            leftPlayerText.text = (++scoreLeft).ToString();
        }
        else {
            rightPlayerText.text = (++scoreRight).ToString();
        }

        transform.position = Vector3.zero;
        vel = Vector2.zero;
        rb2D.velocity = vel;
    }

    private void RandomiseVelocity()
    {
        float angle = Random.Range(-0.25f, 0.25f) * Mathf.PI;
        vel = 10f * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        vel.x = Random.Range(0, 2) == 1 ? vel.x : -vel.x;
        rb2D.velocity = vel;
    }

    
}
