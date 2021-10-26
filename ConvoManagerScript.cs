using UnityEngine;

public class ConvoManagerScript : MonoBehaviour
{
	public StudentManagerScript SM;

	public int NearbyStudents;

	public int Week;

	public int ID;

	public bool Eighties;

	public string[] FemaleCombatAnims;

	public string[] MaleCombatAnims;

	public int CombatAnimID;

	public float CheckTimer;

	public bool Confirmed;

	public int Cycles;

	public void Start()
	{
		if (!MissionModeGlobals.MissionMode && DateGlobals.Week == 1)
		{
			Week = 1;
		}
		Eighties = GameGlobals.Eighties;
	}

	public void CheckMe(int StudentID)
	{
		if (!Eighties)
		{
			switch (StudentID)
			{
			case 2:
				if (SM.Students[3].Routine && (double)Vector3.Distance(SM.Students[2].transform.position, SM.Students[3].transform.position) < 1.4)
				{
					SM.Students[2].Alone = false;
				}
				else
				{
					SM.Students[2].Alone = true;
				}
				break;
			case 3:
				if (SM.Students[2].Routine && (double)Vector3.Distance(SM.Students[3].transform.position, SM.Students[2].transform.position) < 1.4)
				{
					SM.Students[3].Alone = false;
				}
				else
				{
					SM.Students[3].Alone = true;
				}
				break;
			case 11:
				if (SM.Students[10] != null)
				{
					if (SM.Students[10].Routine && Vector3.Distance(SM.Students[11].transform.position, SM.Students[10].transform.position) < 2.1f)
					{
						SM.Students[11].Alone = false;
					}
					else
					{
						SM.Students[11].Alone = true;
					}
				}
				else
				{
					SM.Students[11].Alone = true;
				}
				break;
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
				NearbyStudents = 0;
				ID = 21;
				while (ID < 26)
				{
					if (ID != StudentID)
					{
						if (SM.Students[ID] != null)
						{
							if (SM.Students[ID].Routine && (double)Vector3.Distance(SM.Students[ID].transform.position, SM.Students[StudentID].transform.position) < 2.5)
							{
								SM.Students[StudentID].Alone = false;
								break;
							}
							SM.Students[StudentID].Alone = true;
						}
						else
						{
							SM.Students[StudentID].Alone = true;
						}
					}
					ID++;
					if (ID == StudentID)
					{
						SM.Students[StudentID].Alone = true;
					}
				}
				break;
			default:
				if (StudentID > 25 && StudentID < 31)
				{
					for (ID = 26; ID < 31; ID++)
					{
						if (ID != StudentID)
						{
							if (SM.Students[ID] != null)
							{
								if (SM.Students[ID].Routine && (double)Vector3.Distance(SM.Students[ID].transform.position, SM.Students[StudentID].transform.position) < 2.5)
								{
									SM.Students[StudentID].Alone = false;
									break;
								}
								SM.Students[StudentID].Alone = true;
							}
							else
							{
								SM.Students[StudentID].Alone = true;
							}
						}
					}
					break;
				}
				if (StudentID > 35 && StudentID < 41)
				{
					NearbyStudents = 0;
					ID = 36;
					while (ID < 41)
					{
						if (ID != StudentID)
						{
							if (SM.Students[ID] != null)
							{
								if (SM.Students[ID].Routine && (double)Vector3.Distance(SM.Students[ID].transform.position, SM.Students[StudentID].transform.position) < 2.5)
								{
									SM.Students[StudentID].Alone = false;
									break;
								}
								SM.Students[StudentID].Alone = true;
							}
							else
							{
								SM.Students[StudentID].Alone = true;
							}
						}
						ID++;
						if (ID == StudentID)
						{
							SM.Students[StudentID].Alone = true;
						}
					}
					break;
				}
				if (StudentID > 45 && StudentID < 51)
				{
					for (ID = 46; ID < 51; ID++)
					{
						if (ID != StudentID)
						{
							if (SM.Students[ID] != null)
							{
								if (SM.Students[ID].Routine && (double)Vector3.Distance(SM.Students[ID].transform.position, SM.Students[StudentID].transform.position) < 2.5)
								{
									SM.Students[StudentID].Alone = false;
									break;
								}
								SM.Students[StudentID].Alone = true;
							}
							else
							{
								SM.Students[StudentID].Alone = true;
							}
						}
					}
					break;
				}
				if (StudentID > 30 && StudentID < 36)
				{
					for (ID = 31; ID < 36; ID++)
					{
						if (ID != StudentID)
						{
							if (SM.Students[ID] != null)
							{
								if (SM.Students[ID].Routine && (double)Vector3.Distance(SM.Students[ID].transform.position, SM.Students[StudentID].transform.position) < 2.5)
								{
									SM.Students[StudentID].Alone = false;
									break;
								}
								SM.Students[StudentID].Alone = true;
							}
							else
							{
								SM.Students[StudentID].Alone = true;
							}
						}
					}
					break;
				}
				switch (StudentID)
				{
				case 11:
					if (SM.Students[6] != null)
					{
						if (SM.Students[6].Routine && (double)Vector3.Distance(SM.Students[11].transform.position, SM.Students[6].transform.position) < 1.4)
						{
							SM.Students[11].Alone = false;
						}
						else
						{
							SM.Students[11].Alone = true;
						}
					}
					else
					{
						SM.Students[11].Alone = true;
					}
					break;
				case 6:
					if (SM.Students[11] != null)
					{
						if (SM.Students[11].Routine && (double)Vector3.Distance(SM.Students[6].transform.position, SM.Students[11].transform.position) < 1.4)
						{
							SM.Students[6].Alone = false;
						}
						else
						{
							SM.Students[6].Alone = true;
						}
					}
					break;
				case 56:
				case 57:
				case 58:
				case 59:
				case 60:
					for (ID = 56; ID < 61; ID++)
					{
						if (ID != StudentID)
						{
							if (SM.Students[ID] != null)
							{
								if (SM.Students[ID].Routine && Vector3.Distance(SM.Students[ID].transform.position, SM.Students[StudentID].transform.position) < 2.66666f)
								{
									SM.Students[StudentID].Alone = false;
									break;
								}
								SM.Students[StudentID].Alone = true;
							}
							else
							{
								SM.Students[StudentID].Alone = true;
							}
						}
					}
					break;
				default:
					if (StudentID > 60 && StudentID < 66)
					{
						for (ID = 61; ID < 66; ID++)
						{
							if (ID != StudentID)
							{
								if (SM.Students[ID] != null)
								{
									if (SM.Students[ID].Routine && Vector3.Distance(SM.Students[ID].transform.position, SM.Students[StudentID].transform.position) < 2.66666f)
									{
										SM.Students[StudentID].Alone = false;
										break;
									}
									SM.Students[StudentID].Alone = true;
								}
								else
								{
									SM.Students[StudentID].Alone = true;
								}
							}
						}
					}
					else if (StudentID > 65 && StudentID < 71)
					{
						for (ID = 66; ID < 71; ID++)
						{
							if (ID != StudentID)
							{
								if (SM.Students[ID] != null)
								{
									if (SM.Students[ID].Routine && Vector3.Distance(SM.Students[ID].transform.position, SM.Students[StudentID].transform.position) < 2.66666f)
									{
										SM.Students[StudentID].Alone = false;
										break;
									}
									SM.Students[StudentID].Alone = true;
								}
								else
								{
									SM.Students[StudentID].Alone = true;
								}
							}
						}
					}
					else if (StudentID > 75 && StudentID < 81)
					{
						for (ID = 76; ID < 81; ID++)
						{
							if (ID != StudentID)
							{
								if (SM.Students[ID] != null)
								{
									if ((double)Vector3.Distance(SM.Students[ID].transform.position, SM.Students[StudentID].transform.position) < 2.5)
									{
										SM.Students[StudentID].TrueAlone = false;
										if (SM.Students[ID].Routine)
										{
											SM.Students[StudentID].Alone = false;
											break;
										}
										SM.Students[StudentID].Alone = true;
									}
									else
									{
										SM.Students[StudentID].TrueAlone = true;
										SM.Students[StudentID].Alone = true;
									}
								}
								else
								{
									SM.Students[StudentID].TrueAlone = true;
									SM.Students[StudentID].Alone = true;
								}
							}
						}
					}
					else
					{
						if (StudentID <= 80 || StudentID >= 86)
						{
							break;
						}
						for (ID = 81; ID < 86; ID++)
						{
							if (ID != StudentID)
							{
								if (SM.Students[ID] != null)
								{
									if (SM.Students[ID].Routine && (double)Vector3.Distance(SM.Students[ID].transform.position, SM.Students[StudentID].transform.position) < 2.5)
									{
										SM.Students[StudentID].Alone = false;
										break;
									}
									SM.Students[StudentID].Alone = true;
								}
								else
								{
									SM.Students[StudentID].Alone = true;
								}
							}
						}
					}
					break;
				}
				break;
			}
			if (Week != 1)
			{
				return;
			}
			switch (StudentID)
			{
			case 25:
				if (SM.Students[30] != null && SM.Students[30].Routine && (double)Vector3.Distance(SM.Students[25].transform.position, SM.Students[30].transform.position) < 1.4)
				{
					SM.Students[25].Alone = false;
				}
				else
				{
					SM.Students[25].Alone = true;
				}
				break;
			case 30:
				if (SM.Students[25] != null && SM.Students[25].Routine && (double)Vector3.Distance(SM.Students[25].transform.position, SM.Students[25].transform.position) < 1.4)
				{
					SM.Students[30].Alone = false;
				}
				else
				{
					SM.Students[30].Alone = true;
				}
				break;
			}
			switch (StudentID)
			{
			case 24:
				if (SM.Students[27] != null && SM.Students[27].Routine && (double)Vector3.Distance(SM.Students[24].transform.position, SM.Students[27].transform.position) < 1.4)
				{
					SM.Students[24].Alone = false;
				}
				else
				{
					SM.Students[24].Alone = true;
				}
				break;
			case 27:
				if (SM.Students[24] != null && SM.Students[24].Routine && (double)Vector3.Distance(SM.Students[24].transform.position, SM.Students[27].transform.position) < 1.4)
				{
					SM.Students[27].Alone = false;
				}
				else
				{
					SM.Students[27].Alone = true;
				}
				break;
			}
		}
		else
		{
			if (StudentID >= 13)
			{
				return;
			}
			for (ID = 2; ID < 13; ID++)
			{
				if (ID != StudentID)
				{
					if (SM.Students[ID] != null)
					{
						if (SM.Students[ID].Routine && Vector3.Distance(SM.Students[ID].transform.position, SM.Students[StudentID].transform.position) < 2.66666f)
						{
							SM.Students[StudentID].Alone = false;
							break;
						}
						SM.Students[StudentID].Alone = true;
					}
					else
					{
						SM.Students[StudentID].Alone = true;
					}
				}
			}
		}
	}

