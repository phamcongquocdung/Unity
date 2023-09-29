using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBullet;

    //thoi gian giua 2 lan ban
    public float fireInterval = 2f;
    void Start()
    {
        //enemy ban dan sau 1 giay
        Invoke("FireEnemyBullet", 1f);
        InvokeRepeating("FireEnemyBullet", 0f, fireInterval);
    }

    void Update()
    {
        
    }

    // Dan cua enemy nham vao nguoi choi
    void FireEnemyBullet()
    {
        GameObject player = GameObject.Find("player");
        if(player != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);

            bullet.transform.position = transform.position;

            Vector2 direction = player.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullets>().SetDirection(direction);
        }
    }
}
