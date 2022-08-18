using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandStorm : MonoBehaviour
{
    public LayerMask tankLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == transform)
        {
            // if we some how hit ourselves or another coin
            // ignore it
            return;
        }
        else
        {
            Speed(); // we hit something go fast
        }
    }

    //The sandstorm will now conceal you and give you a speed boost 

    private void Speed()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, tankLayer); // draw a sphere, if any objects are on the tank layer, grab them and store them in this array

        for (int i = 0; i < colliders.Length; i++) // loop through all the colliders in the explosion
        {

            Tank tank = colliders[i].GetComponent<Tank>();
            if (tank)
            {
                tank.tankMovement.speed += 4;
            }

        }

    }
}
