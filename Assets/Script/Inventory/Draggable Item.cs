using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    //do not use start method for isitem and me.
    //because in invetory UI M, we gen UI the ative this.
    //is use start it will overrider  isitem and me.
    public bool isitem = false;
    public Image image;
    public ItemDataCanChange me = null;
    [HideInInspector] public Transform parentAfterDrage;

    
    void OnEnable()
    {
        if (me != null)
        {
            Debug.Log(me.item.name);
        }
        if (!isitem)
        {
            image.raycastTarget = false;
        }
        else
        {
            image.raycastTarget = true;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //ÉùÃ÷¸¸¼¶
        parentAfterDrage = transform.parent;
        //set canva as parent
        transform.SetParent(transform.root);
        //move to last so it can display on top of ever ui
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrage);
        image.raycastTarget = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
 

    // Update is called once per frame
    void Update()
    {
        if(me  != null)
        {
            image.sprite = me.item.icon;
            transform.GetChild(0).GetComponent<TMP_Text>().text = me.count.ToString();

        }
    }
}
