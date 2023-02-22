using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class succrssPanel : MonoBehaviour
{
    public Text Time;
    public Text DeadCount;
    public Button button;
    private void Awake()
    {
        button.onClick.AddListener(() => EditorApplication.isPlaying = false);

    }
    private void OnEnable()
    {
        int a = (int)GameManager.Instance.timeSpend;
        DeadCount.text = "死亡次数:" + GameManager.Instance.DeadCount.ToString();
        Time.text = "本次游戏通关时间:" + a.ToString() + "秒";

        if (GameManager.Instance.gameDate.time != -1)
        {
            if (GameManager.Instance.gameDate.time > a)
            {
                GameManager.Instance.gameDate.time = a;
                GameManager.Instance.time.text = $"最快通过时间:{a}秒";
            }

        }
        if (GameManager.Instance.gameDate.Dead != -1)
        {
            if (GameManager.Instance.gameDate.Dead > GameManager.Instance.DeadCount)
            {
                GameManager.Instance.gameDate.Dead = GameManager.Instance.DeadCount;
                GameManager.Instance.Dead.text = $"最少死亡次数:{GameManager.Instance.DeadCount}次";
            }

        }
    }
}
