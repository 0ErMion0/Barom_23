using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class FishedDataManager : MonoBehaviour
{

    public FishedData fishedData = new FishedData();
    public bool[] Fishlist = new bool[5];
    public int Fished = 0;
    public int Chapter;
    public float vfx = 1;
    public float bgm = 1;
    private void Awake()
    {
        var datas = GameObject.FindGameObjectsWithTag("data");
        if (datas.Length > 1)
        {
            for (int i = 1; i < datas.Length; i++) 
            {
                Destroy(datas[i]);
            }
        }
        DontDestroyOnLoad(datas[0]);
        init();
    }
    public void init()
    {
        fishedData = new FishedData();
        //Fishlist �ʱ�ȭ
        for (int i = 0; i < fishedData.Fishlist.Length; i++)
        {
            fishedData.Fishlist[i] = false;
        }
        fishedData.Fished = 0;
        fishedData.Chapter = 0;
        SaveData();
        for (int i = 0; i < fishedData.Fishlist.Length; i++)
        {
            Fishlist[i] = fishedData.Fishlist[i];
        }
        Fished = fishedData.Fished;
        Chapter = fishedData.Chapter;
    }
    public void SaveData()
    {
        string FishedDataFilePath = Application.persistentDataPath + "/MainGameData.json";
        string ToJsonData = JsonUtility.ToJson(fishedData, true);
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


    public void CalcFishNum()
    {
        if(fishedData.Fished != 0)
        {
            return;
        }
        //for�� ������ true �� ������ Fished�� ����
        for (int i = 0; i < fishedData.Fishlist.Length; i++)
        {
            Debug.Log(fishedData.Fishlist[i]);
            if (fishedData.Fishlist[i] == true)
                fishedData.Fished++;
        }
        //fishedData.Fished = Fished;
        Debug.Log(fishedData.Fished);
    }
}
