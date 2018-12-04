using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrTouchController : MonoBehaviour {

public bool IsTouching;
public bool IsDragged;

	private Vector3 screenPoint;
	private Vector3 offset;

	void Update()
	{
		//transform.position =  new Vector3(Mathf.Clamp(transform.position.x, -5.0f, 5.0f),0,0);		
	}
	void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));		
	}

	void OnMouseDrag()
	{
		var InputX = Input.mousePosition.x;
		var InputY = Input.mousePosition.y;
		
		Vector3 curScreenPoint = new Vector3(InputX, InputY, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint); 

		transform.position = curPosition;
		IsDragged = true;
	}

	void OnMouseUp()
	{
		IsDragged = false;		
		//var Colidindo = this.gameObject.GetComponent<Collider2D>();
		//var OtherColidindo = this.gameObject.GetComponent<Collider2D>();
	}
	
	/*void OnCollisionEnter2D(BoxCollider2D other)
	{	var Colidindo = this.gameObject.GetComponent<BoxCollider2D>();
		if (other.IsTouching(Colidindo))
		{
			IsTouching = true;
		}
		else
		{
			IsTouching = false;
		} 
	}*/
//}


}
