using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Manager_HUD : MonoBehaviour
{
  
    void Start()
    {
        
    }

    void Update()
    {
        GameObject playerObject = this.transform.parent.gameObject;
        bool state = playerObject.GetComponentInParent<PlayerControl>().isInInventory;
        this.transform.GetChild(0).gameObject.SetActive(state);
    }
}
