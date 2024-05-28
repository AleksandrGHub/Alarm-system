using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]

public class Robber : MonoBehaviour
{
    private const string Fire1 = "Fire1";
    private const string Jump = "Jump";
    private const string Horizontal = "Horizontal";
    private const string LeftShift = "left shift";

    private Animator _animator;
    private SpriteRenderer _sprite;
    private Rigidbody2D _rigidbody;
    private float _speed;
    private float _jumpForce = 5.0f;
    private bool _isComplete = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_isComplete)
        {
            if (Input.GetButtonDown(Fire1))
            {
                _isComplete = false;
                _animator.SetTrigger(AnimatorController.State.PunchAttack);
            }

            if (Input.GetButtonDown(Jump))
            {
                JumpUp();
            }

            if (Input.GetButton(Horizontal))
            {
                if (Input.GetKey(LeftShift))
                {
                    _speed = 6;
                    Walk(_speed);
                    _animator.SetBool(AnimatorController.State.Run, true);
                }
                else
                {
                    _animator.SetBool(AnimatorController.State.Run, false);
                }

                _speed = 2;
                Walk(_speed);
                _animator.SetBool(AnimatorController.State.Walk, true);
            }
            else
            {
                _animator.SetBool(AnimatorController.State.Walk, false);
                _animator.SetBool(AnimatorController.State.Run, false);
            }
        }
    }

    private void Walk(float speed)
    {
        Vector3 direction = transform.right * Input.GetAxis(Horizontal);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        _sprite.flipX = direction.x < 0.0F;
    }

    private void JumpUp()
    {
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        _animator.SetTrigger(AnimatorController.State.Jump);
    }

    private void AssignIsCompleteTrue()
    {
        _isComplete = true;
    }
}