using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GhostAnimationController : MonoBehaviour
{
    public SpriteRenderer spriteR { get; private set; }
    private Color gColor;
    [SerializeField] private Sprite[] _runSprites;
    [SerializeField] private Sprite[] _vulnerableRunSprites;


    public float AnimationTime = 0.25f;
    public int AnimationFrame { get; private set; }

    private void Awake()
    {
        spriteR = GetComponent<SpriteRenderer>();
        gColor = spriteR.color;
        AnimationFrame = 0;
    }

    public void PlayRun()
    {
        Reset();
        spriteR.color = gColor;
        gameObject.GetComponentsInChildren<SpriteRenderer>()[1].enabled = true;
        StartCoroutine(PlayAnimation(_runSprites, true, () => { }));
    }

    public void PlayRunVulnerable()
    {
        Reset();
        spriteR.color = Color.white;
        gameObject.GetComponentsInChildren<SpriteRenderer>()[1].enabled = false;
        StartCoroutine(PlayAnimation(_vulnerableRunSprites, true, () => { }));
    }

    IEnumerator PlayAnimation(Sprite[] sprites, bool spriteLoop, Action endFunc)
    {
        while (AnimationFrame < sprites.Length)
        {
            if (AnimationFrame >= 0 && AnimationFrame < sprites.Length)
            {
                spriteR.sprite = sprites[AnimationFrame];
            }

            AnimationFrame++;

            if (AnimationFrame >= sprites.Length && spriteLoop)
            {
                AnimationFrame = 0;
            }

            yield return new WaitForSeconds(AnimationTime);
        }

        endFunc();
    }

    private void Reset()
    {
        StopAllCoroutines();
        AnimationFrame = 0;
    }
}



