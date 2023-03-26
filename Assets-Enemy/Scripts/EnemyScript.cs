using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float range;
    private Transform target;
    private float minDistance = 5.0f;
    private bool targetCollision = false;
    private float speed = 2.0f;
    private float thrust = 1.5f;
    public int health = 5;

    //enemy死了以后变成一滩血
    public Sprite deathSprite;
    public Sprite[] sprites;

    private bool isDead = false;

    void Start()
    {
        //enemy死了以后变成一滩血
        int rnd = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[rnd];
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector2.Distance(transform.position, target.position);
        if (range < minDistance && !isDead)
        {
            if (!targetCollision)
            {
                //Get the position of the player
                transform.LookAt(target.position);

                //Correct the rotation
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
        }
        transform.rotation = Quaternion.identity;
    }

    //如果和玩家碰撞，enemy后退一点并导致伤害
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !targetCollision)
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collision.collider.bounds.center;

            targetCollision = true;
            //检查和center的距离
            bool right = contactPoint.x > center.x;
            bool left = contactPoint.x < center.x;
            bool top = contactPoint.y > center.y;
            bool bottom = contactPoint.y < center.y;

            if (right) GetComponent<Rigidbody2D>().AddForce(transform.right * thrust, ForceMode2D.Impulse);
            if (left) GetComponent<Rigidbody2D>().AddForce(-transform.right * thrust, ForceMode2D.Impulse);
            if (top) GetComponent<Rigidbody2D>().AddForce(transform.up * thrust, ForceMode2D.Impulse);
            if (bottom) GetComponent<Rigidbody2D>().AddForce(-transform.up * thrust, ForceMode2D.Impulse);

            Invoke("FalseCollision", 0.5f);
        }
    }
    //超过和玩家的范围以后停止碰撞后退，继续向玩家靠近
    void FalseCollision()
    {
        targetCollision = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health < 0)
        {
            isDead = true;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<SpriteRenderer>().sprite = deathSprite;
            //enemy死后的血迹不会出现在活着的enemy图像上
            GetComponent<SpriteRenderer>().sortingOrder = -1;

            GetComponent<Collider2D>().enabled = false;
            Destroy(transform.GetChild(0).gameObject);
            Invoke("EnemyDeath", 5.0f);
            
        } else
        {
            //transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
            //Invoke("HideBlood", 0.25f);
        }
    }
    //被攻击才会显示blood图样
//    void HideBlood()
//    {
//        transform.GetChild(0).gameObject.SetActive(false);
//    }

    //死了以后enemy图像消失
    void EnemyDeath()
    {
        Destroy(gameObject);
    }
}