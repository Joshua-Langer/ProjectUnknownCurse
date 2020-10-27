﻿using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mirror;

namespace LangerNetwork
{

	// ===================================================================================
	// EntityMovementComponent
	// ===================================================================================
	public partial class EntityMovementComponent
	{

		// -------------------------------------------------------------------------------
		// GetIsMoving
		// @Server / @Client
		// -------------------------------------------------------------------------------
		public bool GetIsMoving
		{
			get
			{
				return agent.velocity != Vector3.zero;
			}
		}

		// -------------------------------------------------------------------------------

	}

}

// =======================================================================================