using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Item", menuName = " Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public float weight;
    public string description;

}
