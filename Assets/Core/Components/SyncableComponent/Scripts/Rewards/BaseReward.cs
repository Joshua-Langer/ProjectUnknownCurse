﻿// =======================================================================================
// BaseReward
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using System;
using System.Text;
using UnityEngine;

namespace LangerNetwork
{

	// ===================================================================================
	// BaseReward
	// ===================================================================================
	[System.Serializable]
	public abstract partial class BaseReward
	{

		[HideInInspector] public string title;
		[HideInInspector] public long timer = 0;

		/*
		public virtual void OnValidate()
		{
	
			if (String.IsNullOrWhiteSpace(name))
				title = name;
			
		}
		*/

	}

}

// =======================================================================================