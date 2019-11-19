using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldContains : MonoBehaviour
{
    [SerializeField] float ShredderIn = 0.1f;
    [SerializeField] float ShredderTimer = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Shredder)
        {
            if (ShredderTimer > 0f)
            {
                ShredderTimer -= Time.deltaTime;
            } else
            {
                leaveObjects();
            }
        }
    }
    TargetShootBehaviour[] Targets;

    [SerializeField] bool Shredder = false;
    public void resetObjects()
    {
        Shredder = true;
        ShredderTimer = ShredderIn;
        GetComponent<BoxCollider2D>().enabled = true;
    }
    public void leaveObjects()
    {
        Shredder = false;
        ShredderTimer = ShredderIn;
        GetComponent<BoxCollider2D>().enabled = false;
    }
    [SerializeField] TargetShootBehaviour aTarget;
    [SerializeField] GameObject objectTarget;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectTarget = collision.gameObject;
        aTarget = collision.gameObject.GetComponent<TargetShootBehaviour>();
        Destroy(aTarget.gameObject);
    }
}
