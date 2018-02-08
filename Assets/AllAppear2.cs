using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AllAppear2 : MonoBehaviour, ITrackableEventHandler
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

    public static bool isFinishedSecond = false;


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
        bala = GameObject.Find("balal_shalsky2");
        animatorBala = bala.GetComponent<Animator>();
        all = GameObject.Find("All2");
        pol = GameObject.Find("All2/muha");
        shygis = GameObject.Find("All2/shygis");
        batys = GameObject.Find("All2/batys");
        pro = GameObject.Find("All2/project");
        aniBala = bala.GetComponent<Animation>();
        aniPro = pro.GetComponent<Animation>();
        aniShy = shygis.GetComponent<Animation>();
        aniBat = batys.GetComponent<Animation>();
        aniPol = pol.GetComponent<Animation>();
        aniAll = all.GetComponent<Animation>();
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

            isFinishedSecond = false;
            canv.SetActive(false);
            isFound = true;

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
            isFound = false;
        }
    }
    void Update()
    {
        if (!aniAll.isPlaying && isFinishedSecond)
        {
            camPos = Camera.main.gameObject.transform.position;
            if ((camPos.z > -239) && (camPos.x > -228))
            {
                Debug.Log("Eminem2");
                aniAll.Play("ani_all_shy_close");

            }
            else if ((camPos.z > 190) && (camPos.x < -228))
            {
                Debug.Log("Eminem2");
                aniAll.Play("ani_all_shy_close");
            }
            else
            {
                Debug.Log("Eminem2");
                aniAll.Play("ani_all_bats_close");
            }
        }
    }
}
