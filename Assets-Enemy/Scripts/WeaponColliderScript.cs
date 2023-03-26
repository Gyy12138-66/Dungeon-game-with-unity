using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponColliderScript : MonoBehaviour
{
    public GameObject player;
    //weapon����Ч��
    //����trigger����Ϊǰ����OnCollisionEnter2D http://cppdebug.com/archives/216
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //�˺�ֵΪ5
            collision.gameObject.GetComponent<EnemyScript>().TakeDamage(5);
        }
        if (collision.gameObject.CompareTag("EnemyGenerator"))
        {
            //�˺�ֵΪ5
            collision.gameObject.GetComponent<EnemyGeneratorScript>().TakeDamage(false);
        }
    }
}