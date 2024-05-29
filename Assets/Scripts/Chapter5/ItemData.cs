using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemScriptable/CreateItemData", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    public enum ItemType
    {
        Negative,
        Positive
    }

    public string itemName;
    public ItemType itemType;
    public GameObject itemPrefeb;
    
    //[SerializeField]
    //private int itemType; // 1: p, 0: n
    //public int ItemType { get { return itemType; } set { itemType = value; } }

    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }
}

