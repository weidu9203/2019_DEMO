using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    public GameObject arrow;   // 弓箭 -- 预设物体
    public GameObject bullet;  // 子弹 -- 预设物体
    public Transform firePoint;// 发射点(枪口) -- 新建空gameObject,置放于发射枪口，然后拖进脚本即可

    private GameObject weapon; // 私有化 武器，用于切换武器装备

    public int speed = 100; // 初始化武器速度

    private string str = "发射次数：";
    private int count = 0;
    GUISkin guiskin;

    // 文本显示
    void OnGUI()
    {
       // GUI.skin = guiSkin;
        GUI.color = Color.white;
        GUI.Label(new Rect(20, 20, 100, 300), str);
    }

    void Start()
    {
        weapon = bullet; // 初始化 弓箭为攻击武器
    }


    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            //GameObject clone = Instantiate(bullet, this.transform.position, this.transform.rotation); // 以当前对象 为发射点

            // 实例化 clone ,让它 与发射点的方向 保持一致。
            GameObject clone = Instantiate(weapon, firePoint.position, firePoint.rotation);  //以枪口为发射点,
            clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.right * speed); // 根据发射口 ，判断发射方向，3D 用 Vector3.forward

            count++;
        }

        // 武器切换，并更改武器发射速度
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Replace the weapon.");
            weapon = (weapon == arrow) ? bullet : arrow; // 切换武器
            speed = (weapon == arrow) ? 80 : 100;
        }
    }

    // 武器射击后 碰撞销毁 (3D 用OnCollisionEnter()方法 )
    // 也可以把下面代码单独写进 一个脚本，然后绑定预制武器的预制武器即可。
    void OnCollisionEnter2D()
    {

        Destroy(weapon);
    }

}
