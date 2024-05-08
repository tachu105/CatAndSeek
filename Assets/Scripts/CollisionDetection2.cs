using System.Collections.Generic;
using UnityEngine;
 
public class CollisionDetection2 : MonoBehaviour {

    [HideInInspector] public bool isHit = false;
    public GameObject cat;

    void Start(){
        
    }
    //OnCollisionEnter()
    private void OnTriggerStay(Collider other)
    {
        if(cat.GetComponent<AgentScr>().isOffMeshLink &&!cat.GetComponent<AgentScr>().isDoCol) return;
        
        if(other.gameObject.tag=="Target"){
        Debug.Log("hitEnter");
        isHit = true;
        }
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Target"){
            Debug.Log("hitExit");
            isHit = false;
        }
    }
}