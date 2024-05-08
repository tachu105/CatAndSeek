using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveEffectScr : MonoBehaviour
{
    SpriteRenderer renderer;
    Vector4 setColor = new Vector4();
    float alpha = 1;
    public float alphaSpeed = 1;
    public float moveSpeed = 1;

    GameObject cat;
    public Vector3 offset = new Vector3(0,0,0);
    
    AudioSource audioSource;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        transform.localScale = new Vector3(0.1f,0.1f,0.1f);
        transform.Rotate(0,90,0);
        audioSource.PlayOneShot(audioSource.clip);
        setColor = renderer.color;
        cat = GameObject.Find("cu_cat");
        transform.position = cat.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        if(alpha<0) Destroy(this.gameObject);
        renderer.color = new Vector4(setColor.x,setColor.y,setColor.z,alpha);
        transform.position += new Vector3(0,moveSpeed,0)*Time.deltaTime;
        alpha -= Time.deltaTime*alphaSpeed;
    }
}
