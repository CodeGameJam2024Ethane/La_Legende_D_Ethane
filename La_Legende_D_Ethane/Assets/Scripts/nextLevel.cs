using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Collider2D>().IsTouching(GameObject.Find("Player").GetComponent<Collider2D>()))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
