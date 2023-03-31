using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllor : MonoBehaviour
{

    Rigidbody2D rb;

    Animator anim;

    public float speed;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
         if (movement.x != 0)
        {
            transform.localScale = new Vector3(movement.x, 1, 1);
        }
        SwitchAnim();
    }

      private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void SwitchAnim()
    {
        anim.SetFloat("speed", movement.magnitude + 1.0);
    }
}
