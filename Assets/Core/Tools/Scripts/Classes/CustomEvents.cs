using System;
using UnityEngine;
using UnityEngine.Events;
using Mirror;

namespace LangerNetwork
{

    [Serializable]
    public class UnityEventString : UnityEvent<string> { }
    [Serializable]
    public class UnityEventLong : UnityEvent<long>{ }
    [Serializable]
    public class UnityEventInt : UnityEvent<int> { }
    [Serializable]
    public class UnityEventBool : UnityEvent<bool> { }
    [Serializable]
    public class UnityEventGameObject : UnityEvent<GameObject> { }
    [Serializable]
    public class UnityEventConnection : UnityEvent<NetworkConnection> { }
}
