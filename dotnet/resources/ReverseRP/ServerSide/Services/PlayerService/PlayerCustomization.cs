using System;
using System.Collections.Generic;
using GTANetworkAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ServerSide.Services.PlayerService;

public class PlayerCustomization
{
    public static void PlayerSetBaseCustomization(Player player,string headOverlaysJson, string headOverlaysColorsJson,
        string headBlendDataJson, string faceFeaturesJson, bool gender, string firstName, string lastName,
        byte hairColor, int hairType, byte eyeColor)
    {
        float[] headBlendObj = JsonConvert.DeserializeObject<float[]>(headBlendDataJson);
        float[] faceFeaturesObj = JsonConvert.DeserializeObject<float[]>(faceFeaturesJson);
        int[] headOverlaysObj = JsonConvert.DeserializeObject<int[]>(headOverlaysJson);
        byte[] headOverlaysColorsObj = JsonConvert.DeserializeObject<byte[]>(headOverlaysColorsJson);
        player.Name = firstName + " " + lastName;
        //player.Nametag = firstName + " " + lastName;
        HeadBlend headBlend = new HeadBlend()
        {
            ShapeFirst = Convert.ToByte(headBlendObj[0]),
            ShapeSecond = Convert.ToByte(headBlendObj[1]),
            ShapeThird = 0,
            SkinFirst = Convert.ToByte(headBlendObj[4]),
            SkinSecond = Convert.ToByte(headBlendObj[5]),
            SkinThird = 0,
            ShapeMix = headBlendObj[2],
            SkinMix = headBlendObj[3]
        };
        float[] faceFeatures = new float[20];
        for (int i = 0; i < 20; i++)
        {
            faceFeatures[i] = faceFeaturesObj[i];
        }
        Dictionary<int, HeadOverlay> headOverlays = new Dictionary<int, HeadOverlay>();
        for (byte i = 0; i < 12; i++)
        {
            headOverlays.Add(i,new HeadOverlay(){Index = (byte)headOverlaysObj[i], Color = headOverlaysColorsObj[i], Opacity = 1});
        }
        player.SetCustomization(gender, headBlend, eyeColor,hairColor,0,faceFeatures,headOverlays,new Decoration[]{});
        player.SetClothes(2,hairType,0);
    }
}