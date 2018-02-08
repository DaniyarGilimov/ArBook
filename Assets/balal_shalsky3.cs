using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balal_shalsky3 : MonoBehaviour {

    GameObject bala;
    Animator balaAnimator;

    GameObject all;
    Animation allAnimation;

    GameObject shal;
    Animator shalAnimator;

    public static bool isPointed = false;

    private Vector3 trans = bala_script.trans;
    bool wait2 = false;
    GameObject mdoor;
    Animator ani;

    // Use this for initialization
    void Start () {
        all = GameObject.Find("All3");
        shal = GameObject.Find("Asian_Nomad_Old_Man3");
        bala = GameObject.Find("balal_shalsky3");
        shalAnimator = shal.GetComponent<Animator>();
        balaAnimator = bala.GetComponent<Animator>();
        allAnimation = all.GetComponent<Animation>();
    }
	

	void Update () {
        if (!AllAppear3.isFound)
        {
            isPointed = false;
            balaAnimator.SetBool("isPointed", false);
            balaAnimator.SetBool("isSit", false);
            transform.localPosition = new Vector3(6.44f, -15.326f, 1.19f);
            transform.localEulerAngles = new Vector3(0f, -36.45f, 0f);
        }
        if (AllAppear3.isFound)
        {
            shalAnimator.SetBool("isFound", true);
        }

        if (isPointed && transform.localPosition.x >= 1.72)
        {
            balaAnimator.SetBool("isPointed", true);
            transform.Translate(trans);
        }else if(transform.localPosition.x <= 1.72)
        {
            balaAnimator.SetBool("isSit", true);
            transform.Translate(new Vector3(0, 0, 0));
        }
		
	}
}
