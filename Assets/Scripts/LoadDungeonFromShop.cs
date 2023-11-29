using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadDungeonFromShop : MonoBehaviour
{

    public GameObject fadePanelObject;
    public Image fadePanel;
    public ImageFade ImageFade;

    void Awake()
    {
        fadePanelObject = GameObject.Find("Fade Out");
        fadePanel = fadePanelObject.GetComponent<Image>();

    }

    void Start()
    {
        fadePanelObject.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void toDungeon()
    {
        fadePanelObject.SetActive(true);
        ImageFade.fadeIn();

        // Assuming that ImageFade.fadeIn() handles the fade-in animation asynchronously
        StartCoroutine(LoadSceneAfterFade("SewerLayout"));
    }

    private IEnumerator LoadSceneAfterFade(string sceneName)
    {
        // Wait for the fade-in animation to complete
        yield return new WaitForSeconds(ImageFade.fadeDuration);

        // Load the desired scene
        SceneManager.LoadScene(sceneName);
    }

}
