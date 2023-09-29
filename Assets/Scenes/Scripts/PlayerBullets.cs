using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets: MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float DestroyTime;
    void Start()
    {
        Invoke("DestroyObject", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //dan dinh dich thi chet dich
        if(col.tag == "EnemyTag")
        {
            Destroy(gameObject);
        }
    }
}
