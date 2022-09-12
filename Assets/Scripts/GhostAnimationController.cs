using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GhostAnimationController : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer { get; private set; }
    [SerializeField] private Sprite[] _runSprites;

    public float AnimationTime = 0.25f;
    public int AnimationFrame { get; private set; }

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        AnimationFrame = 0;
    }

    public void PlayRun()
    {
        Reset();
        StartCoroutine(PlayAnimation(_runSprites, true, () => { }));
    }

    IEnumerator PlayAnimation(Sprite[] sprites, bool spriteLoop, Action endFunc)
    {
        while (AnimationFrame < sprites.Length)
        {
            if (AnimationFrame >= 0 && AnimationFrame < sprites.Length)
            {
                SpriteRenderer.sprite = sprites[AnimationFrame];
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
        AnimationFrame = 0;
    }
}



