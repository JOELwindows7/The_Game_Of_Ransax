using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FellOffScreenDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] TargetShootBehaviour TouchTarget;
    [SerializeField] GameObject MakeSureCompare;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("FellOffScreen");
        TouchTarget = collision.gameObject.GetComponent<TargetShootBehaviour>();
        MakeSureCompare = collision.gameObject;
        if(MakeSureCompare.gameObject == TouchTarget.gameObject)
        {
            Destroy(TouchTarget.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exitoid");
    }
}
