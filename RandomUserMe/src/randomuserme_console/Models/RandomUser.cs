/*
time: 1472500800,
summary: "Partly Cloudy",
icon: "partly-cloudy-day",
precipIntensity: 0,
precipProbability: 0,
temperature: 63.53,
apparentTemperature: 63.53,
dewPoint: 54.41,
humidity: 0.72,
windSpeed: 6.8,
windBearing: 267,
visibility: 9.56,
cloudCover: 0.51,
pressure: 1018.97,
ozone: 281.58
*/
using System;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Forecast
    {
        [DataMember(Name="time")]
        public int Time { get; set; }
        [DataMember(Name="summary")]
        public string Summary { get; set; }
        [DataMember(Name="icon")]
        public string Icon { get; set; }
        [DataMember(Name="precipIntensity")]
        public double PrecipIntensity { get; set; }
        [DataMember(Name="precipProbability")]
        public int PrecipProbability { get; set; }
        [DataMember(Name="temperature")]
        public double Temperature { get; set; }
        [DataMember(Name="apparentTemperature")]
        public double ApparentTemperature { get; set; }
        [DataMember(Name="dewPoint")]
        public double DewPoint { get; set; }
        [DataMember(Name="humidity")]
        public string Humidity { get; set; }
        [DataMember(Name="windSpeed")]
        public double WindSpeed { get; set; }
        [DataMember(Name="windBearing")]
        public double WindBearing { get; set; }
        [DataMember(Name="visibility")]
        public string Visibility { get; set; }
        [DataMember(Name="cloudCover")]
        public double CloudCover { get; set; }
        [DataMember(Name="pressure")]
        public double Pressure { get; set; }
        [DataMember(Name="ozone")]
        public string Ozone { get; set; }

        public Forecast() {
        }
    }
}
