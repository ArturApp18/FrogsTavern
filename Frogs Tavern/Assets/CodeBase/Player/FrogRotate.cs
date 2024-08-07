using UnityEngine;

namespace CodeBase.Player
{

	public class FrogRotate : MonoBehaviour
	{
		[SerializeField] private FrogWorkingWithTable _workingWithTable;
		[SerializeField] private GameObject[] _frontPart;
		[SerializeField] private GameObject[] _backPart;
		[SerializeField] private bool _isLookUp;

		public bool IsLookUp => _isLookUp;

		public void RotateToUp()
		{
			if (_workingWithTable.IsWorking)
			{
				if (_isLookUp)
					RotateToDown();

				return;
			}
			_isLookUp = true;

			foreach (GameObject part in _backPart)
			{
				part.SetActive(true);
			}

			foreach (GameObject part in _frontPart)
			{
				part.SetActive(false);
			}
		}

		public void RotateToDown()
		{
			_isLookUp = false;

			foreach (GameObject part in _frontPart)
			{
				part.SetActive(true);
			}

			foreach (GameObject part in _backPart)
			{
				part.SetActive(false);
			}
		}
	}
}