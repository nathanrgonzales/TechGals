using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    // Update is called once per frame
    private static int velocidade = 5; 
    private float posX, posY = 0f; 
    private float angle = 0.1f;
    private Vector3 nextPosTop,nextPosBot,nextPosLeft,nextPosRight, initialPos;
    private bool changeDestinationUD, changeDestinationLR = false;
    private void Start()
   
    {
        initialPos = gameObject.transform.localPosition;
        nextPosTop = new Vector3(initialPos.x, initialPos.y + 2);
        nextPosBot = new Vector3(initialPos.x, initialPos.y - 2);
        nextPosLeft = new Vector3(initialPos.x-2,initialPos.y);
        nextPosRight = new Vector3(initialPos.x+2,initialPos.y);
    }
    void Update () {
        this.Movimento();
	}


    private void Movimento()
    {
       if (gameObject.tag == "Bug")
        {
            posX = gameObject.transform.position.x + Mathf.Cos(angle) * Time.deltaTime *3; 
            posY = gameObject.transform.position.y + Mathf.Sin(angle) * Time.deltaTime *3;
            transform.position = new Vector2(posX, posY);
            angle = angle + Time.deltaTime*5 ;
            if (angle >=360f)
            {
                angle = 0f;
            }
                
        }


        if (gameObject.tag == "Bug1")
        {
            if (!changeDestinationUD)
            {
                gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, nextPosTop, 1.5f * Time.deltaTime);
            }            
            
            if (gameObject.transform.localPosition == nextPosTop)
            {
                changeDestinationUD = true;
            }
            if (changeDestinationUD)
            {
                gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, nextPosBot, 1.5f * Time.deltaTime);
            }
            if (gameObject.transform.localPosition == nextPosBot)
            {
                changeDestinationUD = false;
            }

        }

        if (gameObject.tag == "Bug2")
        {
            if (!changeDestinationLR)
            {
                gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, nextPosLeft, 1.5f * Time.deltaTime);
            }

            if (gameObject.transform.localPosition == nextPosLeft)
            {
                changeDestinationLR = true;
            }
            if (changeDestinationLR)
            {
                gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, nextPosRight, 1.5f * Time.deltaTime);
            }
            if (gameObject.transform.localPosition == nextPosRight)
            {
                changeDestinationLR = false;
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grace")
        {
            
            gameObject.transform.parent.gameObject.SetActive(false);
        }



    }

}


    