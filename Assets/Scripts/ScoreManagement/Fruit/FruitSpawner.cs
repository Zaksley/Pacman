using System.Collections;
using System.Collections.Generic;
using ScoreManagement;
using UnityEngine;
using UnityEngine.UI;

public class FruitSpawner : MonoBehaviour
{
    [Header("FruitManager")] 
    
    public int RespawnTime = 15;
    public int MaxFruitSpawn = 6;
    public int FruitPoint = 100; 

    public Sprite[] SpritesFruits;
    private List<Image> ImageDisplayFruits = new List<Image>(); 
    
    private int _eatenFruitCounter = 0;
    
    [SerializeField] private Fruit fruit; 
    
    void Start()
    {
        fruit = Instantiate(fruit);
        fruit.transform.position = transform.position;
        RandomSpriteSelector();
        GetCanvasImage();
    }

    private void GetCanvasImage()
    {
        for (int i = 0; i < MaxFruitSpawn; i++)
        {
            var imageFruit = GameObject.Find("Canvas/FruitEaten" + (i + 1)).GetComponent<Image>();
            Debug.Log(imageFruit);
            ImageDisplayFruits.Add(imageFruit);
            imageFruit.enabled = false;
        }
    }

    private void DisplayFruitEaten()
    {
        var displayFruit = ImageDisplayFruits[_eatenFruitCounter];
        displayFruit.enabled = true;
        displayFruit.sprite = fruit.GetComponent<SpriteRenderer>().sprite;
    }

    public void FruitEaten()
    {
        DisplayFruitEaten();
        fruit.gameObject.SetActive(false);
        _eatenFruitCounter++;
        
        GameManager manager = FindObjectOfType<GameManager>(); 
        manager.SetScore(manager.score + FruitPoint);
        
        if (_eatenFruitCounter < MaxFruitSpawn)
        {
            StartCoroutine(SpawnFruit());
        }
    }

    private void RandomSpriteSelector()
    {
        fruit.GetComponent<SpriteRenderer>().sprite = SpritesFruits[Random.Range(0, SpritesFruits.Length)]; 
    }
    
    IEnumerator SpawnFruit()
    {
        yield return new WaitForSeconds(RespawnTime); 
        fruit.gameObject.SetActive(true);
        RandomSpriteSelector();
    }
}
