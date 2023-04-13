using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2D;

    public float speed = 1;
    public bool otherPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (otherPlayer)
        {
            spriteRenderer.color = Color.red;
        } else
        {
            spriteRenderer.color = Color.blue;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(otherPlayer ? KeyCode.UpArrow : KeyCode.W) && transform.position.y < 5)
        {
            rigidbody2D.velocity = speed * Vector2.up;

        } else if (Input.GetKey(otherPlayer ? KeyCode.DownArrow : KeyCode.S) && transform.position.y > -5)
        {
            rigidbody2D.velocity = speed * Vector2.down;
        } else
        {
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}
