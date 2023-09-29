using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public AudioSource[] soundfx;
    public GameObject GameManager;
    [SerializeField] public float MovementSpeed = 10f;
    [SerializeField] public float HorizontalBorder = 8.5f;
    [SerializeField] public float VerticalBorder = 4.5f;
    [SerializeField] public Vector3 moveAmount;

    [SerializeField] private GameObject PlayerBullets;
    [SerializeField] private Transform AttackPoint;
    [SerializeField] private float waitAttack = 0.35f;
    [SerializeField] private float timer;
    private bool canAttack;
    public GameObject Explosion;

    [SerializeField]public Text LivesUIText;
    const int MaxLives = 3;//So mang toi da la 3
    int lives; //so mang hien co
    public void Init()
    {
        lives = MaxLives;
        LivesUIText.text = lives.ToString();  //cap nhat so mang UI TEXT
        gameObject.SetActive(true);//hien player khi con song
        transform.position = new Vector2(0, 0);
    }

    void Update()
    {
        MovePlayer();
        Attack();
    }
    void MovePlayer()
    {
        // Dung cac phim mui ten de di chuyen 
        moveAmount += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed, Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed, 0);
        Vector3 moveDiff = moveAmount * Time.deltaTime * 8;
        transform.position += moveDiff;
        moveAmount -= moveDiff;

        // Gioi han pham vi di chuyen cua nhan vat
        if (transform.position.x < -HorizontalBorder) transform.position = new Vector3(-HorizontalBorder, transform.position.y, transform.position.z);
        if (transform.position.x > HorizontalBorder) transform.position = new Vector3(HorizontalBorder, transform.position.y, transform.position.z);
        if (transform.position.y < -VerticalBorder) transform.position = new Vector3(transform.position.x, -VerticalBorder, transform.position.z);
        if (transform.position.y > VerticalBorder) transform.position = new Vector3(transform.position.x, VerticalBorder, transform.position.z);
    }
    void Attack()
    {
        timer += Time.deltaTime;
        if (timer > waitAttack)
        {
            canAttack = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (canAttack)
            {
                soundfx[0].Play();
                canAttack = false;
                timer = 0;
                Instantiate(PlayerBullets, AttackPoint.position, Quaternion.identity);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //cham vao ke dich, dan ke dich thi chet
        if ((col.tag == "EnemyTag") || (col.tag == "EnemyBulletTag"))
        {
            PlayExplosion();
            lives--;//mat 1 mang 
            LivesUIText.text = lives.ToString();//cap nhat so mang 

            if(lives == 0 )
            {

                GameManager.GetComponent<GameManager>().SetGameManagerState(global::GameManager.GameManagerState.GameOver);

                //an di player khi chet
                gameObject.SetActive(false);
            }
           
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);
        explosion.transform.position = transform.position;
    }

}
