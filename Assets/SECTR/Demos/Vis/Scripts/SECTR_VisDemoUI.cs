﻿// Copyright (c) 2014 Make Code Now! LLC

#if UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6
#define UNITY_4
#endif

using UnityEngine;
using System.Collections;

[AddComponentMenu("SECTR/Demos/SECTR Vis Demo UI")]
public class SECTR_VisDemoUI : SECTR_DemoUI
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
		watermarkLocation = WatermarkLocation.UpperCenter;
		AddButton(KeyCode.C, "Enable Culling", "Disable Culling", ToggleCulling);
		base.OnEnable();
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

		if(passedIntro && !CaptureMode)
		{
			int renderersCulled = 0;
			int lightsCulled = 0;
			int terrainsCulled = 0;

			SECTR_CullingCamera cullingCamera = GetComponent<SECTR_CullingCamera>();
			if(cullingCamera)
			{
				renderersCulled += cullingCamera.RenderersCulled;
				lightsCulled += cullingCamera.LightsCulled;
				terrainsCulled += cullingCamera.TerrainsCulled;
			}

			string statsString = "Culling Stats\n";
			statsString += "Renderers: " + renderersCulled + "\n";
			statsString += "Lights: " + lightsCulled + "\n";
			statsString += "Terrains: " + terrainsCulled;

			GUIContent statsContent = new GUIContent(statsString);
			float width = Screen.width * 0.33f;
			float height = demoButtonStyle.CalcHeight(statsContent, width);
			Rect statsRect = new Rect(Screen.width - width, 0, width, height);
			GUI.Box(statsRect, statsContent, demoButtonStyle);
		}
	}
	#endregion

	#region Private Details
	protected void ToggleCulling(bool active)
	{
		SECTR_CullingCamera cullingCamera = GetComponent<SECTR_CullingCamera>();
		if(cullingCamera)
		{
			cullingCamera.enabled = !active;
			cullingCamera.ResetStats();
		}
	}
	#endregion
}
