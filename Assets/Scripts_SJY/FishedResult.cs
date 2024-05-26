using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishedResult : MonoBehaviour
{
    public FishedData fishedData = new FishedData();

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
        if (fishedData.Fished == 7)
        {
            //퍼펙트! 이거 image 비활성화로
            //GetComponent.resultImage
            Debug.Log("물고기");
        }
        else if (fishedData.Fished == 5 && fishedData.Fished == 6)
        {
            //굿엔딩
            Debug.Log("잡힘");
        }
        else if (fishedData.Fished == 3 && fishedData.Fished == 4)
        {
            //노멀엔딩
            Debug.Log("도마 위에");
        }
        else
        {
            //배드엔딩
            Debug.Log("회 됨");
        }
    }
}
