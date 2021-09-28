using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool _hasCastleKey { get; set; }
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UImnanager instance null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

 

}
