using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DraggableItem : MonoBehaviour,IBeginDragHandler,IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrage;
    public void OnBeginDrag(PointerEventData eventData)
    {
        image = transform.GetComponent<Image>();
        Debug.Log("start"); 
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
        Debug.Log("On drag");
        transform.position = Input.mousePosition;
     
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End");
        transform.SetParent(parentAfterDrage);
        image.raycastTarget = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
