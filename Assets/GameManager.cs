using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum GameState
{
    ready,
    playing,
    GameOver,
    Win,
    success,
}

public class GameManager : UnitySingleton<GameManager>
{
    public List<GameObject> level = new List<GameObject>();
    public List<GameObject> spawn = new List<GameObject>();
    public GameState gameState;
    public GameObject player;
    public int index;
    public float timeSpend;
    public int DeadCount;
    public GameObject succeessPanel;
    public Text count;
    public GameObject levelturn;
    public GameDate gameDate;

    public int AddBlonecount;

    public Text time;
    public Text Dead;

    public Text Addcount;
    private void Start()
    {
        AddBlonecount = gameDate.addbloneCount;
        if (gameDate.time == -1)
        {
            time.text = "最快通过时间:暂无记录";
            Dead.text = "最少死亡次数:暂无记录";
        }
        else
        {
            time.text = "最快通过时间:" + gameDate.time.ToString();
            Dead.text = "最少死亡次数:" + gameDate.Dead.ToString();
        }

    }
    private void OnEnable()
    {
        gameState = GameState.ready;
    }

    public IEnumerator star(GameObject obj)
    {

        yield return new WaitForSeconds(1f);
        obj.SetActive(true);
    }
    private void Update()
    {
        timeSpend += Time.deltaTime;
        GameTime();
        if (gameState == GameState.Win)
        {
            count.text = (index + 1) + "/2";
            if (index >= level.Count - 1)
            {
                gameState = GameState.success;
                succeessPanel.SetActive(true);
                return;
            }
            levelturn.SetActive(true);
            GameManager.Instance.level[index].SetActive(false);
            index++;
            EnemiesManager.CreateEnemt(index);
            player.transform.localPosition = GameManager.Instance.spawn[index].transform.position;
            GameManager.Instance.level[index].SetActive(true);
            gameState = GameState.playing;
        }
        if (gameState == GameState.GameOver)
        {
            DeadCount++;
            player.transform.localPosition = GameManager.Instance.spawn[index].transform.position;
            gameState = GameState.playing;
            player.GetComponent<playerController>().CurrentHealth = 100;
            player.GetComponent<playerController>().statebar.UpdateStats(player.GetComponent<playerController>().CurrentHealth, 100);
        }
        if (player.GetComponent<playerController>().CurrentHealth <= 0)
        {
            gameState = GameState.GameOver; ;
        }
        Addcount.text = $"{AddBlonecount}";
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    if (AddBlonecount > 0)
        //    {
        //        AddBlonecount--;

        //        player.GetComponent<playerController>().Addblone(10);
        //    }
        //}
    }
    int hour;
    int minute;
    int second;
    int millisecond;
    public void GameTime()
    {
        // if (gameState != GameState.success)


        //hour = (int)timeSpend / 3600;
        //minute = ((int)timeSpend - hour * 3600) / 60;
        //second = (int)timeSpend - hour * 3600 - minute * 60;
        //millisecond = (int)((timeSpend - (int)timeSpend) * 1000);



    }


}
