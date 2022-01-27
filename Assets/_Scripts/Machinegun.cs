using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machinegun : MonoBehaviour
{

    public GameMaster GM;
    public GameObject Bullet;
    public float Xoffset;
    public float Yoffset;
    public float Zoffset;
    private Quaternion quaternion;
    

    void Start()
    {
        quaternion = new Quaternion(-1, 1, -1, 1);
        GM = GameObject.Find("Roof").GetComponent<GameMaster>();
        StartCoroutine(BulletVolley());
       
    }

    

    private IEnumerator BulletVolley()
    {
        
            for (int i = 0; i < GM.BulletCount; i++)
            {
            
            Instantiate(Bullet, new Vector3(transform.position.x - Xoffset, transform.position.y - Yoffset, transform.position.z - Zoffset),quaternion);
                yield return new WaitForSeconds(GM.BulletFireRate);
            }
       
    }
}
