using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Initializer : MonoBehaviour
{
    public GameObject videoGroup,commentPrefab;
    public Transform videoObjectPlaceholder, commentsPlaceholder;

    public VideoData[] videoDatas;

    public ScrollRect scroller;

    [SerializeField]
    private GameObject shareVideoObject, commentObject;

    private VideoData currentVideoData;

    private int currentPlayingVideo = 0;

    void Start()
    {
        for (int i = 0; i < videoDatas.Length; i++)
        {
            var ob = (Instantiate(videoGroup, videoObjectPlaceholder)as GameObject).GetComponent<VideoPanelHandler>();
            ob.data = videoDatas[i];
            ob.parent = this;
            if(i == 0)
            {
                ob.VideoButtonClicked();
            }
        }


    }

    public void TextFieldEditEnd(InputField input)
    {
        var comment = input.text.Trim();
        if (comment.Length > 0)
        {
            var c = new CommentData();
            c.name = "Me";
            c.comment = comment;
            currentVideoData.comments.Add(c);
            var ob = (Instantiate(commentPrefab, commentsPlaceholder) as GameObject).GetComponent<CommentHandler>();
            ob.SetComment(c);
        }
        input.text = "";
    }

    public void ShareClicked()
    {
        shareVideoObject.SetActive(true);
    }

    public void CommentClicked(VideoData vData)
    {
        currentVideoData = vData;

        for (int i = 0; i < commentsPlaceholder.childCount; i++)
        {
            Destroy(commentsPlaceholder.GetChild(i).gameObject);
        }

        for (int i = 0; i < vData.comments.Count; i++)
        {
            var ob = (Instantiate(commentPrefab, commentsPlaceholder) as GameObject).GetComponent<CommentHandler>();
            ob.SetComment(vData.comments[i]);
        }

        commentObject.SetActive(true);
    }
}