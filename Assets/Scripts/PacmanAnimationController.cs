using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PacmanAnimationController : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer { get; private set; }
    [SerializeField] private Sprite[] _StartSprites;
    [SerializeField] private Sprite[] _runSprites;
    [SerializeField] private Sprite[] _DeathSprites;

    public float AnimationTime = 0.25f;
    public int AnimationFrame { get; private set; }

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        AnimationFrame = 0;
    }

    public void PlayStart()
    {
        Reset();
        StartCoroutine(PlayAnimation(_StartSprites, false, GetComponent<PacmanController>().StartMoving));
    }

    public void PlayRun()
    {
        Debug.Log("PlayRun");
        Reset();
        StartCoroutine(PlayAnimation(_runSprites, true, () => { }));
    }

    public void PlayDeath()
    {
        Reset();
        StartCoroutine(PlayAnimation(_DeathSprites, false, () => { }));
    }

    IEnumerator PlayAnimation(Sprite[] sprites, bool spriteLoop, Action endFunc)
    {
        while(AnimationFrame < sprites.Length)
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
