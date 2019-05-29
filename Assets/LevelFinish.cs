using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    public AudioSource victory;

    //public int index;
    //public string levelName;

    void Start (){
        victory = GetComponent<AudioSource> ();
    }

    public void OnCollisionEnter (Collision collision){
        if(collision.gameObject.tag == "Player"){
            //SceneManager.LoadScene(index);
            //SceneManager.LoadScene(levelName);
            //Application.LoadLevel(1);
            victory.Play();
            print("HI!");
            //Application.Quit();
        }
    
    }
}
