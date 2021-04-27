using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private bool _restartKey() { return (Input.GetKeyDown(KeyCode.R)); }
    private bool _continue;

    public AudioSource gameOverMusic;
    public static AudioSource restart;

    // Start is called before the first frame update
    void Awake()
    {
        InitAudio();
        _continue = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_restartKey() && _continue == false)
        {
            StartCoroutine(LoadGame());
        }
    }

    private void InitAudio()
    {
        AudioSource[] audio = GetComponents<AudioSource>();
        gameOverMusic = audio[0];
        restart = audio[1];

        audio[0].volume = .7f;
        audio[1].volume = .6f;
    }

    IEnumerator LoadGame()
    {
        restart.Play();
        gameOverMusic.mute = true;
        _continue = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GregTest");
    }
}
