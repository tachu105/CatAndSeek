using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBowlMoveScr : MonoBehaviour
{
    public GameObject cat;
    public float offset;


    public GameObject lightCollider;
    private bool isHit = false;
    private bool isEating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isHit = lightCollider.GetComponent<CollisionDetection2>().isHit; 
        isEating = cat.GetComponent<AnimationScr>().isEating;

        transform.position = cat.transform.position + cat.transform.forward*offset;

        if(isEating){
            GetComponent<MeshRenderer>().enabled = true;
        }else{
            GetComponent<MeshRenderer>().enabled = false;
        }


    }
}
