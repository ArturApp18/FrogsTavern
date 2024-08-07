using System;
using SimpleInputNamespace;
using UnityEngine;

namespace CodeBase.Player
{
	public class FrogMove : MonoBehaviour
	{
		private const float Epsilon = 0.001f;

		[SerializeField] private Joystick _joystick;
		[SerializeField] private FrogAnimator _animator;
		[SerializeField] private FrogRotate _rotate;
		[SerializeField] private Rigidbody2D _rigidbody2D;
		[SerializeField] private float _movementSpeed;
		private bool _isMoving;
		public bool IsMoving
		{
			get
			{
				return _isMoving;
			}
			set
			{
				_isMoving = value;
				_animator.Moving(_isMoving);
			}
		}

		private void Update()
		{
			Vector2 movementVector = Vector2.zero;

			Vector2 axis = new Vector2(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));

			if (axis.sqrMagnitude > Epsilon)
			{
				movementVector = axis.normalized;
				IsMoving = true;
			}
			else
			{
				IsMoving = false;
			}

			_rigidbody2D.velocity = movementVector * _movementSpeed;

			switch (axis.y)
			{
				case > Epsilon when !_rotate.IsLookUp:
					_rotate.RotateToUp();
					break;
				case < -Epsilon when _rotate.IsLookUp:
					_rotate.RotateToDown();
					break;
			}
		}
	}
}