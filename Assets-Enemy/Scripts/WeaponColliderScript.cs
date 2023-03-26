using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponColliderScript : MonoBehaviour
{
    public GameObject player;
    //weapon攻击效果
    //不用trigger是因为前面有OnCollisionEnter2D http://cppdebug.com/archives/216
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //伤害值为5
            collision.gameObject.GetComponent<EnemyScript>().TakeDamage(5);
        }
        if (collision.gameObject.CompareTag("EnemyGenerator"))
        {
            //伤害值为5
            collision.gameObject.GetComponent<EnemyGeneratorScript>().TakeDamage(false);
        }
    }
}