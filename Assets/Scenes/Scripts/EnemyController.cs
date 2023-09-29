using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject scoreUIText;

    [SerializeField]public GameObject Explosion;
    float speed;
    void Start()
    {
        speed = 2f;
        scoreUIText = GameObject.FindGameObjectWithTag("ScoreTextTag");
    }

    
    void Update()
    {
        //lay vi tri hien tai cua enemy
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        // cap nhat vi tri enemy
        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        //gioi han pham vi cua enemy
        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //dich trung nguoi choi hay dan nguoi choi thi chet
        if((col.tag == "PlayerTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();
            //them diem khi ban duoc ke dich
            scoreUIText.GetComponent<GameScore>().Score += 100;
            Destroy(gameObject);
        }
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);
        explosion.transform.position = transform.position;
    }
}
