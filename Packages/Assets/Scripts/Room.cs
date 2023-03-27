using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject doorLeft, doorRight, doorUp, doorDown;//用来存放各个位置的门

    public bool roomLeft, roomRight, roomUp, roomDown;//判断上下左右是否有房间

    public Text text;
    
    public int stepToStart;//距离初始点的网格距离

    public int doorNumber;//当前房间的门的数量/入口数量

    private Key key; //调用key脚本中的开门关门

    void Start()
    {
        doorLeft.SetActive(roomLeft);
        doorRight.SetActive(roomRight);
        doorUp.SetActive(roomUp);
        doorDown.SetActive(roomDown);
    }

    // Update is called once per frame
    public void UpdateRoom(float xOffset,float yOffset)
    {
        //计算距离初始点的网格距离
        stepToStart = (int)(Mathf.Abs(transform.position.x / xOffset) + Mathf.Abs(transform.position.y / yOffset));

        text.text = stepToStart.ToString();

        if (roomUp)
            doorNumber++;
        if (roomDown)
            doorNumber++;
        if (roomLeft)
            doorNumber++;
        if (roomRight)
            doorNumber++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CameraControllor.instance.ChangeTarget(transform);
            
        }
    }
}
