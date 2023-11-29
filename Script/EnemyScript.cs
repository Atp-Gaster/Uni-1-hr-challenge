using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int hp = 10;
    public TextMesh hpText;
    public bool killThisToWin;
    public int addScore;

    void Start()
    {
        UpdateHpText();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            //ทำลายกระสุน
            Destroy(other.gameObject);

            //หักเลือด
            hp = hp - other.GetComponent<BulletScript>().dmg;
            UpdateHpText();
            //ตัวกระพริบ
            Animation animation = this.GetComponent<Animation>();
            animation.Play();

            if (hp <= 0)
            {
                Vector3 box = this.transform.position;
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().PlayExplodeSound();
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().AddScore(addScore , box);
                Destroy(this.gameObject);

                if(killThisToWin == true)
                {
                    GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().YouWin();
                }
            }
        }
    }

    void UpdateHpText()
    {
        hpText.text = "Hp : " + hp;
    }
}
