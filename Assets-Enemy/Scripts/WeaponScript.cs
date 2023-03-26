using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private bool swing = false;
    int degree = 0;
    //��weapon position - player position (-0.33-0=-0.33)��0.264-0��
    private float weaponY = -0.33f;
    private float weaponX = 0.264f;

    Vector3 pos;
    public GameObject player;

    void Update()
    {
        //playerҪ��weapon��ʱ��ʼ����Attack function
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<SpriteRenderer>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
            Attack();
        }
    }
    private void FixedUpdate()
    {
        if(swing)
        {
            degree -= 7;
            if(degree < -65)
            {
                degree = 0;
                swing = false;
                GetComponent<SpriteRenderer>().enabled = false;
                transform.GetChild(0).gameObject.SetActive(false);
            }
            transform.eulerAngles = Vector3.forward * degree;
        }
    }

    //�ȵ���palyer location�� Ȼ���ȡweapon location, ͨ������weaponX, weaponY, ʹweaponʼ����ʾ��player������
    void Attack()
    {
         if(player.GetComponent<PlayerScript>().turnedLeft)
        {
            //������+������ʱ��weapon���������
            GetComponent<SpriteRenderer>().flipX = true;
            weaponX = -0.264f; 
        }
        else
        {
            //������+������ʱ��weapon�������ұ�
            GetComponent<SpriteRenderer>().flipX = false;
            weaponX = 0.264f;
        }
        pos = player.transform.position;
        pos.x += weaponX;
        pos.y += weaponY;
        transform.position = pos;
        swing = true;
    }
}
