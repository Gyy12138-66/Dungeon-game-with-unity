using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] generatorPoints;
    private float timer;
    private int generatorIndex;
    public bool health = true;
    private int enemyNumber = 4;

    public Sprite gateway;

    //刚开始从第二个点出现一个，再加上设定的4个，一共会出现5个enemy
    void Start()
    {
        Instantiate(enemyPrefab, generatorPoints[1].transform.position, Quaternion.identity);
        timer = Time.time + 5.0f;
        enemyNumber--;
    }

    void Update()
    {
        if(timer < Time.time && enemyNumber >= 0)
        {
            //要么0要么1→在两个产生点依次产生enemy
            Instantiate(enemyPrefab, generatorPoints[generatorIndex % 2].transform.position, Quaternion.identity);
            timer = Time.time + 5.0f;
            generatorIndex++;
            enemyNumber--;
        }
    }

    public void TakeDamage(bool state)
    {
        health = state;
        if(!health && enemyNumber < 0)
        {
            GetComponent<SpriteRenderer>().sprite = gateway;
        }
    }

}
