using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryGrid : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    int rows = 4;

    [SerializeField]
    int columns = 4;

    public float tileSize = 32;

    void Start()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Image gridSlot = Instantiate(Resources.Load<Image>("GridSlot"),this.transform);
                gridSlot.rectTransform.anchorMin = new Vector2 (0, 1);
                gridSlot.rectTransform.anchorMax = new Vector2(0, 1);
                gridSlot.rectTransform.pivot = new Vector2(0, 1);
                gridSlot.rectTransform.sizeDelta = new Vector2(tileSize, tileSize);
                gridSlot.rectTransform.anchoredPosition = new Vector2(j * tileSize, -i * tileSize);
            }
        }
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(tileSize * rows, tileSize * columns);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerEnter);
    }
}
