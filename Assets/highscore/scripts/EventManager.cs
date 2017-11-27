using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace ScoreManager
{
	public class EventManager : MonoBehaviour 
	{
		[Header("Add the Score Manager Script Here!")]
		public UnityEvent AddScore;
		public UnityEvent RemScore;
		public UnityEvent AddBonus;
		public UnityEvent SaveScore;

		void Start()
		{
			//YourFunction();
		}
		
		private void YourFunction()
		{
			if (AddScore!=null) AddScore.Invoke();
		}
	}
}

