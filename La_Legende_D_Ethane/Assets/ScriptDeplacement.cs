using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDeplacement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float speed = 20;

        transform.Translate(new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime);
    }
}
