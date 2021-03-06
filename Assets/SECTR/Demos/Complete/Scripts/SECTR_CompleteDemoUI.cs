﻿// Copyright (c) 2014 Make Code Now! LLC

#if UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6
#define UNITY_4
#endif

using UnityEngine;
using System.Collections;

[AddComponentMenu("SECTR/Demos/SECTR Complete Demo UI")]
public class SECTR_CompleteDemoUI : SECTR_DemoUI
{
#if UNITY_4
	#region Private Details
	private string originalDemoMessage;
	#endregion
	
	#region Public Interface
	[Multiline] public string Unity4PerfMessage;
	#endregion
#endif

	#region Unity Interface
	protected override void OnEnable()
	{
#if UNITY_4
		originalDemoMessage = DemoMessage;
#endif
		base.OnEnable();
		SECTR_StartLoader startLoader = GetComponent<SECTR_StartLoader>();
		if(startLoader)
		{
			startLoader.Paused = true;
		}
	}

	protected override void OnGUI()
	{
#if UNITY_4
		if(Application.isEditor && Application.isPlaying && !string.IsNullOrEmpty(Unity4PerfMessage))
		{
			DemoMessage = originalDemoMessage;
			DemoMessage += "\n\n";
			DemoMessage += Unity4PerfMessage;
		}
#endif

		base.OnGUI();
		
		SECTR_StartLoader startLoader = GetComponent<SECTR_StartLoader>();
		if(passedIntro && startLoader && startLoader.Paused)
		{
			startLoader.Paused = false;
		}
	}
	#endregion
}
