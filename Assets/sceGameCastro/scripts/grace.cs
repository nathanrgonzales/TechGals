﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class grace : MonoBehaviour
{      
    private Vector3 inverteSprite = new Vector3(0,180,0);
    private readonly float velocidade = 3f;
    private bool posicaoDireita = true;   
    private Rigidbody2D rb;
    private float dirx;
    private Vector3 localscale;



    private void  Start()
    {
        rb = GetComponent<Rigidbody2D>();
        localscale = transform.localScale;        
    }

    private void Update()
    {
        dirx = CrossPlatformInputManager.GetAxis("Horizontal") * velocidade;
        

       this.MoverCima();


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirx, rb.velocity.y);
    }
    private void LateUpdate()
    {
        if (dirx>0 && !posicaoDireita)
        {
          
            posicaoDireita = true;
            transform.Rotate(inverteSprite);

        }
        else if (dirx < 0 && posicaoDireita)
        {
            
            posicaoDireita = false;
            transform.Rotate(inverteSprite);
        }
       
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
            rb.AddForce(Vector2.up * 700f);
        }

    }

}