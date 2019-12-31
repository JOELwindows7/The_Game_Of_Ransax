using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestorePurchaseButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer || 
            Application.platform != RuntimePlatform.OSXPlayer)
        {
            //This is not iOS or macOS platform
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickRestore(){
        InAppPurchaser.Instance.RestorePurchases();
    }
}
