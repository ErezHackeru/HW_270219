using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HW270219_operator_Overloading
{
    public class Camp2
    {
        public int id { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public int NumberOfPoeple { get; set; }
        public int NumberOfTents { get; set; }
        public int NumberOfFlashLights { get; set; }
        private int LastCampId = 0;

        public Camp2()
        {

        }

        public Camp2(int id, int latitude, int longitude, int numberOfPoeple, int numberOfTents, int numberOfFlashLights, int lastCampId)
        {
            this.id = id;
            Latitude = latitude;
            Longitude = longitude;
            NumberOfPoeple = numberOfPoeple;
            NumberOfTents = numberOfTents;
            NumberOfFlashLights = numberOfFlashLights;
            LastCampId = lastCampId;
        }
        public static bool operator ==(Camp2 p1, Camp2 p2)
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
        public static bool operator !=(Camp2 p1, Camp2 p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            Camp2 otherPoint = obj as Camp2;
            if (otherPoint == null)
                return false;
            return (otherPoint.id == this.id);
        }

        public override int GetHashCode()
        {
            return this.id;
        }

        //===========================
        //Static Part of the Class
        //===========================
        public static void SerializeACamp(string fileName, Camp2 camp)
        {
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Camp2));
            using (Stream file = new FileStream(fileName, FileMode.Create))
            {
                myXmlSerializer.Serialize(file, camp);
            }
        }

        public static Camp2 DeserializeACamp(string fileName)
        {
            Camp2 c2 = null;
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Camp2));
            using (Stream file = new FileStream(fileName, FileMode.Open))
            {
                c2 = myXmlSerializer.Deserialize(file) as Camp2;
            }
            return c2;
        }
    }
}
