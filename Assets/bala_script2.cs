using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala_script2 : MonoBehaviour {

    GameObject bala;
    Animator balaAnimator;

    GameObject all;
    Animation allAnimation;

    GameObject shal;
    Animator shalAnimator;


    private Vector3 trans = bala_script.trans;
    bool wait2 = false;
    GameObject mdoor;
    Animator ani;

    void Start () {
        bala = GameObject.Find("balal_shalsky2");
        all = GameObject.Find("All2");
        shal = GameObject.Find("Asian_Nomad_Old_Man2");
        shalAnimator = shal.GetComponent<Animator>();
        balaAnimator = bala.GetComponent<Animator>();
        allAnimation = all.GetComponent<Animation>();
    }
	

	void Update () {
        if (AllAppear2.isFound)
        {

        }
        else if (!AllAppear2.isFound)
        {

        }
    }


}
