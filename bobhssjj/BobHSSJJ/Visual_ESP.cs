using System;
using Entitas;
using UnityEngine;
using Veh;
using Veh.Hs;

internal class Visual_ESP
{
	public Visual_ESP(Main class12_1)
	{
		mainCam = null;
		class12_0 = class12_1;
		mainCam = Camera.main;
		espconfig_0.showEnemy = true;
		espconfig_0.showTranceline = true;
		espconfig_0.showName = true;
		espconfig_0.showHealth = true;
		espconfig_0.showBone = true;
		espconfig_0.showTeammate = false;
		espconfig_0.teamBoxCol = new ImVec4(0f, 1f, 0f, 1f);
		espconfig_0.enemyBoxCol = new ImVec4(1f, 0f, 0f, 1f);
		espconfig_0.TracelineCol = new ImVec4(1f, 1f, 1f, 1f);
		espconfig_0.showDistance = true;
		espconfig_0.BoxThickness = 1.5f;
		espconfig_0.TracelineThickness = 1.5f;
		espconfig_0.BoneThickness = 2f;
	}

	public void UpdateCamera()
	{
		mainCam = Camera.main;
	}

	Vector3 method_1(Vector3 vector3_0)
	{
		return new Vector3(-vector3_0.y, vector3_0.z, vector3_0.x);
	}

	Vector3 method_2(Vector3 vector3_0)
	{
		return new Vector3(-vector3_0.y, vector3_0.z, vector3_0.x);
	}

	Vector3 method_3(Vector3 vector3_0)
	{
		return new Vector3(vector3_0.z, -vector3_0.x, vector3_0.y);
	}

