using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FishedResult : MonoBehaviour
{
    //public FishedData fishedData = new FishedData();
    public FishedDataManager fishedDataManager;

    public GameObject resultImg1;
    public GameObject resultImg2;
    public GameObject resultImg3;
    public GameObject resultImg4;
    //public Sprite sp1;
    //public Sprite sp2;
    //public Sprite sp3;
    //public Sprite sp4;
    public TextMeshProUGUI text;

    private void Awake()
    {
        //fishedData = new FishedData();
        fishedDataManager = GameObject.Find("FishedDataMng").GetComponent<FishedDataManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FishedResultt()
    {
        //Debug.Log(fishedData.Fished);

        if (fishedDataManager.fishedData.Fished == 0)
        {
            //����Ʈ! �̰� image ��Ȱ��ȭ��
            //resultImage.sprite = sp1;
            resultImg1.SetActive(true);
            text.text = fishedDataManager.fishedData.Fished + "ȸ";
            Debug.Log("�����");
        }
        else if (fishedDataManager.fishedData.Fished == 1 || fishedDataManager.fishedData.Fished == 2)
        {
            //�¿���
            //resultImage.sprite = sp2;
            resultImg2.SetActive(true);
            text.text = fishedDataManager.fishedData.Fished + "ȸ";
            Debug.Log("����");
        }
        else if (fishedDataManager.fishedData.Fished == 3 || fishedDataManager.fishedData.Fished == 4)
        {
            //��ֿ���
            //resultImage.sprite = sp3;
            resultImg3.SetActive(true);
            text.text = fishedDataManager.fishedData.Fished + "ȸ";
            Debug.Log("���� ����");
        }
        else
        {
            //��忣��
            //resultImage.sprite = sp4;
            resultImg4.SetActive(true);
            text.text = fishedDataManager.fishedData.Fished + "ȸ";
            Debug.Log("ȸ ��");
        }
    }
}
