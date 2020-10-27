using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using Mirror;

namespace Mirror { 

    public static partial class Extensions
    {
        //ID
        //Returns the connection id of NetworkConnection as formatted string
        //used ver often in logfiles
        //Extends: NetworkConnection
        public static string ID(this NetworkConnection conn)
        {
            return "ID " + conn.connectionId.ToString();
        }
    }
}
