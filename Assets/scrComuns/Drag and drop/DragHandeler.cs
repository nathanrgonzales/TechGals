using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler {
	public static GameObject itemBeingDragged;
	public Vector3 startPosition;
	public Transform startParent;

	public void OnBeginDrag (PointerEventData eventData)	
	{
		//startPosition = transform.position;	
		startParent = transform.parent;
		itemBeingDragged = this.gameObject;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
		startPosition = transform.position;	
        //Debug.Log("Cursor Entering " + name + " GameObject");
    }	

	public void OnDrag (PointerEventData eventData)
	{
		//transform.position = eventData.position;
	}

	public void OnEndDrag (PointerEventData eventData)	
	{
		itemBeingDragged = null;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		if(transform.parent == startParent){
			transform.position = startPosition;			
			transform.SetParent (startParent);
		}
	}

}
