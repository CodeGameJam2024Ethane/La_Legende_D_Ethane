using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mortNiveauFinal : MonoBehaviour
{
    void Update()
    {
        if (GetComponent<Collider2D>().IsTouching(GameObject.Find("Player").GetComponent<Collider2D>()))
        {
            GameObject.Find("Player").transform.SetPositionAndRotation(new Vector3(-11.65f, 2.41f, 0.09f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        }
    }
}
