using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW270219_operator_Overloading
{
    class Camp
    {
        private readonly int id;
        public int Latitude { get; private set; }
        public int Longitude { get; private set; }
        public int NumberOfPoeple { get; private set; }
        public int NumberOfTents { get; private set; }
        public int NumberOfFlashLights { get; private set; }
        private int LastCampId = 0;

        public Camp(int latitude, int longitude, int numberOfPoeple, int numberOfTents, int numberOfFlashLights)
        {
            LastCampId++;
            id = LastCampId;
            Latitude = latitude;
            Longitude = longitude;
            NumberOfPoeple = numberOfPoeple;
            NumberOfTents = numberOfTents;
            NumberOfFlashLights = numberOfFlashLights;            
        }

        public override string ToString()
        {
            return $"id {id}, latitude {Latitude}, longitude {Longitude}, numberOfPoeple {NumberOfPoeple}, numberOfTents {NumberOfTents}, numberOfFlashLights {NumberOfFlashLights}";
        }

        public static bool operator ==(Camp p1, Camp p2)
        {
            if (ReferenceEquals(p1, null) && ReferenceEquals(p2, null))
            {
                return true;
            }
            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
            {
                return false;
            }
            if (p1.id == p2.id)
                return true;
            return false;
        }
        public static bool operator !=(Camp p1, Camp p2)
        {
            return !(p1 == p2);
        }

        public static bool operator >(Camp p1, Camp p2)
        {
            //Taking care of null
            if (p1 == p2)
                return false;

            return (p1.NumberOfPoeple > p2.NumberOfPoeple);
        }
        public static bool operator <(Camp p1, Camp p2)
        {
            //Taking care of null
            if (p1 == p2)
                return false;

            return (p1.NumberOfPoeple < p2.NumberOfPoeple);
        }

        public override bool Equals(object obj)
        {
            Camp otherPoint = obj as Camp;
            if (otherPoint == null)
                return false;
            return (otherPoint.id == this.id);
        }

        public override int GetHashCode()
        {
            return this.id;
        }

        public static Camp operator +(Camp p1, Camp p2)
        {
            return new Camp(p1.Latitude, p1.Longitude, p1.NumberOfPoeple + p2.NumberOfPoeple, 
                p1.NumberOfTents + p2.NumberOfTents, p1.NumberOfFlashLights + p2.NumberOfFlashLights);
        }
    }
}
