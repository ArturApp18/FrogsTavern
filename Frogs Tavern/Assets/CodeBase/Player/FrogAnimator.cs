using UnityEngine;

namespace CodeBase.Player
{
	public class FrogAnimator : MonoBehaviour
	{
		private static readonly int IsWorking = Animator.StringToHash("IsWorking");
		private static readonly int IsMoving = Animator.StringToHash("IsMove");

		[SerializeField] private Animator _animator;

		public void Working(bool isWorking) =>
			_animator.SetBool(IsWorking, isWorking);	
		
		public void Moving(bool isMoving) =>
			_animator.SetBool(IsMoving, isMoving);
	}
}