using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Share()
    {
        Application.OpenURL("https://www.naver.com/");
    }

    public void FishingList()
    {
        Application.OpenURL("https://www.daum.net/");
    }

    public void Explain()
    {
        Application.OpenURL("https://www.google.com/");
    }
}
