using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterAnnouncers : MonoBehaviour
{
    //We ned our events here

    public delegate void StartAction();

    public static event StartAction OnStartEvent;

    public void Start()
    {
        if(OnStartEvent != null)
        {
            OnStartEvent();
        }
    }


}
