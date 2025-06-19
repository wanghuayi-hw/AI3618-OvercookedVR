using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;
    [SerializeField] AudioSource BGMSource, YinXiaoSource, ZhaSource;
    [SerializeField] AudioClip qieCai;
    private void Awake()
    {
        Instance = this;
    }
    public void ChossBGM()
    {
        if (BGMSource.isPlaying)
        {
            BGMSource.Stop();
        }
        else
        {
            BGMSource.Play();
        }
    }
    public void ChossZha(Vector3 point)
    {
        ZhaSource.transform.position = point;
        if (ZhaSource.isPlaying)
        {
            ZhaSource.Stop();
        }
        else
        {
            ZhaSource.Play();
        }
    }
    public void Play(YinXiao yinXiao)
    {
        AudioClip audioClip = null;
        if (yinXiao == YinXiao.切菜)
        {
            audioClip = qieCai;
        }
        if (YinXiaoSource.isPlaying)
            YinXiaoSource.Stop();
        YinXiaoSource.clip = audioClip;
        YinXiaoSource.Play();

    }
}
public enum YinXiao
{
    切菜,

}
