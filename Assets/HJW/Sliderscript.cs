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

    public bool gamepause;

    // Update is called once per frame
    void Update()
    {
        if(isalram && alramslider.value <= 0.1f)
        {
            Event.instance.startcor(2);
        }
    }
    public void refresh()
    {
        BGM.value = Event.instance.datamgr.bgm;
        VFX.value = Event.instance.datamgr.vfx;
        if(Event.instance.datamgr.Chapter == 5)
        {
            gamepause = true;
            Time.timeScale = 0;
        }
    }
    public void resume()
    {
        gamepause = false;
        Time.timeScale = 1;
    }
    public void BGMVolumchanege()
    {
        Event.instance.BGM.volume = BGM.value;
        Event.instance.datamgr.bgm = BGM.value;
    }
    public void VFXVolumchanege()
    {
        Event.instance.VFX.volume = VFX.value;
        Event.instance.datamgr.vfx = VFX.value;
    }
    public void tomain()
    {
        Event.instance.datamgr.init();
        Time.timeScale = 1;
        SceneManager.LoadScene("Chapter1");
    }
}
