using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stonks : MonoBehaviour
{
    Texture2D Stonk_Texture;
    public SpriteRenderer Sprite_Renderer;
    public float Time_Duration;
    public enum Behavior { Stop, Repeat, Scroll };
    public float Random_Range;
    public float Range_Clamp;
    public Sprite Backgroud_Image;

    public Behavior End_Behavior;

    int updates;
    int updatesPerPixel;
    int currentUpdate;

    float currentCourse;
    float currentDir;

    // Start is called before the first frame update
    void Start()
    {
        Stonk_Texture = new Texture2D(Sprite_Renderer.sprite.texture.width, Sprite_Renderer.sprite.texture.height);
        Stonk_Texture.SetPixels(Sprite_Renderer.sprite.texture.GetPixels());
        Stonk_Texture.filterMode = FilterMode.Point;
        Stonk_Texture.Apply();
        updates = (int)(Time_Duration * 50);
        updatesPerPixel = updates / Stonk_Texture.width;
        Debug.Log(updatesPerPixel.ToString());
        currentCourse = Stonk_Texture.height / 2;

        Sprite_Renderer.sprite = Sprite.Create(Stonk_Texture, new Rect(0.0f, 0.0f, Stonk_Texture.width, Stonk_Texture.height), new Vector2(0.5f, 0.5f));
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        int drawX = currentUpdate / updatesPerPixel;
        {
            currentDir = Mathf.Clamp(currentDir + UnityEngine.Random.Range(-Random_Range, Random_Range), -Range_Clamp, Range_Clamp);
            Stonk_Texture.SetPixel(drawX, (int)currentCourse, Color.green);
            Stonk_Texture.Apply();
            currentCourse += currentDir;
        }
        currentUpdate++;
        Debug.Log(currentCourse.ToString());
        Debug.Log(drawX.ToString());
        if(drawX % Stonk_Texture.width == 0)
        {
            Stonk_Texture.SetPixels(Backgroud_Image.texture.GetPixels());
            Stonk_Texture.Apply();
        }
    }
}
