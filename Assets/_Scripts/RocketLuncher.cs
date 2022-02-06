using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLuncher : MonoBehaviour
{
    public GameMaster GM;
    public GameObject Rocket;
    private Quaternion quaternion;

    private void Start()
    {
        quaternion = new Quaternion(0, 0, 0, 1);
    }

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
            Instantiate(Rocket, transform.position, quaternion);
            
            yield return new WaitForSeconds(GM.RocketFireRate);
        }
        GM.Firing = true;
    }
}
