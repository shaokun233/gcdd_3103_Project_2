using TMPro;
using UnityEngine;


public abstract class Item : ScriptableObject
{
    public Sprite icon;
    public GameObject item;
    public int itemID;
    public string itemName;
    [Range(1, 10)]
    public int max = 1;

    public virtual void Use(Transform tf)
    {

    }
  
    
    
}
