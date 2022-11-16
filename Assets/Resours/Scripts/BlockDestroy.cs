using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockDestroy : MonoBehaviour
{
    private PlayerLogic Player;
    private MeshRenderer MatRender; 
    public TextMeshPro CountText; 
    public Material[] Materials;

    public ParticleSystem DestroyEffect;

    public int Count;
    public float DestroyTime;
    public float Rate = 1f;
    private void Awake()
    {
        MatRender = GetComponent<MeshRenderer>();
        Player = GameObject.Find("Snake").GetComponent<PlayerLogic>();
        Count = Random.Range(1, 40);
        CountText.text = Count.ToString();

        if(Count >= 1 && Count < 5)
            MatRender.material = Materials[0];
        else if(Count >= 5 && Count < 10)
            MatRender.material = Materials[1];
        else if(Count >= 10 && Count < 15)
            MatRender.material = Materials[2];
        else if(Count >= 15 && Count < 20)
            MatRender.material = Materials[3];
        else if(Count >= 20 && Count < 30)
            MatRender.material = Materials[4];
        else if(Count >= 30)
            MatRender.material = Materials[5];  
    }  
    public void Destroy(PlayerLogic player)
    {
        if (Count > 0)
        {
            player.RemoveElement();
            player.Score += 1;
            player.ScoreText.text = player.Score.ToString();
            DestroyEffect.Play();
            Count -= 1;
            CountText.text = Count.ToString();  
            if (Count <= 0)
                Destroy(gameObject);
        }
        else
            Destroy(gameObject); 
    }


    private void OnCollisionStay(Collision collision)
    { 
        if (collision.gameObject.tag == "Snake" && Time.time > DestroyTime)
        {
            DestroyTime = Time.time + 1f / Rate;
            Destroy(Player);
        }
    }
}
