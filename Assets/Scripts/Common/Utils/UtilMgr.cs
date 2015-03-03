﻿using System;
using UnityEngine;
using System.Collections;

public class UtilMgr : MonoBehaviour {

	static UtilMgr _instance;

	static UtilMgr Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType(typeof(UtilMgr)) as UtilMgr;
				Debug.Log("UtilMgr is null");
				if (_instance == null)
				{
					GameObject container = new GameObject();  
					container.name = "UtilMgr";  
					_instance = container.AddComponent(typeof(UtilMgr)) as UtilMgr;
					Debug.Log("and makes new one");
					
				}
			}
			
			return _instance;
		}
	}

	void Awake()
	{
		DontDestroyOnLoad (this);
	}

	public static string AddsThousandsSeparator(string number)
	{
		return string.Format ("{n0}", number);
	}

	public static string AddsThousandsSeparator(int number)
	{
		return string.Format ("{0:n0}", number);
	}

	public static string AddsThousandsSeparator(double number)
	{
		return string.Format ("{0:n0}", number);
	}

	/** "yyyy-MM-dd HH:mm:ss" */
	public static string GetDateTime(string expression)
	{
		return System.DateTime.Now.ToString (expression);
	}
	/** "20150225182000"  */
	public static string ConvertToDate(string timeStr)
	{
		string year = timeStr.Substring (0, 4);
		string month = timeStr.Substring (4, 2);
		string day = timeStr.Substring (6, 2);
		int nTime = int.Parse(timeStr.Substring (8, 2));
		string minute = timeStr.Substring (10, 2);
		string time;
		if(nTime > 11)
		{
			time = "오후 ";
			if(nTime > 12)
			{
				nTime -= 12;
			}
			time += nTime+":";
		}
		else
		{
			time = "오전 ";
			time += nTime+":";
		}
		string final = year + ". " + month + ". " + day + " " + time + minute;
		return final;
	}

	public static string GetTeamEmblem(int teamSeq)
	{
		switch(teamSeq)
		{
		case 10:
			return "ic_samsung";
		case 11:
			return "ic_nexen";
		}
		return null;
	}

	public static string GetTeamEmblem(string teamCode)
	{
		switch(teamCode)
		{
		case "SS":
			return "ic_samsung";
		case "WO":
			return "ic_nexen";
		}
		return null;
	}

	public static string GetRoundString(int round)
	{

		if(round == 1)
		{
			return "ST";
		}
		else if(round == 2)
		{
			return "ND";
		}
		else if(round == 3)
		{
			return "RD";
		}
		else
		{
			return "TH";
		}
	}

	/** 객체의 이름을 통하여 자식 요소를 찾아서 리턴하는 함수 */
	public static GameObject GetChildObj( GameObject source, string strName) { 
		Transform[] AllData = source.GetComponentsInChildren< Transform >(); 
		GameObject target = null;
		
		foreach( Transform Obj in AllData ) { 
			if( Obj.name == strName ) { 
				target = Obj.gameObject;
				break;
			} 
		}
		
		return target;
	}

	public static Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight)
	{
		Texture2D result = new Texture2D(targetWidth, targetHeight, source.format, true);
		Color[] rpixels = result.GetPixels(0);
		float incX = (1.0f / (float)targetWidth);
		float incY = (1.0f / (float)targetHeight);
		for (int px = 0; px < rpixels.Length; px++)
		{
			rpixels[px] = source.GetPixelBilinear(incX * ((float)px % targetWidth), incY * ((float)Mathf.Floor(px / targetWidth)));
		}
		result.SetPixels(rpixels, 0);
		result.Apply();
		Destroy (source);
//		System.GC.Collect ();
		return result;
	}
}
