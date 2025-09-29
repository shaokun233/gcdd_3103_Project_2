using UnityEngine;


public abstract class Item : ScriptableObject
{
    public Sprite icon;
    public GameObject item;
    public string name;
    [Range(1, 10)]
    public int max = 1;
}
