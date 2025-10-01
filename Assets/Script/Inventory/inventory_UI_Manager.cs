using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class inventory_UI_Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject inventory_ui;
    private Inventory inventory = new Inventory();

    void OnOpenInventory()
    {
        bool isOpen = inventory_ui.activeSelf;
        inventory_ui.SetActive(!isOpen);
        Time.timeScale = isOpen ? 1.0f : 0.0f;
    }

    //x can only be 0 to 11
    Transform FindSlot(int x)
    {
        return inventory_ui.transform.GetChild(0).GetChild(x);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.transform.tag == "Item")
        {
            inventory.addItem(collision.transform.GetComponent<ItemObject>().item);
           Destroy(collision.transform.gameObject);
            Debug.Log("get");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int a = inventory.size();
        Debug.Log(a);
        if(a > 0 )
        inventory.GetItem(0);
    }
}
