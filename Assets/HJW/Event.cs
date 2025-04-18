using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Eventtype
{
    Fadeout,
    Fadein,
    Wait,
    ChangeMainImage,
    ChangeOtherImage,
    ChangeMainText,
    ChangeTextColor,
    ChangeOtherText,
    ActivateButton,
    ActivateObject,
    DeactivateButton,
    DisableObject,
    PlayBgm,
    PlayVFX,
    StopBgm,
    StopVFX,
    SetChapter,
    Fished,
    EnableFishList,
    VIberate,
    EndApp,
    AudioRepeat,
    AudioNotRepeat,
    ShakeDisplay,
    ChangeScene,
    Savedata,
    Loaddata,
    CalcFishnum,
    ToResultScene
}

[System.Serializable]
public class Eventt
{
    public Eventtype type;
    public float Intvalue;

    public bool open;
    [DrawIf("open", true)] public Button button;
    [DrawIf("open", true)] public GameObject Object;
    [DrawIf("open", true)] public Color Textcolor;
    [DrawIf("open", true)] public string OtherTextString;

    
}
[System.Serializable]
public class Eventtt
{
    public string eventitle;
    public Eventt[] eventlist;
}
public class Event : MonoBehaviour
{
    public Data data;
    public AudioSource BGM;
    public AudioSource VFX;
    public Image MainImagepannel;
    public Image FadeOutPannel;
    public TextMeshProUGUI MainText;
    public Animation shakeanim;
    public FishedDataManager datamgr;
    public FishedResult fishedResult;
    public AudioClip bubble;
    [Space(50)]
    public Eventtt[] events;
    public static Event instance;
    void OnEnable()
    {
        // 델리게이트 체인 추가
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        datamgr = GameObject.Find("FishedDataMng").GetComponent<FishedDataManager>();
        BGM.volume = datamgr.bgm;
        VFX.volume = datamgr.vfx;
        if (datamgr.Chapter != 0)
        {
            VFX.clip = bubble;
            VFX.Play();
        }

    }

    void OnDisable()
    {
        // 델리게이트 체인 제거
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    public void startcor(int eventidx)
    {
        StartCoroutine(eventcor(eventidx));
    }

    IEnumerator eventcor(int eventidx)
    {
        for (int i = 0; i < events[eventidx].eventlist.Length; i++)
        {
            switch (events[eventidx].eventlist[i].type)
            {
                case Eventtype.Wait:
                    yield return new WaitForSeconds(events[eventidx].eventlist[i].Intvalue);
                    break;
                case Eventtype.Fadeout:
                    while(FadeOutPannel.color.a < 1)
                    {
                        FadeOutPannel.color += new Color(0, 0, 0, events[eventidx].eventlist[i].Intvalue);
                        yield return null;
                    }
                    break;
                case Eventtype.Fadein:
                    while (FadeOutPannel.color.a > 0)
                    {
                        FadeOutPannel.color -= new Color(0, 0, 0, events[eventidx].eventlist[i].Intvalue);
                        yield return null;
                    }
                    break;
                case Eventtype.ChangeMainImage:
                    MainImagepannel.sprite = data.Images[(int)events[eventidx].eventlist[i].Intvalue];
                    break;
                case Eventtype.ChangeMainText:
                    MainText.text = data.Texts[(int)events[eventidx].eventlist[i].Intvalue];
                    break;
                case Eventtype.ActivateButton:
                    events[eventidx].eventlist[i].button.interactable = true;
                    break;
                case Eventtype.DeactivateButton:
                    events[eventidx].eventlist[i].button.interactable = false;
                    break;
                case Eventtype.PlayBgm:
                    BGM.clip = data.Audio[(int)events[eventidx].eventlist[i].Intvalue];
                    BGM.Play();
                    break;
                case Eventtype.PlayVFX:
                    VFX.clip = data.Audio[(int)events[eventidx].eventlist[i].Intvalue];
                    VFX.Play();
                    break;
                case Eventtype.StopVFX:
                    VFX.Stop();
                    break;
                case Eventtype.StopBgm:
                    BGM.Stop();
                    break;
                case Eventtype.ActivateObject:
                    events[eventidx].eventlist[i].Object.SetActive(true);
                    break;
                case Eventtype.DisableObject:
                    events[eventidx].eventlist[i].Object.SetActive(false);
                    break;
                case Eventtype.SetChapter:
                    datamgr.Chapter = (int)events[eventidx].eventlist[i].Intvalue;
                    datamgr.fishedData.Chapter = (int)events[eventidx].eventlist[i].Intvalue;
                    break;
                case Eventtype.EnableFishList:
                    datamgr.Fishlist[(int)events[eventidx].eventlist[i].Intvalue] = true;
                    datamgr.fishedData.Fishlist[(int)events[eventidx].eventlist[i].Intvalue] = true;
                    Debug.Log("Enable 실행");
                    Debug.Log(datamgr.Fishlist.Length);
                    for (int j = 0; j < datamgr.Fishlist.Length; j++)
                    {
                        Debug.Log(datamgr.Fishlist[j]);
                    }
                    break;
                //case Eventtype.Fished:
                //    datamgr.Fished++;
                //    datamgr.fishedData.Fished++;
                //    break;
                case Eventtype.EndApp:
                    Application.Quit();
                    break;
                case Eventtype.VIberate:
                    //if(Application.platform==RuntimePlatform.Android)
                       // Handheld.Vibrate(); 
                    break;
                case Eventtype.ChangeOtherText:
                    events[eventidx].eventlist[i].Object.GetComponent<TextMeshProUGUI>().text = events[eventidx].eventlist[i].OtherTextString;
                    break;
                case Eventtype.ChangeOtherImage:
                    events[eventidx].eventlist[i].Object.GetComponent<Image>().sprite = data.Images[(int)events[eventidx].eventlist[i].Intvalue];
                    break;
                case Eventtype.ChangeTextColor:
                    MainText.color = events[eventidx].eventlist[i].Textcolor;
                    break;
                case Eventtype.AudioRepeat:
                    VFX.loop = true;
                    break;
                case Eventtype.AudioNotRepeat:
                    VFX.loop = false;
                    break;
                case Eventtype.ShakeDisplay:
                    shakeanim.Play();
                    break;
                case Eventtype.ChangeScene:
                    SceneManager.LoadScene(events[eventidx].eventlist[i].OtherTextString);
                    break;
                case Eventtype.Savedata:
                    datamgr.SaveData();
                    break;
                case Eventtype.Loaddata:
                    datamgr.LoadData();
                    break;
                case Eventtype.CalcFishnum:
                    datamgr.CalcFishNum();
                    break;
                case Eventtype.ToResultScene:
                    fishedResult.FishedResultt();
                    break;
            }
        }
    }
}
