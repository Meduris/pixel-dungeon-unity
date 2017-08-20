using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public static bool musicEnabled = true;
	public static bool soundFXEnabled = true;

	public void enableMusic() {
		musicEnabled = true;
	}

	public void disableMusic() {
		musicEnabled = false;
	}

	public void toggleMusic() {
		musicEnabled = !musicEnabled;
	}

	public void enableSoundFX() {
		soundFXEnabled = true;
	}

	public void disableSoundFX() {
		soundFXEnabled = false;
	}

	public void toggleSoundFX() {
		soundFXEnabled = !soundFXEnabled;
	}
}
