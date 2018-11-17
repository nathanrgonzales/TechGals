using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
	// How far from the new position we should be before snapping to it.
	public Transform MainAxis;
	// Axis that moves the camera
	public Transform ShakeAxis;
	// Axis that shakes the camera

	// For moving camera
	public bool IsMoving { get; private set; }

	// For shaking camera
	private bool _isShaking = false;
	private int _shakeCount;
	private float _shakeIntensity, _shakeSpeed, _baseX, _baseY;
	private Vector3 _nextShakePosition;


	void Start ()
	{
		enabled = false;

		// Set up base positions, these are used for shaking to determine where to return to after a shake.
		_baseX = ShakeAxis.localPosition.x;
		_baseY = ShakeAxis.localPosition.y;
	}

	
	void Update ()
	{
		if (_isShaking) {
			// Move toward the previously determined next shake position
			ShakeAxis.localPosition = Vector3.MoveTowards (ShakeAxis.localPosition, _nextShakePosition, Time.deltaTime * _shakeSpeed);

			// Determine if we are there or not
			if (Vector2.Distance (ShakeAxis.localPosition, _nextShakePosition) < _shakeIntensity / 5f) {
				//Decrement shake counter
				_shakeCount--;

				// If we are done shaking, turn this off if we're not longer moving
				if (_shakeCount <= 0) {
					_isShaking = false;
					ShakeAxis.localPosition = new Vector3 (_baseX, _baseY, ShakeAxis.localPosition.z);
					if (!IsMoving)
						enabled = false;
				}
                // If there is only 1 shake left, return back to base
                else if (_shakeCount <= 1) {
					_nextShakePosition = new Vector3 (_baseX, _baseY, ShakeAxis.localPosition.z);
				}
                // If we are not done or nearing done, determine the next position to travel to
                else {
					DetermineNextShakePosition ();
				}
			}
		}
	}


	/// <summary>
	/// Move the camera in a certain direction by a certain distance.
	/// </summary>
	/// <param name="x">Distance along x axis to move.</param>
	/// <param name="y">Distance along y axis to move.</param>
	/// <param name="speed">How quickly to move in specified direction.</param>


	/// <summary>
	/// Immediately sets the position of the camera
	/// </summary>

	/// <summary>
	/// Shakes the camera. Essentially places some random points around the camera and lerps it to them.
	/// </summary>
	/// <param name="intensity">Max distance from the center point the camera will travel.</param>
	/// <param name="shakes">Total number of random points the camera will travel to.</param>
	/// <param name="speed">How quickly the camera moves from point to point.</param>

	private void DetermineNextShakePosition ()
	{
		_nextShakePosition = new Vector3 (Random.Range (-_shakeIntensity, _shakeIntensity),
			Random.Range (-_shakeIntensity, _shakeIntensity),
			ShakeAxis.localPosition.z);
	}
}