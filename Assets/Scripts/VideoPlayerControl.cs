using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System;

public class VideoPlayerControl : MonoBehaviour {
    private const string TAG = "VideoPlayerControl";

    public Sprite playBtnSprite;
    public Sprite pauseBtnSprite;
    public VideoClip[] videoClips;
    public Button playBtn;
    public Button forwardBtn;
    public Button backwardBtn;
    public Button nextClipBtn;  
    public Slider sliderVideo;
    public Slider sliderSource;
    public Text currTime;   
    public Text totalTime;  
    public PlayHeadMover playHeadMover;
    public float numBer = 20f;  
    public bool hasGotTotalTime;   
    public GameObject carSelection;
    
    private VideoPlayer videoPlayer;
    private AudioSource audioSource;
    private int videoClipIndex;
    private int minutes, seconds;      
    private float time;
    private float time_Count;
    private float time_Current;
    private bool isPlayFinished;   
    private CarSelector carSelector;
    
    void Awake () {
        videoPlayer = GetComponent<VideoPlayer>();
        audioSource = GetComponent<AudioSource>();
        carSelector = carSelection.GetComponent<CarSelector>();
    }

    void Start() {
        videoPlayer.clip = videoClips[0];
        
        playBtn.onClick.AddListener(delegate {
                PlayPause();
            });
        forwardBtn.onClick.AddListener(delegate {
                OnClick(0);
            });
        backwardBtn.onClick.AddListener(delegate {
                OnClick(1);
            });
        nextClipBtn.onClick.AddListener(delegate {
                SetNextClip();
            });
        sliderSource.value = audioSource.volume;
        sliderSource.onValueChanged.AddListener(delegate {
                ChangeAudioSource(sliderSource.value);
            });
        sliderVideo.onValueChanged.AddListener(delegate {
                UpdateVideoAndSlider(sliderVideo.value);
            });
        SetTotalTime();
    }

    void Update () {
        if (videoPlayer.isPlaying) {
            SetCurrentTime((float)videoPlayer.time);
            playHeadMover.MovePlayHead(CalculatePlayedFraction());
        }
        
        if (videoPlayer.isPlaying && hasGotTotalTime) {
            sliderVideo.maxValue = (float)videoPlayer.clip.length;
            time = sliderVideo.maxValue;
            hasGotTotalTime = !hasGotTotalTime;
        }
        if (Mathf.Abs((int)videoPlayer.time - (int)sliderVideo.maxValue) == 0) {
            videoPlayer.frame = (long)videoPlayer.frameCount;
            videoPlayer.Stop();
            isPlayFinished = false;
            return;
        } else if (isPlayFinished && videoPlayer.isPlaying) {
            time_Count += Time.deltaTime;
            if ((time_Count - time_Current) >= 1) {
                sliderVideo.value +=  1;
                time_Current = time_Count;
            }
        }
    }

    public void SetNextClip() {
        if (carSelector.latestActiveCarIndex >= 0) 
            carSelector.DeactivatePreviousGameObjects();
        bool isPlaying = false;
        if (videoPlayer.isPlaying) {
            isPlaying = true;
            videoPlayer.Pause();
            playBtn.GetComponent<Image>().sprite = playBtnSprite;
        }
        ++videoClipIndex;
        if (videoClipIndex >= videoClips.Length) 
            videoClipIndex = videoClipIndex % videoClips.Length;
        videoPlayer.clip = videoClips[videoClipIndex];
        SetTotalTime();
        if (isPlaying) {
            videoPlayer.Play();
            playBtn.GetComponent<Image>().sprite = pauseBtnSprite;
        }
    }

    public void PlayPause() {
        if (carSelector.latestActiveCarIndex >= 0) 
            carSelector.DeactivatePreviousGameObjects();
        if (videoPlayer.isPlaying) {
            videoPlayer.Pause();
            playBtn.GetComponent<Image>().sprite = playBtnSprite;
        } else {
            videoPlayer.Play();
            playBtn.GetComponent<Image>().sprite = pauseBtnSprite;
        }
    }
    
    public void ChangeAudioSource(float value) {  
        audioSource.volume = value;
    }

    public void UpdateVideoAndSlider(float value) {  
        if (videoPlayer.isPlaying && videoPlayer.isPrepared) {
            videoPlayer.time = (long)value;
            SetCurrentTime(value);
        }
    }

    void SetCurrentTime(float value) {
        minutes = (int)value / 60; 
        seconds = (int)value % 60;
        currTime.text = string.Format("{0:D2}:{1:D2}", minutes.ToString(), seconds.ToString("00"));
    }

    void SetTotalTime() {
        sliderVideo.maxValue = (float)videoPlayer.clip.length;
        time = sliderVideo.maxValue;
        minutes = (int)time / 60;
        seconds = (int)time % 60;
        totalTime.text = string.Format("{0:D2}:{1:D2}", minutes.ToString(), seconds.ToString());
    }
    
    double CalculatePlayedFraction() { 
        double fraction = (double)videoPlayer.frame / (double)videoPlayer.clip.frameCount;
        return fraction;
    }
    
    void OnClick(int num) {
        switch (num) {
        case 0:
            sliderVideo.value = (float)videoPlayer.time + numBer;
            break;
        case 1:
            sliderVideo.value = (float)videoPlayer.time - numBer;
            break;
        default:
            break;
        }
    }

    void Prepared(VideoPlayer player) {
        player.Play();
    }
}
