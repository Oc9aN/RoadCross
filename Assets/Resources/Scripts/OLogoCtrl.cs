using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OLogoCtrl : MonoBehaviour {
    public GameObject Logo;
    public GameObject Chicken;
    public GameObject Whale;
    public AudioSource SoundOfWhale;
    private bool LogoMoveStart = false;
	// Use this for initialization
	void Start () {
        Invoke("ChickenRemove", 2f);
        Invoke("NextScene", 7f);
    }
	
	// Update is called once per frame
	void Update () {
	}
    void LogoMove()
    {
        Logo.GetComponent<Animation>().Play();
    }
    void ChickenRemove()
    {
        Chicken.SetActive(false);
        SoundOfWhale.Play();
        Whale.SetActive(true);
        Invoke("WhaleRemove", 3f);
    }
    void WhaleRemove()
    {
        Whale.SetActive(false);
        LogoMove();
    }
    void NextScene()
    {
        SceneManager.LoadScene("OGameScene");
    }
}
