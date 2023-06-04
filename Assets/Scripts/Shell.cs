using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{

    public GameObject shellExplosionPrefab;
    public AudioClip shellExplosionAudio;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider )
    {
        AudioSource.PlayClipAtPoint( shellExplosionAudio,transform.position );
        GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation);//实列化爆炸效果
        GameObject.Destroy(this.gameObject);        //删除子弹
        if (collider.tag == "Tank")     //碰撞到坦克时
        {
            collider.SendMessage("TakeDamege");     //给坦克发送消息
        }
    }
}
