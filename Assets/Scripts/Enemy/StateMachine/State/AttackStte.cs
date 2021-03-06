using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackStte : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    
    private float _lastAttackTime;
    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (_lastAttackTime<=0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _animator.Play(EnemyAnomationController.States.Attack);
        target.ApplyDamage(_damage);
    }
}
