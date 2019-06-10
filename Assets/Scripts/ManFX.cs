using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManFX : MonoBehaviour
{
    AudioSource audio;
    public AudioClip[] sounds;
    public int sound2play;

    void Start (){
        audio = GetComponent<AudioSource> ();
    }
    public void OnCollisionEnter (Collision collision){
        if(collision.gameObject.tag == "Player"){
            audio.Play();
        }
    }
}
