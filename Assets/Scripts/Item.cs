using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{
    string name;
    int id;
    int points;
    string type;


    public bool destroyItem()
    {
        Destroy(gameObject);
        return true;
    }
}
