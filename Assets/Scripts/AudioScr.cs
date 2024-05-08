using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScr : MonoBehaviour
{
    public AudioClip[] sound;
    AudioSource audioSource;

    public GameObject lightCollider;

    private bool isHit = false;
    private bool isEating = false;
    private bool preIsHit = false;
    private bool preIsEating = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isHit = lightCollider.GetComponent<CollisionDetection2>().isHit;
        isEating = GetComponent<AnimationScr>().isEating;

        if(isHit != preIsHit && preIsHit == false && isEating == false){
            audioSource.PlayOneShot(sound[0]);
        }
        if(isEating != preIsEating && preIsEating == false){
            audioSource.PlayOneShot(sound[1]);
        }

        preIsHit = isHit;
        preIsEating = isEating;
    }
}
