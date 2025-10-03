using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<ItemDataCanChange> Itemlist = new List<ItemDataCanChange>();

    public Inventory() {
        for (int i = 0; i < 12; i++)
        {
            Itemlist.Add(null);
        }
    }

    public bool addItem(Item item)
    {
        
        if (have_this(item.itemID))
            return true;

        for (int i = 0; i < Itemlist.Count; i++)
        {
            if (Itemlist[i] == null)
            {
                Itemlist[i] = new ItemDataCanChange(item);
                return true;
            }
        }
        return false;
    }

    public void setItem(ItemDataCanChange temp,int index)
    {
        if(temp != null){
            Debug.Log(temp.item.name );
            Debug.Log(index);
        }
        else
        {
            Debug.Log(index);
        }
        Itemlist[index] = temp;
    }

    //check if have same item, and add to it. if not return false
    public bool have_this(int id)
    {
        for (int i = 0; i < Itemlist.Count; i++)
        {
            if (Itemlist[i] != null)
            {
                ItemDataCanChange temp = Itemlist[i];
                if (temp.item.itemID == id && temp.add())
                {
                    return true;
                }
            }
        }
        return false;

    }

    public void toString()
    {
        foreach(ItemDataCanChange x in Itemlist)
        {
            if(x != null)
            Debug.Log(x.item.name);
        }
    }


    
    public ItemDataCanChange GetItem(int x)
    {
         return Itemlist[x];

    }
    
    public void Remove(int x)
    {
        Itemlist[x] = null;
    }


    public bool isfull()
    {
        for(int i = 0; i < Itemlist.Count; i++)
        {
            if(Itemlist[i] == null)
                return true;
        }
        return false;
    }
    public int size()
    {
        return (int)Itemlist.Count;
    }
}
