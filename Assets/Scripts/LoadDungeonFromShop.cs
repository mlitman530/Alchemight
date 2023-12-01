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

    public Inventory inventory;

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
        Dictionary<int, int> inv = inventory.GetItemCounts();
        for (int i = 0; i < 6; i++)
        {
            int test;
            if (!inv.TryGetValue(i, out test))
            {
                inv.Add(i, 0);
            }
            Debug.Log("Item " + i + " count: " + inv[i]);
        }
        PlayerPrefs.SetInt("NumHealthPotions", inv[0]);
        PlayerPrefs.SetInt("NumStrengthPotions", inv[1]);
        PlayerPrefs.SetInt("NumSpeedPotions", inv[2]);
        PlayerPrefs.SetInt("NumJumpPotions", inv[3]);
        PlayerPrefs.SetInt("SwordPurchased", inv[4]);
        PlayerPrefs.SetInt("NumFirePotions", inv[5]);
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
