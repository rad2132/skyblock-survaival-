using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockBreakingVisualiser : MonoBehaviour
{
    private List<Animator> animators = new();
    private ParticleSystem _particleSystem;
    private AudioSource _audio;
    public float AnimationSpeed = 0.5f;
    
    private void Awake()
    {
        TryGetComponent(out _particleSystem);
        TryGetComponent(out _audio);
        
        animators = GetComponentsInChildren<Animator>().ToList();
        foreach (Animator animator in animators)
        {
            animator.gameObject.SetActive(false);
        }
    }

    public void OnBreakingStart()
    {
        _particleSystem.Play();
        _audio.Play();
        
        foreach(Animator animator in animators)
        {
            animator.gameObject.SetActive(true);
            animator.speed = AnimationSpeed;
            animator.Play("BlockBreaking");
        }
    }

    public void OnBreakingStop()
    {
        _particleSystem.Stop();
        _audio.Stop();

        foreach (Animator animator in animators)
        {
            animator.gameObject.SetActive(false);
        }
    }
}