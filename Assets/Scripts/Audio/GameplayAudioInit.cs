using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayAudioInit : MonoBehaviour
{

    public AudioSource levelMusic;
    public static AudioSource bounce;
    public static AudioSource chomp1;
    public static AudioSource chomp2;
    public static AudioSource chomp3;
    public static AudioSource crumble;
    public static AudioSource dash;
    public static AudioSource enemyHit1;
    public static AudioSource jump;
    public static AudioSource pickup;
    public static AudioSource playerDamage1;
    public static AudioSource playerDamage2;
    public static AudioSource vaseBreak;

    // Start is called before the first frame update
    void Awake()
    {
        InitAudio();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InitAudio()
    {
        AudioSource[] audio = GetComponents<AudioSource>();
        levelMusic = audio[0];
        bounce = audio[1];
        chomp1 = audio[2];
        chomp2 = audio[3];
        chomp3 = audio[4];
        crumble = audio[5];
        dash = audio[6];
        enemyHit1 = audio[7];
        jump = audio[8];
        pickup = audio[9];
        playerDamage1 = audio[10];
        playerDamage2 = audio[11];
        vaseBreak = audio[12];

        audio[0].volume = .85f;
        audio[1].volume = 1f;
        audio[2].volume = .65f;
        audio[3].volume = .65f;
        audio[4].volume = .65f;
        audio[5].volume = .5f;
        audio[6].volume = .5f;
        audio[7].volume = .5f;
        audio[8].volume = .2f;
        audio[9].volume = .5f;
        audio[10].volume = .5f;
        audio[11].volume = 1f;

        audio[0].mute = false;

        /*Mutes all audio sources*/
        //for (int i = 0; i < audio.Length; i++)
        //{
        //    audio[i].mute = true;
        //}

    }

}
