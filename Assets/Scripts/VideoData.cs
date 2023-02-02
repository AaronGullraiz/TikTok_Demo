using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "VideoData", menuName = "VideoData/VideoData", order = 1)]
public class VideoData : ScriptableObject
{
    public VideoClip video;

    public bool isLiked = false;

    public List<CommentData> comments;
}

[System.Serializable]
public class CommentData
{
    public string name;
    public string comment;
}