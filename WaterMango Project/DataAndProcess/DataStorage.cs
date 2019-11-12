using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WaterMango_Project.Models;

namespace WaterMango_Project.Data
{
    public class DataStorage
    {
        public static List<Plant> plants = new List<Plant>
            {
            new Plant() {Id = 100, Name = "Cactus", lastTimeWatered = DateTime.Now.TimeOfDay, canBeWatered = true, secondsWatered = 0 , plantImageUrl = @"https://hips.hearstapps.com/vader-prod.s3.amazonaws.com/1568042845-Cactus_mix_yellow_2048x.jpg" },
            new Plant() {Id = 101, Name = "Rose", lastTimeWatered   = DateTime.Now.TimeOfDay, canBeWatered = true, secondsWatered = 0, plantImageUrl = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fwww.bmstores.co.uk%2Fimages%2FhpcProductImage%2FimgFull%2F297350-Leafy-Plant-Pot-3.jpg&f=1&nofb=1"},
            new Plant() {Id = 102, Name = "Bonsai", lastTimeWatered = DateTime.Now.TimeOfDay, canBeWatered = true, secondsWatered = 0, plantImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.gardeners.com%2Fdw%2Fimage%2Fv2%2FAABF_PRD%2Fon%2Fdemandware.static%2F-%2FSites-GSC_Products%2Fdefault%2Fdw9eafb841%2FProducts%2F8592680BL_002E_tokyo-tall-resin-planters-small-colorful-flower-pots.jpg%3Fsw%3D840%26sh%3D1120%26sm%3Dfit&f=1&nofb=1"},
            new Plant() {Id = 103, Name = "Kiwi", lastTimeWatered  = DateTime.Now.TimeOfDay, canBeWatered = true, secondsWatered = 0, plantImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fs3.envato.com%2Ffiles%2F100422653%2F2%2F02a%2520copy.jpg&f=1&nofb=1"},
            new Plant() {Id = 104, Name = "Cabbage", lastTimeWatered   = DateTime.Now.TimeOfDay, canBeWatered = true, secondsWatered = 0, plantImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.wallpapersin4k.org%2Fwp-content%2Fuploads%2F2016%2F12%2FPlant-Wallpapers.jpg&f=1&nofb=1"},
            };

    }
}