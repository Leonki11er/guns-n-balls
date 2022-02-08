using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machinegun : MonoBehaviour
{

    public GameMaster GM;
    public GameObject Bullet;
    public GameObject RightMG;
    public Button MG_button;
    float mgCD;
    private AudioSource _audioSource;



    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        GM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        mgCD = GM.MGcd;
    }


    public void FireMG()
    {
        if (!GM.Firing||mgCD<GM.MGcd) return;
        StartCoroutine(BulletVolley());
        StartCoroutine(MGCoolDown(GM.MGcd));
    }

    private IEnumerator MGCoolDown(float cooldown)
    {
        mgCD = 0;
        while (mgCD < cooldown)
        {
            mgCD += Time.deltaTime;
            MG_button.image.fillAmount = Mathf.InverseLerp(0f, cooldown, mgCD);
            yield return null;
        }
    }

    private IEnumerator BulletVolley()
    {
            GM.Firing = false;
        _audioSource.Play();
        
            for (int i = 0; i < GM.BulletCount; i++)
            {
                Instantiate(Bullet, transform.position, transform.rotation);
                Instantiate(Bullet, RightMG.transform.position, RightMG.transform.rotation);
                yield return new WaitForSeconds(GM.BulletFireRate);
            }
            GM.Firing = true;
        _audioSource.Stop();
    }
}
