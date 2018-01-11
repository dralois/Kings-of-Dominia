﻿using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
	public static SoundEffectManager Instance = null;

	[SerializeField] private AudioClip m_CanonDominoContact;
	[SerializeField] private AudioClip m_MenuClose;
	[SerializeField] private AudioClip m_MenuOpen;
	[SerializeField] private AudioClip m_DominoFall;
	[SerializeField] private AudioClip m_DominoSetting;
	[SerializeField] private AudioClip[] m_CanonShots;
	[SerializeField] private AudioClip m_GateClose;
	[SerializeField] private AudioClip m_GateOpen;
	[SerializeField] private AudioClip m_Schalter;

	private AudioSource[] myAudioSources;

	private void Awake()
	{
        //-----------------------------------------------------------------
        //Erstelle eine Instanz falls nicht vorhanden
        //-----------------------------------------------------------------
        if (Instance == null)
        {
            Instance = this;
        }
        //-----------------------------------------------------------------
        //..Oder lösche falls diese Instanz nicht die Instanz ist
        //-----------------------------------------------------------------
        else if (Instance != this)
            Destroy(this);

        myAudioSources = new AudioSource[1];

		GameObject l_NewSource = new GameObject("AddedSource");
		SoundUtilities.AddAudioListener(l_NewSource, false, 1.0f, false);
		l_NewSource.transform.parent = transform;
		myAudioSources[0] = l_NewSource.GetComponent<AudioSource>();
	}

	public void PlayOpenMenu()
	{
		PlaySound(m_MenuOpen);   
	}

	public void PlayCloseMenu()
	{
		PlaySound(m_MenuClose);
	}

	public void PlayCanonDominoContact()
	{
		PlaySound(m_CanonDominoContact);
	}

	public void PlayDominoFall()
	{
		PlaySound(m_DominoFall);
	}

	public void PlayDominoSetting()
	{
		PlaySound(m_DominoSetting);
	}

	public void PlayCanonShot()
	{
		PlayRandomSound(m_CanonShots);
	}

	public void PlayGateClose()
	{
		PlaySound(m_GateClose);
	}

	public void PlayGateOpen()
	{
		PlaySound(m_GateOpen);
	}

	public void PlaySchalter()
	{
		PlaySound(m_Schalter);
	}

	private void PlaySound(AudioClip clip)
	{
		foreach (AudioSource aS in myAudioSources)
		{
			if (aS.playOnAwake == true)
			{
				continue;
			}
			else
			{
				SoundUtilities.PlaySound(aS, clip);
			}
		}
	}

	private void PlayRandomSound(AudioClip[] clips)
	{
		foreach (AudioSource aS in myAudioSources)
		{
			if (aS.playOnAwake == true)
			{
				continue;
			}
			else
			{
				SoundUtilities.PlayRandomSound(aS, clips);
			}
		}
	}
}