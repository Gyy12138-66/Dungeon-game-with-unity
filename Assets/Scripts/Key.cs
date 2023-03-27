using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public GameObject doorLeft, doorRight, doorUp, doorDown; // 关联的门对象
    public bool isComplete = false; // 是否完成任务

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 玩家触碰到钥匙时，将钥匙消失，并解锁关联的门
            Destroy(gameObject);
            OppenTheDoor();
            Debug.Log("钥匙已捡起，门已解锁");

            
        }
    }
    public void OppenTheDoor(){
        doorLeft.GetComponent<DoorController>().isLocked = false;
        doorRight.GetComponent<DoorController>().isLocked = false;
        doorUp.GetComponent<DoorController>().isLocked = false;
        doorDown.GetComponent<DoorController>().isLocked = false;

        doorLeft.GetComponent<BoxCollider2D>().isTrigger = true;
        doorRight.GetComponent<BoxCollider2D>().isTrigger = true;
        doorDown.GetComponent<BoxCollider2D>().isTrigger = true;
        doorUp.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public void CloseTheDoor(){
        doorLeft.GetComponent<DoorController>().isLocked = true;
        doorRight.GetComponent<DoorController>().isLocked = true;
        doorUp.GetComponent<DoorController>().isLocked = true;
        doorDown.GetComponent<DoorController>().isLocked = true;

        doorLeft.GetComponent<BoxCollider2D>().isTrigger = false;
        doorRight.GetComponent<BoxCollider2D>().isTrigger = false;
        doorDown.GetComponent<BoxCollider2D>().isTrigger = false;
        doorUp.GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