	void DrawBoneSection(ref PlayerEntity playerEntity_1, string string_0, string string_1, uint uint_0)
	{
		if (playerEntity_1 != null)
		{
            if (playerEntity_1.hasThirdPersonUnityObjects)
            {
                try
                {
                    Transform bone = playerEntity_1.thirdPersonUnityObjects.Animator.GetBone(string_0);
                    if (bone == null)
                    {
                        return;
                    }
                    Transform bone2 = playerEntity_1.thirdPersonUnityObjects.Animator.GetBone(string_1);
                    if (bone2 == null)
                    {
                        return;
                    }
                    Vector3 position = bone.position;
                    Vector3 position2 = bone2.position;
                    if ((position - mainCam.transform.position).magnitude < 8000f)
                    {
                        Vector3 vector = mainCam.WorldToScreenPoint(position);
                        Vector3 vector2 = mainCam.WorldToScreenPoint(position2);
                        bool flag;
                        if (vector.z >= 0f)
                        {
                            flag = vector2.z >= 0f;
                        }
                        else
                        {
                            flag = false;
                        }
                        if (flag)
                        {
                            IMGUI._AddLine(new ImVec2(vector.x, (float)Screen.height - vector.y), new ImVec2(vector2.x, (float)Screen.height - vector2.y), uint_0, espconfig_0.BoneThickness);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
	}

	void DrawEsp(ref PlayerEntity playerEntity_1)
	{
        if (_myPlayer != null)
        {
            if (playerEntity_1 != null)
            {
                if (playerEntity_1 != _myPlayer)
                {
                    if (playerEntity_1.hasFpos)
                    {
                        if (_myPlayer.hasFpos)
                        {
                            Vector3 vector = Misc_Pos_Movement_Godstate.GetEntityPos(playerEntity_1);
                            Vector3 vector2 = Misc_Pos_Movement_Godstate.GetEntityPos(_myPlayer);
                            string playerName = playerEntity_1.basicInfo.PlayerName;
                            if (playerName != "")
                            {
                                int num = (int)((vector2 - vector).magnitude / 100f);
                                bool flag = playerEntity_1.GetTeam() == _myPlayer.GetTeam();
                                float num2 = (float)playerEntity_1.GetHpPercent();
                                int num3 = (int)(playerEntity_1.GetHpPercent() * 100);
                                if (num3 > 0)
                                {
                                    Vector3 vector3 = Misc_Pos_Movement_Godstate.GetEntityPos(playerEntity_1);
                                    Vector3 vector4 = mainCam.WorldToScreenPoint(vector3);
                                    if (vector4.z > 0f)
                                    {
                                        Vector3 vector5 = mainCam.WorldToScreenPoint(vector3 + new Vector3(0f, 180f, 0f));
                                        float num4 = Mathf.Abs(vector4.y - vector5.y);
                                        float num5 = num4 / 2f;
                                        int num6 = 20;
                                        if (num <= 30)
                                        {
                                            num6 = 24;
                                        }
                                        else if (num > 60)
                                        {
                                            if (num <= 80)
                                            {
                                                num6 = 20;
                                            }
                                            else
                                            {
                                                num6 = 18;
                                            }
                                        }
                                        else
                                        {
                                            num6 = 22;
                                        }
                                        ImVec2 imVec = IMGUI.smethod_30(num6, 9999, 9999, playerName);
                                        int num7 = 5;
                                        int num8 = 20;
                                        float num9 = Math.Max(imVec.x + 5f * 2f, num5);
                                        uint uint_ = IMGUI._GetImU32ByRGBA(0, 153, 0, 240);
                                        uint uint_2 = IMGUI._GetImU32ByRGBA(255, 80, 80, 240);
                                        float num10 = (2f * 5f + imVec.y) * 0.15f;
                                        if (num9 != num5)
                                        {
                                            ImVec2 imVec2 = new ImVec2(vector4.x - num5 / 2f, (float)Screen.height - vector4.y - num4);
                                            ImVec2 imVec3 = new ImVec2(imVec2.x + num5 / 2f - num9 / 2f, imVec2.y - (float)(2 * num7) - imVec.y - (float)num8);
                                            ImVec2 imVec2_ = new ImVec2(imVec2.x + num5 / 2f + num9 / 2f, imVec2.y - (float)num8);
                                            int num11;
                                            if (espconfig_0.showTeammate && flag)
                                            {
                                                num11 = (espconfig_0.showName ? 1 : 0);
                                            }
                                            else
                                            {
                                                num11 = 0;
                                            }
                                            if (num11 != 0)
                                            {
                                                IMGUI._AddRectFilled(imVec3, imVec2_, uint_, 2, 15);
                                                imVec3 = new ImVec2(imVec2.x + num5 / 2f - num9 / 2f + (float)num7, imVec2.y - (float)num7 - imVec.y - (float)num8);
                                                float float_ = num6;
                                                ImVec2 imVec2_2 = imVec3;
                                                int int_ = 255;
                                                int int_2 = 255;
                                                int int_3 = 255;
                                                IMGUI._AddText2(float_, imVec2_2, IMGUI._GetImU32ByRGBA(int_, int_2, int_3, 255), playerName);
                                            }
                                            int num12;
                                            if (espconfig_0.showEnemy && !flag)
                                            {
                                                num12 = (espconfig_0.showName ? 1 : 0);
                                            }
                                            else
                                            {
                                                num12 = 0;
                                            }
                                            if (num12 != 0)
                                            {
                                                IMGUI._AddRectFilled(imVec3, imVec2_, uint_2, 2, 15);
                                                imVec3 = new ImVec2(imVec2.x + num5 / 2f - num9 / 2f + (float)num7, imVec2.y - (float)num7 - imVec.y - (float)num8);
                                                float float_2 = num6;
                                                ImVec2 imVec2_3 = imVec3;
                                                int int_4 = 255;
                                                int int_5 = 255;
                                                int int_6 = 255;
                                                IMGUI._AddText2(float_2, imVec2_3, IMGUI._GetImU32ByRGBA(int_4, int_5, int_6, 255), playerName);
                                            }
                                            imVec3 = new ImVec2(imVec2.x + num5 / 2f - num9 / 2f, imVec2.y - (float)(2 * num7) - imVec.y - (float)num8 - num10);
                                            imVec2_ = new ImVec2(imVec2.x + num5 / 2f - num9 / 2f + num9 * num2, imVec2.y - (float)(2 * num7) - imVec.y - (float)num8);
                                            int num13;
                                            if (espconfig_0.showHealth)
                                            {
                                                num13 = (espconfig_0.showTeammate ? 1 : 0);
                                            }
                                            else
                                            {
                                                num13 = 0;
                                            }
                                            if (((uint)num13 & (flag ? 1u : 0u)) != 0)
                                            {
                                                ImVec2 imVec2_4 = imVec3;
                                                ImVec2 imVec2_5 = imVec2_;
                                                uint uint_3 = IMGUI._GetImU32ByRGBA(255, 255, 255, 255);
                                                IMGUI._AddRectFilled(imVec2_4, imVec2_5, uint_3, 2, 15);
                                            }
                                            int num14;
                                            if (espconfig_0.showHealth && espconfig_0.showEnemy)
                                            {
                                                num14 = ((!flag) ? 1 : 0);
                                            }
                                            else
                                            {
                                                num14 = 0;
                                            }
                                            if (num14 != 0)
                                            {
                                                ImVec2 imVec2_6 = imVec3;
                                                ImVec2 imVec2_7 = imVec2_;
                                                uint uint_4 = IMGUI._GetImU32ByRGBA(255, 255, 255, 255);
                                                IMGUI._AddRectFilled(imVec2_6, imVec2_7, uint_4, 2, 15);
                                            }
                                        }
                                        else
                                        {
                                            ImVec2 imVec4 = new ImVec2(vector4.x - num5 / 2f, (float)Screen.height - vector4.y - num4);
                                            ImVec2 imVec5 = new ImVec2(imVec4.x, imVec4.y - (float)(2 * num7) - imVec.y - (float)num8);
                                            ImVec2 imVec2_8 = new ImVec2(imVec4.x + num5, imVec4.y - (float)num8);
                                            int num15;
                                            if (espconfig_0.showTeammate && flag)
                                            {
                                                num15 = (espconfig_0.showName ? 1 : 0);
                                            }
                                            else
                                            {
                                                num15 = 0;
                                            }
                                            if (num15 != 0)
                                            {
                                                IMGUI._AddRectFilled(imVec5, imVec2_8, uint_, 2, 15);
                                                imVec5 = new ImVec2(imVec4.x + num5 / 2f - num9 / 2f + (float)num7, imVec4.y - (float)num7 - imVec.y - (float)num8);
                                                float float_3 = num6;
                                                ImVec2 imVec2_9 = imVec5;
                                                int int_7 = 255;
                                                int int_8 = 255;
                                                int int_9 = 255;
                                                IMGUI._AddText2(float_3, imVec2_9, IMGUI._GetImU32ByRGBA(int_7, int_8, int_9, 255), playerName);
                                            }
                                            int num16;
                                            if (espconfig_0.showEnemy && !flag)
                                            {
                                                num16 = (espconfig_0.showName ? 1 : 0);
                                            }
                                            else
                                            {
                                                num16 = 0;
                                            }
                                            if (num16 != 0)
                                            {
                                                IMGUI._AddRectFilled(imVec5, imVec2_8, uint_2, 2, 15);
                                                imVec5 = new ImVec2(imVec4.x + num5 / 2f - num9 / 2f + (float)num7, imVec4.y - (float)num7 - imVec.y - (float)num8);
                                                float float_4 = num6;
                                                ImVec2 imVec2_10 = imVec5;
                                                int int_10 = 255;
                                                int int_11 = 255;
                                                int int_12 = 255;
                                                IMGUI._AddText2(float_4, imVec2_10, IMGUI._GetImU32ByRGBA(int_10, int_11, int_12, 255), playerName);
                                            }
                                            imVec5 = new ImVec2(imVec4.x + (float)num7, imVec4.y - (float)num7 - imVec.y - (float)num8);
                                            imVec5 = new ImVec2(imVec4.x, imVec4.y - (float)(2 * num7) - imVec.y - (float)num8 - num10);
                                            imVec2_8 = new ImVec2(imVec4.x + num5 * num2, imVec4.y - (float)(2 * num7) - imVec.y - (float)num8);
                                            int num17;
                                            if (espconfig_0.showHealth)
                                            {
                                                num17 = (espconfig_0.showTeammate ? 1 : 0);
                                            }
                                            else
                                            {
                                                num17 = 0;
                                            }
                                            if (((uint)num17 & (flag ? 1u : 0u)) != 0)
                                            {
                                                ImVec2 imVec2_11 = imVec5;
                                                ImVec2 imVec2_12 = imVec2_8;
                                                uint uint_5 = IMGUI._GetImU32ByRGBA(255, 255, 255, 255);
                                                IMGUI._AddRectFilled(imVec2_11, imVec2_12, uint_5, 2, 15);
                                            }
                                            int num18;
                                            if (espconfig_0.showHealth && espconfig_0.showEnemy)
                                            {
                                                num18 = ((!flag) ? 1 : 0);
                                            }
                                            else
                                            {
                                                num18 = 0;
                                            }
                                            if (num18 != 0)
                                            {
                                                ImVec2 imVec2_13 = imVec5;
                                                ImVec2 imVec2_14 = imVec2_8;
                                                uint uint_6 = IMGUI._GetImU32ByRGBA(255, 255, 255, 255);
                                                IMGUI._AddRectFilled(imVec2_13, imVec2_14, uint_6, 2, 15);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

	void DrawBone(ref PlayerEntity playerEntity_1)
	{
		if (playerEntity_1 != null)
		{
			if (playerEntity_1.hasThirdPersonUnityObjects)
			{
				if (espconfig_0.showBone)
				{
                    if (_myPlayer != null)
                    {
                        if (playerEntity_1 != _myPlayer)
                        {
                            bool myteam = playerEntity_1.GetTeam() == _myPlayer.GetTeam();
                            int num = (int)(playerEntity_1.GetHpPercent() * 100);
                            if (num != 0)
                            {
                                playerEntity_1.thirdPersonUnityObjects.Animator.GetAllBones();
                                bool drawteam;
                                if (myteam)
                                {
                                    drawteam = espconfig_0.showTeammate;
                                }
                                else
                                {
                                    drawteam = false;
                                }
                                if (drawteam)
                                {
                                    uint num2 = IMGUI._GetImU32ByImVec4(espconfig_0.teamBoxCol);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_Head", "Bip01_Neck", num2);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_Neck", "Bip01_L_Clavicle", num2);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_Neck", "Bip01_R_Clavicle", num2);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_R_Clavicle", "Bip01_R_Forearm", num2);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_L_Clavicle", "Bip01_L_Forearm", num2);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_L_Forearm", "Bip01_L_Hand", num2);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_R_Forearm", "Bip01_R_Hand", num2);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_Neck", "Bip01_Spine2", num2);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_Spine2", "Bip01_Spine1", num2);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_Spine1", "Bip01_Spine", num2);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_Spine", "Bip01_L_Thigh", num2);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_Spine", "Bip01_R_Thigh", num2);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_R_Thigh", "Bip01_R_Calf", num2);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_R_Calf", "Bip01_R_Foot", num2);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_L_Thigh", "Bip01_L_Calf", num2);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_L_Calf", "Bip01_L_Foot", num2);
                                }
                                bool drawEnemy;
                                if (!myteam)
                                {
                                    drawEnemy = espconfig_0.showEnemy;
                                }
                                else
                                {
                                    drawEnemy = false;
                                }
                                if (drawEnemy)
                                {
                                    uint num4 = IMGUI._GetImU32ByImVec4(espconfig_0.enemyBoxCol);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_Head", "Bip01_Neck", num4);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_Neck", "Bip01_L_Clavicle", num4);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_Neck", "Bip01_R_Clavicle", num4);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_R_Clavicle", "Bip01_R_Forearm", num4);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_L_Clavicle", "Bip01_L_Forearm", num4);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_L_Forearm", "Bip01_L_Hand", num4);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_R_Forearm", "Bip01_R_Hand", num4);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_Neck", "Bip01_Spine2", num4);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_Spine2", "Bip01_Spine1", num4);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_Spine1", "Bip01_Spine", num4);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_Spine", "Bip01_L_Thigh", num4);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_Spine", "Bip01_R_Thigh", num4);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_R_Thigh", "Bip01_R_Calf", num4);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_R_Calf", "Bip01_R_Foot", num4);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_L_Thigh", "Bip01_L_Calf", num4);
                                    DrawBoneSection(ref playerEntity_1, "Bip01_L_Calf", "Bip01_L_Foot", num4);
                                }
                            }
                        }
                    }
                }
			}
		}
	}

	void DrawTrace_Distance(ref PlayerEntity playerEntity_1)
	{
		if (_myPlayer != null)
		{
			if (playerEntity_1 != null)
			{
				if (mainCam != null)
				{
					if (playerEntity_1 != _myPlayer)
					{
                        if (playerEntity_1.hasFpos)
                        {
                            if (_myPlayer.hasFpos)
                            {
                                bool myTeam = playerEntity_1.GetTeam() == _myPlayer.GetTeam();
                                int hppercent = (int)(playerEntity_1.GetHpPercent() * 100);
                                if (hppercent > 0)
                                {
                                    Vector3 vector = Misc_Pos_Movement_Godstate.GetEntityPos(playerEntity_1);
                                    Vector3 vector2 = mainCam.WorldToScreenPoint(vector);
                                    if (vector2.z > 0f)
                                    {
                                        Vector3 vector3 = mainCam.WorldToScreenPoint(vector + new Vector3(0f, 180f, 0f));
                                        float num2 = Mathf.Abs(vector2.y - vector3.y);
                                        float num3 = num2 / 2f;
                                        Vector3 vector4 = Misc_Pos_Movement_Godstate.GetEntityPos(playerEntity_1);
                                        Vector3 vector5 = Misc_Pos_Movement_Godstate.GetEntityPos(_myPlayer);
                                        int num4 = (int)((vector5 - vector4).magnitude / 100f);
                                        int num5 = 20;
                                        if (num4 > 30)
                                        {
                                            int num6 = num4;
                                            bool flag2;
                                            if (num6 > 30)
                                            {
                                                int num8 = num4;
                                                flag2 = num8 <= 60;
                                            }
                                            else
                                            {
                                                flag2 = false;
                                            }
                                            if (flag2)
                                            {
                                                num5 = 18;
                                            }
                                            else
                                            {
                                                num5 = 16;
                                            }
                                        }
                                        else
                                        {
                                            num5 = 20;
                                        }
                                        bool drawteam;
                                        if (myTeam)
                                        {
                                            drawteam = espconfig_0.showTeammate;
                                        }
                                        else
                                        {
                                            drawteam = false;
                                        }
                                        if (drawteam)
                                        {
                                            ImVec2 imVec = new ImVec2(vector2.x - num3 / 2f, (float)Screen.height - vector2.y - num2);
                                            ImVec2 imVec2 = imVec + new ImVec2(num3, num2);
                                            ImVec2 imVec3 = imVec + new ImVec2(0f, num2 + 3f);
                                            IMGUI._AddRect(imVec, imVec2, IMGUI._GetImU32ByImVec4(espconfig_0.teamBoxCol), 2, 15, espconfig_0.BoxThickness);
                                            if (espconfig_0.showTranceline)
                                            {
                                                IMGUI._AddLine(new ImVec2((float)Screen.width / 2f, 0f), new ImVec2(vector2.x, (float)Screen.height - vector2.y - num2), IMGUI._GetImU32ByImVec4(espconfig_0.TracelineCol), espconfig_0.TracelineThickness);
                                            }
                                            if (espconfig_0.showDistance)
                                            {
                                                float num12 = (float)num5;
                                                ImVec2 imVec4 = imVec3;
                                                uint num13 = IMGUI._GetImU32ByRGBA(255, 255, 255, 255);
                                                string text = num4.ToString();
                                                IMGUI._AddText2(num12, imVec4, num13, text + " m");
                                            }
                                        }
                                        else
                                        {
                                            bool drawenemy;
                                            if (!myTeam)
                                            {
                                                drawenemy = espconfig_0.showEnemy;
                                            }
                                            else
                                            {
                                                drawenemy = false;
                                            }
                                            if (drawenemy)
                                            {
                                                ImVec2 imVec5 = new ImVec2(vector2.x - num3 / 2f, (float)Screen.height - vector2.y - num2);
                                                ImVec2 imVec6 = imVec5 + new ImVec2(num3, num2);
                                                ImVec2 imVec7 = imVec5 + new ImVec2(0f, num2 + 3f);
                                                ImVec2 imVec8 = imVec5;
                                                ImVec2 imVec9 = imVec6;
                                                ImVec4 imVec10;
                                                if (playerEntity_1.GetId() != Rage_SilentAim.int_0)
                                                {
                                                    imVec10 = espconfig_0.enemyBoxCol;
                                                }
                                                else
                                                {
                                                    imVec10 = new ImVec4(0.5f, 1f, 0f, 1f);
                                                }
                                                uint num16 = IMGUI._GetImU32ByImVec4(imVec10);
                                                int num17 = 2;
                                                IMGUI._AddRect(imVec8, imVec9, num16, num17, 15, espconfig_0.BoxThickness);
                                                if (espconfig_0.showTranceline)
                                                {
                                                    IMGUI._AddLine(new ImVec2((float)Screen.width / 2f, 0f), new ImVec2(vector2.x, (float)Screen.height - vector2.y - num2), IMGUI._GetImU32ByImVec4(espconfig_0.TracelineCol), espconfig_0.TracelineThickness);
                                                }
                                                if (espconfig_0.showDistance)
                                                {
                                                    float num19 = (float)num5;
                                                    ImVec2 imVec11 = imVec7;
                                                    uint num20 = IMGUI._GetImU32ByRGBA(255, 255, 255, 255);
                                                    string text2 = num4.ToString();
                                                    IMGUI._AddText2(num19, imVec11, num20, text2 + " m");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
				}
			}
		}
	}

	public void DrawESP()
	{
		_myPlayer = class12_0.myPlayer;
		foreach (PlayerEntity entity in class12_0.EntityList)
		{
			if (entity != null)
			{
                PlayerEntity playerEntity = entity;
                DrawTrace_Distance(ref playerEntity);
                DrawBone(ref playerEntity);
                DrawEsp(ref playerEntity);
            }
		}
	}

	public void MenuDrawing(ref bool bool_0)
	{
		IMGUI._Begin("玩家透视", ref bool_0, 500, 500);
		IMGUI._Checkbox("透视队友", ref espconfig_0.showTeammate);
		IMGUI._SameLine();
		IMGUI._Checkbox("透视敌人", ref espconfig_0.showEnemy);
		IMGUI._SameLine();
		IMGUI._Checkbox("显示名字", ref espconfig_0.showName);
		IMGUI._SameLine();
		IMGUI._Checkbox("追踪线条", ref espconfig_0.showTranceline);
		IMGUI._Checkbox("骨骼透视", ref espconfig_0.showBone);
		IMGUI._SameLine();
		IMGUI._Checkbox("血量透视", ref espconfig_0.showHealth);
		IMGUI._SameLine();
		IMGUI._Checkbox("距离透视", ref espconfig_0.showDistance);
		IMGUI._TextColored(new ImVec4(0f, 1f, 0f, 1f), "颜色设置:");
		IMGUI._Text("敌人颜色:");
		IMGUI._SameLine();
		IMGUI._ColorEdit4("敌人颜色", ref espconfig_0.enemyBoxCol);
		IMGUI._Text("队友颜色:");
		IMGUI._SameLine();
		IMGUI._ColorEdit4("队友颜色", ref espconfig_0.teamBoxCol);
		IMGUI._Text("追踪线条颜色:");
		IMGUI._SameLine();
		IMGUI._ColorEdit4("追踪线条颜色", ref espconfig_0.TracelineCol);
		IMGUI._TextColored(new ImVec4(0f, 1f, 0f, 1f), "粗细设置:");
		IMGUI._SliderFloat("方框粗细", ref espconfig_0.BoxThickness, 0.1f, 6f, "粗细: %.2f");
		IMGUI._SliderFloat("追踪线条粗细", ref espconfig_0.TracelineThickness, 0.1f, 6f, "粗细: %.2f");
		IMGUI._SliderFloat("骨骼粗细", ref espconfig_0.BoneThickness, 0.1f, 5f, "粗细: %.2f");
		IMGUI._End();
	}

	Camera mainCam;

	public ESPConfig espconfig_0;

	PlayerEntity _myPlayer;

	readonly Main class12_0;
}
