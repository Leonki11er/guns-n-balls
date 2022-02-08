using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidCannon : MonoBehaviour
{
    public GameMaster GM;
    public GameObject BlackHole;
    public float Zoffset;

    public void FireVC()
    {
        if (!GM.Firing) return;
        StartCoroutine(LunchVoid());

    }

    private IEnumerator LunchVoid()
    {
        GM.Firing = false;
        
            Instantiate(BlackHole, transform.position+new Vector3(0f,0f,Zoffset), transform.rotation);

            yield return new WaitForSeconds(GM.VoidCD);
       
        GM.Firing = true;
    }
}
