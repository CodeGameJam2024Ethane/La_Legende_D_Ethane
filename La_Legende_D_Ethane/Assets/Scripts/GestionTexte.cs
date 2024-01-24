using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionTexte : MonoBehaviour
{
    public GameObject[] textes;
    public int nextObject = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        textes[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (nextObject < textes.Length)
            {
                textes[nextObject-1].SetActive(false);
                textes[nextObject].SetActive(true);
            }
            nextObject++;
        }

        if (nextObject > textes.Length)
        {
            this.SendMessageUpwards("HideBox");
        }
    }
}