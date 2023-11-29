using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public Transform EnemyPrefab;
    public string animationToPlay;
    public float interval;
    public int amount;
    public float startTime;
    public string spawnerAnimation;

    void Start()
    {
        Invoke("StartCreateEnemy", startTime);
    }

    void StartCreateEnemy()
    {
        if(spawnerAnimation != "")
        {
            this.GetComponent<Animation>().Play(spawnerAnimation);
        }
        if (amount > 0)
        {
            CreateEnemy();
        }
    }

    void CreateEnemy()
    {
        //ลากมาปล่อย
        Transform clone = Instantiate(EnemyPrefab);
        //set parent
        clone.parent = this.transform;
        //set position 0 0 0
        Vector3 newPosition = new Vector3(0, 0, 0);
        clone.transform.localPosition = newPosition;
        //เล่น animation
        if(animationToPlay != "")
        {
            clone.GetComponent<Animation>().Play(animationToPlay);
        }

        amount = amount - 1;
        if(amount > 0)
        {
            Invoke("CreateEnemy", interval);
        }
    }
}
