using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    float speed;
    //huong vien dan
    Vector2 _direction;
    bool isReady;

    private void Awake()
    {
        speed = 5f;
        isReady = false;
    }
    void Start()
    {
        
    }
    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;
    }
    
    void Update()
    {
        if(isReady)
        {
            //lay vi tri hien tai vien dan
            Vector2 position = transform.position;
            position += _direction * speed * Time.deltaTime;

            //cap nhat vi tri vien dan
            transform.position = position;

            //gioi han vien dan, loai bo vien dan khi ra khoi man hinh
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if((transform.position.x < min.x) || (transform.position.x > max.x) || (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //nguoi choi dinh dan thi chet
        if(col.tag == "PlayerTag")
        {
            Destroy(gameObject);
        }
    }
}
