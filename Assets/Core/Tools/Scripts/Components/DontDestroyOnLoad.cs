using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class DontDestroyOnLoad : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
