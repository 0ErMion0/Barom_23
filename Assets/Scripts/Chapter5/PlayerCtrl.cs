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

    GameObject director;

    public Data data;
    public AudioSource VFX;

    private void Start()
    {
        charTrans = gameObject.transform;

        director = GameObject.Find("GameDirector");
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
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0); // 첫번째 터치만 처리  // 터치가 발생한 화면 좌표를 월드 좌표로 변환
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

                // 캐릭터의 이동 범위를 제한
                float clampedX = Mathf.Clamp(touchPos.x, minPosX, maxPosX);

                // 캐릭터를 이동
                charTrans.position = new Vector3(clampedX, -4, 0);
            }
        }
        //else
        //{
        //    // 마우스의 현재 위치를 가져옴
        //    Vector3 mousePosition = Input.mousePosition;
        //    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //    // 플레이어 오브젝트의 새로운 위치 설정
        //    Vector3 targetPosition = new Vector3(mousePosition.x, transform.position.y, transform.position.z);

        //    // 플레이어 오브젝트가 화면 경계를 넘지 않도록 설정
        //    targetPosition.x = Mathf.Clamp(targetPosition.x, minPosX, maxPosX);

        //    // 플레이어 오브젝트를 타겟 위치로 이동
        //    charTrans.position = new Vector3(targetPosition.x, -4, 0);
        //        //Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        //}
    }

    private void OnMouseDrag()
    {
        // 마우스의 현재 위치를 가져옴
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // 플레이어 오브젝트의 새로운 위치 설정
        Vector3 targetPosition = new Vector3(mousePosition.x, transform.position.y, transform.position.z);

        // 플레이어 오브젝트가 화면 경계를 넘지 않도록 설정
        targetPosition.x = Mathf.Clamp(targetPosition.x, minPosX, maxPosX);

        // 플레이어 오브젝트를 타겟 위치로 이동
        charTrans.position = new Vector3(targetPosition.x, -4, 0);
        //Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            //print("충돌");
            ItemCtrl itemCtrl = collision.gameObject.GetComponent<ItemCtrl>();

            // 충돌 시 n -> 생명 하나 감소
            if (itemCtrl.ItemData.itemType == 0) //n
            {
                // 생명 감소 함수 호출
                director.GetComponent<GameDirector>().DecreaseHp();
                VFX.clip = data.Audio[2];
                VFX.Play();
            }
            else // 충돌 시 p -> 10개까지 채우면 클리어
            {
                // 아이템 점수 컨트롤 호출
                director.GetComponent<GameDirector>().ItemCount();
                VFX.clip = data.Audio[1];
                VFX.Play();
            }

            // 충돌 판정
            Destroy(collision.gameObject);
        }
    }
}
