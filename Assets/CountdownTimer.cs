using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    
    public Text timerText;
    RectTransform m_RectTransform;

    float startTime = 120f;
    float currentTime = 0f;
    string lost = "You Lost!";
    
    void Start (){
        currentTime = startTime;
        //m_RectTransform = GetComponent<RectTransform>();
    }
    
    void Update()
    {
         currentTime -= 1 * Time.deltaTime;
         timerText.text = currentTime.ToString("0");

         if(currentTime <=0 ){
            timerText.text = lost;
            timerText.color = Color.red;
            timerText.fontSize = 25;
            //m_RectTransform.sizeDelta = new Vector2(m_Text.fontSize * 10, 100);
            //Application.Quit();
         }
         
    }
}
