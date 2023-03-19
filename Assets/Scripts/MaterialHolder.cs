using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MaterialHolder : MonoBehaviour
{
    public Material[] materials;
    public static MaterialHolder instance;
    public ColorContainer[] cContainters;
    public GameObject portal;
    public GameObject portalCords;
    public GameObject effect;
    public GameObject portalAudioObj;
    public AudioMixer mainMixer;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("lastScene") && PlayerPrefs.GetInt("lastScene") != 0)
        {
            SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("lastScene"), LoadSceneMode.Additive);
            StartCoroutine(Set(PlayerPrefs.GetInt("lastScene")));
            BlackOut.instance.scene = PlayerPrefs.GetInt("lastScene");
        }
        else
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            StartCoroutine(Set(1));
        }

        if (PlayerPrefs.HasKey("Volume"))
        {
            if (PlayerPrefs.GetFloat("Volume") == 0f)
            {
                mainMixer.SetFloat("Volume", 0f);
            }
            else if (PlayerPrefs.GetFloat("Volume") == -80f)
            {
                mainMixer.SetFloat("Volume", -80f);
            }
        }
    }

    public void SpawnPortal()
    {
        cContainters = FindObjectsOfType<ColorContainer>();
        foreach(ColorContainer cc in cContainters)
        {
            if(!cc.isDone)
            {
                return;
            }
            else
            {
                continue;
            }
        }

        portalCords = GameObject.FindGameObjectWithTag("PortalCords");
        Instantiate(portal, portalCords.transform.position, Quaternion.identity, portalCords.transform);
        Instantiate(portalAudioObj, portalCords.transform.position, Quaternion.identity);
        Instantiate(effect, portalCords.transform.position, Quaternion.identity);
        Camera.main.gameObject.GetComponent<GrayscalePostprocess>().enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            BlackOut.instance.gameObject.GetComponent<Animator>().Play("MainBlackOut");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (SceneManager.GetActiveScene().buildIndex != 1)
            {
                BlackOut.instance.gameObject.GetComponent<Animator>().Play("GoBackBlackOut");
            }        
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public IEnumerator Set(int sceneIndex)
    {
        if (sceneIndex != 0)
        {
            yield return new WaitForSeconds(.1f);
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneIndex));
        }     
    }

    private void OnApplicationQuit()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        }    
    }
}
