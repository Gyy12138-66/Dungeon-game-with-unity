using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DoorController : MonoBehaviour
{
    public bool isLocked = true; // 是否上锁
    public GameObject task; // 关联任务的对象
    // Start is called before the first frame update
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isLocked)
            {
                // 如果门上锁，则检查任务是否完成
                if (task != null && task.GetComponent<Key>().isComplete)
                {
                    // 如果任务完成，则解锁门
                    isLocked = false;
                    Debug.Log("任务完成，门已解锁");
                }
                else
                {
                    Collider playerCollider = other.GetComponent<Collider>();
                    if (playerCollider != null)
                    {
                        Physics.IgnoreCollision(playerCollider, GetComponent<Collider>());
                    }
                    // 如果任务未完成，则禁止玩家通过门
                    Debug.Log("门已上锁，需要完成任务才能通过");
                }
            }

            if (!isLocked)
            {
                // 如果门已解锁，则允许玩家通过门
                Debug.Log("门已解锁，玩家可以通过");
                // 在此处添加玩家通过门的代码
            }
        }
    }
}
