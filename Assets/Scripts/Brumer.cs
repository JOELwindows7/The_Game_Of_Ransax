using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brumer : MonoBehaviour
{

    public float speeds = 10f;
    public float steers = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") < -.1f || Input.GetAxis("Vertical") > .1f)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speeds * Mathf.Clamp(Input.GetAxis("Vertical"), -1f, 1f), Space.Self);
        }
        if(Input.GetAxis("Horizontal") < -.1f || Input.GetAxis("Horizontal") > .1f)
        {
            transform.Rotate(-Vector3.forward * steers * Mathf.Clamp(Input.GetAxis("Horizontal"),-1f,1f));

        }
    }
}
