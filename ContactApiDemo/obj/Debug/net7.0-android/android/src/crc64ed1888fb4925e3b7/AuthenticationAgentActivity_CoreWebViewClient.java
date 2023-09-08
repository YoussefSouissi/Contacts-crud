package crc64ed1888fb4925e3b7;


public class AuthenticationAgentActivity_CoreWebViewClient
	extends android.webkit.WebViewClient
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLoadResource:(Landroid/webkit/WebView;Ljava/lang/String;)V:GetOnLoadResource_Landroid_webkit_WebView_Ljava_lang_String_Handler\n" +
			"n_shouldOverrideUrlLoading:(Landroid/webkit/WebView;Ljava/lang/String;)Z:GetShouldOverrideUrlLoading_Landroid_webkit_WebView_Ljava_lang_String_Handler\n" +
			"n_onPageFinished:(Landroid/webkit/WebView;Ljava/lang/String;)V:GetOnPageFinished_Landroid_webkit_WebView_Ljava_lang_String_Handler\n" +
			"n_onPageStarted:(Landroid/webkit/WebView;Ljava/lang/String;Landroid/graphics/Bitmap;)V:GetOnPageStarted_Landroid_webkit_WebView_Ljava_lang_String_Landroid_graphics_Bitmap_Handler\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Identity.Client.Platforms.Android.EmbeddedWebview.AuthenticationAgentActivity+CoreWebViewClient, Microsoft.Identity.Client", AuthenticationAgentActivity_CoreWebViewClient.class, __md_methods);
	}


	public AuthenticationAgentActivity_CoreWebViewClient ()
	{
		super ();
		if (getClass () == AuthenticationAgentActivity_CoreWebViewClient.class) {
			mono.android.TypeManager.Activate ("Microsoft.Identity.Client.Platforms.Android.EmbeddedWebview.AuthenticationAgentActivity+CoreWebViewClient, Microsoft.Identity.Client", "", this, new java.lang.Object[] {  });
		}
	}

	public AuthenticationAgentActivity_CoreWebViewClient (java.lang.String p0, android.app.Activity p1)
	{
		super ();
		if (getClass () == AuthenticationAgentActivity_CoreWebViewClient.class) {
			mono.android.TypeManager.Activate ("Microsoft.Identity.Client.Platforms.Android.EmbeddedWebview.AuthenticationAgentActivity+CoreWebViewClient, Microsoft.Identity.Client", "System.String, System.Private.CoreLib:Android.App.Activity, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public void onLoadResource (android.webkit.WebView p0, java.lang.String p1)
	{
		n_onLoadResource (p0, p1);
	}

	private native void n_onLoadResource (android.webkit.WebView p0, java.lang.String p1);


	public boolean shouldOverrideUrlLoading (android.webkit.WebView p0, java.lang.String p1)
	{
		return n_shouldOverrideUrlLoading (p0, p1);
	}

	private native boolean n_shouldOverrideUrlLoading (android.webkit.WebView p0, java.lang.String p1);


	public void onPageFinished (android.webkit.WebView p0, java.lang.String p1)
	{
		n_onPageFinished (p0, p1);
	}

	private native void n_onPageFinished (android.webkit.WebView p0, java.lang.String p1);


	public void onPageStarted (android.webkit.WebView p0, java.lang.String p1, android.graphics.Bitmap p2)
	{
		n_onPageStarted (p0, p1, p2);
	}

	private native void n_onPageStarted (android.webkit.WebView p0, java.lang.String p1, android.graphics.Bitmap p2);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
