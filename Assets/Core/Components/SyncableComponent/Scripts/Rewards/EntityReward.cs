﻿// =======================================================================================
// EntityReward
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using System;
using System.Text;
using UnityEngine;

namespace LangerNetwork
{

	// ===================================================================================
	// EntityReward
	// ===================================================================================
	[System.Serializable]
	public abstract partial class EntityReward : BaseReward
	{

		[SerializeField] protected int minLevel;
		[SerializeField] protected int maxLevel;

		public int GetLevel
		{
			get
			{
				if (maxLevel <= 0) return minLevel;
				return UnityEngine.Random.Range(minLevel, maxLevel);
			}
		}

	}

}

// =======================================================================================