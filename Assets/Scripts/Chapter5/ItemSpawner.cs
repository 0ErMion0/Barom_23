using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static ItemSpawner main;

    public List<ItemData> ItemList = new List<ItemData>();
    public enum ItemType { 
        EnemyCan,
        EnemyKnife,
        EnemySushi,
        ItemComputer,
        ItemFolder,
        ItemKeyboard,
        ItemPen
    };

    public Vector3[] genPoint; // 생성 포인트
    float span = 1.0f; // 아이템 호출 간격
    float delta = 0; // 현재 시간

    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //// 스폰 포인트
        //for(int i = 0; i < 3; i++)
        //{
        //    // 0,1,2
        //    // (i-1) -> -1, 0, 1 => -1.3, 0, 1.3
        //    genPoint[i] = new Vector3(1.3f*(i-1), 6f, 0);
        //}
    }

    private void Update()
    {
        int posNum = Random.Range(0, 3); // 생성 위치 결정 0, 1, 2 중에서

        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            SpawnItems(posNum);
        }
    }

    // 조건
    // x축: -1.3~1.3 사이, y축: 6 에서 generate
    // 아이템이 겹치지 않도록 해야되나? -> 그럼 각 포인트를 찍어야 함
    // -1.3, 0, 1.3
    // 한번에 5개만 화면에 존재할 수 있도록?
    public void SpawnItems(int posNum)
    {
        ItemData randonItem = ItemList[Random.Range(0, ItemList.Count)];
        GameObject go = Instantiate(randonItem.itemPrefeb) as GameObject;
        go.transform.position = genPoint[posNum];


        //for (int i = 0; i < ItemDatas.Count; i++)
        //{
        //    var monster = SpawnMonsterFunc((ItemType)i);
        //    monster.WatchMonsterInfo();
        //}
    }

    //public ItemCtrl SpawnMonsterFunc(ItemType type)
    //{
    //    var newMonster = Instantiate(itemPrefabs).GetComponent<ItemCtrl>();
    //    newMonster.ItemData = ItemDatas[(int)(type)];
    //    return newMonster;
    //}



}
