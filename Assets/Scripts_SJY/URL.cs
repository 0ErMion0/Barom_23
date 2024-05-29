using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class URL : MonoBehaviour
{
    private const string subject = "��ſ� ������ �ڵ��� ����Ŀ ������ �ĸ��� ����! ���� ������ ������";
    private const string body = "https://play.google.com/store/apps/details?id=com.CEREALLAB.FruitsLoop&showAllReviews=true";

    public void Share()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
		using (AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent")) 
		using (AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent")) {
			intentObject.Call<AndroidJavaObject>("setAction", intentObject.GetStatic<string>("ACTION_SEND"));
			intentObject.Call<AndroidJavaObject>("setType", "text/plain");
			intentObject.Call<AndroidJavaObject>("putExtra", intentObject.GetStatic<string>("EXTRA_SUBJECT"), subject);
			intentObject.Call<AndroidJavaObject>("putExtra", intentObject.GetStatic<string>("EXTRA_TEXT"), body);
			using (AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
			using (AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity")) 
			using (AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share Via"))
			currentActivity.Call("startActivity", jChooser);
		}
#endif

    }

    public void FishingList()
    {
        //Application.OpenURL("https://www.daum.net/");
        SceneManager.LoadScene("ShowFishedList");
    }

    public void Explain()
    {
        Application.OpenURL("https://www.google.com/");
    }
}
