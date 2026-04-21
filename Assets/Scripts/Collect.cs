using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collect : MonoBehaviour
{
    public List<GameObject> images; // Список 
    private int currentImageIndex = 0;

    private void Start()
    {
        foreach (var image in images)
        {
            image.SetActive(false);
        }
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            ActivateNextImage();
        }
    }

    private void ActivateNextImage()
    {
        
        if (currentImageIndex < images.Count)
        {
            
            images[currentImageIndex].SetActive(true);
            currentImageIndex++;
        }
        else
        {

            SceneManager.LoadScene(2);

        }
    }

}
