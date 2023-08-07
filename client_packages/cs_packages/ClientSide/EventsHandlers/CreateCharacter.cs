using Newtonsoft.Json.Linq;
using RAGE;



namespace ClientSide.EventsHandlers
{
    public class CreateCharacter : Events.Script
    {
        public CreateCharacter()
        {
            Events.Add("CEF::CLIENT::ON_CHANGE_CHARACTER", OnChangeCharacterHeadBlendData);
        }
        private void OnChangeCharacterHeadBlendData(object[] args)
        {
            var character = JObject.Parse((string)args[0]);
            
            if((string)character["gender"] == "мужской")RAGE.Elements.Player.LocalPlayer.Model = RAGE.Game.Misc.GetHashKey("mp_m_freemode_01");
            if((string)character["gender"] == "женский")RAGE.Elements.Player.LocalPlayer.Model = RAGE.Game.Misc.GetHashKey("mp_f_freemode_01");
            
            //гены
            RAGE.Elements.Player.LocalPlayer.SetHeadBlendData((int)character["blendData"][0],(int)character["blendData"][1],0,(int)character["blendData"][4],(int)character["blendData"][5],0,(int)character["blendData"][2],(int)character["blendData"][3],0, false);
            
            //лицо
            for (int i = 0; i < 19; i++)
            {
                RAGE.Elements.Player.LocalPlayer.SetFaceFeature(i,(float)character["faceFeatures"][i]);
            }
            
            //прическа
            RAGE.Elements.Player.LocalPlayer.SetComponentVariation(2,(int)character["hair"][0],0,0);
            RAGE.Elements.Player.LocalPlayer.SetHairColor((int)character["hair"][1],0);
            
            //борода
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlay(1,(int)character["beard"][0],100);
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlayColor(1,1,(int)character["beard"][1],0);
            
            //брови
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlay(2,(int)character["headOverlays"][2],100);
            RAGE.Elements.Player.LocalPlayer.SetHeadOverlayColor(2,1,(int)character["eyeBrowColor"],0);
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