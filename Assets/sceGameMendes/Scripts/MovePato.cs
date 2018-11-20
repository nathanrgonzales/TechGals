using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class MovePato : MonoBehaviour {

	private float x = 2.5f;
	private SpriteRenderer spriteRenderer;
	Transform currentItem = null;
	public Transform carryLocation;
	public GameObject lugarDoFlux;
	private Collider2D playerInTrigger;
	public Button esquerdaBtn;
	public Button direitaBtn;
	public Button pegaBtn;
	public Button largaBtn;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.RightArrow) || direitaBtn.GetComponent<ButtonModafoca>().pressed){
			spriteRenderer.flipX = true;
			transform.Translate(new Vector3(x * Time.deltaTime, 0, 0));
		}
		if (Input.GetKey(KeyCode.LeftArrow) || esquerdaBtn.GetComponent<ButtonModafoca>().pressed ) {

			spriteRenderer.flipX = false;
			transform.Translate(new Vector3(-x * Time.deltaTime, 0, 0));
		}


		if (playerInTrigger != null) {
			Rigidbody2D rigiDuchaPeu = playerInTrigger.GetComponent<Rigidbody2D> ();
			if (Input.GetKey (KeyCode.A)|| pegaBtn.GetComponent<ButtonModafoca>().pressed) {

				// pickup if it has tag "Item" and we are not carrying anything
				if (playerInTrigger.CompareTag ("bloco")) {
					// take reference to that collided object


					rigiDuchaPeu.simulated = false;

					playerInTrigger.transform.parent = lugarDoFlux.transform;

					playerInTrigger.transform.localPosition = new Vector3 (0, 0, 0);

					currentItem = playerInTrigger.transform;

				}
			}
		}


		// press X to drop item, if carrying something
		if (currentItem!=null)
		{
			if (Input.GetKeyDown(KeyCode.X)|| largaBtn.GetComponent<ButtonModafoca>().pressed)
			{
				// remove as child
				currentItem.parent = null;

				//set position near player
				//currentItem.position = transform.GetComponent<SpriteRenderer>().bounds.max;

				// release reference
				Rigidbody2D rigiDuchaPeu = currentItem.GetComponent<Rigidbody2D> ();
				rigiDuchaPeu.simulated = true;
				currentItem = null;
			}
		}
		
	}
		

	void OnTriggerEnter2D (Collider2D coll) {
		playerInTrigger = coll;

	}


	void OnTriggerExit2D (Collider2D coll) {
		playerInTrigger = null;
	}

}
