using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoStopper : MonoBehaviour
{
    public VideoPlayer video;
    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.loopPointReached += VideoFinished;
    }

    void VideoFinished(VideoPlayer player)
    {
        player.Stop();
    }
}
