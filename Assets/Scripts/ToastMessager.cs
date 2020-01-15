using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class ToastMessager : Singleton<ToastMessager>
{
    /*Toastejing
    https://forum.unity.com/threads/toast-message-on-android.106953/
    https://deltabit.wordpress.com/2016/03/04/show-toast-on-unity/#more-228
    https://github.com/zakirshikhli/toaster/commit/b18af0d58f605faedaf92de47ad8cb9123d0a5a4
    */

    string toastString;
    string input;
    AndroidJavaObject currentActivity;
    AndroidJavaClass UnityPlayer;
    AndroidJavaObject context;

    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
        }
    }


    public void showToastOnUiThread(string toastString)
    {
        this.toastString = toastString;
        currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(showToast));
    }

    void showToast()
    {
        Debug.Log(this + ": Running on UI thread");

        AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
        AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", toastString);
        AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
        toast.Call("show");
    }
}
