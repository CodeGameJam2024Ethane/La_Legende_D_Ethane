using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class ScriptDeplacement : MonoBehaviour
{
    static float gravity = 3;
    private AnimationTrack animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float speed = 10;

        if (horizontal < 0) {
            
        }
        transform.Translate(new Vector3(horizontal, 0, 0) * speed * Time.deltaTime);
        
    }
}
