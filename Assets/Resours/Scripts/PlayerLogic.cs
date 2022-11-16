using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    public AudioSource Aud;

    public AudioClip DestroySphereSound;
    public AudioClip AddSphereSound;

    public List<GameObject> Elements;
    public GameObject ElementPrefab;
    public Transform PlayerTransform;
    public TextMeshPro TextCount;
    public Text ScoreText;

    public GameObject LosePanel;
    public GameObject WinPanel; 

    public int Score;

    private void Start()
    {
        Time.timeScale = 1f;
        Elements.Add(gameObject);
        Aud = GetComponent<AudioSource>();
    }

    public void Pause() => Time.timeScale = 0f;
    public void Continue() => Time.timeScale = 1f;
    public void Load_Scene(int number_scene) => SceneManager.LoadScene(number_scene);

    private void OnDestroy()
    {
        LosePanel.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void AddElement(int Number)
    {
        for (int i = 0; i < Number; i++)
        {
            var Element = Instantiate(ElementPrefab, new Vector3(0, 0, 0), Quaternion.identity, PlayerTransform);
            Element.transform.localPosition = new Vector3(0, 0, 0 - Elements.Count);
            Elements.Add(Element);
            TextCount.text = (Elements.Count - 1).ToString();
        }
        Aud.PlayOneShot(AddSphereSound);
    }

    public void RemoveElement()
    {
        Destroy(Elements[Elements.Count - 1]);
        Elements.RemoveAt(Elements.Count - 1);  
        TextCount.text = (Elements.Count - 1).ToString();
        Aud.PlayOneShot(DestroySphereSound);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AddSphere")
        { 
            AddElement(other.GetComponent<Food>().CountFood);
            Destroy(other.gameObject); 
        } 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FinishS")
            WinPanel.SetActive(true);
    }
}
