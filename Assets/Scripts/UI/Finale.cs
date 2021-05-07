using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReturnToMainMenu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene("MainMenu");
    }
}
