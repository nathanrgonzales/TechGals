using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class MovePato1 : MonoBehaviour {

	private float x = 2.5f;
	private SpriteRenderer spriteRenderer;
	Transform currentItem = null;
	public Transform carryLocation;
	private Collider2D playerInTrigger;
	public Button esquerdaBtn;
	public Button direitaBtn;

	public Animator animator;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		animator.SetBool("Andando", false);
		if (Input.GetKey(KeyCode.RightArrow) || direitaBtn.GetComponent<ButtonModafoca>().pressed){
			spriteRenderer.flipX = false;
			transform.Translate(new Vector3(x * Time.deltaTime, 0, 0));
			animator.SetBool("Andando", true);
		}
		if (Input.GetKey(KeyCode.LeftArrow) || esquerdaBtn.GetComponent<ButtonModafoca>().pressed ) {

			spriteRenderer.flipX = true;
			transform.Translate(new Vector3(-x * Time.deltaTime, 0, 0));
			animator.SetBool("Andando", true);
		}
			
	}

	void OnTriggerEnter2D (Collider2D coll) {
		playerInTrigger = coll;

	}


	void OnTriggerExit2D (Collider2D coll) {
		playerInTrigger = null;
	}

}
