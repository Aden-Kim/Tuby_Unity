﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScriptDetailHighlight : MonoBehaviour {

	public GameObject[] Items;
	public GameObject mListFriends;
	public GameObject mItemFriend;

	GetQuizResultResponse mResponse;
	float mPosGuide;
	static List<GameObject> mListFriendItems = new List<GameObject>();

	public void Init(GetQuizResultResponse response)
	{
		mPosGuide = 175f;
		mResponse = response;
		SetResultGraph ();
		SetResultFriends ();
	}

	public void ClearList(){
		foreach (GameObject go in mListFriendItems)
			NGUITools.DestroyImmediate (go);
	}

	void SetResultGraph(){
		for (int i = 0; i < mResponse.data.global.Count; i++) {
			Items[i].GetComponent<ScriptItemDetailGraph>().Init(
				mResponse.data.global[i], mResponse.data.friend[i]);
		}
	}

	void SetResultFriends(){

		mListFriendItems.Clear ();

		for (int i = 0; i < mResponse.data.result.Count; i++) {
			QuizResultResults friend = mResponse.data.result[i];
			List<QuizResultGlobal> orders = mResponse.data.global;
			GameObject go = Instantiate(mItemFriend, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
			go.transform.parent = mListFriends.transform;
			go.transform.localScale = new Vector3(1f, 1f, 1f);	
			go.GetComponent<ScriptItemListFriends>().Init(friend, orders);			
			go.transform.localPosition = new Vector3(0f, -mPosGuide, 0f);
			mPosGuide += 140f;
			mListFriendItems.Add (go);
		}
		mListFriends.GetComponent<UIScrollView> ().ResetPosition ();
	}
}
