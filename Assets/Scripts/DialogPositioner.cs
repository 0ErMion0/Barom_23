using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPositioner : MonoBehaviour
{
    public RectTransform dialogRectTransform;
    public Camera mainCamera;

    void Update()
    {
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(dialogRectTransform.position);

        // Select�� ȭ�� �����ʿ��� 15 ���������� ����
        screenPosition.x = Screen.width - 15;

        // �ٽ� ���� ��ǥ�� ��ȯ�Ͽ� ��ġ ����
        dialogRectTransform.position = mainCamera.ScreenToWorldPoint(screenPosition);
    }
}
