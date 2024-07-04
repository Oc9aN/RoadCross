using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OMap : MonoBehaviour {
    List<GameObject> Maps = new List<GameObject>();
    public List<AudioSource> Sounds = new List<AudioSource>();
    public GameObject GroundObj;
    public GameObject RoadObj_1;
    public GameObject RoadObj_2;
    public GameObject TrainRoad;
    public GameObject River;
    public GameObject RemoveTitle;
    public GameObject MainCam;
    public GameObject OHero;
    public float FSpeed;
    private int GroundCount;
    private int RandomGround;
    private bool Road, cheak;
    private const float StartX = -30f, StartY = -8f, StartZ = -15f;
    private Vector3 AfterHeroPos;
    private float CamHeroDistance;
    private Animation HeroAni;
    private const int LimiteMap = 39;
    RaycastHit HeroRayHit;
    // Use this for initialization
    void Start () {
        Road = false;
        GroundCount = 0;
        CreateMap();
        HeroAni = OHero.GetComponentInChildren<Animation>();
        cheak = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (OHero.activeSelf == false)
        {
            return;
        }
        Debug.DrawRay(OHero.transform.position, OHero.transform.forward, Color.red);
        Physics.Raycast(OHero.transform.position, OHero.transform.forward, out HeroRayHit, 1.0f);
        if (OHero.GetComponentInChildren<Animation>().IsPlaying("HeroJump") == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                OHero.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                HeroAni.Play("HeroDown");
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                OHero.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                HeroAni.Play("HeroDown");
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                OHero.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                HeroAni.Play("HeroDown");
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                OHero.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                HeroAni.Play("HeroDown");
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                HeroAni.Stop();
                RemoveTitle.SetActive(false);
                HeroAni.Play("HeroJump");
                AfterHeroPos = OHero.transform.position + OHero.transform.forward;
                StartCoroutine("HeroForward");
                Physics.Raycast(OHero.transform.position, OHero.transform.forward, out HeroRayHit, 1.0f);
                if (Vector3.Distance(Maps[0].transform.position, OHero.transform.position) > CamHeroDistance
                    && (HeroRayHit.collider == null
            || HeroRayHit.collider.CompareTag("Block") == false))
                    MapTouch();
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                RemoveTitle.SetActive(false);
                HeroAni.Play("HeroJump");
                AfterHeroPos = OHero.transform.position + OHero.transform.forward;
                StartCoroutine("HeroForward");
            }
        }
        if (OHero.GetComponent<OHero>().HeroRayHitDown.collider != null)
            MainCam.transform.position = new Vector3(OHero.transform.position.x + 5.5f, MainCam.transform.position.y, MainCam.transform.position.z);
    }
    void CreateMap()
    {
        for (GroundCount = 0; GroundCount < 9;)
            Maps.Add(Instantiate(GroundObj, new Vector3(StartX, StartY, StartZ + (GroundCount++)), Quaternion.identity) as GameObject);
        for (GroundCount = 9; GroundCount < LimiteMap;)
        {
            RandomGround = Random.Range(0, 4);
            if (RandomGround == 0)
                Maps.Add(Instantiate(GroundObj, new Vector3(StartX, StartY, StartZ + (GroundCount++)), Quaternion.identity) as GameObject);
            else if (RandomGround == 1)
            {
                Maps.Add(Instantiate(RoadObj_1, new Vector3(StartX, StartY, StartZ + (GroundCount++)), Quaternion.identity) as GameObject);
                Maps.Add(Instantiate(RoadObj_2, new Vector3(StartX, StartY, StartZ + (GroundCount++)), Quaternion.identity) as GameObject);
            }
            else if (RandomGround == 2)
            {
                Maps.Add(Instantiate(TrainRoad, new Vector3(StartX, StartY, StartZ + (GroundCount++)), Quaternion.identity) as GameObject);
            }
            else if (RandomGround == 3)
            {
                Maps.Add(Instantiate(River, new Vector3(StartX, StartY, StartZ + (GroundCount++)), Quaternion.identity) as GameObject);
            }
            foreach(var i in Maps)
            {
                i.transform.parent = gameObject.transform;
            }
        }
        CamHeroDistance = Vector3.Distance(Maps[0].transform.position, OHero.transform.position);
        Debug.Log(Maps.Count);
    }
    void MapTouch()
    {
        if (Road == true)
        {
            Maps.Add(Instantiate(RoadObj_2, new Vector3(StartX, StartY, StartZ + (GroundCount++)), Quaternion.identity) as GameObject);
            Road = false;
            Destroy(Maps[0]);
            Maps.RemoveAt(0);
            Maps[Maps.Count - 1].transform.parent = gameObject.transform;
            return;
        }
        RandomGround = Random.Range(0, 4);
        if (RandomGround == 0)
        {
            Maps.Add(Instantiate(GroundObj, new Vector3(StartX, StartY, StartZ + (GroundCount++)), Quaternion.identity) as GameObject);
        }
        else if(RandomGround == 1)
        {
            Maps.Add(Instantiate(RoadObj_1, new Vector3(StartX, StartY, StartZ + (GroundCount++)), Quaternion.identity) as GameObject);
            Road = true;
        }
        else if (RandomGround == 2)
        {
            Maps.Add(Instantiate(TrainRoad, new Vector3(StartX, StartY, StartZ + (GroundCount++)), Quaternion.identity) as GameObject);
        }
        else if (RandomGround == 3)
        {
            Maps.Add(Instantiate(River, new Vector3(StartX, StartY, StartZ + (GroundCount++)), Quaternion.identity) as GameObject);
        }
        Destroy(Maps[0]);
        Maps.RemoveAt(0);
        Maps[Maps.Count - 1].transform.parent = gameObject.transform;
    }
    IEnumerator HeroForward()
    {
        bool Jump = false;
        if (HeroRayHit.collider == null
            || HeroRayHit.collider.CompareTag("Block") == false)
            Jump = true;
        int a = Random.Range(0, 6);
        Sounds[a].Play();
        if (Vector3.Distance(Maps[1].transform.position, OHero.transform.position + OHero.transform.forward) >= CamHeroDistance)
        {
            cheak = true;
        }
        while (Jump)
        {
            if (OHero.activeSelf == false)
            {
                yield break;
            }
            if (Vector3.Distance(OHero.transform.position, AfterHeroPos) >= 0.1f)
            {
                OHero.transform.position += OHero.transform.forward * Time.deltaTime * FSpeed;
                if (Vector3.Distance(OHero.transform.position, AfterHeroPos) >= 1f)
                {
                    Debug.Log(Vector3.Distance(OHero.transform.position, AfterHeroPos));
                    OHero.transform.position = new Vector3(Mathf.Round(OHero.transform.position.x), OHero.transform.position.y, Mathf.Round(OHero.transform.position.z - 1));
                    if (Vector3.Distance(Maps[0].transform.position, OHero.transform.position) >= CamHeroDistance)
                        MainCam.transform.position = new Vector3(MainCam.transform.position.x, MainCam.transform.position.y, Mathf.Round(MainCam.transform.position.z - 1));
                    yield break;
                }
                if (OHero.GetComponent<OHero>().HeroRayHitDown.collider == null && OHero.transform.rotation == Quaternion.Euler(0f, 90f, 0f) || OHero.transform.rotation == Quaternion.Euler(0f, -90f, 0f) || cheak == true)
                    MainCam.transform.position += OHero.transform.forward * Time.deltaTime * FSpeed;
            }
            else
            {
                Debug.Log("CB");
                OHero.transform.position = new Vector3(Mathf.Round(OHero.transform.position.x), OHero.transform.position.y, Mathf.Round(OHero.transform.position.z));
                if (OHero.GetComponent<OHero>().HeroRayHitDown.collider == null)
                    MainCam.transform.position = new Vector3(MainCam.transform.position.x, MainCam.transform.position.y, Mathf.Round(MainCam.transform.position.z));
                cheak = false;
                if (OHero.GetComponent<OHero>().HeroRayHitDown.collider != null && OHero.GetComponent<OHero>().HeroRayHitDown.collider.tag == "Dead")
                {
                    OHero.GetComponent<OHero>().cheak = true;
                }
                yield break;
            }
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }
}