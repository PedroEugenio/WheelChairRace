using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleFX : MonoBehaviour
{

   private AudioSource dropSound;

    void Start (){
        dropSound = GetComponent<AudioSource> ();
    }

     public void OnCollisionEnter (Collision collision){

        if(collision.gameObject.tag == "Ground"){
            dropSound.Play();
        }
    }

}
