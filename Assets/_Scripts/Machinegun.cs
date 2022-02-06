using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machinegun : MonoBehaviour
{

    public GameMaster GM;
    public GameObject Bullet;
    public GameObject RightMG;
    private Vector3 _rightMGoffset;
    

    void Start()
    {
        GM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        _rightMGoffset = new Vector3(1.79f, 0, 0);
    }


    public void FireMG()
    {
        if (!GM.Firing) return;
        StartCoroutine(BulletVolley());
    }
    

    private IEnumerator BulletVolley()
    {
            GM.Firing = false;
            for (int i = 0; i < GM.BulletCount; i++)
            {
                Instantiate(Bullet, transform.position, transform.rotation);
                Instantiate(Bullet, RightMG.transform.position, RightMG.transform.rotation);
                yield return new WaitForSeconds(GM.BulletFireRate);
            }
            GM.Firing = true;
    }
}
