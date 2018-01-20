﻿using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using KSP.Localization;

namespace SpeedUnitAnnex
{
    // http://forum.kerbalspaceprogram.com/index.php?/topic/147576-modders-notes-for-ksp-12/#comment-2754813
    // search for "Mod integration into Stock Settings

    public class SpeedUnitAnnexSettings : GameParameters.CustomParameterNode
    {

        public static IList planeSpeedList = new List<string> {
                Localizer.Format("#SpeedUnitAnnex_machNumber"),
                Localizer.Format("#SpeedUnitAnnex_knot"),
                Localizer.Format("#SpeedUnitAnnex_kmph"),
                Localizer.Format("#SpeedUnitAnnex_mph")
            };

        public static IList roverSpeedList = new List<string> {
            Localizer.Format("#SpeedUnitAnnex_kmph"),
            Localizer.Format("#SpeedUnitAnnex_mph")
        };



        public override string Title { get { return Localizer.Format("#SpeedUnitAnnex_navball_info") ; } }
        public override GameParameters.GameMode GameMode { get { return GameParameters.GameMode.ANY; } }
        public override string Section { get { return "Speed Unit Annex"; } }
        public override string DisplaySection { get { return "Speed Unit Annex"; } }
        public override int SectionOrder { get { return 1; } }
        public override bool HasPresets { get { return true; } }

        [GameParameters.CustomStringParameterUI("#SpeedUnitAnnex_surfaceMode", lines = 2, title = "#SpeedUnitAnnex_surfaceMode")]
        public string UIstring1 = "";

        [GameParameters.CustomParameterUI("#SpeedUnitAnnex_roverSpeed", toolTip = "#SpeedUnitAnnex_roverSpeed_toolTip")]
        public string roverSpeed = roverSpeedList[0].ToString();

        [GameParameters.CustomParameterUI("#SpeedUnitAnnex_planeSpeed", toolTip = "#SpeedUnitAnnex_planeSpeed_toolTip")]
        public string planeSpeed = planeSpeedList[0].ToString();

        //[GameParameters.CustomParameterUI("#SpeedUnitAnnex_speedometer", toolTip = "#SpeedUnitAnnex_speedometer_toolTip")]
        //public bool kph = true;

        [GameParameters.CustomParameterUI("#SpeedUnitAnnex_altimeter", toolTip = "#SpeedUnitAnnex_altimeter_toolTip")]
        public bool radar = true;

        


        [GameParameters.CustomStringParameterUI("#SpeedUnitAnnex_orbitMode", lines = 2, title = "#SpeedUnitAnnex_orbitMode")]
        public string UIstring2 = "";

        [GameParameters.CustomParameterUI("#SpeedUnitAnnex_Ap", toolTip = "#SpeedUnitAnnex_Ap_toolTip")]
        public bool orbit = true;

        [GameParameters.CustomStringParameterUI("#SpeedUnitAnnex_targetMode", lines = 2, title = "#SpeedUnitAnnex_targetMode")]
        public string UIstring3 = "";

        [GameParameters.CustomParameterUI("#SpeedUnitAnnex_targetDistance", toolTip = "#SpeedUnitAnnex_targetDistance_toolTip")]
        public bool targetDistance = true;

        public override void SetDifficultyPreset(GameParameters.Preset preset)
        {
            //kph = true;
            radar = true;
            orbit = true;
            targetDistance = true;
            roverSpeed = roverSpeedList[0].ToString();
            planeSpeed = planeSpeedList[0].ToString();
        }

    public override bool Enabled(MemberInfo member, GameParameters parameters)
        {
            return true;
        }


        public override bool Interactible(MemberInfo member, GameParameters parameters)
        {
            return true;
        }

        public override IList ValidValues(MemberInfo member)
        {
            if (member.Name == "planeSpeed")
            {
                return planeSpeedList;
            }
            else if (member.Name == "roverSpeed")
            {
                return roverSpeedList;
            }
            else
            {
                return null;
            }
        }
    }
}
