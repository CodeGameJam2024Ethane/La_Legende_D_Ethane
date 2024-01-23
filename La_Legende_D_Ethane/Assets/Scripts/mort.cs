using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mort : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<BoxCollider2D>().IsTouching(GameObject.Find("Player").GetComponent<BoxCollider2D>()))
        {
            GameObject.Find("Player").transform.SetPositionAndRotation(new Vector3(-67.11f, 0.83f, 0.09f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            GameObject.Find("MusicPlaying").GetComponent<musicSwitch>().switchVillage();
        }
    }
}
