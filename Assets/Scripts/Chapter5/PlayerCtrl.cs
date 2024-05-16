using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    // move
    public Transform charTrans;

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
        //if (Application.platform == RuntimePlatform.Android)
        //{
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0); // ù��° ��ġ�� ó��  // ��ġ�� �߻��� ȭ�� ��ǥ�� ���� ��ǥ�� ��ȯ
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

                // ĳ������ �̵� ������ ����
                float clampedX = Mathf.Clamp(touchPos.x, minPosX, maxPosX);

                // ĳ���͸� �̵�
                charTrans.position = new Vector3(clampedX, -4, 0);
            }
        //}
    }

    // item collect and get to the end (sucsses)

    // 
}
