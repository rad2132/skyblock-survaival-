using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockBreakingVisualiser : MonoBehaviour
{
    private List<Animator> animators = new();
    private ParticleSystem _particleSystem;
    public float AnimationSpeed = 0.5f;
    
    private void Awake()
    {
        TryGetComponent(out _particleSystem);
        
        animators = GetComponentsInChildren<Animator>().ToList();
        foreach (Animator animator in animators)
        {
            animator.gameObject.SetActive(false);
        }
    }

    public void OnBreakingStart()
    {
        _particleSystem.Play();
        
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
        
        foreach (Animator animator in animators)
        {
            animator.gameObject.SetActive(false);
        }
    }
}