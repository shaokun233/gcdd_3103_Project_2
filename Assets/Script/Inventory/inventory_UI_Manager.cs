using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class inventory_UI_Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject inventory_ui;
    [SerializeField] private GameObject quick_item;
    private Inventory inventory = new Inventory();
    private int selectItem = 0;
    [SerializeField] private GameObject full;

    private bool isFull = false;


    void OnOpenInventory()
    {
        bool isOpen = inventory_ui.activeSelf;
        Time.timeScale = isOpen ? 1.0f : 0.0f;
        if( isOpen)
        {
            setinvetory();
            setQuickItemBar();
        }
        else
        {
            gen_inv_UI();

        }

        inventory.toString();
        inventory_ui.SetActive(!isOpen);
    }

    // For select quick item
    void OnItem1()
    {
        selectItem = 0;
        chooseQuickItem(0, selectItem);
    }
    void OnItem2()
    {
        selectItem = 1;
        chooseQuickItem(0, selectItem);
    }
    void OnItem3()
    {
        selectItem = 2;
        chooseQuickItem(0, selectItem);
    }
    void OnItem4()
    {
        selectItem = 3;
         chooseQuickItem(0, selectItem);
    }

    //to use seleced item
    public void UseItem()
    {
        if(inventory.GetItem(selectItem) != null)
        {
            ItemDataCanChange temp = inventory.GetItem(selectItem);

            temp.item.Use(this.transform);

            temp.count -= 1;
            if (temp.count == 0)
            {
                inventory.Remove(selectItem);
                isFull = false;
                setQuickItemBar();
            }
        }
        
        
    }

    private void Update()
    {
        full.SetActive(isFull);
    }

    // For select quick item

    void chooseQuickItem(int x,int index)
    {
        if(x > 3)
            return;
        if(x == index)
        {
            FindQuickItem(x).GetComponent<quick_item_display>().selected();

        }
        else
        {
            FindQuickItem(x).GetComponent<quick_item_display>().unSelected();
        }
        chooseQuickItem(x+1,index);

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
                if (i > 5)
                {
                    genUI(FindItem(i), false);

                }
              
            }
            
        }
    }
    public void genUI(Transform x,bool isoff)
    {
        Transform temp = x;
        temp.parent.gameObject.SetActive(isoff);

    }
    public void genUI(Transform x)
    {
        Transform temp = x;
        temp.GetComponent<DraggableItem>().me = null;
        temp.GetComponent<DraggableItem>().isitem = false;
        temp.parent.gameObject.SetActive(true);
    }
    public void genUI(Transform x, ItemDataCanChange y)
    {
        Transform temp = x;
        temp.GetComponent<DraggableItem>().me = y;
        temp.GetComponent<DraggableItem>().isitem = true;
        temp.parent.gameObject.SetActive(true);
    }


    //After player move item in inventory, change the place of inventory
    void setinvetory()
    {
        for (int i = 0; i < 12; i++)
        {
           
            inventory.setItem(FindItem(i).GetComponent<DraggableItem>().me, i);
        }
    }

    //to set quick item bar

    void setQuickItemBar()
    {
        for( int i = 0;i < 4; i++)
        {
            FindQuickItem(i).GetComponent<quick_item_display>().setItem(inventory.GetItem(i));
        }
    }

    Transform FindItem(int x)
    {
       
        return inventory_ui.transform.GetChild(0).GetChild(x).GetChild(0);
    }
    Transform FindQuickItem(int x)
    {
        return quick_item.transform.GetChild(x).GetChild(0);
    }
    


    //to store the item
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.transform.tag == "Item")
        {
            bool k = inventory.addItem(collision.transform.GetComponent<ItemObject>().item);
            if (k)
            {
                Destroy(collision.transform.gameObject);
                setQuickItemBar();
            }
            else
            {
                isFull = true;
            }
            
           
        }
    }
  

    // Update is called once per frame
    
}
