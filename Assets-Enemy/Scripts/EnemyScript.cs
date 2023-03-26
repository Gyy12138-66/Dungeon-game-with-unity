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

    //enemy�����Ժ���һ̲Ѫ
    public Sprite deathSprite;
    public Sprite[] sprites;

    private bool isDead = false;

    void Start()
    {
        //enemy�����Ժ���һ̲Ѫ
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

    //����������ײ��enemy����һ�㲢�����˺�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !targetCollision)
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collision.collider.bounds.center;

            targetCollision = true;
            //����center�ľ���
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
    //��������ҵķ�Χ�Ժ�ֹͣ��ײ���ˣ���������ҿ���
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
            //enemy�����Ѫ����������ڻ��ŵ�enemyͼ����
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
    //�������Ż���ʾbloodͼ��
//    void HideBlood()
//    {
//        transform.GetChild(0).gameObject.SetActive(false);
//    }

    //�����Ժ�enemyͼ����ʧ
    void EnemyDeath()
    {
        Destroy(gameObject);
    }
}