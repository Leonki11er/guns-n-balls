using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketLuncher : MonoBehaviour
{
    public GameMaster GM;
    public GameObject Rocket;
    public Button Rocket_button;
    float rocketCD;
    private AudioSource _audioSource;

    private void Start()
    {
        rocketCD = GM.RocketCD;
        _audioSource = GetComponent<AudioSource>();
    }

    public void BlastSound()
    {
        _audioSource.Play();
    }
    public void FireRL()
    {
        if (!GM.Firing||rocketCD<GM.RocketCD) return;
        StartCoroutine(RocketVolley());
        StartCoroutine(RocketCoolDown(GM.RocketCD));

    }

    private IEnumerator RocketCoolDown(float cooldown)
    {
        rocketCD = 0;
        while (rocketCD < cooldown)
        {
            rocketCD += Time.deltaTime;
            Rocket_button.image.fillAmount = Mathf.InverseLerp(0f, cooldown, rocketCD);
            yield return null;
        }
        GM.Firing = true;
    }

    private IEnumerator RocketVolley()
    {
        GM.Firing = false;
        for (int i = 0; i < GM.RocketCount; i++)
        {
            Instantiate(Rocket, transform.position, transform.rotation);
            
            yield return new WaitForSeconds(GM.RocketFireRate);
        }
        
    }
}
