using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicSwitch : MonoBehaviour
{

    public AudioSource musicVillage;
    public AudioSource musicNiveau1;
    // Start is called before the first frame update
    void Start()
    {
        musicVillage.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentsInChildren<BoxCollider2D>()[1].IsTouching(GameObject.Find("Player").GetComponent<BoxCollider2D>()) && !musicNiveau1.isPlaying)
        {
            switchNiveau1();
        } else if (GetComponentsInChildren<BoxCollider2D>()[0].IsTouching(GameObject.Find("Player").GetComponent<BoxCollider2D>()) && !musicVillage.isPlaying)
        {
            switchVillage();
        }
    }

    public void switchNiveau1() 
    {
        musicVillage.Stop();
        musicNiveau1.Play();
    }

    public void switchVillage()
    {
        musicNiveau1.Stop();
        musicVillage.Play();
    }
}
