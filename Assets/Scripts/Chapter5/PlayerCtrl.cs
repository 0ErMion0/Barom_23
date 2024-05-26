using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    // move
    public Transform charTrans;
    public Sliderscript sliderscript;

    float minPosX = -1.3f;
    float maxPosX = 1.3f;

    private void Start()
    {
        charTrans = gameObject.transform;
    }

    private void Update()
    {
        OnMove();
    }

    private void OnMove()
    {
        if(sliderscript.gamepause)
        {
            return;
        }
        //if (Application.platform == RuntimePlatform.Android)
        //{
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0); // 첫번째 터치만 처리  // 터치가 발생한 화면 좌표를 월드 좌표로 변환
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

                // 캐릭터의 이동 범위를 제한
                float clampedX = Mathf.Clamp(touchPos.x, minPosX, maxPosX);

                // 캐릭터를 이동
                charTrans.position = new Vector3(clampedX, -4, 0);
            }
        //}
    }
}
