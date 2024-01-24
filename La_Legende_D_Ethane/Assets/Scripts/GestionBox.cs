using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionBox : MonoBehaviour
{   public GameObject box; 
    bool tkt= true;
    // Start is called before the first frame update
    void Start()
    {
        
        box.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {   if (tkt==true){
        if (GameObject.Find("Player").GetComponent<Rigidbody2D>().IsTouching(GameObject.Find("Terrain").GetComponent<CompositeCollider2D>())){
            box.SetActive(true);
        }

        }
        
    }
    void HideBox(){

        box.SetActive(false);
        tkt=false;
        Debug.Log("WSH");
    }

}
