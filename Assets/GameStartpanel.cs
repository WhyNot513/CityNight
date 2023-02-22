using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartpanel : MonoBehaviour
{
    public Button Start_btn;
    public Button Exit;
    public GameObject a;
    public GameObject signpanel;
    private void Awake()
    {
        Start_btn.onClick.AddListener(GameStart);
        Exit.onClick.AddListener(() => Application.Quit());

    }
    public void GameStart()
    {
        GameManager.Instance.gameState = GameState.playing;
        GameManager.Instance.level[0].SetActive(true);
        gameObject.SetActive(false);
        GameManager.Instance.player.SetActive(true);
        signpanel.SetActive(false);
        EnemiesManager.CreateEnemt(0);
        a.SetActive(true);
    }
}
