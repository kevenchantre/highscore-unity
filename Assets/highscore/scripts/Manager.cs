using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScoreManager
{
	public class Manager : MonoBehaviour 
	{

		// Get the UnityPlayer class
		
		// Get the current activity
		//AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");


		public GameObject playerScoreContainer;
		private float nextPosition = 0.0f;
		public float spaceBewteenContainers;
		public int scoresNumberToShow;
		public GameObject parent;

		public Text debug;
		
		void Start () 
		{
			EventManager eventManager = this.gameObject.GetComponent<EventManager>();
			eventManager.AddScore.Invoke();
			//SpawnPlayerScore("Keven Chantre", 1000);
			//eventManager.
			eventManager.SaveScore.Invoke();
			ListScoresInGame();
			// Get the current activity
			AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			string Times_Called = activity.Call<string>("account");
			Debug.Log(Times_Called + " AAAAAAAAAAAAAAAAAAAAAAAA");
			debug.text = "Olá " + Times_Called;
			//StartCoroutine(ScoresRequest.loadScores("http://adzunga.us-west-2.elasticbeanstalk.com/mobile/ads/?gameId=00000&deviceModel=G75VW+(ASUSTeK+COMPUTER+INC.)&deviceName=KEVEN-PC&deviceType=Desktop&deviceUniqueIdentifier=8f10c60d47c33fa042a0466af9532d017a1dbb3a&operatingSystem=Windows+10++(10.0.0)+64bit&unityVersion=5.4.0f3&testMode=True"));
		}

		//SPAWN NEW PLAYER SCORE CONTAINER
		public void SpawnPlayerScore(string username, int userscore)
		{
			playerScoreContainer = Instantiate(playerScoreContainer);
			playerScoreContainer.gameObject.transform.GetChild(0).GetComponent<Text>().text = username;
			playerScoreContainer.gameObject.transform.GetChild(1).GetComponent<Text>().text = userscore.ToString();
			playerScoreContainer.GetComponent<RectTransform>().anchoredPosition = scoreContainerPosition(playerScoreContainer.GetComponent<RectTransform>().anchoredPosition);
			playerScoreContainer.transform.SetParent(parent.transform, false);
		}

		//DEFINE PLAYER SCORE CONTAINER POSITION
		public Vector2 scoreContainerPosition(Vector2 positionInY)
		{
			positionInY = this.GetComponent<RectTransform>().anchoredPosition + new Vector2(0, nextPosition);
			nextPosition = nextPosition - playerScoreContainer.GetComponent<RectTransform>().rect.height - spaceBewteenContainers;
			return positionInY;
		}

		void ListScoresInGame()
		{
			for(int i = 0; i < scoresNumberToShow; i++)
			{
				SpawnPlayerScore("Keven Chantre", 1000);
			}
		}

		void ManageParent()
		{
			//parent.GetComponent<RectTransform>().rect.height = 500;
		}

	}
}

