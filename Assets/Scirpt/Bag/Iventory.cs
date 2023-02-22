using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Iventory : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isUse;//是否被使用了
    public int index = 1;
    public int count = 0;

    public void OnPointerDown(PointerEventData eventData)
    {

//        Inventory_message.PointObj(this.gameObject);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //-------------拖拽逻辑------//
        //GameObject go = eventData.pointerCurrentRaycast.gameObject;

        //if (InventoryManager.Instance.IsDrag == true)
        //    if (go.tag == "lattice" && go.transform.childCount == 0)
        //    {
        //        SetAnchorpoint(go);
        //        InventoryManager.Instance.IsDrag = false;
        //        InventoryManager.Instance.Target = null;
        //    }
        //    else
        //    {
        //        SetAnchorpoint(InventoryManager.Instance.oldParent.gameObject);
        //        InventoryManager.Instance.oldParent = null;
        //        InventoryManager.Instance.IsDrag = false;
        //        InventoryManager.Instance.Target = null;
        //    }
        //GetComponent<RawImage>().raycastTarget = true;
        //InventoryManager.Instance.oldParent = null;


    }

    void SetAnchorpoint(GameObject go)
    {
        this.gameObject.transform.SetParent(go.transform);
        gameObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    public void Use()
    {
        count--;
        if (count == 0)
        {
            this.gameObject.SetActive(false);
        }
    }
    public void Add()
    {
        count++;
    }

}


