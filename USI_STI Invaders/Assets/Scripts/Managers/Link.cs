using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{
    string facebook = "https://www.facebook.com/sharer/sharer.php?u=usi.ie/", twitter = "https://twitter.com/intent/tweet?text=%20Play%20Escape%20From%20Debt%20Valley%20now%20http://usi.ie/%20@TheUSI";
    string USI_fb = "https://www.facebook.com/USI.ie/", USI_Tw = "https://twitter.com/TheUSI?ref_src=twsrc%5Egoogle%7Ctwcamp%5Eserp%7Ctwgr%5Eauthor", USI = "http://usi.ie/";

	public void OpenLinkJSPluginFacebook()
	{
		#if !UNITY_EDITOR
		openWindow(facebook);
		#endif
	}

    public void OpenLinkJSPluginTwitter()
    {
        #if !UNITY_EDITOR
		openWindow(twitter);
        #endif
    }

    public void OpenLinkJSPluginUSI()
    {
        #if !UNITY_EDITOR
		openWindow(USI);
        #endif
    }

    public void OpenLinkJSPluginUSIFacebook()
    {
        #if !UNITY_EDITOR
		openWindow(USI_fb);
        #endif
    }

    public void OpenLinkJSPluginUSITwitter()
    {
        #if !UNITY_EDITOR
		openWindow(USI_Tw);
        #endif
    }

    [DllImport("__Internal")]
	private static extern void openWindow(string url);

}