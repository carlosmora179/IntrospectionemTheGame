using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 7.5f;
    private Rigidbody2D rb2d;

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Vector2 move = Vector2.zero;

            if (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.W)))
            {
                move.y = 1;
            }
            if (Input.GetKey(KeyCode.DownArrow) || (Input.GetKey(KeyCode.S)))
            {
                move.y = -1;
            }
            if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A)))
            {
                move.x = -1;
            }
            if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D)))
            {
                move.x = 1;
            }

            rb2d.MovePosition((Vector2)this.transform.position + (move * speed * Time.deltaTime));
        }
    }
}
