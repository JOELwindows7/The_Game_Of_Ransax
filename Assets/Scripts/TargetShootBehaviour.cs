using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShootBehaviour : MonoBehaviour
{
    public float MoveLeftSpeed = 10f;
    public float MoveUpSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.left * MoveLeftSpeed * Time.deltaTime);
        transform.Translate(new Vector3(-MoveLeftSpeed * Time.deltaTime, MoveUpSpeed * Time.deltaTime));
    }

    void TargetHit()
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Debug.Log("Bang!");
        TargetHit();
    }
}
