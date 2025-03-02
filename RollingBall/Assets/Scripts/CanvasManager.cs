using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{

    [SerializeField] private GameObject Base;
    [SerializeField] private GameObject ConfigMenu;

    public void onStartButtonClicked()
    {

        SceneManager.LoadScene(1);
    }

    public void onOptionsButtonClicked()
    {
        if (Base.activeSelf) {

            Base.SetActive(false);
            ConfigMenu.SetActive(true);

        } else {

            Base.SetActive(true);
            ConfigMenu.SetActive(false);
        }

    }

    public void onQuitButtonClicked()
    {

        Application.Quit();
    }
}

