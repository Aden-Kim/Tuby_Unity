using UnityEngine;
using System.Collections;

public class JiverMain : MonoBehaviour {
	void Start () {
//		App ID: 1C0C2894-E73D-4711-B9A0-A55C2C4DEBF6
//			API Token: 95a9676a5e8d1dd421aad0a4e3d6c203752362e4

		string appId = "1C0C2894-E73D-4711-B9A0-A55C2C4DEBF6";
		string userId = SystemInfo.deviceUniqueIdentifier;
		string userName = "Unity-" + userId.Substring (0, 5);
		string channelUrl = "jia_test.Unity3d";


		Jiver.Init (appId);
		Jiver.Login (userId, userName);
		Jiver.Join (channelUrl);
		Jiver.Connect ();

	}
	
	void Update () {
	
	}
}
