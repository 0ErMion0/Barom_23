using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum easterevent
{
    Fadein,
    Fadeout,
    FadeinandCammoveright,
    FadeinandCammoveleft,
    FadeinandCamrotate,
    nameanim,
    wait,
    enabletext,
    enableimg,
    disabletext,
    disableimg,
    end
}
public class Easter : MonoBehaviour
{
    public int touched;
    public Animation fadeinout;
    public Animation cammove;
    public Animation nameanim;
    public GameObject settings;
    public GameObject settingspannel;
    public GameObject initpannel;
    public GameObject arrow;
    public GameObject chumziname;
    public GameObject text;
    public GameObject img;
    public easterevent[] easterevents;
    Animation tempanim;
    public void istouched()
    {
        if(Event.instance.datamgr.Chapter == 0)
        {
            if (touched == 10)
            {
                StartCoroutine(eventstart());
                settings.SetActive(false);
                settingspannel.SetActive(false);
                touched = 0;
                return;
            }
            touched++;
        }

    }
    public void tozero() { touched = 0; }
    public void init()
    {
        fadeinout.clip = fadeinout.GetClip("fadeout");
        fadeinout.Play();
        initpannel.SetActive(false);
        settings.SetActive(true);
        arrow.SetActive(false);
        chumziname.SetActive(false );
        text.SetActive(false );
        img.SetActive(false);
        fadeinout.clip = fadeinout.GetClip("fadein");
        fadeinout.Play();
    }
    IEnumerator eventstart()
    {
        for(int i = 0; i < easterevents.Length; i++)
        {
            if(tempanim != null)
            {
                yield return new WaitUntil(() => tempanim.isPlaying == false);
            }
            switch (easterevents[i])
            {
                case easterevent.Fadein:
                    fadeinout.clip = fadeinout.GetClip("fadein");
                    fadeinout.Play();
                    tempanim = fadeinout;
                    break;
                case easterevent.Fadeout:
                    fadeinout.clip = fadeinout.GetClip("fadeout");
                    fadeinout.Play();
                    tempanim = fadeinout;
                    break;
                case easterevent.FadeinandCamrotate:
                    fadeinout.clip = fadeinout.GetClip("fadein");
                    fadeinout.Play();
                    cammove.clip = cammove.GetClip("fishegggggg");
                    cammove.Play();
                    tempanim = cammove;
                    break;
                case easterevent.FadeinandCammoveright:
                    fadeinout.clip = fadeinout.GetClip("fadein");
                    fadeinout.Play();
                    cammove.clip = cammove.GetClip("fishegggg");
                    cammove.Play();
                    tempanim = cammove;
                    break;
                case easterevent.FadeinandCammoveleft:
                    fadeinout.clip = fadeinout.GetClip("fadein");
                    fadeinout.Play();
                    cammove.clip = cammove.GetClip("fisheggggg");
                    cammove.Play();
                    tempanim = cammove;
                    break;
                case easterevent.nameanim:
                    fadeinout.clip = fadeinout.GetClip("fadein");
                    fadeinout.Play();
                    cammove.clip = cammove.GetClip("fishegggggg");
                    cammove.Play();
                    chumziname.SetActive(true);
                    nameanim.Play();
                    tempanim = nameanim;
                    break;
                case easterevent.enabletext:
                    text.SetActive(true);
                    tempanim = null;
                    break;
                case easterevent.enableimg:
                    img.SetActive(true);
                    tempanim = null;
                    break;
                case easterevent.disabletext:
                    text.SetActive(false);
                    tempanim = null;
                    break;
                case easterevent.disableimg:
                    img.SetActive(false);
                    tempanim = null;
                    break;
                case easterevent.wait:
                    yield return new WaitForSeconds(1);
                    tempanim = null;
                    break;
                case easterevent.end:
                    arrow.SetActive(true);
                    initpannel.SetActive(true);
                    break;
            }
        }
    }
}
