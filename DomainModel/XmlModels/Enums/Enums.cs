using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.XmlModels.Enums
{
    public enum TypeOfPayments
    {
        A,
        H
    }

    public enum Preference
    {
        One = 100,
        Two = 200,
        Three = 300,
        Four = 400
    }

    public enum Transfer
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4
    }

    public class Core
    {
        public static IEnumerable<TypeOfPayments> GetTypeOfPayments => Enum.GetValues(typeof(TypeOfPayments)).Cast<TypeOfPayments>();
        public static IEnumerable<Preference> GetPreference => Enum.GetValues(typeof(Preference)).Cast<Preference>();
        public static IEnumerable<Transfer> GetTransfer => Enum.GetValues(typeof(Transfer)).Cast<Transfer>();
    }
    
}
