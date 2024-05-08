using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScr : MonoBehaviour
{
    private Animator anim;  //Animatorをanimという変数で定義する

    public GameObject lightCollider;
    private bool isHit = false;
    private bool isStopAnim = false;
    [HideInInspector] public bool isEating = false;

    string preAnimName;
    
    private AgentScr agentScr;

    public GameObject loveEffect;

    // Start is called before the first frame update
    void Start()
    {
         //変数animに、Animatorコンポーネントを設定する
        anim = gameObject.GetComponent<Animator>();
        agentScr = GetComponent<AgentScr>();
    }

    // Update is called once per frame
    void Update()
    {
        isHit = lightCollider.GetComponent<CollisionDetection2>().isHit;
        isStopAnim = GetComponent<AgentScr>().isStopAnim;


        if (isHit == true || isStopAnim == true)
        {
            anim.SetBool("isStop", true);
        }else{
            anim.SetBool("isStop", false);
        }

        
        
        if(preAnimName == "A_eat" && anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "A_eat" ){
            StartCoroutine(AfterEating());
        }
        preAnimName = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;



        
        if(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "A_eat" ){
            
        }
        if(isHit && Input.GetMouseButtonDown(0)){
            anim.SetBool("isEat",true);
            isEating = true;
        }
    }

    IEnumerator AfterEating(){
        anim.SetBool("isEat",false);
        Instantiate(loveEffect,transform.position,Quaternion.identity);
        yield return new WaitForSeconds(1);
        agentScr.Teleport();
        isEating = false;
    }

    
}