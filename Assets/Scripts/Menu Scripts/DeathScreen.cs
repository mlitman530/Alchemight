using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void BackToShop()
    {
        SceneManager.LoadScene("Shop");
    }
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
