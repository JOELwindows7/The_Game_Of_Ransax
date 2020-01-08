using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    //https://www.youtube.com/watch?v=j98jrUPHVYw&t=202s
    public enum BuyTypes{
        Donate,
        MachineGun,
        GrenadeLauncher,
        AdDestroy
    }

    private string defaultText = "";

    public Text priceText;

    public BuyTypes BuyProductsOf;

    // Start is called before the first frame update
    void Start()
    {
        if(priceText){
            defaultText = priceText.text;
        }
        StartCoroutine(LoadPriceRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyNow(){
        switch(BuyProductsOf){
            default:
            break;

            case BuyTypes.Donate:
                InAppPurchaser.Instance.DonateToMe();
            break;

            case BuyTypes.MachineGun:
            break;

            case BuyTypes.GrenadeLauncher:
            break;

            case BuyTypes.AdDestroy:
            break;
        }
    }

    public void DonateMeButton(){

    }

    private IEnumerator LoadPriceRoutine(){
        while(!InAppPurchaser.Instance.IsInitialized()){
            yield return null;
        }
        string loadedPrice = "";

        switch(BuyProductsOf){
            default:
            break;

            case BuyTypes.Donate:
                loadedPrice = InAppPurchaser.Instance.GetProductPriceFromStore(InAppPurchaser.Instance.DONATE_BUTTON);
            break;

            case BuyTypes.MachineGun:
            break;

            case BuyTypes.GrenadeLauncher:
            break;

            case BuyTypes.AdDestroy:
            break;
        }

        if(priceText){
            priceText.text = loadedPrice;
        }
    }

    
}
