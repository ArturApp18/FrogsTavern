using UnityEngine;

namespace CodeBase.Table
{
	public class TableAnimator : MonoBehaviour
	{
		private static readonly int IsWorking = Animator.StringToHash("IsWorking");
		private static readonly int Open = Animator.StringToHash("Open");
		private static readonly int Close = Animator.StringToHash("Close");
		
		[SerializeField] private Animator _animator;

		public void Working(bool isWorking) =>
			_animator.SetBool(IsWorking, isWorking);		
		
		public void OpenTable() =>
			_animator.SetTrigger(Open);		
		
		public void CloseTable() =>
			_animator.SetTrigger(Close);
	}
}