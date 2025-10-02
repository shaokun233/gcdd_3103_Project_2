using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using static UnityEditor.Progress;



public class inventory_UI_Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject inventory_ui;
    private Inventory inventory = new Inventory();


    void OnOpenInventory()
    {
        bool isOpen = inventory_ui.activeSelf;
        Time.timeScale = isOpen ? 1.0f : 0.0f;
        if( isOpen)
        {
            setinvetory();

        }
        else
        {
            gen_inv_UI();

        }

        inventory.toString();
        inventory_ui.SetActive(!isOpen);
       

    }

    void gen_inv_UI()
    {
        for(int i = 0; i < inventory.size(); i++)
        {
            //add new icon
            if (inventory.GetItem(i)!= null)
            {
                genUI(FindItem(i), inventory.GetItem(i));
                Debug.Log("did");
            }
            else
            {
                genUI(FindItem(i));
            }
        }
    }
    
    public void genUI(Transform x)
    {
        Transform temp = x;
        temp.GetComponent<DraggableItem>().isitem = false;
    }
    public void genUI(Transform x, ItemDataCanChange y)
    {
        Transform temp = x;
       temp.GetComponent<DraggableItem>().me = y;
        temp.GetComponent<DraggableItem>().isitem = true;

    }
    //x can only be 0 to 11
    void setinvetory()
    {
        for (int i = 0; i < 12; i++)
        {
            if(FindItem(i).GetComponent<DraggableItem>().me == null)
            {
                Debug.Log(i + "is null");
            }
            inventory.setItem(FindItem(i).GetComponent<DraggableItem>().me, i);
        }
    }
    Transform FindItem(int x)
    {
       
        return inventory_ui.transform.GetChild(0).GetChild(x).GetChild(0);
        
    }
    InventorySlot FindSlot(int x)
    {
        return inventory_ui.transform.GetChild(0).GetChild(x).GetComponent<InventorySlot>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.transform.tag == "Item")
        {
            bool k = inventory.addItem(collision.transform.GetComponent<ItemObject>().item);
            if (k)
            {
                Destroy(collision.transform.gameObject);
            }
        }
    }
  

    // Update is called once per frame
    
}
