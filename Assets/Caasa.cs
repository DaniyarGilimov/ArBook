using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caasa : MonoBehaviour {
    //GameObject cam = GameObject.Find("ARCamera");
    bool isShy = false;
    Vector3 camPos;
    GameObject batys;
    GameObject shygis;
    public Animation batysAni;
    public Animation shygisAni;
    GameObject all;
    // Use this for initialization
    void Start () {
        all = GameObject.Find("All");
        batys = GameObject.Find("batys");
        shygis = GameObject.Find("shygis");
        shygisAni = shygis.GetComponent<Animation>();
        batysAni = batys.GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
        camPos = Camera.main.gameObject.transform.position;
        //Debug.Log(camPos.x + " " + camPos.y + " " + camPos.z);
        if ((camPos.z > -239) && (camPos.x > -228))
        {
            shygis.SetActive(true);
            if (!isShy)
            {
                isShy = true;
                shygisAni.Play("ani_shy2");
            }
            batys.SetActive(false);
        }else if((camPos.z > 190) && (camPos.x < -228))
        {
            shygis.SetActive(true);
            if (!isShy)
            {
                shygisAni.Play("ani_shy2");
                isShy = true;
            }
            batys.SetActive(false);
        }
        else
        {
            batys.SetActive(true);
            if (isShy)
            {
                isShy = false;
                batysAni.Play("ani_bats2");
            }
           
            shygis.SetActive(false);
        }
    }
}
