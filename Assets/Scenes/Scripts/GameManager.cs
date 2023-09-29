using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject player;
    public GameObject enemySpawner;
    public GameObject GameOver;
    public GameObject scoreUIText;
    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }
    GameManagerState GMState;

    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    void UpdateGameManagerState()
    {
        switch(GMState)
        {
            case GameManagerState.Opening:
                //an game over
                GameOver.SetActive(false);
                //hien nut play
                playButton.SetActive(true);
                break;
            case GameManagerState.Gameplay:
                //reset diem so
                scoreUIText.GetComponent<GameScore>().Score = 0;
                playButton.SetActive(false);//an nut play khi bat dau game
                player.GetComponent<PlayerControler>().Init();//hien player khi bat dau game

                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
                break;
            case GameManagerState.GameOver:
                //dung spawn enemy
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();

                //quay ve mo dau game sau 5 giay
                Invoke("ChangeToOpeningState", 5f);

                //hien game over
                GameOver.SetActive(true);
                break;
        }
    }
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
