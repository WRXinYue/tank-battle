using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Attack : MonoBehaviour
{

    public GameObject shellPrefab;      //子弹预制体
    public KeyCode fireKey = KeyCode.Space;     //发射子弹键盘按钮
    public float shellSpeed = 10;
    public AudioClip shotAudio;

    private Transform firePoint;

    void Start()
    {
        firePoint = transform.Find("FirePoint");//找到发射点
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(fireKey))
        {
            AudioSource.PlayClipAtPoint(shotAudio, transform.position);
            GameObject go = GameObject.Instantiate(shellPrefab, firePoint.position, firePoint.rotation) as GameObject;//在发射点位置实体化子弹
            go.GetComponent<Rigidbody>().velocity = go.transform.forward*shellSpeed;
        }
    }
}
