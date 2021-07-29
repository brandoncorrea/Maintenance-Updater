using System;
using Maintenance_Updater.Extensions;

namespace Maintenance_Updater.Editor
{
    public class PromotionCode : IEquatable<PromotionCode>, IComparable<PromotionCode>
    {
        public char PriceMethod { get; private set; }
        public short MixMatchCode { get; private set; }

        public PromotionCode(string line)
        {
            if (line.Substring(0, 2) != "IT")
                throw new ArgumentException("IT line is required.");
            PriceMethod = line[109];

            MixMatchCode = line.Substring(250, 3) == "~~~" ? 
                (short)0 : short.Parse(line.Substring(250, 3));
        }
        
        public PromotionCode(char priceMethod, short mixMatchNumber)
        {
            PriceMethod = priceMethod;
            MixMatchCode = mixMatchNumber;
        }

        public void Increment()
        {
            if (MixMatchCode == 999)
                MixMatchCode = 1;
            else
                MixMatchCode++;
        }

        public bool IsPromotion()
        {
            return PriceMethod != '0' && PriceMethod != '~' && MixMatchCode != 0;
        }
        
        public bool Equals(PromotionCode other)
        {
            //Check whether the compared object is null.
            if (ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return MixMatchCode.Equals(other.MixMatchCode) 
                && PriceMethod.Equals(other.PriceMethod);
        }
        
        public override int GetHashCode()
        {
            int hashProductPriceMethod = PriceMethod.GetHashCode();
            int hashProductMixMatchCode = MixMatchCode.GetHashCode();

            return hashProductPriceMethod ^ hashProductMixMatchCode;
        }

        public PromotionCode Copy()
        {
            return new PromotionCode(PriceMethod, MixMatchCode);
        }

        public static bool operator== (PromotionCode code1, PromotionCode code2)
        {
            return code1?.MixMatchCode == code2?.MixMatchCode
                && code1?.PriceMethod == code2?.PriceMethod;
        }

        public static bool operator !=(PromotionCode code1, PromotionCode code2)
        {
            return code1?.MixMatchCode != code2?.MixMatchCode
                || code1?.PriceMethod != code2?.PriceMethod;
        }

        public override string ToString()
        {
            return PriceMethod + MixMatchCode.ToString().PadLeft(3, '0');
        }

        public string SetMixMatchCode(string line)
        {
            if (line.Substring(0, 2) != "IT")
                throw new ArgumentException("IT line is required.");
            
            return line
                .Replace(PriceMethod, 109)
                .Replace(MixMatchCode.ToString().PadLeft(3, '0'), 250);
        }

        public int CompareTo(PromotionCode other)
        {
            if (PriceMethod < other.PriceMethod)
                return 1;
            else if (PriceMethod > other.PriceMethod)
                return -1;
            else
            {
                if (MixMatchCode < other.MixMatchCode)
                    return 1;
                else if (MixMatchCode > other.MixMatchCode)
                    return -1;
                else return 0;
            }
        }
    }
}
