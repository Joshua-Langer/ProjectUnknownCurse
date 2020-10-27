using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LangerNetwork
{

	// ===================================================================================
	// IdleStateTemplate
	// ===================================================================================
	[CreateAssetMenu(fileName = "New IdleState", menuName = "LangerNetwork - States/New IdleState", order = 999)]
	public partial class IdleStateTemplate : StateTemplate
	{

		// -------------------------------------------------------------------------------
		// GetIsActive
		// -------------------------------------------------------------------------------
		public override bool GetIsActive(EntityComponent entityComponent)
		{
			return !entityComponent.movementComponent.GetIsMoving;
		}

		// -------------------------------------------------------------------------------

	}

}

// =======================================================================================