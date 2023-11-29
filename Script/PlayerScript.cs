using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform bulletPrefab;
    public Transform bulletGroup;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Transform clone = Instantiate(bulletPrefab);

            //copy
            Vector3 newPos = this.transform.localPosition;
            //modify
            newPos.z = 12;
            //paste
            clone.localPosition = newPos;

            //set parent
            clone.parent = bulletGroup;

            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().PlayShootSound();
        }
        if (Input.GetKey(KeyCode.W))
        {
            if(this.transform.localPosition.y < 5)
            {
                //1 - copy
                Vector3 playerPosition = this.transform.localPosition;
                //2 - modify
                playerPosition.y = playerPosition.y + 0.1f;
                //3 - paste
                this.transform.localPosition = playerPosition;
            }
            else
            {
                //1 - copy
                Vector3 playerPosition = this.transform.localPosition;
                //2 - modify
                playerPosition.y = 5;
                //3 - paste
                this.transform.localPosition = playerPosition;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if(this.transform.localPosition.x > -6)
            {
                //1 - copy
                Vector3 playerPosition = this.transform.localPosition;
                //2 - modify
                playerPosition.x = playerPosition.x - 0.1f;
                //3 - paste
                this.transform.localPosition = playerPosition;
            }
            else
            {
                //1 - copy
                Vector3 playerPosition = this.transform.localPosition;
                //2 - modify
                playerPosition.x = -6;
                //3 - paste
                this.transform.localPosition = playerPosition;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if(this.transform.localPosition.y > -4.3f)
            {
                //1 - copy
                Vector3 playerPosition = this.transform.localPosition;
                //2 - modify
                playerPosition.y = playerPosition.y - 0.1f;
                //3 - paste
                this.transform.localPosition = playerPosition;
            }
            else
            {
                //1 - copy
                Vector3 playerPosition = this.transform.localPosition;
                //2 - modify
                playerPosition.y = -4.3f;
                //3 - paste
                this.transform.localPosition = playerPosition;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if(this.transform.localPosition.x < 6)
            {
                //1 - copy
                Vector3 playerPosition = this.transform.localPosition;
                //2 - modify
                playerPosition.x = playerPosition.x + 0.1f;
                //3 - paste
                this.transform.localPosition = playerPosition;
            }
            else
            {
                //1 - copy
                Vector3 playerPosition = this.transform.localPosition;
                //2 - modify
                playerPosition.x = 6;
                //3 - paste
                this.transform.localPosition = playerPosition;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);

            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().PlayExplodeSound();
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().YouLose();
        }
    }
}
