using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank_health : MonoBehaviour
{

    public int hp = 100;
    public GameObject tankExplosion;
    public AudioClip tankExplosionAudio;

    public Slider hpSlider;

    private int hpTotal;

    void Start()
    {
        hpTotal = hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamege()
    {
        if (hp <= 0)
            return;
        hp -= Random.Range(10, 20);
        hpSlider.value = (float)hp /hpTotal;
        if (hp <= 0)
        {   //收到伤害之后 血量为零0 控制死亡效果
            AudioSource.PlayClipAtPoint(tankExplosionAudio,transform.position);
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }
}
