using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AllAppear : MonoBehaviour, ITrackableEventHandler
{
    // Global variables

    
    
    // end Global variables
    private TrackableBehaviour mTrackableBehaviour;
    GameObject all;
    GameObject pol;
    GameObject dom;
    GameObject shygis;
    GameObject batys;
    GameObject pro;
    GameObject door;
    GameObject bala;
    GameObject canv;

    public static bool isFound = false;
    public Animation aniBala;
    public Animator aniDoor;
    public Animation aniPro;
    public Animation aniBat;
    public Animation aniShy;
    public Animation aniPol;
    public Animation aniAll;
    public Animator animatorAll;
    public Animator animatorBala;
    AudioSource ass;

    Vector3 camPos;

    void Start()
    {
        canv = GameObject.Find("Canvas");
        bala = GameObject.Find("balal_shalsky");
        animatorBala = bala.GetComponent<Animator>();
        door = GameObject.Find("Door1");
        all = GameObject.Find("All");
        pol = GameObject.Find("muha");
        shygis = GameObject.Find("shygis");
        batys = GameObject.Find("batys");
        pro = GameObject.Find("project");
        aniBala = bala.GetComponent<Animation>();
        aniDoor = door.GetComponent<Animator>();
        aniPro = pro.GetComponent<Animation>();
        aniShy = shygis.GetComponent<Animation>();
        aniBat = batys.GetComponent<Animation>();
        aniPol = pol.GetComponent<Animation>();
        aniAll = all.GetComponent<Animation>();
        ass = all.GetComponent<AudioSource>();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
    

    public void OnTrackableStateChanged(
    TrackableBehaviour.Status previousStatus,
    TrackableBehaviour.Status newStatus)
    {

        camPos = Camera.main.gameObject.transform.position;
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            canv.SetActive(false);
            aniDoor.SetBool("isFound", true);
            isFound = true;
            ass.Play();
            if ((camPos.z > -239) && (camPos.x > -228))
            {
                aniAll.Play("ani_all_shy");
            }
            else if ((camPos.z > 190) && (camPos.x < -228))
            {
            	
                aniAll.Play("ani_all_shy");
            }
            else
            {
                aniAll.Play("ani_all_bats");
            }

        }
        else
        {
            canv.SetActive(true);
            aniDoor.SetBool("isFound", false);
            aniDoor.SetBool("pushed", false);
            isFound = false;
            bala_push_script.doorOpened = false;
            ass.Stop();
        }
    }
    void Update()
    {

    }
}
