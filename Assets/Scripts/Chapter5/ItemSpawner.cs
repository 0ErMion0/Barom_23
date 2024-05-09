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

    public Vector3[] genPoint; // ���� ����Ʈ
    float span = 1.0f; // ������ ȣ�� ����
    float delta = 0; // ���� �ð�

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
        //// ���� ����Ʈ
        //for(int i = 0; i < 3; i++)
        //{
        //    // 0,1,2
        //    // (i-1) -> -1, 0, 1 => -1.3, 0, 1.3
        //    genPoint[i] = new Vector3(1.3f*(i-1), 6f, 0);
        //}
    }

    private void Update()
    {
        int posNum = Random.Range(0, 3); // ���� ��ġ ���� 0, 1, 2 �߿���

        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            SpawnItems(posNum);
        }
    }

    // ����
    // x��: -1.3~1.3 ����, y��: 6 ���� generate
    // �������� ��ġ�� �ʵ��� �ؾߵǳ�? -> �׷� �� ����Ʈ�� ���� ��
    // -1.3, 0, 1.3
    // �ѹ��� 5���� ȭ�鿡 ������ �� �ֵ���?
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
