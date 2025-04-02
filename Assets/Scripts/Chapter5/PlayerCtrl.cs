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
                Touch touch = Input.GetTouch(0); // ù��° ��ġ�� ó��  // ��ġ�� �߻��� ȭ�� ��ǥ�� ���� ��ǥ�� ��ȯ
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

                // ĳ������ �̵� ������ ����
                float clampedX = Mathf.Clamp(touchPos.x, minPosX, maxPosX);

                // ĳ���͸� �̵�
                charTrans.position = new Vector3(clampedX, -4, 0);
            }
        }
        //else
        //{
        //    // ���콺�� ���� ��ġ�� ������
        //    Vector3 mousePosition = Input.mousePosition;
        //    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //    // �÷��̾� ������Ʈ�� ���ο� ��ġ ����
        //    Vector3 targetPosition = new Vector3(mousePosition.x, transform.position.y, transform.position.z);

        //    // �÷��̾� ������Ʈ�� ȭ�� ��踦 ���� �ʵ��� ����
        //    targetPosition.x = Mathf.Clamp(targetPosition.x, minPosX, maxPosX);

        //    // �÷��̾� ������Ʈ�� Ÿ�� ��ġ�� �̵�
        //    charTrans.position = new Vector3(targetPosition.x, -4, 0);
        //        //Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        //}
    }

    private void OnMouseDrag()
    {
        // ���콺�� ���� ��ġ�� ������
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // �÷��̾� ������Ʈ�� ���ο� ��ġ ����
        Vector3 targetPosition = new Vector3(mousePosition.x, transform.position.y, transform.position.z);

        // �÷��̾� ������Ʈ�� ȭ�� ��踦 ���� �ʵ��� ����
        targetPosition.x = Mathf.Clamp(targetPosition.x, minPosX, maxPosX);

        // �÷��̾� ������Ʈ�� Ÿ�� ��ġ�� �̵�
        charTrans.position = new Vector3(targetPosition.x, -4, 0);
        //Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            //print("�浹");
            ItemCtrl itemCtrl = collision.gameObject.GetComponent<ItemCtrl>();

            // �浹 �� n -> ���� �ϳ� ����
            if (itemCtrl.ItemData.itemType == 0) //n
            {
                // ���� ���� �Լ� ȣ��
                director.GetComponent<GameDirector>().DecreaseHp();
                VFX.clip = data.Audio[2];
                VFX.Play();
            }
            else // �浹 �� p -> 10������ ä��� Ŭ����
            {
                // ������ ���� ��Ʈ�� ȣ��
                director.GetComponent<GameDirector>().ItemCount();
                VFX.clip = data.Audio[1];
                VFX.Play();
            }

            // �浹 ����
            Destroy(collision.gameObject);
        }
    }
}
