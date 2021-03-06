﻿
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using LangerNetwork;
using LangerNetwork.UI;

namespace LangerNetwork.UI
{

	// ===================================================================================
	// UITooltip
	// ===================================================================================
	[DisallowMultipleComponent]
	public class UITooltip : UIBase
	{

		public Text tooltipText;

		public static UITooltip singleton;

		// -------------------------------------------------------------------------------
		// Awake
		// -------------------------------------------------------------------------------
		protected override void Awake()
		{
			singleton = this;
			base.Awake();
		}

		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public void Show(string _text)
		{
			tooltipText.text = _text;
			base.Show();
		}

		// -------------------------------------------------------------------------------
		// UpdateTooltip
		// -------------------------------------------------------------------------------
		public void UpdateTooltip(string _text)
		{
			if (root.activeSelf)
				tooltipText.text = _text;
		}

		// -------------------------------------------------------------------------------
		// Active
		// -------------------------------------------------------------------------------
		public bool Active
		{
			get
			{
				return root.activeSelf;
			}
		}

	}

	// -----------------------------------------------------------------------------------

}

// =======================================================================================