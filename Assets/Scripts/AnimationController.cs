using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimationController : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer { get; private set; }
    [SerializeField] private Sprite[] _sprites;

    public float AnimationTime = 0.25f;
    public int AnimationFrame { get; private set; }

    public bool SpriteLoop = true; 

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    private void Start()
    {
        InvokeRepeating(nameof(NextFrame), AnimationTime, AnimationTime);
    }

    private void NextFrame()
    {
        AnimationFrame++;

        if (AnimationFrame >= _sprites.Length && SpriteLoop)
        {
            AnimationFrame = 0; 
        }

        if (AnimationFrame >= 0 && AnimationFrame < _sprites.Length)
        {
            SpriteRenderer.sprite = _sprites[AnimationFrame]; 
        }
    }

    public void Restart()
    {
        AnimationFrame = -1; 
        NextFrame();
    }
}
