using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{
    string name;
    int id;
    int points;
    string type;

    public AudioSource dropSound;

    void Start (){
        dropSound = GetComponent<AudioSource> ();
    }

    public void OnCollisionEnter (Collision collision){

        if(collision.gameObject.tag == "Bottle"){
            dropSound.Play();
        }
    }

    public bool destroyItem()
    {
        Destroy(gameObject);
        return true;
    }
}
