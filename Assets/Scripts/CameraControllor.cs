using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllor : MonoBehaviour
{

    public static CameraControllor instance;

    public float speed;//相机移动速度

    public Transform target;//目标坐标
    
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
         if (target != null)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x,
             target.position.y, transform.position.z), speed * Time.deltaTime);
    }

    public void ChangeTarget(Transform newTarget)//函数方法在Room中判断碰撞进入后调用
    {
        target = newTarget;
    }

}

