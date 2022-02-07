using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidCannon : MonoBehaviour
{
    public GameMaster GM;
    public GameObject BlackHole;

    public void FireVC()
    {
        if (!GM.Firing) return;
        StartCoroutine(LunchVoid());

    }

    private IEnumerator LunchVoid()
    {
        GM.Firing = false;
        
            Instantiate(BlackHole, transform.position, transform.rotation);

            yield return new WaitForSeconds(GM.VoidCD);
       
        GM.Firing = true;
    }
}
