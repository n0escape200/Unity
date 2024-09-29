using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    [SerializeField]
    List<Item> items;


    public void AddItem(Item item)
    {
        items.Add(item);
    }

    void Start()
    {
        items = new List<Item>();  
    }

    
    void Update()
    {
        
    }
}
