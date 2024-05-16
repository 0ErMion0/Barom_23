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
	//public List<ItemData> ItemDatas = new List<ItemData>(); // 스크립터블 오브젝트
	
	public GameObject player;

	[SerializeField]
	private float fallSpeed;
	// 그 아이템마다 스피드 다르게 하면 좋을듯. n이 더 빠르게 떨어지게.

	[SerializeField]
	ItemData itemData;
	public ItemData ItemData { set { itemData = value; } }

	GameObject director;


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
		// 아래로 이동
		transform.Translate(0, -fallSpeed, 0);

		// 화면 밖으로 나가면 오브젝트 소멸
		if (transform.position.y < -3.5f)
		{
			Destroy(gameObject);
		}

		// 충돌 판정 추가
		Vector2 p1 = transform.position;
		Vector2 p2 = player.transform.position;
		Vector2 dir = p1 - p2;
		float d = dir.magnitude;
		float r1 = 0.5f; // 오브젝트 반경
		float r2 = 0.8f; // 플레이어 반경

		if (d < r1 + r2)
		{ 
			// 충돌 판정
			Destroy(gameObject);

            // 충돌 시 n -> 생명 하나 감소
            if (itemData.itemType == 0) //n
            {
				// 생명 감소 함수 호출
				director.GetComponent<GameDirector>().DecreaseHp();
            }
            else // 충돌 시 p -> 10개까지 채우면 클리어
            {
				// 아이템 점수 컨트롤 호출
				director.GetComponent<GameDirector>().ItemCount();
			}
		}
	}
}
