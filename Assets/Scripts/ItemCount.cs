using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCount : MonoBehaviour
{
    public Text itemsText;
    public Text timerText;

    private float startTime = 300f;
    private float currentTime = 0f;
    private string lost = "YOU LOST!";
    
    private int hotdog_counter = 0, stereo_counter = 0, jar_counter = 0, popcorn_counter = 0, fruit_counter = 0;

    private AudioSource paySound;

    public void OnCollisionEnter (Collision collision){
        if (collision.gameObject.tag == "HotDog"){
            Destroy(collision.gameObject);
            if(hotdog_counter < 3)
                hotdog_counter++;
            paySound.Play();
        }
        else if (collision.gameObject.tag == "Stereo"){
            Destroy(collision.gameObject);
            if(stereo_counter < 1)
                stereo_counter++;
            paySound.Play();
            
        }
        else if (collision.gameObject.tag == "Jar"){
            Destroy(collision.gameObject);
            if(jar_counter < 1)
                jar_counter++;
            paySound.Play();
        }
        else if (collision.gameObject.tag == "Popcorn"){
            Destroy(collision.gameObject);
            if(popcorn_counter < 2)
                popcorn_counter++;
            paySound.Play();
        }
        else if (collision.gameObject.tag == "Fruit"){
            Destroy(collision.gameObject);
            if(fruit_counter < 3)
                fruit_counter++;
            paySound.Play();
        }
    }

    void Start (){
        currentTime = startTime;
        paySound = GetComponent<AudioSource>();
    }

    void Update(){
        if(timerText.text != "lost" && hotdog_counter == 3 && stereo_counter == 1 && jar_counter == 1 && popcorn_counter == 2 && fruit_counter == 3){
            timerText.text = "YOU WON!!!";
            timerText.color = Color.green;
            timerText.fontSize = 25;
        }

        else{
            itemsText.text = "Hot Dogs: "+hotdog_counter+"/3 \n Stereo: "+stereo_counter+"/1 \n Mayo Jar: "+jar_counter+"/1 \n Popcorn: "+popcorn_counter+"/2 Fruit: "+fruit_counter+"/3";

            currentTime -= 1 * Time.deltaTime;
            timerText.text = currentTime.ToString("0");

            if(currentTime <= 0 && currentTime >= (-3)){ 
                timerText.text = lost;
                timerText.color = Color.red;
                timerText.fontSize = 25;
                
            }/* else if(currentTime < (-2)){
                SceneManager.LoadScene(2);
            }  */
        }
    }
}
