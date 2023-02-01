using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPanelHandler : MonoBehaviour
{
    public VideoPlayer vp;

    public Image likeButton;
    public RawImage videoPlayerImage;

    public GameObject videoImage;

    bool likeButtonStatus = false, isVideoPlaying = false;

    private void Start()
    {
        vp.loopPointReached += Vp_loopPointReached;

        RenderTexture t = new RenderTexture(Screen.width, 1750, 0);
        vp.targetTexture = t;
        videoPlayerImage.texture = t;
    }

    private void Vp_loopPointReached(VideoPlayer source)
    {
        isVideoPlaying = false;
        videoImage.SetActive(true);
    }

    public void LikeButtonClicked()
    {
        Debug.Log("Video: "+isVideoPlaying);
        if (likeButtonStatus)
        {
            likeButton.color = Color.black;
        }
        else
        {
            likeButton.color = Color.white;
        }
        likeButtonStatus = !likeButtonStatus;
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
}