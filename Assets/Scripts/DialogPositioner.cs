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

        // Select를 화면 오른쪽에서 15 떨어지도록 설정
        screenPosition.x = Screen.width - 15;

        // 다시 월드 좌표로 변환하여 위치 적용
        dialogRectTransform.position = mainCamera.ScreenToWorldPoint(screenPosition);
    }
}
