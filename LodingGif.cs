using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


/// <summary>
/// ����gif��̬ͼƬ
/// </summary>
public class LodingGif : MonoBehaviour
{
    RawImage rawImage;
    List<UniGif.GifTexture> gifTextures;
    //��ǰ���ŵ�����
    int index = -1;
    //��ʱ��
    float timer = 0;


    private void Awake()
    {
        //��ȡ���
        rawImage = GetComponent<RawImage>();
        //��ȡͼƬ
        string gifpath = Application.dataPath + "/test.gif";
        Stream stream = new FileStream(gifpath, FileMode.Open, FileAccess.Read);
        byte[] bt = new byte[stream.Length];
        stream.Read(bt, 0, (int)stream.Length);

        //ʹ�ù���   Э��
        StartCoroutine(UniGif.GetTextureListCoroutine(bt, Lodinggifpic));
    }


    //�õ�ͼƬ�����   
    private void Lodinggifpic(List<UniGif.GifTexture> list, int count, int width, int hight)
    {
        //�ѵõ������������
        gifTextures = list;
        index = 0;
    }


    private void Update()
    {
        //˵����û�����꣬��ʲôҲ����
        if (index == -1)
        {
            return;
        }
        //�������
        timer += Time.deltaTime;
        if (timer >= 0.05f)
        {
            //��ʱ������
            timer = 0;
            //Ҫ����Խ������   ������һ֡ == list�е����һ��,�����²���
            if (index > gifTextures.Count - 1)
            {
                index = 0;
            }
            else
            {
                //��ʾͼƬ
                rawImage.texture = gifTextures[index++].m_texture2d;
            }
        }

    }
}
