using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class FishedDataManager : MonoBehaviour
{

    public FishedData fishedData = new FishedData();
    public bool[] Fishlist = new bool[6];
    public int Fished = 0;
    public int Chapter = 0;

    private void Awake()
    {
        //Fishlist �ʱ�ȭ
        for (int i = 0; i < fishedData.Fishlist.Length; i++)
        {
            fishedData.Fishlist[i] = false;
        }

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveData()
    {
        string FishedDataFilePath = Application.persistentDataPath + "/MainGameData.json";
        string ToJsonData = JsonUtility.ToJson(fishedData, true);

        Debug.Log(FishedDataFilePath);

        File.WriteAllText(FishedDataFilePath, ToJsonData);
    }

    public void LoadData()
    {
        string FishedDataFilePath = Application.persistentDataPath + "/MainGameData.json";

        if (File.Exists(FishedDataFilePath))
        {
            string FromJsonData = File.ReadAllText(FishedDataFilePath);
            fishedData = JsonUtility.FromJson<FishedData>(FromJsonData);

            //Local�� ����Ǿ� �ִ� �� Load�ؼ� �����ϱ�
            for(int i =0; i < fishedData.Fishlist.Length; i++)
            {
                Fishlist[i] = fishedData.Fishlist[i];
            }
            Fished = fishedData.Fished;
            Chapter = fishedData.Chapter;
        }
        else
        {
            //�� ���� ����
            SaveData();
            //fishedData = new FishedData();

            //�ʱ�ȭ
            for (int i = 0; i < fishedData.Fishlist.Length; i++)
            {
                fishedData.Fishlist[i] = false;
            }
            fishedData.Fished = 0;
            fishedData.Chapter = 0;
        }
    }


    void CalcFishNum()
    {
        //for�� ������ true �� ������ Fished�� ����
        for (int i = 0; i < fishedData.Fishlist.Length; i++)
        {
            if (fishedData.Fishlist[i] == true)
                fishedData.Fished++;
        }
    }

    public void FishedResult()
    {
        if (fishedData.Fished == 7)
        {
            //����Ʈ! �� ��ȯ���� �ؾ߰ڴ�
            Debug.Log("����Ʈ");
        }
        else if (fishedData.Fished == 5 && fishedData.Fished == 6)
        {
            //�¿���
            Debug.Log("�� ����");
        }
        else if (fishedData.Fished == 3 && fishedData.Fished == 4)
        {
            //��ֿ���
            Debug.Log("��� �ص�");
        }
        else
        {
            //��忣��
            Debug.Log("��� ����");
        }
    }
}
