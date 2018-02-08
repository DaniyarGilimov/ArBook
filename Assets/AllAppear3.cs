using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AllAppear3 : MonoBehaviour, ITrackableEventHandler
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
    GameObject shal;
    Animator shalAnimator;


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

        shal = GameObject.Find("Asian_Nomad_Old_Man3");
        shalAnimator = shal.GetComponent<Animator>();
        canv = GameObject.Find("Canvas");
        bala = GameObject.Find("balal_shalsky3");
        animatorBala = bala.GetComponent<Animator>();
        all = GameObject.Find("All3");
        pol = GameObject.Find("All3/muha");
        shygis = GameObject.Find("All3/shygis");
        batys = GameObject.Find("All3/batys");
        pro = GameObject.Find("All3/project");
        aniPro = pro.GetComponent<Animation>();
        aniShy = shygis.GetComponent<Animation>();
        aniBat = batys.GetComponent<Animation>();
        aniPol = pol.GetComponent<Animation>();
        aniAll = all.GetComponent<Animation>();
        //shalAnimator.SetBool("isFound", true);
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
            
            all.transform.localScale = new Vector3(1F, 1F, 1F);

            canv.SetActive(false);
            isFound = true;

            //.SetBool("isFound", true);

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
            shalAnimator.SetBool("isFound", false);
            canv.SetActive(true);
            isFound = false;
        }
    }
    void Update()
    {
        //if (!aniAll.isPlaying)
        //{
        //    camPos = Camera.main.gameObject.transform.position;
        //    if ((camPos.z > -239) && (camPos.x > -228))
        //    {
        //        Debug.Log("Eminem2");
        //        aniAll.Play("ani_all_shy_close");

        //    }
        //    else if ((camPos.z > 190) && (camPos.x < -228))
        //    {
        //        Debug.Log("Eminem2");
        //        aniAll.Play("ani_all_shy_close");
        //    }
        //    else
        //    {
        //        Debug.Log("Eminem2");
        //        aniAll.Play("ani_all_bats_close");
        //    }
        //}
    }
}
