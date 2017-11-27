﻿// Copyright (C) 2017 Interactive Load

using UnityEngine;
using System.Collections;

namespace Common
{
	internal class Utils
	{
		private static void Log(string message)
		{
			Debug.Log(message);
		}
		public static void LogDebug(string message) 
		{
			Log ("Debug: " + message);
		}
		public static void LogInfo(string message) 
		{
			Log ("Info:" + message);
		}
		public static void LogWarning(string message) 
		{
			Log ("Warning:" + message);
		}
		public static void LogError(string message) 
		{
			Log ("Error: " + message);
		}
		public static string unityVersion
		{
			get
			{
				return Application.unityVersion;
			}
		}
	}
}


