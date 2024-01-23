using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioSauts : MonoBehaviour
{
    public AudioSource saut1;
    public AudioSource saut2;
    public AudioSource dash;
    // Start is called before the first frame update
    public void playSound1()
    {
        saut1.Play();
    }

    // Update is called once per frame
    public void playSound2()
    {
        saut2.Play();
    }

    public void playSound3()
    {
        dash.Play();
    }
}
