using System.Xml.Serialization;

namespace DomainModel.XmlModels.ID15A
{
    public class PREADMREFAR2
    {
        private string _preDocTypAr21;
        private string _preDocRefAr26;
        private string _preDocRefLng;
        private string _preDocCatPreadmref21;

        [XmlElement("PreDocTypAR21")]
        public string PreDocTypAR21
        {
            get { return _preDocTypAr21; }
            set
            {
                _preDocTypAr21 = value;
                var stringForCheck = value + PreDocRefAR26 + PreDocCatPREADMREF21;
                PreDocRefLNG = Repository.MainSettings.FoundGreekLetters(stringForCheck) ? "EL" : "EN";
            }
        }

        [XmlElement("PreDocRefAR26")]
        public string PreDocRefAR26
        {
            get { return _preDocRefAr26; }
            set
            {
                _preDocRefAr26 = value;
                var stringForCheck = PreDocTypAR21 + value + PreDocCatPREADMREF21;
                PreDocRefLNG = Repository.MainSettings.FoundGreekLetters(stringForCheck) ? "EL" : "EN";
            }
        }

        [XmlElement("PreDocCatPREADMREF21")]
        public string PreDocCatPREADMREF21
        {
            get { return _preDocCatPreadmref21; }
            set
            {
                _preDocCatPreadmref21 = value;
                var stringForCheck = PreDocTypAR21 + PreDocRefAR26 + value;
                PreDocRefLNG = Repository.MainSettings.FoundGreekLetters(stringForCheck) ? "EL" : "EN";
            }
        }

        [XmlElement("PreDocRefLNG")]
        public string PreDocRefLNG
        {
            get { return _preDocRefLng; }
            set { _preDocRefLng = value; }
        }


    }
}