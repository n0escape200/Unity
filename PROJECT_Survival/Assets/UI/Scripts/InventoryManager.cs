using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    GameObject content;

    readonly float offset = 25f;

    void CreateGrid(Vector2 position)
    {
        GameObject grid = new GameObject("Grid", typeof(RectTransform));
        grid.AddComponent<InventoryGrid>();
        grid.GetComponent<RectTransform>().SetParent(content.transform);
        grid.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        grid.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
        grid.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
        grid.GetComponent<RectTransform>().localPosition = position + new Vector2(1,-1) * offset;

        content.GetComponent<RectTransform>().sizeDelta += new Vector2(0, 128);
    }


    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            CreateGrid(new Vector2(0, -i * 128));
        }
        
    }

    void Update()
    {
        
    }
}
