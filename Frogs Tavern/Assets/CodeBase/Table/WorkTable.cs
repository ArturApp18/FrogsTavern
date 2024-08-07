using System;
using UnityEngine;

namespace CodeBase.Table
{
	public class WorkTable : MonoBehaviour
	{
		[SerializeField] private bool _isReadyToOpen;
		[SerializeField] private bool _isReadyToWork;
		[SerializeField] private GameObject _workObject;
		[SerializeField] private TableAnimator _tableAnimator;
		public bool IsReadyToWork
		{
			get
			{
				return _isReadyToWork;
			}
			set
			{
				_isReadyToWork = value;
			}
		}

		private void Start()
		{
			if (!_isReadyToWork)
			{
				_tableAnimator.CloseTable();
			}
		}

		private void OnMouseDown()
		{
			if (_isReadyToOpen)
				Open();
		}

		private void Open()
		{
			_tableAnimator.OpenTable();
			_workObject.SetActive(true);
			_isReadyToWork = true;
		}

		public void Working(bool isWorking) =>
			_tableAnimator.Working(isWorking);
	}
}