using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 4.0f;
    Rigidbody2D rb;

    public int health = 100;

    public bool turnedLeft = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);

        turnedLeft = false;
        //根据方位调整图片
        if(horizontal > 0)
        {
            GetComponent<Animator>().Play("right");
        } else if (horizontal < 0)
        {
            GetComponent<Animator>().Play("left");
            turnedLeft = true;
        } else if (vertical > 0)
        {
            GetComponent<Animator>().Play("up");
        } else if (vertical < 0)
        {
            GetComponent<Animator>().Play("down");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 5;
            transform.GetChild(0).gameObject.SetActive(true);
            Invoke("HidePlayerBlood", 0.25f);
        }
    }

    void HidePlayerBlood()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

}
 