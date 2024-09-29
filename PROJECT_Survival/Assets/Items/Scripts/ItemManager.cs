using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    [SerializeField]
    Item item;

    public string itemName;
    public string description;
    public float weight;

    public Item GetScriptObj()
    {
        return item;
    }

    void Start()
    {
        itemName = item.itemName;
        description = item.description;
        weight = item.weight;

    }

    void Update()
    {
        
    }
}
