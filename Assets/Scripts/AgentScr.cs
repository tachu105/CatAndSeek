using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class AgentScr : MonoBehaviour
{
    [SerializeField]
    [Tooltip("巡回する地点の配列")]
    private Transform[] target;

    private NavMeshAgent navMeshAgent;
    private int targetIndex;

    private Animator animator;

    public GameObject lightCollider;
    private bool isHit = false;
    public GameObject mainCamera;

    public GameObject catNeck;

    private bool isEating;

    [HideInInspector] public bool isOffMeshLink = false;

    [HideInInspector] public bool isDoCol = false;
    bool isAbleSetNextPoint = true;
    public bool isStopAnim = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(target[0].position);
        animator = GetComponent<Animator>();
        
    }

    void Update() {
        isHit = lightCollider.GetComponent<CollisionDetection2>().isHit;
        isEating = GetComponent<AnimationScr>().isEating;
        isOffMeshLink = navMeshAgent.isOnOffMeshLink;

        if(isHit == true){
            navMeshAgent.speed = 0;
            this.transform.LookAt(new Vector3(mainCamera.transform.position.x,0,mainCamera.transform.position.z));
        }else{
            if(!isEating){
                navMeshAgent.speed = 3.5f;
            }
            
        }

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if(!isDoCol){
                StartCoroutine(StayPoint());
            }
            if(isAbleSetNextPoint){
                targetIndex = Random.Range(0,1000)%target.Length;
                navMeshAgent.SetDestination(target[targetIndex].position);
                isAbleSetNextPoint = false;
            }
            
        }


        if(isStopAnim){
            navMeshAgent.speed = 0;
        }
        
        Debug.Log(isHit);
    }

    IEnumerator StayPoint()
    {
        isDoCol = true;
        isStopAnim = true;
        
        yield return new WaitForSeconds(5);
        isAbleSetNextPoint = true;
        isDoCol = false;
        isStopAnim = false;
        
    }


    public void Teleport(){
        targetIndex = Random.Range(0,1000)%target.Length;
        transform.position = target[targetIndex].position;
    }
}