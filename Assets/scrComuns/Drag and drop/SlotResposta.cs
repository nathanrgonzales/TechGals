using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SlotResposta : MonoBehaviour, IDropHandler {
	
	public GameObject Objetivo;
	public bool EstaCerto; 

	void Start () {
		EstaCerto = false;
	}
	public GameObject item {
		get {
			if(transform.childCount>0){
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}
	
	void Update()
	{		
		if(transform.childCount>0)
		{
			var Teste = transform.GetChild (0).gameObject;
			if (Teste.gameObject.name == Objetivo.gameObject.name)
			{
				EstaCerto = true;
			}
		}
		else
		{
			EstaCerto = false;
		}					
	}

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		if(!item){
			DragHandeler.itemBeingDragged.transform.SetParent (transform);
			ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject,null,(x,y) => x.HasChanged ());
		}
	}
	#endregion
}
