using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qwx
{
    internal class ComplexNumber
    {
        public double RealNumber{ get; set; }
        public double ImaginaryPart { get; set; }
        public double Modul { get; set; }
        public double Angle { get; set; }

        public ComplexNumber(double realNumber, double imaginaryPart)
        {
            RealNumber = realNumber;
            ImaginaryPart = imaginaryPart;
            Modul = Math.Sqrt(realNumber * realNumber + imaginaryPart * imaginaryPart);
            Angle = Math.Atan(imaginaryPart / realNumber);
        }

        public ComplexNumber(double realNumber):this(realNumber, 0) { }

        public ComplexNumber() : this(0, 0) { }

        public override string ToString()
        {
            if (RealNumber == 0)
                return $"{ImaginaryPart}i";
            else if (ImaginaryPart == 0)
                return $"{RealNumber}";
            else if (Math.Abs(ImaginaryPart) == 1)
                return (ImaginaryPart > 0) ? $"{RealNumber}+i" : $"{RealNumber}-i";
            else
                return (ImaginaryPart > 0) ? $"{RealNumber}+{ImaginaryPart}i" : $"{RealNumber}-{Math.Abs(ImaginaryPart)}i";
        }

        public ComplexNumber Add(ComplexNumber number)
        {
            var newRealNumber = RealNumber + number.RealNumber;
            var newImaginaryPart = ImaginaryPart + number.ImaginaryPart;
            return new ComplexNumber(newRealNumber, newImaginaryPart);
        }

        public ComplexNumber Minus(ComplexNumber number)
        {
            var newRealNumber = RealNumber - number.RealNumber;
            var newImaginaryPart = ImaginaryPart - number.ImaginaryPart;
            return new ComplexNumber(newRealNumber, newImaginaryPart);
        }

        public ComplexNumber Multiplication(ComplexNumber number)
        {
            var newRealNumber = RealNumber * number.RealNumber - ImaginaryPart * number.ImaginaryPart;
            var newImaginaryPart = RealNumber * number.ImaginaryPart + number.RealNumber * ImaginaryPart;
            return new ComplexNumber(newRealNumber, newImaginaryPart);
        }

        public ComplexNumber Div(ComplexNumber number)
        {
            var newRealNumber = (RealNumber * number.RealNumber + ImaginaryPart * number.ImaginaryPart) /
                (number.RealNumber * number.RealNumber + number.ImaginaryPart * number.ImaginaryPart);
            var newImaginaryPart = (number.RealNumber * ImaginaryPart - RealNumber*number.ImaginaryPart) /
                (number.RealNumber * number.RealNumber + number.ImaginaryPart * number.ImaginaryPart);
            return new ComplexNumber(newRealNumber, newImaginaryPart);
        }
        
    }
}
