using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameDirector : MonoBehaviour
{
    // 생명
    public GameObject[] hearts;
    private int hp = 3;
    //public GameObject hpGauge;

    // 점수
    private int score = 0;
    public TextMeshProUGUI scoreText;
    int clearScore = 5;

    // 시간
    public bool gameStart = false;
    public GameObject timeGauge;
    //float maxTimeGauge = 1.0f;
    float fillAmountCheck = 1;
    float time = 0f;

    public GameObject gameUICanvas;
    public GameObject clearImg;
    public GameObject failImg;
    public GameObject dialog;

    public TextMeshProUGUI dialogText;
    private string clearText = "성공!\n승진에 한 발짝 가까워졌다!";
    private string failText = "실패..\n이번에 승진은 글렀네..";

    public GameObject gameObjects;

    private void Start()
    {
        //StartCoroutine(TimeCtrl());
    }

    private void Update()
    {
        if(gameStart)
            TimeCtrl();
    }

    public void StartGame()
    {
        gameStart = true;
    }

    // 생명 컨트롤
    // - 총 3개의 생명
    // - 생명 다 잃으면 실패 판넬 띄우고 다음으로 넘어가기
    public void DecreaseHp()
    {
        hp--;
        hearts[hp].SetActive(false);

        if (hp <= 0)
            Fail();
    }

    // 아이템 점수 컨트롤
    // - positive 아이템 획득 시 카운트
    // - 10개 모으면 성공 판넬 띄우고 다음으로 넘어가기
    public void ItemCount()
    {
        score++;
        scoreText.text = score + " / " + clearScore;

        if (score >= clearScore)
            Clear();
    }

    // 시간 컨트롤
    // - 15초 버티면 성공
    //private IEnumerator TimeCtrl()
    //{

    //}
    public void TimeCtrl()
    {
        time += Time.deltaTime;
        fillAmountCheck = (15 - time) / 15; // 총 15초 (15-deltatime)/15
        this.timeGauge.GetComponent<Image>().fillAmount = fillAmountCheck;
        if(fillAmountCheck <= 0 && hp >= 1)
        {
            //Debug.Log("성공");
            Clear();
        }
    }

    // 성공 시
    private void Clear()
    {
        clearImg.SetActive(true); // 성공 씬
        dialog.SetActive(true);
        dialogText.text = clearText;
        gameUICanvas.SetActive(false);
        gameObjects.SetActive(false);

        ResetData();
    }

    // 실패 시
    private void Fail()
    {
        failImg.SetActive(true); // 성공 씬
        dialog.SetActive(true);
        dialogText.text = failText;
        gameUICanvas.SetActive(false);
        gameObjects.SetActive(false);

        ResetData();
    }

    // 초기화
    private void ResetData()
    {
        score = 0;
        scoreText.text = "0 / " +  clearScore;

        time = 0;
        fillAmountCheck = 1;

        gameStart = false;
    }
}
