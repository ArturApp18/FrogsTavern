using CodeBase.Table;
using UnityEngine;

namespace CodeBase.Player
{
	public class FrogWorkingWithTable : MonoBehaviour
	{
		private const string WorkTable = "WorkTable";
		
		[SerializeField] private FrogAnimator _frogAnimator;
		[SerializeField] private FrogRotate _rotate;
		[SerializeField] private bool _isWorking;

		private WorkTable _currentWorkTable;
		public bool IsWorking
		{
			get
			{
				return _isWorking;
			}
			set
			{
				_isWorking = value;
			}
		}


		private void OnTriggerEnter2D(Collider2D col)
		{
			if (!col.CompareTag(WorkTable) || !col.TryGetComponent(out WorkTable workTable) || !workTable.IsReadyToWork || _currentWorkTable)
				return;

			if (_rotate.IsLookUp)
			{
				_rotate.RotateToDown();
			}
			
			if (IsTableLeft(workTable))
			{
				transform.rotation = Quaternion.Euler(0, 180, 0);
			}
			else
			{
				transform.rotation = Quaternion.Euler(0, 0, 0);
			}

			

			_isWorking = true;
			_currentWorkTable = workTable;
			_frogAnimator.Working(true);
			workTable.Working(true);
		}

		private void OnTriggerExit2D(Collider2D col)
		{
			if (!col.CompareTag(WorkTable) || !col.TryGetComponent(out WorkTable workTable) || _currentWorkTable != workTable)
				return;

			_isWorking = false;
			_currentWorkTable.Working(false);
			_currentWorkTable = null;
			_frogAnimator.Working(false);
		}

		private bool IsTableLeft(WorkTable workTable) =>
			workTable.transform.position.x < transform.position.x;

	}
}