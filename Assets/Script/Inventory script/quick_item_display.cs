using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class quick_item_display : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private ItemDataCanChange item = null;
    private bool isSelected = false;
    private GameObject genItem = null;

    public void setItem(ItemDataCanChange x)
    {
        item = x;
    }

    // Update is called once per frame

    public void selected()
    {
        Debug.Log("used?");
        transform.GetChild(0).GetComponent<Image>().color = Color.white;
        isSelected = true;
      
        
    }
    public void unSelected()
    {
        transform.GetChild(0).GetComponent<Image>().color = Color.black;
        isSelected = false;
        if(genItem != null)
            Destroy(genItem);

    }
    void Update()
    {
        if (item != null)
        {
            transform.GetComponent<Image>().sprite = item.item.icon;
            transform.GetComponentInChildren<TMP_Text>().text = item.count.ToString();
            
        }
        else
        {
            transform.GetComponent<Image>().sprite = null;
            transform.GetComponentInChildren<TMP_Text>().text = "";

        }
    }
}
