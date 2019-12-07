using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEnd : MonoBehaviour
{
   public void videoFinished()
    {
        SceneManager.LoadScene("Menu");
    }
}
