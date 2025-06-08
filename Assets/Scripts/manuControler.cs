using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainMenuControllerAuto : MonoBehaviour
{
    private GameObject SettingsPanel;
    private Slider VolumeSlider;
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
        Debug.Log(playButton.tag);
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

        SettingsPanel = GameObject.Find("SettingsPanel");
        VolumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();

        SettingsPanel.SetActive(false);

        VolumeSlider.value = AudioListener.volume;
        VolumeSlider.onValueChanged.AddListener(SetVolume);
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
        SceneManager.LoadScene("LalicLevel1");
        // TODO: SceneManager.LoadScene("GameScene");
    }

    public void OpenTutorial()
    {
        Debug.Log("📘 Tutorial");
    }

    public void OpenSettings()
    {
        Debug.Log("⚙️ Opening Settings");
        SettingsPanel.SetActive(!SettingsPanel.activeSelf);
    }

    public void ExitGame()
    {
        Debug.Log("❌ Exit Game");
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        Debug.Log("🔊 Volume set to: " + volume);
    }

}