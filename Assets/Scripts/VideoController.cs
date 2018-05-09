/*===============================================================================
  Copyright (c) 2017 PTC Inc. All Rights Reserved.

  Vuforia is a trademark of PTC Inc., registered in the United States and other 
  countries.
  ===============================================================================*/
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

[RequireComponent(typeof(VideoPlayer))]
public class VideoController : MonoBehaviour {
    private const string TAG = "VideoController";

#region PRIVATE_MEMBERS
    private VideoPlayer videoPlayer;
    //private int audioTrackCount;
#endregion //PRIVATE_MEMBERS

#region PUBLIC_MEMBERS
    public Button m_PlayButton;
    public RectTransform m_ProgressBar;
#endregion //PRIVATE_MEMBERS

#region MONOBEHAVIOUR_METHODS
    private void Awake() {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;
        transform.gameObject.GetComponent<AudioSource>().playOnAwake = false;
    }
    
    void Start() {
        // Setup Delegates
        videoPlayer.errorReceived += HandleVideoError;
        videoPlayer.started += HandleStartedEvent;
        videoPlayer.prepareCompleted += HandlePrepareCompleted;
        videoPlayer.seekCompleted += HandleSeekCompleted;
        videoPlayer.loopPointReached += HandleLoopPointReached;

        // play on awake set to false
        //videoPlayer.playOnAwake = false;
        
        LogClipInfo();
    }

    void Update() {
        if (videoPlayer.isPlaying) {
            ShowPlayButton(false);
            if (videoPlayer.frameCount < float.MaxValue) {
                float frame = (float)videoPlayer.frame;
                float count = (float)videoPlayer.frameCount;
                //Debug.Log("count: " + count);
                
                float progressPercentage = 0;

                if (count > 0)
                    progressPercentage = (frame / count) * 100.0f;

                if (m_ProgressBar != null)
                    m_ProgressBar.sizeDelta = new Vector2((float)progressPercentage, m_ProgressBar.sizeDelta.y);
            }

        } else {
            ShowPlayButton(true);
        }
    }

    void OnApplicationPause(bool pause) {
        Debug.Log("OnApplicationPause(" + pause + ") called.");
        if (pause)
            Pause();
    }

#endregion // MONOBEHAVIOUR_METHODS

#region PUBLIC_METHODS

    public void Play() {
        Debug.Log(TAG + ": Play() bgn"); 
        //Debug.Log("Play Video");
        PauseAudio(false);
        if (videoPlayer != null)
            Debug.Log(TAG + ": Play() bef videoPlayer.Play()"); 
            videoPlayer.Play();
            Debug.Log(TAG + ": Play() aft videoPlayer.Play()"); 
        ShowPlayButton(false);
        Debug.Log(TAG + ": Play() end"); 
    }

    public void Pause() {
        Debug.Log(TAG + ": Pause() bgn");
        Debug.Log("(videoPlayer != null): " + (videoPlayer != null));
        if (videoPlayer) {
            //Debug.Log("Pause Video");
            PauseAudio(true);
            videoPlayer.Pause();
            ShowPlayButton(true);
        }
        Debug.Log(TAG + ": Pause() end"); 
    }
#endregion // PUBLIC_METHODS

#region PRIVATE_METHODS
    private void PauseAudio(bool pause) {
        Debug.Log(TAG + ": PauseAudio() bgn");
        Debug.Log("pause: " + pause);
        
        Debug.Log("(videoPlayer == null): " + (videoPlayer == null));
        //if (videoPlayer != null) {
        Debug.Log("videoPlayer.audioTrackCount: " + videoPlayer.audioTrackCount);
        
            for (ushort trackNumber = 0; trackNumber < videoPlayer.audioTrackCount; ++trackNumber) {
                if (pause)
                    videoPlayer.GetTargetAudioSource(trackNumber).Pause();
                else
                    videoPlayer.GetTargetAudioSource(trackNumber).UnPause(); // 
            }
        //}
    }

    private void ShowPlayButton(bool enable) {
        m_PlayButton.enabled = enable;
        m_PlayButton.GetComponent<Image>().enabled = enable;
    }

    private void LogClipInfo() {
        Debug.Log("videoPlayer.clip == null: " + (videoPlayer.clip == null)); // true
        Debug.Log("(videoPlayer == null): " + (videoPlayer == null));         // false
        
        if (videoPlayer.clip != null) {
/*            string stats =
                "\nName: " + videoPlayer.clip.name +
                "\nAudioTracks: " + videoPlayer.clip.audioTrackCount +
                "\nFrames: " + videoPlayer.clip.frameCount +
                "\nFPS: " + videoPlayer.clip.frameRate +
                "\nHeight: " + videoPlayer.clip.height +
                "\nWidth: " + videoPlayer.clip.width +
                "\nLength: " + videoPlayer.clip.length +
                "\nPath: " + videoPlayer.clip.originalPath;
            Debug.Log(stats);
*/            
            Debug.Log("videoPlayer.clip.name: " + videoPlayer.clip.name);
            Debug.Log("videoPlayer.clip.audioTrackCount: " + videoPlayer.clip.audioTrackCount);
            Debug.Log("videoPlayer.clip.frameCount: " + videoPlayer.clip.frameCount);
            Debug.Log("videoPlayer.clip.frameRate: " + videoPlayer.clip.frameRate);
            Debug.Log("videoPlayer.clip.height: " + videoPlayer.clip.height);
            Debug.Log("videoPlayer.clip.width: " + videoPlayer.clip.width);
            Debug.Log("videoPlayer.clip.length: " + videoPlayer.clip.length);
            Debug.Log("videoPlayer.clip.originalPath: " + videoPlayer.clip.originalPath);
        } else {
            Debug.Log("videoPlayer.clip == null");
        }
    }

#endregion // PRIVATE_METHODS

#region DELEGATES
    void HandleVideoError(VideoPlayer video, string errorMsg) {
        Debug.LogError("Error: " + video.clip.name + "\nError Message: " + errorMsg);
    }

    void HandleStartedEvent(VideoPlayer video) {
        Debug.Log("Started: " + videoPlayer.clip.name);
        videoPlayer.Play();
    }

    void HandlePrepareCompleted(VideoPlayer video) {
        Debug.Log("Prepare Completed: " + video.clip.name);
    }

    void HandleSeekCompleted(VideoPlayer video) {
        Debug.Log("Seek Completed: " + video.clip.name);
    }

    void HandleLoopPointReached(VideoPlayer video) {
        Debug.Log("Loop Point Reached: " + video.clip.name);

        ShowPlayButton(true);
    }
#endregion //DELEGATES

}