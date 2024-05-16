using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    [SerializeField] private GameObject menuLvls;
    [SerializeField] private GameObject pauseMenu;
    private Scene crntScene;

    void Start() { crntScene = SceneManager.GetActiveScene(); }

    public void OpenLvlsMenu() { menuLvls.SetActive(true); }
    public void CloseLvlsMenu() { menuLvls.SetActive(false); }
    public void BackToMenu() { SceneManager.LoadScene(0); }
    public void LoadLvl1() { SceneManager.LoadScene(1); Time.timeScale = 1f; }
    public void LoadLvl2() { SceneManager.LoadScene(2); Time.timeScale = 1f; }
    public void LoadLvl3() { SceneManager.LoadScene(3); Time.timeScale = 1f; }
    public void LoadLvl4() { SceneManager.LoadScene(4); Time.timeScale = 1f; }
    public void LoadLvl5() { SceneManager.LoadScene(5); Time.timeScale = 1f; }
    public void UnPauseBtn() { pauseMenu.SetActive(false); Time.timeScale = 1f; }
    public void PauseBtn() { Time.timeScale = 0; pauseMenu.SetActive(true); }
    public void ResetBtn() { SceneManager.LoadScene(crntScene.buildIndex); Time.timeScale = 1f; }
}
