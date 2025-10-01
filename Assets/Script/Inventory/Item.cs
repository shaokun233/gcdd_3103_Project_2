using UnityEngine;


public abstract class Item : ScriptableObject
{
    public Sprite icon;
    public GameObject item;
    public GameObject item_when_use;
    public string name;
    [Range(1, 10)]
    public int max = 1;
    public void printname()
    {
        Debug.Log(name);
    }
}
