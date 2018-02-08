using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caasa : MonoBehaviour {
    //GameObject cam = GameObject.Find("ARCamera");
    bool isShy = false;
    Vector3 camPos;
    GameObject batys1;
    GameObject shygis1;
    GameObject batys2;
    GameObject shygis2;
    public Animation batysAni1;
    public Animation shygisAni1;
    public Animation batysAni2;
    public Animation shygisAni2;
    GameObject all1;
    GameObject all2;

    GameObject batys3;
    GameObject shygis3;
    public Animation batysAni3;
    public Animation shygisAni3;
    GameObject all3;
    // Use this for initialization
    void Start () {
        all1 = GameObject.Find("All");
        batys1 = GameObject.Find("All/batys");
        shygis1 = GameObject.Find("All/shygis");
        shygisAni1 = shygis1.GetComponent<Animation>();
        batysAni1 = batys1.GetComponent<Animation>();


        //Second ImageTarget
        all2 = GameObject.Find("All2");
        batys2 = GameObject.Find("All2/batys");
        shygis2 = GameObject.Find("All2/shygis");
        shygisAni2 = shygis2.GetComponent<Animation>();
        batysAni2 = batys2.GetComponent<Animation>();

        //Third ImageTarget
        all3 = GameObject.Find("All3");
        batys3 = GameObject.Find("All3/batys");
        shygis3 = GameObject.Find("All3/shygis");
        shygisAni3 = shygis3.GetComponent<Animation>();
        batysAni3 = batys3.GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
        camPos = Camera.main.gameObject.transform.position;
        //Debug.Log(camPos.x + " " + camPos.y + " " + camPos.z);
        if ((camPos.z > -239) && (camPos.x > -228))
        {
            shygis1.SetActive(true);
            shygis2.SetActive(true);
            shygis3.SetActive(true);
            if (!isShy)
            {
                isShy = true;
                shygisAni1.Play("ani_shy2");
                shygisAni2.Play("ani_shy2");
                shygisAni3.Play("ani_shy2");
            }
            batys1.SetActive(false);
            batys2.SetActive(false);
            batys3.SetActive(false);
        }
        else if((camPos.z > 190) && (camPos.x < -228))
        {
            shygis1.SetActive(true);
            shygis2.SetActive(true);
            shygis3.SetActive(true);
            if (!isShy)
            {
                shygisAni1.Play("ani_shy2");
                shygisAni2.Play("ani_shy2");
                shygisAni3.Play("ani_shy2");
                isShy = true;
            }
            batys1.SetActive(false);
            batys2.SetActive(false);
            batys3.SetActive(false);
        }
        else
        {
            batys1.SetActive(true);
            batys2.SetActive(true);
            batys3.SetActive(true);
            if (isShy)
            {
                isShy = false;
                batysAni1.Play("ani_bats2");
                batysAni2.Play("ani_bats2");
                batysAni3.Play("ani_bats2");
            }
            shygis2.SetActive(false);
            shygis1.SetActive(false);
            shygis3.SetActive(false);
        }
    }
}
