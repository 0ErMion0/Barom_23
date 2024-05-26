using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
	public enum ItemType
    {
		Positive,
		Negetive
    };
	//public List<ItemData> ItemDatas = new List<ItemData>(); // ��ũ���ͺ� ������Ʈ
	
	public GameObject player;
	GameObject director;

	public AudioSource VFX;
	public AudioClip getItemPositiveVFX;
	public AudioClip getItemNegativeVFX;

	[SerializeField]
	private float fallSpeed;
	// �� �����۸��� ���ǵ� �ٸ��� �ϸ� ������. n�� �� ������ ��������.
	private float minPos = -2.88f;

	[SerializeField]
	ItemData itemData;
	public ItemData ItemData { set { itemData = value; } }

	private void Start()
    {
		//Debug.Log(itemData.ItemType);
		//Debug.Log(itemData.Speed);

		player = GameObject.FindGameObjectWithTag("Player");
		fallSpeed = itemData.Speed;


		director = GameObject.Find("GameDirector");
	}

    void Update()
	{
		// �Ʒ��� �̵�
		transform.Translate(0, -fallSpeed * Time.deltaTime, 0, 0);

		// ȭ�� ������ ������ ������Ʈ �Ҹ�
		if (transform.position.y < minPos)
		{
			Destroy(gameObject);
		}

		//// �浹 ���� �߰�
		//Vector2 p1 = transform.position;
		//Vector2 p2 = player.transform.position;
		//Vector2 dir = p1 - p2;
		//float d = dir.magnitude;
		////float r1 = 0.5f; // ������Ʈ �ݰ�
		////float r2 = 0.8f; // �÷��̾� �ݰ�
		//float r1 = 0.55f; // ������Ʈ �ݰ�
		//float r2 = 0.8f; // �÷��̾� �ݰ�

		//if (d < r1 + r2)
		//{ 
		//	// �浹 ����
		//	Destroy(gameObject);

		//          // �浹 �� n -> ���� �ϳ� ����
		//          if (itemData.itemType == 0) //n
		//          {
		//		// ���� ���� �Լ� ȣ��
		//		director.GetComponent<GameDirector>().DecreaseHp();
		//          }
		//          else // �浹 �� p -> 10������ ä��� Ŭ����
		//          {
		//		// ������ ���� ��Ʈ�� ȣ��
		//		director.GetComponent<GameDirector>().ItemCount();
		//	}
		//}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Player")
		{
			//print("�浹");

			// �浹 �� n -> ���� �ϳ� ����
			if (itemData.itemType == 0) //n
			{
				// ���� ���� �Լ� ȣ��
				director.GetComponent<GameDirector>().DecreaseHp();
				VFX.clip = getItemPositiveVFX;
			}
			else // �浹 �� p -> 10������ ä��� Ŭ����
			{
				// ������ ���� ��Ʈ�� ȣ��
				director.GetComponent<GameDirector>().ItemCount();
				VFX.clip = getItemNegativeVFX;
			}

			// �浹 ����
			Destroy(gameObject);
		}
	}
}
