using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishedResult : MonoBehaviour
{
    public FishedData fishedData = new FishedData();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FishedResultt()
    {
        if (fishedData.Fished == 7)
        {
            //����Ʈ! �̰� image ��Ȱ��ȭ��
            //GetComponent.resultImage
            Debug.Log("�����");
        }
        else if (fishedData.Fished == 5 && fishedData.Fished == 6)
        {
            //�¿���
            Debug.Log("����");
        }
        else if (fishedData.Fished == 3 && fishedData.Fished == 4)
        {
            //��ֿ���
            Debug.Log("���� ����");
        }
        else
        {
            //��忣��
            Debug.Log("ȸ ��");
        }
    }
}
