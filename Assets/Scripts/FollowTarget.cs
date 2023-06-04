using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    public Transform player1;//坦克的组件
    public Transform player2;

    private Camera camera;  //camera组件
    private Vector3 offset; //坦克中心位置和camera偏移量

    void Start()
    {
        offset = transform.position - (player1.position + player2.position)/2;//获取偏移量
        camera = this.GetComponent<Camera>();  //获取camera组件
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 == null || player2 == null) return;
        transform.position = (player1.position + player2.position)/2 + offset; //设置Cemara位置
        float distance = Vector3.Distance(player1.position, player2.position); //获取坦克之间的位置
        if (distance <= 5f) return;
        float size = distance * 0.875f;  //获取size大小
        camera.orthographicSize = size;
    }
}
