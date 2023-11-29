using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public int dmg;
    public int direction;

    void Update()
    {
        //copy
        Vector3 pos = this.transform.localPosition;
        //modify
        pos.y = pos.y + (speed*direction);
        //paste
        this.transform.localPosition = pos;
    }
}
