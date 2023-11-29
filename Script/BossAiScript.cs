using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAiScript : MonoBehaviour
{
    public float speed;
    public int direction;
    public Transform bulletPrefab;
    public Transform bulletGroup;

    public float cooldown;
    public float cooldownSet = 100;

    void Start()
    {
        cooldown = cooldownSet;
        bulletGroup = GameObject.FindGameObjectWithTag("BulletGroup").transform;
    }
    void Update()
    {
        //===================Movement==========================
        //copy
        Vector3 pos = this.transform.localPosition;
        //modify
        pos.x = pos.x + (speed*direction);
        //paste
        this.transform.localPosition = pos;

        //เช็คตำแหน่ง และเซตทิศทาง
        if(this.transform.localPosition.x >= 6)
        {
            direction = -1;
        }
        if (this.transform.localPosition.x <= -6)
        {
            direction = 1;
        }
        //=====================================================

        //====================Bullet==========================
        cooldown = cooldown - 1;
        if(cooldown <= 0)
        {
            Shoot();
            cooldown = cooldownSet;
        }
        //====================================================
    }

    void Shoot()
    {
        Transform clone = Instantiate(bulletPrefab);

        //copy
        Vector3 newPos = this.transform.position;
        //modify
        newPos.z = 12;
        //paste
        clone.position = newPos;

        //set parent
        clone.parent = bulletGroup;
    }
}
