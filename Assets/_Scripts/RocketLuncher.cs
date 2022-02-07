using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLuncher : MonoBehaviour
{
    public GameMaster GM;
    public GameObject Rocket;
    private Quaternion quaternion;

    public void FireRL()
    {
        if (!GM.Firing) return;
        StartCoroutine(RocketVolley());

    }

    private IEnumerator RocketVolley()
    {
        GM.Firing = false;
        for (int i = 0; i < GM.RocketCount; i++)
        {
            Instantiate(Rocket, transform.position, transform.rotation);
            
            yield return new WaitForSeconds(GM.RocketFireRate);
        }
        GM.Firing = true;
    }
}
