using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepStatic : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