	public void MartialArtsCheck()
	{
		CheckTimer += Time.deltaTime;
		if ((CheckTimer > 1f || Confirmed) && SM.Students[47] != null && SM.Students[49] != null && SM.Students[47].Routine && SM.Students[49].Routine && SM.Students[47].DistanceToDestination < 0.1f && SM.Students[49].DistanceToDestination < 0.1f)
		{
			Confirmed = true;
			CombatAnimID++;
			if (CombatAnimID > 2)
			{
				CombatAnimID = 1;
			}
			SM.Students[47].ClubAnim = MaleCombatAnims[CombatAnimID];
			SM.Students[49].ClubAnim = FemaleCombatAnims[CombatAnimID];
			SM.Students[47].GetNewAnimation = false;
			SM.Students[49].GetNewAnimation = false;
			Cycles++;
			if (Cycles == 10)
			{
				SM.UpdateMartialArts();
				Cycles = 0;
			}
		}
	}

	public void LateUpdate()
	{
		CheckTimer = Mathf.MoveTowards(CheckTimer, 0f, Time.deltaTime);
		if (!Confirmed)
		{
			return;
		}
		if (SM.Students[47].Routine && SM.Students[49].Routine)
		{
			if (SM.Students[47].DistanceToPlayer < 1.5f || SM.Students[49].DistanceToPlayer < 1.5f || SM.Students[47].Talking || SM.Students[49].Talking || SM.Students[47].Distracted || SM.Students[49].Distracted || SM.Students[47].TurnOffRadio || SM.Students[49].TurnOffRadio)
			{
				if (SM.Students[47].DistanceToPlayer < 1.5f || SM.Students[49].DistanceToPlayer < 1.5f)
				{
					SM.Students[47].Subtitle.UpdateLabel(SubtitleType.IntrusionReaction, 2, 5f);
				}
				SM.Students[47].ClubAnim = "idle_20";
				SM.Students[49].ClubAnim = "f02_idle_20";
				Confirmed = false;
			}
		}
		else
		{
			SM.Students[47].ClubAnim = "idle_20";
			SM.Students[49].ClubAnim = "f02_idle_20";
			Confirmed = false;
		}
	}
}
