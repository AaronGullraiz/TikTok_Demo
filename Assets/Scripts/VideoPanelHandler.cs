using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPanelHandler : MonoBehaviour
{
    public VideoPlayer vp;

    public Image likeButton;
    public RawImage videoPlayerImage;

    public GameObject videoImage;
    public VideoData data;

    public Initializer parent;

    bool likeButtonStatus = false, isVideoPlaying = false;

    private void Start()
    {
        vp.loopPointReached += Vp_loopPointReached;

        RenderTexture t = new RenderTexture(Screen.width, 1750, 0);
        vp.targetTexture = t;
        videoPlayerImage.texture = t;

        likeButtonStatus = data.isLiked;
        if (!likeButtonStatus)
        {
            likeButton.color = Color.black;
        }
        else
        {
            likeButton.color = Color.white;
        }
        vp.clip = data.video;
    }

    private void Vp_loopPointReached(VideoPlayer source)
    {
        isVideoPlaying = false;
        videoImage.SetActive(true);
    }

    public void LikeButtonClicked()
    {
        if (likeButtonStatus)
        {
            likeButton.color = Color.black;
        }
        else
        {
            likeButton.color = Color.white;
        }
        likeButtonStatus = !likeButtonStatus;
        data.isLiked = likeButtonStatus;
    }

    public void VideoButtonClicked()
    {
        if (isVideoPlaying)
        {
            if (vp.isPlaying)
            {
                vp.Pause();
            }
            videoImage.SetActive(true);
        }
        else
        {
            vp.Play();
            videoImage.SetActive(false);
        }
        isVideoPlaying = !isVideoPlaying;
    }

    public void ShareVideoClicked()
    {
        parent.ShareClicked();
    }
    public void CommentClicked()
    {
        parent.CommentClicked(data);
    }

    public void OnShowPage()
    {
        if (!vp.isPlaying)
        {
            VideoButtonClicked();
        }
    }

    public void OnHidePage()
    {
        if (vp.isPlaying)
        {
            VideoButtonClicked();
        }
    }
}