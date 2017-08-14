using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelectWindowButton : MonoBehaviour {
	public GameObject heroDescription;
	public GameObject heroSelect;
	public GameObject start;

	public Text btnHero;
	public Text desc;

	private enum HeroClass
	{
		none,
		Warrior,
		Mage,
		Rogue,
		Huntress
	};
	private HeroClass selected ;

	public void Warrior()
	{
		if (selected != HeroClass.Warrior)
		{
			selected = HeroClass.Warrior;
			return;
		}
		ShowInfo();
	}

	public void Mage()
	{
		if (selected != HeroClass.Mage)
		{
			selected = HeroClass.Mage;
			return;
		}
		ShowInfo();
	}

	public void Rogue()
	{
		if (selected != HeroClass.Rogue)
		{
			selected = HeroClass.Rogue;
			return;
		}
		ShowInfo();
	}

	public void Huntress()
	{
		if (selected != HeroClass.Huntress)
		{
			selected = HeroClass.Huntress;
			return;
		}
		ShowInfo();
	}

	public void Back()
	{
		heroDescription.SetActive(false);
		heroSelect.SetActive(false);
		start.SetActive(true);
	}

	private void ShowInfo()
	{
		btnHero.text = GetName();

		desc.text = GetDesc();

		heroDescription.SetActive(true);
	}

	private String GetName()
	{
		String result = "error";
		switch (selected)
		{
			case HeroClass.Warrior:
				result = "Warrior";
				break;
			case HeroClass.Mage:
				result = "Mage";
				break;
			case HeroClass.Rogue:
				result = "Rogue";
				break;
			case HeroClass.Huntress:
				result = "Huntress";
				break;
			default:
				result = "error";
				break;
		}
		return result;
	}

	private String GetDesc()
	{
		String result = "error";

		switch (selected)
		{
			case HeroClass.Warrior:
				result = "- Warriors start with 11 points of Strength.\n" +
							"- Warriors start with a unique short sword. This sword can be later \"reforged\" to upgrade another melee weapon.\n" +
							"- Warriors are less proficient with missile weapons.\n" +
							"- Any piece of food restores some health when eaten.\n" +
							"- Potions of Strength are identified from the beginning.";
				break;
			case HeroClass.Mage:
				result = "- Mages start with a unique Wand of Magic Missile. This wand can be later \"disenchanted\" to upgrade another wand.\n" +
							"- Mages recharge their wands faster.\n" +
							"- When eaten, any piece of food restores 1 charge for all wands in the inventory.\n" +
							"- Mages can use wands as a melee weapon.\n" +
							"- Scrolls of Identify are identified from the beginning.";
				break;
			case HeroClass.Rogue:
				result = "- Rogues start with a Ring of Shadows+1.\n" +
							"- Rogues identify a type of a ring on equipping it.\n" +
							"- Rogues are proficient with light armor, dodging better while wearing one.\n" +
							"- Rogues are proficient in detecting hidden doors and traps.\n" +
							"- Rogues can go without food longer.\n" +
							"- Scrolls of Magic Mapping are identified from the beginning.";
				break;
			case HeroClass.Huntress:
				result = "- Huntresses start with 15 points of Health.\n" +
							"- Huntresses start with a unique upgradeable boomerang.\n" +
							"- Huntresses are proficient with missile weapons and get a damage bonus for excessive strength when using them.\n" +
							"- Huntresses gain more health from dewdrops.\n" +
							"- Huntresses sense neighbouring monsters even if they are hidden behind obstacles.";
				break;
			default:
				break;
		}

		return result;
	}
}
