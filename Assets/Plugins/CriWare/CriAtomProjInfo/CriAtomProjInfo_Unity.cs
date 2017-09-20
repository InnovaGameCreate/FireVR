/****************************************************************************
*
* CRI Middleware SDK
*
* Copyright (c) 2011-2012 CRI Middleware Co., Ltd.
*
* Library  : CRI Atom
* Module   : CRI Atom for Unity
* File     : CriAtomProjInfo_Unity.cs
* Tool Ver.          : CRI Atom Craft LE Ver.2.13.00
* Date Time          : 2016/01/04 15:58
* Project Name       : OculusAudioPack01
* Project Comment    : 
*
****************************************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class CriAtomAcfInfo
{
    static partial void GetCueInfoInternal()
    {
        acfInfo = new AcfInfo("ACF", 0, "", "OculusAudioPack01.acf","5724eac1-d2b4-44f1-a2b5-04a1fc4623b9","DspBusSetting_0");
        acfInfo.aisacControlNameList.Add("Any");
        acfInfo.aisacControlNameList.Add("Distance");
        acfInfo.aisacControlNameList.Add("AisacControl02");
        acfInfo.aisacControlNameList.Add("AisacControl03");
        acfInfo.aisacControlNameList.Add("AisacControl04");
        acfInfo.aisacControlNameList.Add("AisacControl05");
        acfInfo.aisacControlNameList.Add("AisacControl06");
        acfInfo.aisacControlNameList.Add("AisacControl07");
        acfInfo.aisacControlNameList.Add("AisacControl08");
        acfInfo.aisacControlNameList.Add("AisacControl09");
        acfInfo.aisacControlNameList.Add("AisacControl10");
        acfInfo.aisacControlNameList.Add("AisacControl11");
        acfInfo.aisacControlNameList.Add("AisacControl12");
        acfInfo.aisacControlNameList.Add("AisacControl13");
        acfInfo.aisacControlNameList.Add("AisacControl14");
        acfInfo.aisacControlNameList.Add("AisacControl15");
        acfInfo.acbInfoList.Clear();
        AcbInfo newAcbInfo = null;
        newAcbInfo = new AcbInfo("footsteps", 0, "", "footsteps.acb", "footsteps.awb","6f52aa3e-e1e3-4121-8ac9-edab36df8eb5");
        acfInfo.acbInfoList.Add(newAcbInfo);
        newAcbInfo.cueInfoList.Add(0, new CueInfo("footsteps_shoe_concrete_land_01", 0, ""));
        newAcbInfo.cueInfoList.Add(2, new CueInfo("footsteps_shoe_concrete_run_01", 2, ""));
        newAcbInfo.cueInfoList.Add(7, new CueInfo("footsteps_shoe_concrete_walk_01", 7, ""));
        newAcbInfo.cueInfoList.Add(12, new CueInfo("footsteps_shoe_dirt_land_01", 12, ""));
        newAcbInfo.cueInfoList.Add(14, new CueInfo("footsteps_shoe_dirt_run_01", 14, ""));
        newAcbInfo.cueInfoList.Add(19, new CueInfo("footsteps_shoe_dirt_walk_01", 19, ""));
        newAcbInfo.cueInfoList.Add(24, new CueInfo("footsteps_shoe_grass_land_01", 24, ""));
        newAcbInfo.cueInfoList.Add(26, new CueInfo("footsteps_shoe_grass_run_01", 26, ""));
        newAcbInfo.cueInfoList.Add(31, new CueInfo("footsteps_shoe_grass_walk_01", 31, ""));
        newAcbInfo.cueInfoList.Add(36, new CueInfo("footsteps_shoe_metal_land_01", 36, ""));
        newAcbInfo.cueInfoList.Add(38, new CueInfo("footsteps_shoe_metal_run_01", 38, ""));
        newAcbInfo.cueInfoList.Add(43, new CueInfo("footsteps_shoe_metal_walk_01", 43, ""));
        newAcbInfo.cueInfoList.Add(48, new CueInfo("footsteps_shoe_snow_land_01", 48, ""));
        newAcbInfo.cueInfoList.Add(50, new CueInfo("footsteps_shoe_snow_run_01", 50, ""));
        newAcbInfo.cueInfoList.Add(55, new CueInfo("footsteps_shoe_snow_walk_01", 55, ""));
        newAcbInfo.cueInfoList.Add(60, new CueInfo("footsteps_shoe_wood_land_01", 60, ""));
        newAcbInfo.cueInfoList.Add(62, new CueInfo("footsteps_shoe_wood_run_01", 62, ""));
        newAcbInfo.cueInfoList.Add(67, new CueInfo("footsteps_shoe_wood_walk_01", 67, ""));
        newAcbInfo.cueInfoList.Add(68, new CueInfo("run", 68, ""));
        newAcbInfo.cueInfoList.Add(69, new CueInfo("walk", 69, ""));
        newAcbInfo.cueInfoList.Add(71, new CueInfo("landing", 71, ""));
        newAcbInfo.cueInfoList.Add(70, new CueInfo("footstep", 70, ""));
    }
}
