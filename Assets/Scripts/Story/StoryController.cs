using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{

    public static AudioSource introMusic;
    public static AudioSource portalMusic;
    public static AudioSource portalOpen;
    public static AudioSource startGame;
    public static AudioSource phoneRing;
    public static AudioSource pickup;
    public static AudioSource ding;

    private bool _right() { return (Input.GetKeyDown(KeyCode.RightArrow)); }
    private bool _left() { return (Input.GetKeyDown(KeyCode.LeftArrow)); }
    private bool _select() { return (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)); }
    private bool _fade = false;

    private Vector3 cardPos;
    private Vector3 cardHidePos;
    private GameObject card1;
    private GameObject card2;
    private GameObject card3;
    private GameObject card4;
    private GameObject card5;
    private GameObject card6;
    private GameObject card7;
    private GameObject card8;
    private GameObject card9;
    private GameObject card10;
    private GameObject card11;
    private GameObject card12;
    private GameObject card13;
    private GameObject card14;
    private GameObject card15;
    private GameObject card16;
    private GameObject card17;

    private bool _storyEnd;
    private bool _continue;


    // Start is called before the first frame update
    void Awake()
    {
        InitAudio();


        cardPos = new Vector3(0, 0, 0);
        cardHidePos = new Vector3(0, 50, 0);

        card1 = GameObject.Find("1");
        card2 = GameObject.Find("2");
        card3 = GameObject.Find("3");
        card4 = GameObject.Find("4");
        card5 = GameObject.Find("5");
        card6 = GameObject.Find("6");
        card7 = GameObject.Find("7");
        card8 = GameObject.Find("8");
        card9 = GameObject.Find("9");
        card10 = GameObject.Find("10");
        card11 = GameObject.Find("11");
        card12 = GameObject.Find("12");
        card13 = GameObject.Find("13");
        card14 = GameObject.Find("14");
        card15 = GameObject.Find("15");
        card16 = GameObject.Find("16");

        card1.transform.position = cardPos;

        _storyEnd = false;
        _continue = false;


    }

    // Update is called once per frame
    void Update()
    {
        CardSelect();
        if (_fade == true)
        {
            FadeOut();
        }
    }

    private void CardSelect()
    {
        if (_select() && _storyEnd == true && _continue == false)
        {
            StartCoroutine(LoadGame());
        }

        if (_right())
        {
            if (card2.transform.position.x != cardPos.x)
            {
                card2.transform.position = cardPos;
                card1.transform.position = cardHidePos;
            }
            else if (card3.transform.position.x != cardPos.x)
            {
                card3.transform.position = cardPos;
                card2.transform.position = cardHidePos;
                phoneRing.Play();
                phoneRing.loop = true;
            }
            else if (card4.transform.position.x != cardPos.x)
            {
                card4.transform.position = cardPos;
                card3.transform.position = cardHidePos;
                phoneRing.mute = true;
                pickup.Play();
                
            }
            else if (card5.transform.position.x != cardPos.x)
            {
                card5.transform.position = cardPos;
                card4.transform.position = cardHidePos;
            }
            else if (card6.transform.position.x != cardPos.x)
            {
                card6.transform.position = cardPos;
                card5.transform.position = cardHidePos;
            }
            else if (card7.transform.position.x != cardPos.x)
            {
                card7.transform.position = cardPos;
                card6.transform.position = cardHidePos;
                _fade = true;                
            }
            else if (card8.transform.position.x != cardPos.x)
            {
                card8.transform.position = cardPos;
                card7.transform.position = cardHidePos;
            }
            else if (card9.transform.position.x != cardPos.x)
            {
                card9.transform.position = cardPos;
                card8.transform.position = cardHidePos;
                introMusic.mute = true;
                portalMusic.Play();
            }
            else if (card10.transform.position.x != cardPos.x)
            {
                card10.transform.position = cardPos;
                card9.transform.position = cardHidePos;
            }
            else if (card11.transform.position.x != cardPos.x)
            {
                card11.transform.position = cardPos;
                card10.transform.position = cardHidePos;
            }
            else if (card12.transform.position.x != cardPos.x)
            {
                card12.transform.position = cardPos;
                card11.transform.position = cardHidePos;
            }
            else if (card13.transform.position.x != cardPos.x)
            {
                card13.transform.position = cardPos;
                card12.transform.position = cardHidePos;
            }
            else if (card14.transform.position.x != cardPos.x)
            {
                card14.transform.position = cardPos;
                card13.transform.position = cardHidePos;
                ding.Play();
            }
            else if (card15.transform.position.x != cardPos.x)
            {
                card15.transform.position = cardPos;
                card14.transform.position = cardHidePos;
            }
            else if (card16.transform.position.x != cardPos.x)
            {
                card16.transform.position = cardPos;
                card15.transform.position = cardHidePos;
                portalOpen.Play();
                _storyEnd = true;
            }
        }
    }

    IEnumerator LoadGame()
    {
        startGame.Play();
        portalMusic.mute = true;
        _storyEnd = false;
        _continue = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GregTest");
    }

    private void InitAudio()
    {

        //Initialize audio components
        AudioSource[] audio = GetComponents<AudioSource>();
        introMusic = audio[0];
        portalMusic = audio[1];
        portalOpen = audio[2];
        startGame = audio[3];
        phoneRing = audio[4];
        pickup = audio[5];
        ding = audio[6];

        audio[0].volume = .7f;
        audio[1].volume = .65f;
        audio[2].volume = 1f;
        audio[3].volume = .5f;
        audio[4].volume = .45f;
        audio[5].volume = .45f;
        audio[6].volume = .6f;

        introMusic.Play();

    }

    private void FadeOut()
    {
        if(introMusic.volume > 0.01)
        {
            introMusic.volume -= .28f * Time.deltaTime;
        }
        else
        {
            introMusic.mute = true;
        }
    }
}
