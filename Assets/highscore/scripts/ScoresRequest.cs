using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace ScoreManager
{
	public class ScoresRequest : MonoBehaviour
	{
		private static WWW request;

		void Start () 
		{
			//waitForAdRequest("http://adzunga.us-west-2.elasticbeanstalk.com/mobile/ads/?gameId=00000&deviceModel=G75VW+(ASUSTeK+COMPUTER+INC.)&deviceName=KEVEN-PC&deviceType=Desktop&deviceUniqueIdentifier=8f10c60d47c33fa042a0466af9532d017a1dbb3a&operatingSystem=Windows+10++(10.0.0)+64bit&unityVersion=5.4.0f3&testMode=True");
			PlayerInfo playerInfo = new PlayerInfo();
		}

		public static IEnumerator loadScores(string url)
		{
			request = new WWW(url);
			yield return request;

			// check for errors
			if (request.error == null)
			{
				PlayerInfo json = JsonUtility.FromJson<PlayerInfo>(request.text);
				Debug.Log(json.username);
			}
			else
			{
				Utils.LogError("WWW Error: " + request.error);
			}
		}
	}

	[System.Serializable]
	public class PlayerInfo
	{
		public string username;
		public int userscore;
		public string useravatar;
	}
}



