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

    //�տ�ʼ�ӵڶ��������һ�����ټ����趨��4����һ�������5��enemy
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
            //Ҫô0Ҫô1�����������������β���enemy
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
