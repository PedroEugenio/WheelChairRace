using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    public AudioSource dropSound;
    void Start()
    {
        dropSound = GetComponent<AudioSource>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player"){
            dropSound.Play();
        }
    }
}
