using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{//游戏经理
    public static GameManager Instance { get; private set; }
    public event EventHandler OnZhuangTaiGengGai;
    public event EventHandler OnGameZanTing;
    public event EventHandler OnGameYunXing;

    private enum State
    {
        WaitingToStart,
        DaoJiShi,
        GamePlaying,
        GameOver,
    }
    State state;

    float waitingToStartTimer = 1f;
    float jiShiTimer = 3f;
    float gamePlayingTimerMAX = 120f;
    float gamePlayingTimer;

    int dingDanWanChengShu;//订单完成数

    bool isZanTing;

    private void Awake()
    {
        Instance = this;
        state = State.WaitingToStart;
    }
    private void OnEnable()
    {
        StartCoroutine(NewUpdate());
    }
    private void Start()
    {
    }

    private void Instace_OnZanTingActions(object sender, EventArgs e)
    {
        ZanTingGame();
    }

    private void OnDisable()
    {
        StopCoroutine(NewUpdate());
    }

    IEnumerator NewUpdate()
    {
        state = State.WaitingToStart;
        yield return new WaitForSeconds(waitingToStartTimer);
        state = State.DaoJiShi;
        OnZhuangTaiGengGai?.Invoke(this, EventArgs.Empty);
        yield return new WaitForSeconds(jiShiTimer);


        state = State.GamePlaying;
        OnZhuangTaiGengGai?.Invoke(this, EventArgs.Empty);
        gamePlayingTimer = gamePlayingTimerMAX;
        yield return new WaitForSeconds(gamePlayingTimerMAX);

        state = State.GameOver;
        OnZhuangTaiGengGai?.Invoke(this, EventArgs.Empty);
    }
    public bool isGamePlaying()
    {
        return state == State.GamePlaying;
    }
    public bool isDaoJiShi()
    {
        return state == State.DaoJiShi;
    }
    public bool isGameOver()
    {
        return state == State.GameOver;
    }
    public float GetJiShiTimer()
    {
        return jiShiTimer;
    }
    public void ZanTingGame()
    {
        isZanTing = !isZanTing;
        if (isZanTing)
        {
            Time.timeScale = 0f;//这玩意是时间流速，默认是1
            OnGameZanTing?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Time.timeScale = 1f;
            OnGameYunXing?.Invoke(this, EventArgs.Empty);
        }
    }
    public bool GetIsZanTing()
    {
        return isZanTing;
    }


}
