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
        //Fishlist 초기화
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

            //Local에 저장되어 있는 값 Load해서 대입하기
            for(int i =0; i < fishedData.Fishlist.Length; i++)
            {
                Fishlist[i] = fishedData.Fishlist[i];
            }
            Fished = fishedData.Fished;
            Chapter = fishedData.Chapter;
        }
        else
        {
            //새 파일 생성
            SaveData();
            //fishedData = new FishedData();

            //초기화
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
        //for문 돌려서 true 몇 개인지 Fished에 저장
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
            //퍼펙트! 씬 변환으로 해야겠다
            Debug.Log("퍼펙트");
        }
        else if (fishedData.Fished == 5 && fishedData.Fished == 6)
        {
            //굿엔딩
            Debug.Log("굿 엔딩");
        }
        else if (fishedData.Fished == 3 && fishedData.Fished == 4)
        {
            //노멀엔딩
            Debug.Log("노멀 앤딩");
        }
        else
        {
            //배드엔딩
            Debug.Log("배드 엔딩");
        }
    }
}
