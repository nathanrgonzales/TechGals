using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountTime : MonoBehaviour
{
    public int time = 0; //Seconds Overall
    
    public Text countdown; //UI Text Object
    public void Start()
    {
        StartCoroutine("Counting");
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }
    void Update()
    {
        countdown.text = ("" + time); //Showing the Score on the Canvas
    }

    public void Stop()
    {
        StopCoroutine("Counting");
    }

    public void Reset()
    {
        time = 0;
    }

    public int GetTime()
    {
        return time;
    }

    public void ResetTime()
    {    
        time = 0;
    }

    //Simple Coroutine
    IEnumerator Counting()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time++;
        }
    }
}