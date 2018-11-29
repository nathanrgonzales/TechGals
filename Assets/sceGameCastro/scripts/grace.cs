using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class grace : MonoBehaviour
{      
    private Vector3 inverteSprite = new Vector3(0,180,0);
    private readonly float velocidade = 3f;
    private bool posicaoDireita = true;   
    private Rigidbody2D rb;
    private float dirx;
    private Vector3 localscale;
    public float fatorPulo;

    public Button esquerdaBtn;
	public Button direitaBtn;
	public Animator animator;
    private SpriteRenderer spriteRenderer;


    private void  Start()
    {
        rb = GetComponent<Rigidbody2D>();
        localscale = transform.localScale;     
		spriteRenderer = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();           
    }

    private void Update()
    {
        dirx = CrossPlatformInputManager.GetAxis("Horizontal") * velocidade;
        this.MoverCima();
        
        
        animator.SetBool("andando", false);            
        
        if (dirx>0)
        {          
            spriteRenderer.flipX = false;			
			animator.SetBool("andando", true);            
        }
        
        if (dirx<0)
        {   
			spriteRenderer.flipX = true;			
			animator.SetBool("andando", true);                        
        }        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirx, rb.velocity.y);
    }
    private void LateUpdate()
    {

       
    }
    private void Movimento()
    {

        if (Input.GetKey(KeyCode.UpArrow) || CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            this.MoverCima();
        } 
        
    }
    
    private void MoverCima()
    {
        
        if (CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * fatorPulo);
        }

    }

}