using UnityEngine;
using UnityEngine.UI;

public class MainMenuControllerAuto : MonoBehaviour
{
    private GameObject manuPanel;
    private Button gameTitleButton;
    private Button playButton;
    private Button tutorialButton;
    private Button settingsButton;
    private Button exitButton;

    public GameObject character;

    private bool isMenuVisible = false;

    void Start()
    {
        gameTitleButton = GameObject.Find("GameTittle").GetComponent<Button>();
        manuPanel = GameObject.Find("ManuPanel");

        playButton = GameObject.Find("Play").GetComponent<Button>();
        tutorialButton = GameObject.Find("Tutorial").GetComponent<Button>();
        settingsButton = GameObject.Find("Settings").GetComponent<Button>();
        exitButton = GameObject.Find("Exit").GetComponent<Button>();
        character = GameObject.Find("Character");

        manuPanel.SetActive(false);

        gameTitleButton.onClick.AddListener(ToggleMenu);
        playButton.onClick.AddListener(PlayGame);
        tutorialButton.onClick.AddListener(OpenTutorial);
        settingsButton.onClick.AddListener(OpenSettings);
        exitButton.onClick.AddListener(ExitGame);
        character.SetActive(false);
    }

    public void ToggleMenu()
    {
        isMenuVisible = !isMenuVisible;
        character.SetActive(isMenuVisible);
        manuPanel.SetActive(isMenuVisible);
        
    }

    public void PlayGame()
    {
        Debug.Log("▶️ Play Game");
        // TODO: SceneManager.LoadScene("GameScene");
    }

    public void OpenTutorial()
    {
        Debug.Log("📘 Tutorial");
    }

    public void OpenSettings()
    {
        Debug.Log("⚙️ Settings");
    }

    public void ExitGame()
    {
        Debug.Log("❌ Exit Game");
        Application.Quit();
    }
}
