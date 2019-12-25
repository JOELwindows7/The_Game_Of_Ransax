using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BekgronQuadScroller : MonoBehaviour
{

    [SerializeField] Material materialingBekgron;
    [SerializeField] Vector2 offseting;

    public float xVelocity, yVelocity;

    public float ScrollSpeed = .5f;

    public void SwitchOn(){
        offseting = new Vector2(ScrollSpeed,0f);
    }
    public void SwitchOff(){
        offseting = new Vector2(0f,0f);
    }

    void Awake(){
        materialingBekgron = GetComponent<Renderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        //offseting = new Vector2(xVelocity,yVelocity);
        SwitchOff();
    }

    // Update is called once per frame
    void Update()
    {
        materialingBekgron.mainTextureOffset += offseting * Time.deltaTime;
    }
}
