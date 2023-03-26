using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private bool swing = false;
    int degree = 0;
    //用weapon position - player position (-0.33-0=-0.33)（0.264-0）
    private float weaponY = -0.33f;
    private float weaponX = 0.264f;

    Vector3 pos;
    public GameObject player;

    void Update()
    {
        //player要用weapon的时候开始调用Attack function
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

    //先调用palyer location， 然后获取weapon location, 通过更新weaponX, weaponY, 使weapon始终显示在player的手中
    void Attack()
    {
         if(player.GetComponent<PlayerScript>().turnedLeft)
        {
            //向左走+攻击的时候，weapon出现在左边
            GetComponent<SpriteRenderer>().flipX = true;
            weaponX = -0.264f; 
        }
        else
        {
            //向右走+攻击的时候，weapon出现在右边
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
