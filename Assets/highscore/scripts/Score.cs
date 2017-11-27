using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace ScoreManager
{
	public class Score : MonoBehaviour 
	{
		private static WWW request;
		public static int score;
		public static string username;
		public int addScoreValue;
		public int remScoreValue;
		public int bonusValue;
		void Start () 
		{
			
		}
		public void AddScore()
		{
			//EventManager.
			Debug.Log("Your score is " + score.ToString());
			//Send("firstgame", true);
			SaveScore ();
		}

		public void SaveScore()
		{
			int highscore = PlayerPrefs.GetInt("highscore");
			if(score > highscore)
			{
				PlayerPrefs.SetInt("highscore", score);
				PlayerPrefs.SetString("username", username);
				Send("firstgame", true, username, score);
				Utils.LogInfo("Username: " + username + " " + "Score: " + score);
			}

			username = "kevenchantre";
			score = 1000;
			PlayerPrefs.SetInt("highscore", score);
			PlayerPrefs.SetString("username", username);
			Send("firstgame", true, username, score);
			Utils.LogInfo("Username: " + username + " " + "Score: " + score);
		}

		public void Send(string gameId, bool enableTestMode, string username, int score)
		{

			//adzungaAds.Init(gameId, enableTestMode);

			//string url = "http://api.adzunga.com/unity/ads/?gameId=" + WWW.EscapeURL(gameId)
			string url = "http://localhost/highscore/new?"
			+ "gameId=" + WWW.EscapeURL(gameId)
			+ "&username=" + WWW.EscapeURL(username)
			+ "&score=" + WWW.EscapeURL(score.ToString())
			+ "&testMode=" + WWW.EscapeURL(enableTestMode.ToString());

			Utils.LogInfo(url);

			//StartCoroutine(loadScores(url));
		}

		/*public static IEnumerator loadScores(string url)
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
		}*/



		public static void Send2(string gameId, bool enableTestMode)
		{

			//adzungaAds.Init(gameId, enableTestMode);

			//string url = "http://api.adzunga.com/unity/ads/?gameId=" + WWW.EscapeURL(gameId)
			string url = "http://localhost/highscore/new?"
			+ "gameId=" + WWW.EscapeURL(gameId)
			+ "&deviceModel=" + WWW.EscapeURL(DeviceInfo.deviceModel)
			+ "&deviceName=" + WWW.EscapeURL(DeviceInfo.deviceName)
			+ "&deviceType=" + WWW.EscapeURL(DeviceInfo.deviceType.ToString())
			+ "&deviceUniqueIdentifier=" + WWW.EscapeURL(DeviceInfo.deviceUniqueIdentifier)
			+ "&operatingSystem=" + WWW.EscapeURL(DeviceInfo.operatingSystem)
			+ "&unityVersion=" + WWW.EscapeURL(Utils.unityVersion)
			+ "&testMode=" + WWW.EscapeURL(enableTestMode.ToString());

			Utils.LogInfo(url);

			//instance.StartCoroutine(waitForAd(url));
		}



	}
}

