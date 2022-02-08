using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoidCannon : MonoBehaviour
{
    public GameMaster GM;
    public GameObject BlackHole;
    public float Zoffset;
    public Button BH_button;
    float voidCD;
    private AudioSource _audioSource;
    private void Start()
    {
        voidCD = GM.VoidCD;
        _audioSource = GetComponent<AudioSource>();
    }
    public void FireVC()
    {
        if (!GM.Firing||voidCD<GM.VoidCD) return;
        _audioSource.Play();
        StartCoroutine(LunchVoid());
        StartCoroutine(VoidCoolDown(GM.VoidCD));

    }

    private IEnumerator VoidCoolDown(float cooldown)
    {
       voidCD = 0;
        while (voidCD < cooldown)
        {
            voidCD += Time.deltaTime;
            BH_button.image.fillAmount = Mathf.InverseLerp(0f, cooldown, voidCD);
            yield return null;
        }
    }

    private IEnumerator LunchVoid()
    {
        GM.Firing = false;
        
            Instantiate(BlackHole, transform.position+new Vector3(0f,0f,Zoffset), transform.rotation);

            yield return null;
    }
}
