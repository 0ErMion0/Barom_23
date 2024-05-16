using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameDirector : MonoBehaviour
{
    // ����
    public GameObject[] hearts;
    private int hp = 3;
    //public GameObject hpGauge;

    // ����
    private int score = 0;
    public TextMeshProUGUI scoreText;

    // �ð�
    public GameObject timeGauge;
    //float maxTimeGauge = 1.0f;
    float time = 0f;

    public GameObject gameUICanvas;
    public GameObject clearImg;
    public GameObject failImg;
    public GameObject dialog;

    public TextMeshProUGUI dialogText;
    private string clearText = "������ �� ��¦ ���������!";
    private string failText = "�̹��� ������ �۷���..";

    public GameObject gameObjects;

    private void Start()
    {
        //StartCoroutine(TimeCtrl());
    }

    private void Update()
    {
        TimeCtrl();
    }

    // ���� ��Ʈ��
    // - �� 3���� ����
    // - ���� �� ������ ���� �ǳ� ���� �������� �Ѿ��
    public void DecreaseHp()
    {
        hp--;
        hearts[hp].SetActive(false);

        if (hp <= 0)
            Fail();
    }

    // ������ ���� ��Ʈ��
    // - positive ������ ȹ�� �� ī��Ʈ
    // - 10�� ������ ���� �ǳ� ���� �������� �Ѿ��
    public void ItemCount()
    {
        score++;
        scoreText.text = score + " / 10";

        if (score >= 10)
            Clear();
    }

    // �ð� ��Ʈ��
    // - 15�� ��Ƽ�� ����
    //private IEnumerator TimeCtrl()
    //{

    //}
    public void TimeCtrl()
    {
        time = 0;
        time += Time.deltaTime;
        float fillAmount = (15 - time) / 15; // �� 15�� (15-deltatime)/15
        this.timeGauge.GetComponent<Image>().fillAmount = fillAmount;
        if(fillAmount <= 0 && hp >= 1)
        {
            //Debug.Log("����");
            Clear();
        }
    }

    // ���� ��
    private void Clear()
    {
        clearImg.SetActive(true); // ���� ��
        dialog.SetActive(true);
        dialogText.text = clearText;
        gameUICanvas.SetActive(false);
        gameObjects.SetActive(false);

        ResetData();
    }

    // ���� ��
    private void Fail()
    {
        failImg.SetActive(true); // ���� ��
        dialog.SetActive(true);
        dialogText.text = failText;
        gameUICanvas.SetActive(false);
        gameObjects.SetActive(false);

        ResetData();
    }

    // �ʱ�ȭ
    private void ResetData()
    {
        score = 0;
        scoreText.text = "0 / 10";

        time = 0;
    }

}
