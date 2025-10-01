using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> item = new List<Item>();
    public Inventory() { }

    public void addItem(Weapon weapon)
    {
        if(!isfull())
            item.Add(weapon);
    }
    
    public void GetItem(int x)
    {
          item[x].printname();

    }
    public bool isfull()
    {
        return item.Count >= 12;
    }
    public int size()
    {
        return (int)item.Count;
    }
}
