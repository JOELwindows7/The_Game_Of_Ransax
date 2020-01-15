using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AndroidToast
{
    //https://github.com/zakirshikhli/toaster/commit/b18af0d58f605faedaf92de47ad8cb9123d0a5a4?diff=split#commitcomment-31510727
    private static string _toastString;
    private static AndroidJavaClass _unityPlayer;
    private static AndroidJavaClass UnityPlayer
    {
        get
	{
	    if(_unityPlayer == null)
	    {
		_unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
	    }
	    return _unityPlayer;
	    }
	}


    public static void ShowToast(string toastString)
    {
        if(Application.platform == RuntimePlatform.Android && (Application.platform != RuntimePlatform.WindowsEditor && Application.platform != RuntimePlatform.LinuxEditor)){
            _toastString = toastString;
        var currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(ShowToast));
        } else {
            
        }
    }

    private static void ShowToast()
    {
	var currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
	var context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
        AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
        AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", _toastString);
        AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
        toast.Call("show");
    }
}
