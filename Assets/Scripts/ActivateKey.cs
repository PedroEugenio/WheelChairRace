using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateKey : MonoBehaviour
{
    private GameObject[] shelfie;
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Key"){
            Destroy(collixsion.gameObject);
            shelfie = GameObject.FindGameObjectsWithTag("ShelfToMove");
            foreach (GameObject sh in shelfie){
                sh.transform.Translate(Vector3.up * 2.0f);
            }
        }
    }
}
