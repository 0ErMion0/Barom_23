using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowFishedList : MonoBehaviour
{
    public FishedData fishedData = new FishedData();
    public GameObject[] Fish;
    public TextMeshProUGUI[] FishedText;
    public TextMeshProUGUI text;


    private void Awake()
    {
        FishedText = GetComponentsInChildren<TextMeshProUGUI>();
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

            text.text = "피싱 7개 중 " + fishedData.Fished + "회 당하셨습니다!";
    }

    public void anjgkwl()
    {
        for (int i = 0; i < fishedData.Fishlist.Length; i++)
        {
            Fish[i].SetActive(fishedData.Fishlist[i]);
            FishedText[i].color = Color.white;
            FishedText[2 * i].color = Color.white;
        }
    }
}
