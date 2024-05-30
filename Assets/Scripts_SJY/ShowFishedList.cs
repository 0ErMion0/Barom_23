using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowFishedList : MonoBehaviour
{
    public FishedData fishedData = new FishedData();
    public FishedDataManager FDataMgr;
    public GameObject[] Fish;
    public TextMeshProUGUI[] FishedText;
    public TextMeshProUGUI TotalText;


    //private void Awake()
    //{
    //    FishedText = GetComponents<TextMeshProUGUI>();
    //}

    void Awake()
    {
        FDataMgr = GameObject.Find("FishedDataMng").GetComponent<FishedDataManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        FishedResultt();
        anjgkwl();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FishedResultt()
    {
        //Debug.Log(fishedData.Fished);
        TotalText.text = "피싱 5개 중 " + FDataMgr.fishedData.Fished + "회 당하셨습니다!";
        Debug.Log(FDataMgr.fishedData.Fished);
        Debug.Log("FishedResult 실행");
    }

    public void anjgkwl()
    {
        for (int i = 0; i < FDataMgr.Fishlist.Length; i++)
        {
            Fish[i].SetActive(FDataMgr.Fishlist[i]); //fish image active
            Debug.Log("Fish SetActive");
            if (FDataMgr.Fishlist[i])
            {
                FishedText[i].color = Color.white;
                Debug.Log("Chapter Text Active");
                FishedText[i + 5].color = Color.white;
                Debug.Log("Text2 Active");
            }

        }
    }
}
