using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class OHero : MonoBehaviour {
    public ParticleSystem Dead;
    public List<AudioSource> Sounds = new List<AudioSource>();
    public RaycastHit HeroRayHitDown;
    public bool cheak;
    private OLogs Log;
    // Use this for initialization
    void Start () {
        cheak = false;
    }

    // Update is called once per frame
    void Update () {
        Physics.Raycast(transform.position + transform.up * 0.5f, -transform.up, out HeroRayHitDown, 1.0f);
        Debug.DrawRay(transform.position + transform.up * 0.5f, -transform.up, Color.yellow);
        OnLogs();
        OnRiver();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Dead")
        {
            Sounds[0].Play();
            Dead.transform.position = transform.position;
            Dead.Play();
            Sounds[1].Play();
            Invoke("SceneChange", 2f);
            gameObject.SetActive(false);
        }
    }
    void OnRiver()
    {
        if (cheak == true)
        {
            Sounds[0].Play();
            Dead.transform.position = transform.position;
            Dead.Play();
            Sounds[1].Play();
            Invoke("SceneChange", 2f);
            gameObject.SetActive(false);
        }
    }
    void SceneChange()
    {
        SceneManager.LoadScene("OGameScene");
    }
    void OnLogs()
    {
        if (HeroRayHitDown.transform != null && HeroRayHitDown.collider.tag == "Log")
        {
            transform.parent = HeroRayHitDown.collider.transform;
        }
        else
        {
            transform.parent = null;
        }
    }
}
