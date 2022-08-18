using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    //This script will be listening for the "OnObjectTakeDamageEvent" event
    //When the event is announced the class will increase the counter and update the Ui Text

    [SerializeField] private int counter = 0;
    [SerializeField] private TMPro.TextMeshProUGUI counterUiText;

    // For events, we want to subscribe and unsubscribe to whichever event we want to hear

    private void OnEnable()
    {
        //Subscribe to events   
        TankGameEvents.OnObjectTakeDamageEvent += Floaty;

    }

    private void OnDisable()
    {
        //Unsubscribe to events
        TankGameEvents.OnObjectTakeDamageEvent -= Floaty;

    }

    private void Floaty(Transform ObjectDamaged, float amountOfDamage)
    {

        counter++;
        counterUiText.text = "Total Hits: " + counter;
    }
}
