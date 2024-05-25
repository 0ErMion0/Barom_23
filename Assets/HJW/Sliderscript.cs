using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sliderscript : MonoBehaviour
{
    public bool isalram;
    public Slider alramslider;
    public Slider BGM;
    public Slider VFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isalram && alramslider.value <= 0.1f)
        {
            Event.instance.startcor(2);
        }
    }

    public void BGMVolumchanege()
    {
        Event.instance.BGM.volume = BGM.value;
    }
    public void VFXVolumchanege()
    {
        Event.instance.VFX.volume = VFX.value;
    }
    public void tomain()
    {
        SceneManager.LoadScene("Chapter1");
    }
}
