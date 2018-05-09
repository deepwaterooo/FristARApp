﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System;

public class VideoPlayerTeach : MonoBehaviour {
    private const string TAG = "VideoPlayerTeach";

    public RawImage image; // 图像
    //public string urlNetWork = "http:// www.quirksmode.org/html5/videos/big_buck_bunny.mp4";// 网络视频路径

    public Button playBtn;
    public Button pauseBtn;
    public Button forwardBtn;
    public Button backwardBtn;
    // 下一个
    //public Button btn_Next;
    public Slider sliderVideo;
    public Slider sliderSource;
    // 音量大小
    //public Text text;
    // 当前视频时间
    public Text currTime;
    // 视频总时长
    public Text totalTime;

    // 需要添加播放器的物体
    public GameObject obj;
    // 是否拿到视频总时长
    public bool isShow;
    // 前进后退的大小
    public float numBer = 20f;

    private VideoPlayer vPlayer;
    private AudioSource source;
    
    // 时分的转换
    private int hour, mint;
    private float time;
    private float time_Count;
    private float time_Current;
    // 视频是否播放完成
    private bool isVideo;

    void Start () {
        image = obj.GetComponent<RawImage>();
        vPlayer = GetComponent<VideoPlayer>();
        source = GetComponent<AudioSource>();

        // 这3个参数不设置也会没声音 唤醒时就播放关闭
        vPlayer.playOnAwake = false;
        source.playOnAwake = false;
        source.Pause();
        //Init(urlNetWork); 

        playBtn.onClick.AddListener(delegate { OnClick(0); });
        pauseBtn.onClick.AddListener(delegate { OnClick(1); });
        forwardBtn.onClick.AddListener(delegate { OnClick(2); });
        backwardBtn.onClick.AddListener(delegate { OnClick(3); });
        //btn_Next.onClick.AddListener(delegate { OnClick(4); });

        sliderSource.value = source.volume;
        //text.text = string.Format("{0:0}%", source.volume * 100);
        sliderSource.onValueChanged.AddListener(delegate { ChangeSource(sliderSource.value); });
    }

    // 初始化VideoPlayer
    private void Init(string url) {
        isVideo = true;
        isShow = true;
        time_Count = 0;
        time_Current = 0;
        sliderVideo.value = 0;
        // 设置为URL模式
        //vPlayer.source = VideoSource.Url;
        // 设置播放路径
        //vPlayer.url = url;

        // 在视频中嵌入的音频类型
        vPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        // 把声音组件赋值给VideoPlayer
        vPlayer.SetTargetAudioSource(0, source);

        // 当VideoPlayer全部设置好的时候调用
        vPlayer.prepareCompleted += Prepared;
        // 启动播放器
        vPlayer.Prepare();
    }

    // 改变音量大小
    public void ChangeSource(float value) {
        source.volume = value;
        //text.text = string.Format("{0:0}%", value * 100);
    }

    // 改变视频进度
    public void ChangeVideo(float value) {
        if (vPlayer != null && vPlayer.isPrepared) {
            vPlayer.time = (long)value; 
            Debug.Log("VideoPlayer Time: " + vPlayer.time);
            time = (float)vPlayer.time;
            hour = (int)time / 60;
            mint = (int)time % 60;
            currTime.text = string.Format("{0:D2}:{1:D2}", hour.ToString(), mint.ToString());
        }
    }

    private void OnClick(int num) {
        Debug.Log(TAG + ": OnClick() bgn"); 
        switch (num) {
            case 0:
                Debug.Log("play button clicked");
                playBtn.enabled = false;
                vPlayer.Play();
                pauseBtn.enabled = true;
                Time.timeScale = 1;
                break;
            case 1:
                Debug.Log("pause button clicked");
                pauseBtn.enabled = false;
                vPlayer.Pause();
                playBtn.enabled = true;
                Time.timeScale = 0;
                break;
            case 2:
                sliderVideo.value = sliderVideo.value + numBer;
                break;
            case 3:
                sliderVideo.value = sliderVideo.value - numBer;
                break;
                case 4:
                vPlayer.Stop();
                Init(Application.streamingAssetsPath + "/VuforiaSizzle.mp4");  // update
                break;
            default:
                break;
        }
        Debug.Log(TAG + ": OnClick() end"); 
    }
    
    // Update is called once per frame
    void Update () {
        if (vPlayer.isPlaying && isShow) {
            // 把图像赋给RawImage
            //image.texture = vPlayer.texture;
            // 帧数/帧速率=总时长    如果是本地直接赋值的视频，我们可以通过VideoClip.length获取总时长
            //sliderVideo.maxValue = vPlayer.frameCount/vPlayer.frameRate;
            sliderVideo.maxValue = (float)vPlayer.clip.length;
            
            time = sliderVideo.maxValue;
            hour = (int)time / 60;
            mint = (int)time % 60;
            totalTime.text = string.Format("/  {0:D2}:{1:D2}", hour.ToString(), mint.ToString());

            Debug.Log("sliderVideo.value: " + sliderVideo.value);
            sliderVideo.onValueChanged.AddListener(delegate { ChangeVideo(sliderVideo.value); });
            isShow = !isShow;
        }

        if (Mathf.Abs((int)vPlayer.time - (int)sliderVideo.maxValue) == 0) {
            vPlayer.frame = (long)vPlayer.frameCount;
            vPlayer.Stop();
            Debug.Log("Video play finished！");
            isVideo = false;
            return;
        } else if (isVideo && vPlayer.isPlaying) {
            time_Count += Time.deltaTime;
            if ((time_Count - time_Current) >= 1) {
                sliderVideo.value +=  1;
                Debug.Log("value:" + sliderVideo.value);
                time_Current = time_Count;
            }
        }
    }

    void Prepared(VideoPlayer player) {
        player.Play();
    }
}
