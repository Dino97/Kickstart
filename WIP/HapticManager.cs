using UnityEngine;
using System.Collections;
using MoreMountains.NiceVibrations;

public static class HapticManager
{
	public static bool AllowHaptics { get; set; } = true;

	private static float _nextVibrationTime = 0.0f;



	public static void Vibrate(HapticTypes hapticType, float cooldown = 0.0f)
	{
		if (AllowHaptics)
		{
			// If no cooldown is set
			if (cooldown == 0.0f)
			{
				MMVibrationManager.Haptic(hapticType);
			}
			else
			{
				if (Time.time >= _nextVibrationTime)
				{
					MMVibrationManager.Haptic(hapticType);
					_nextVibrationTime = Time.time + cooldown;
				}
			}
		}
	}
}
