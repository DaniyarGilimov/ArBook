using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala_script : MonoBehaviour {

    private float vert;

    GameObject bala;
    Animator balaAnimator;

    GameObject all;
    Animation allAnimation;

    GameObject shal;
    Animator shalAnimator;
   

    public static Vector3 trans = new Vector3(0, 0, 1.1f);
    bool wait2 = false;
    GameObject mdoor;
    Animator ani;

    

    public static int scenario = 0;
       
    void Start () {
        bala = GameObject.Find("balal_shalsky1");
        all = GameObject.Find("All");
        shal = GameObject.Find("Asian_Nomad_Old_Man1");
        shalAnimator = shal.GetComponent<Animator>();
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
            //Debug.Log(balaAnimator.GetBool("isFound"));
        }
    }



	public void Update () {
        
        if (AllAppear.isFound)
        {
            startBala();
        }
        else if (!AllAppear.isFound)
        {
            balaAnimator.SetBool("isFound", false);
            transform.Translate(new Vector3(0, 0, 0));
            transform.localPosition = new Vector3(16.63f, -15.326f, 7.27f);

            scenario = 0;
            if ((transform.eulerAngles.y != 270) || (transform.eulerAngles.x != 0) || (transform.eulerAngles.z != 0))
            {
                transform.localEulerAngles = new Vector3(0f, 270f, 0f);
            }
        }

        if (bala_push_script.doorOpened && transform.localPosition.x > 10.45)
        {
            transform.Translate(trans);
            transform.localEulerAngles =  new Vector3(0f, 257f, 0f);
        }
        else if (bala_push_script.doorOpened && transform.localPosition.x <= 10.45)
        {
            if (!balaAnimator.GetBool("isEntered"))
            {
                transform.localEulerAngles = new Vector3(0f, 270f, 0f);

                transform.Translate(new Vector3(0, 0, 0));

                balaAnimator.SetBool("isEntered", true);
                ani.SetBool("isEntered", true);
            }
            if (balaAnimator.GetCurrentAnimatorStateInfo(0).IsName("bala1_walk2") && !wait2)
            {
                transform.Translate(new Vector3(-0.8f, 0, 0.8f));
                if (transform.localPosition.x <= 7.2)
                {
                    wait2 = true;
                }
            }
            else if (wait2)
            {
                transform.Translate(new Vector3(0, 0, 0));
                balaAnimator.SetBool("isLined", true);
                wait2 = false;
                scenario = 1;
            }

        }
        switch (scenario)
        {
            case 1:
                if (transform.eulerAngles.y <= 340)
                {
                    Debug.Log(transform.localRotation.y);
                    transform.Rotate(0, 3, 0);
                }
                else if (!shalAnimator.GetBool("isDombyrad") || !balaAnimator.GetBool("isRotatedToSoz1"))
                {
                    shalAnimator.SetBool("isDombyrad", true);
                    balaAnimator.SetBool("isRotatedToSoz1", true);
                }
                break;
            case 2:
                transform.Translate(trans);
                break;
        }
    }
}
