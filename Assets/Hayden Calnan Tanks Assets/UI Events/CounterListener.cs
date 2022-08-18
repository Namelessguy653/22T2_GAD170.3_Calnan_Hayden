using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterListener : MonoBehaviour
{
    //This script will be listening for the "Increase Counter" event
    //When the event is announced the class will increase the counter and update the Ui Text

    [SerializeField] private int counter = 0;
    [SerializeField] private TMPro.TextMeshProUGUI counterUiText;

    // For events, we want to subscribe and unsubscribe to whichever event we want to hear

    private void OnEnable()
    {
        //Subscribe to events
        //CounterAnnouncers.OnStartEvent += IncreaseCount; <- original
        TankGameEvents.OnRoundResetEvent += IncreaseCount;

    }

    private void OnDisable()
    {
        //Unsubscribe to events
        //CounterAnnouncers.OnStartEvent -= IncreaseCount; <- original
        TankGameEvents.OnRoundResetEvent -= IncreaseCount;  

    }

    private void Start()
    {
        IncreaseCount();
    }

    //Increases the counter amount 
    private void IncreaseCount()
    {
        //Counter has been increased by 1 "(++)" and updates the Ui Text

        counter++;
        counterUiText.text = "Number of Game Starts: " + counter;
    }
}
