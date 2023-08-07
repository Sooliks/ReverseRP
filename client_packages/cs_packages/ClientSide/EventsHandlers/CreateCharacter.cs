using Newtonsoft.Json.Linq;
using RAGE;
using System;


namespace ClientSide.EventsHandlers
{
    public class CreateCharacter : Events.Script
    {
        public CreateCharacter()
        {
            Events.Add("CEF::CLIENT::ON_CHANGE_CHARACTER", OnChangeCharacterHeadBlendData);
            RAGE.Elements.Player.LocalPlayer.Model = RAGE.Game.Misc.GetHashKey("mp_m_freemode_01");
        }
        private void OnChangeCharacterHeadBlendData(object[] args)
        {
            var character = JObject.Parse((string)args[0]);
            
            if((string)character["gender"] == "мужской")RAGE.Elements.Player.LocalPlayer.Model = RAGE.Game.Misc.GetHashKey("mp_m_freemode_01");
            if((string)character["gender"] == "женский")RAGE.Elements.Player.LocalPlayer.Model = RAGE.Game.Misc.GetHashKey("mp_f_freemode_01");
            
            //гены
            RAGE.Elements.Player.LocalPlayer.SetHeadBlendData(Convert.ToInt32(character["blendData"][0]),Convert.ToInt32(character["blendData"][1]),0,Convert.ToInt32(character["blendData"][4]),Convert.ToInt32(character["blendData"][5]),0,(float)character["blendData"][2],(float)character["blendData"][3],0, true);
            
            
            //прическа
            RAGE.Elements.Player.LocalPlayer.SetComponentVariation(2,(int)character["hair"][0],0,0);
            RAGE.Elements.Player.LocalPlayer.SetHairColor((int)character["hair"][1],0);
            
            //борода
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlay(1,(int)character["beard"][0],100);
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlayColor(1,1,(int)character["beard"][1],0);
            
            //брови
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlay(2,(int)character["headOverlays"][2],100);
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlayColor(2,1,(int)character["eyeBrowColor"],0);
            
            //особенности кожи
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlay(0,(int)character["headOverlays"][0],100);
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlay(3,(int)character["headOverlays"][3],100);
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlay(5,(int)character["headOverlays"][5],100);
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlay(7,(int)character["headOverlays"][7],100);
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlay(9,(int)character["headOverlays"][9],100);
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlay(10,(int)character["headOverlays"][10],100);
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlay(11,(int)character["headOverlays"][11],100);
            
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlayColor(0,1,20,0);
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlayColor(3,1,63,0);
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlayColor(5,1,20,0);
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlayColor(7,1,21,0);
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlayColor(9,1,20,0);
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlayColor(10,1,0,0);
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlayColor(11,1,10,0);
            
            //макияж
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlay(4,(int)character["headOverlays"][4],100);
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlay(8,(int)character["headOverlays"][8],100);
            
            //RAGE.Elements.Player.LocalPlayer.SetHeadOverlayColor(4,1,0,0);
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlayColor(8,1,(int)character["headOverlaysColors"][8],0);
            
            //лицо
            for (int i = 0; i < 20; i++)
            {
                RAGE.Elements.Player.LocalPlayer.SetFaceFeature(i,(float)character["faceFeatures"][i]);
            }
        }
    }
    /*public class CreateCharacterData
    {
        public string Gender { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int birth { get; set; }
        public string promo { get; set; }
        public string origin { get; set; }
        public int[] hair { get; set; }
        public int[] beard { get; set; }
        public int[] blendData { get; set; }
        public int[] faceFeatures { get; set; }
        public int torso { get; set; }
        public int[] clothing { get; set; }
        public int[] headOverlays { get; set; }
        public int[] headOverlaysColors { get; set; }
        public int eyeColor { get; set; }
        public int eyeBrowColor { get; set; }
    }*/
}