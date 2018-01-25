using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala_script : MonoBehaviour {

    private float vert;

    GameObject bala;
    Animator balaAnimator;

    GameObject all;
    Animation allAnimation;

    Vector3 trans = new Vector3(0, 0, 0.9f);
    bool wait2 = false;
    GameObject mdoor;
    Animator ani;
       
    void Start () {
        bala = GameObject.Find("balal_shalsky");
        all = GameObject.Find("All");
        balaAnimator = bala.GetComponent<Animator>();
        allAnimation = all.GetComponent<Animation>();
        mdoor = GameObject.Find("Door1");
        ani = mdoor.GetComponent<Animator>();

    }

    public void startBala()
    {
        if (!allAnimation.isPlaying)
        {
            balaAnimator.SetBool("isFound", true);
        }
    }



	public void Update () {
        if (AllAppear.isFound)
        {
            startBala();
        }else if (!AllAppear.isFound)
        {
            balaAnimator.SetBool("isFound", false);
            transform.Translate(new Vector3(0, 0, 0));
            transform.localPosition = new Vector3(16.63f, -15.326f, 5.81f);
        }

        if(bala_push_script.doorOpened && transform.localPosition.x > 10.45)
        {
            transform.Translate(trans);
            
        }else if (bala_push_script.doorOpened && transform.localPosition.x <= 10.45)
        {
            transform.Translate(new Vector3(0, 0, 0));
            balaAnimator.SetBool("isEntered", true);
            ani.SetBool("isEntered", true);
            bool zone = false;
            
            if (balaAnimator.GetCurrentAnimatorStateInfo(0).IsName("bala1_walk2") && !wait2)
            {
                transform.Translate(new Vector3(-0.5f, 0, 0.5f));
                if (transform.localPosition.x <= 7.2)
                {
                    wait2 = true;
                }
            }else if (wait2)
            {
                transform.Translate(new Vector3(0, 0, 0));
                Debug.Log(transform.localPosition.x);
                Debug.Log(transform.position.x);
                balaAnimator.SetBool("isLined", true);
            }

        }
    }
}
