using Newtonsoft.Json.Linq;
using RAGE;



namespace ClientSide.EventsHandlers
{
    public class CreateCharacter : Events.Script
    {
        public CreateCharacter()
        {
            Events.Add("CEF::CLIENT::ON_CHANGE_CHARACTER_HEAD_BLEND_DATA", OnChangeCharacterHeadBlendData);
        }
        private void OnChangeCharacterHeadBlendData(object[] args)
        {
            var character = JObject.Parse((string)args[0]);
            RAGE.Elements.Player.LocalPlayer.SetHeadBlendData((int)character["blendData"][0],(int)character["blendData"][1],0,0,4,0,(int)character["blendData"][2],(int)character["blendData"][3],0, false);
            for (int i = 0; i < 19; i++)
            {
                RAGE.Elements.Player.LocalPlayer.SetFaceFeature(i,(float)character["faceFeatures"][i]);
            }
            RAGE.Elements.Player.LocalPlayer.SetEyeColor(4);
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