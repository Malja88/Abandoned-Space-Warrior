using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AttackBehaviour : MonoBehaviour, IBehavior
{
    public Transform PlayerTransform { private get; set; }
    public Animator animator;
    private bool _isAttaking;
    [SerializeField] private float _attackDistance;
    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    public void Behave()
    {
        if (_isAttaking) return;
        StopCoroutine(StartAttackCoroutine());
        animator.CrossFade("Attack", 0.1f);
        StartCoroutine(StartAttackCoroutine());
    }
    public float Evaluate()
    {
        if (PlayerTransform == null) return 0;
        {
            return Vector3.Distance(transform.position, PlayerTransform.position) < _attackDistance ? 1 : 0;
        }      
    }
    private IEnumerator StartAttackCoroutine()
    {
        _isAttaking = true;
        yield return new WaitForSeconds(0.6f);
        _isAttaking = false;
    }
}
