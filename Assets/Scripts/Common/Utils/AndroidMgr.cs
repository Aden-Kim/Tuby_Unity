﻿using UnityEngine;
using System.Collections;

public class AndroidMgr : MonoBehaviour
{
	#if(UNITY_ANDROID)
	private AndroidJavaObject curActivity;
	public string strLog = "No Log";
	public Texture2D texTmp;
	static AndroidMgr _instance;
	Object mReceiver;

	int callNum = 0;

	private static AndroidMgr Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType(typeof(AndroidMgr)) as AndroidMgr;
				Debug.Log("AndroidMgr is null");
				if (_instance == null)
				{
					GameObject container = new GameObject();  
					container.name = "AndroidMgr";  
					_instance = container.AddComponent(typeof(AndroidMgr)) as AndroidMgr;
					Debug.Log("and makes new one");
					
				}
			}
			
			return _instance;
		}
	}

	void Awake()
	{

		///&lt; 현재 활성화된 액티비티 얻어와서 저장
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		curActivity = jc.GetStatic<AndroidJavaObject>("currentActivity");
	}
	void Start ()
	{
//		texTmp = new Texture2D (1024, 1024, TextureFormat.DXT1, false);
	}

	public static void CallJavaFunc( string strFuncName, string str)
	{
		if( Instance.curActivity == null )
			return;
		///&lt; 액티비티안의 자바 메소드 호출
		Instance.curActivity.Call( strFuncName, str);
	}

	public static void CallJavaFunc( string strFuncName, string str, Object receiver)
	{
		if( Instance.curActivity == null )
			return;
		///&lt; 액티비티안의 자바 메소드 호출
		Instance.SetReceiver(receiver);
		Instance.curActivity.Call( strFuncName, str);
	}

	public void SetGalleryImage(string image)
	{
		ScriptItemPhoto sip = mReceiver as ScriptItemPhoto;
		sip.SetImgData (image);
	}

	public void SetGalleryImages(string images)
	{
//		if(images.Length < 1)
//		{
//			AndroidMgr.Instance.strLog = "no Images";
//		}
//
//		JSONObject json = new JSONObject (images);
//
//		ScriptUpload su = mReceiver as ScriptUpload;
//
//		su.setImageDictionary (json);

	}

	public void SetReceiver(Object receiver)
	{
		mReceiver = receiver;
	}

	public void SetKeyboardHeight(string height)
	{
		ScriptInputBody sib = mReceiver as ScriptInputBody;
		sib.SetKeyboardHeight (int.Parse (height));
	}

	public void SetGCMId(string GCMId)
	{
		Debug.Log ("Recieved GCMId : "+GCMId);
		ScriptTitle receiver = mReceiver as ScriptTitle;
		receiver.SetGCMId (GCMId);
	}

	public void GCMFailed(string msg)
	{
		Debug.Log ("Failed GCM : "+msg);
	}
#else
	public static void CallJavaFunc( string strFuncName, string str){}
	public static void CallJavaFunc( string strFuncName, string str, Object receiver){}

#endif
}