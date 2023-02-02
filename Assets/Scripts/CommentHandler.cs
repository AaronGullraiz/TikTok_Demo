using UnityEngine;
using UnityEngine.UI;

public class CommentHandler : MonoBehaviour
{
    [SerializeField]
    private Text nameTxt, commentTxt;

    public void SetComment(CommentData data)
    {
        nameTxt.text = data.name;
        commentTxt.text = data.comment;
    }
}