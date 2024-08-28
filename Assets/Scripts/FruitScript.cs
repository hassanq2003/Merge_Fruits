using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class FruitScript : MonoBehaviour
{
    public float offSetYNewFruit = 2f;
    public GameObject Strawberry;
    public GameObject BlackBerry;
    public GameObject RaspBerry;
    public GameObject Peach;
    public GameObject Apple;
    public GameObject Pear;
    public GameObject Banana;
    public GameObject Orange;
    public GameObject Coconut;
    public GameObject StarFruit;
    public GameObject Watermelon;

    
    public int Points_when_Fruit_Merges=0;//different for different fruits(change in inspector of prefabs)

    Score_Manager score_Manager;

    // Start is called before the first frame update
    void Start()
    {
        score_Manager=FindObjectOfType<Score_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        if(rigidbody2D!=null)
        {
            if(rigidbody2D.isKinematic==true)
            {
                FindObjectOfType<Game_Manager>().GameOver();
            }
        }
        if(collision.gameObject.tag == gameObject.tag)
        {
            if(transform.position.y < collision.transform.position.y)
            {
                mergeFruit(gameObject.tag);
                if(score_Manager!=null)
                {
               
                score_Manager.AddToScore(Points_when_Fruit_Merges);
                }
                Destroy(collision.gameObject);
                Destroy(gameObject);

            }
            else if (transform.position.y == collision.transform.position.y)
            {
                if(transform.position.x < collision.transform.position.x)
                {
                    mergeFruit(gameObject.tag);
                    if(score_Manager!=null)
                    {
                    
                    score_Manager.AddToScore(Points_when_Fruit_Merges);
                    }
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }

    void mergeFruit(string fruitTag)
    {
        if(fruitTag == "Cherry")
        {
            Instantiate(Strawberry,instantiationPosition(),transform.rotation);
        }
        else if(fruitTag == "Strawberry")
        {
            Instantiate(RaspBerry, instantiationPosition(), transform.rotation);
        }
        else if (fruitTag == "Berry")
        {
            Instantiate(Peach, instantiationPosition(), transform.rotation);
        }
        else if (fruitTag == "Peach")
        {
            Instantiate(Apple, instantiationPosition(), transform.rotation);
        }
        else if (fruitTag == "Apple")
        {
            Instantiate(Pear, instantiationPosition(), transform.rotation);
        }
        else if (fruitTag == "Pear")
        {
            Instantiate(Banana, instantiationPosition(), transform.rotation);
        }
        else if (fruitTag == "Banana")
        {
            Instantiate(Coconut, instantiationPosition(), transform.rotation);
        }
        else if (fruitTag == "Coconut")
        {
            Instantiate(StarFruit, instantiationPosition(), transform.rotation);
        }
        else if (fruitTag == "StarFruit")
        {
            Instantiate(Watermelon, instantiationPosition(), transform.rotation);
        }
    }
    Vector3 instantiationPosition()
    {
        return transform.position + (Vector3.up * offSetYNewFruit);
    }
}
