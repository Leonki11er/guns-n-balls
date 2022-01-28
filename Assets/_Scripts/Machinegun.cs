using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machinegun : MonoBehaviour
{

    public GameMaster GM;
    public GameObject Bullet;
    private Quaternion quaternion;
    private Vector3 _rightMGoffset;
    

    void Start()
    {
        quaternion = new Quaternion(-1, 1, -1, 1);
        GM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        _rightMGoffset = new Vector3(1.79f, 0, 0);
    }


    public void FireMG()
    {
        StartCoroutine(BulletVolley());
    }
    

    private IEnumerator BulletVolley()
    {
        if (GM.Firing)
        {
            GM.Firing = false;
            for (int i = 0; i < GM.BulletCount; i++)
            {
                Instantiate(Bullet, transform.position, quaternion);
                Instantiate(Bullet, transform.position+ _rightMGoffset, quaternion);
                yield return new WaitForSeconds(GM.BulletFireRate);
            }
            GM.Firing = true;
        }
        
            
       
    }
}
