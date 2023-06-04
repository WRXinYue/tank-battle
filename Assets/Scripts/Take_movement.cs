using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take_movement : MonoBehaviour
{
    public float speed = 5;     //坦克移动速度
    public float angularSpeed = 10;//坦克旋转速度
    public float number = 1;        //添加玩家编号，通过编号区分不同的控制
    public AudioClip idleAudio;     //停止声音
    public AudioClip drivingAudio;  //发动声音

    private AudioSource audio;
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();//获得刚体组件
        audio = this.GetComponent<AudioSource>();
    }

void FixedUpdate()
    {
        float v = Input.GetAxis("VerticalP" + number);        //对应键盘上面的上下箭头，当按上或下箭头时触发
        rigidbody.velocity = transform.forward * v * speed; //利用刚体施加速度

        float h = Input.GetAxis("HorizontalP" + number);//对应键盘上面的左右箭头，当按左或右箭头时出发
        rigidbody.angularVelocity = transform.up * h * speed;//利用刚体施加旋转速度

        if (Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1)
        {
            audio.clip = drivingAudio;
            if(audio.isPlaying==false)
                audio.Play();
        }
        else
        {
            audio.clip = idleAudio;
            if (audio.isPlaying == false)
                audio.Play();
        }
    }
}