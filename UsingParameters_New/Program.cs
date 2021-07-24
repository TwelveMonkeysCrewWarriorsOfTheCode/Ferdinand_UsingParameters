using System;
using UsingParametersBLL;

namespace UsingParameters_New
{
    class Program
    {
        #region Entry point of program
        static void Main(string[] args)
        {
            try
            {
                ManageDisplay();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Managing display
        static void ManageDisplay()
        {
            Console.WriteLine();
            Console.WriteLine("************ Opérations sur le temps *****************");
            Console.WriteLine("'1' surchage des opérateurs , '2' surcharge des opérateurs de conversion, '3' surcharge des opérateurs relationnels");
            Console.WriteLine("Faites votre choix: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    DisplayResultOperatorOverloading();
                    break;
                case 2:
                    DisplayResultOverloadingConversionOperator();
                    break;
                case 3:
                    DisplayResultOverloadingRelationalOperator();
                    break;
            }
        }
        #endregion

        #region Display result operator overloading
        static void DisplayResultOperatorOverloading()
        {
            char operationChoice = GetOverloadingType("Surcharge des opérateurs");
            if (operationChoice == 'a' || operationChoice == 'A')
            {
                GetResultWithOperatorOverloading("Addition");
            }
            else if (operationChoice == 's' || operationChoice == 'S')
            {
                GetResultWithOperatorOverloading("Soustraction");
            }
            else if (operationChoice == 'm' || operationChoice == 'M')
            {
                GetResultWithOperatorOverloading("Multiplication");
            }
            else if (operationChoice == 'd' || operationChoice == 'D')
            {
                GetResultWithOperatorOverloading("Division");
            }
        }
        #endregion

        #region Display result overloading operator
        static void DisplayResultOverloadingConversionOperator()
        {
            GetOverloadingConversion("Surcharge des opérateurs de conversion");
            Console.WriteLine();
            Console.WriteLine("*** conversion type int en type Time **** ");
            int minutes = GetTimeInMinute();
            Time myTime = new Time(minutes);
            Console.WriteLine($"{minutes} min ==> {myTime}\n");
            Console.WriteLine("*** conversion type Time en type int **** ");
            Time time = GetTime(0);
            Console.WriteLine($"{time} ==> {(int)time} min\n");
            Console.WriteLine("*** conversion type Time en type float **** ");
            Console.WriteLine($"{time} ==> {(float)time} heure(s)\n");
            Console.WriteLine("*** conversion type float en type Time **** ");
            float minuteInFloat = GetFloatTime();
            Time myFloatTime = new Time(minuteInFloat);
            Console.WriteLine($"{minuteInFloat} heure(s) ==> {myFloatTime}");
        }
        #endregion

        #region Display result overloading relational operator
        static void DisplayResultOverloadingRelationalOperator()
        {
            GetOverloadingConversion("Surcharge des opérateurs relationnels");
            Time time1 = GetTime(1);
            Time time2 = GetTime(2);
            Console.WriteLine($"Comparaison: {time1} < {time2} --> {time1 < time2}");
            Console.WriteLine($"Comparaison: {time1} > {time2} --> {time1 > time2}");
            Console.WriteLine($"Comparaison: {time1} <= {time2} --> {time1 <= time2}");
            Console.WriteLine($"Comparaison: {time1} >= {time2} --> {time1 >= time2}");
            Console.WriteLine($"Comparaison: {time1} == {time2} --> {time1.Equals(time2)}");
            Console.WriteLine($"Comparaison: {time1} != {time2} --> {time1 != time2}");
        }
        #endregion

        #region Get result with operator overloading
        static void GetResultWithOperatorOverloading(string pOperation)
        {
            char typeOperation = GetOperationType(pOperation);

            if (typeOperation == 'A' || typeOperation == 'a')
            {
                Time time1 = GetTime(1);
                Time time2 = GetTime(2);
                Console.WriteLine($"{time1} + {time2} = " + "{0}", time1 + time2);
            }
            else if (typeOperation == 'S' || typeOperation == 's')
            {
                Time time1 = GetTime(1);
                Time time2 = GetTime(2);
                Console.WriteLine($"{time1} - {time2} = " + "{0}", time1 - time2);
            }
            else if (typeOperation == 'M' || typeOperation == 'm')
            {
                Time time = GetTime(0);
                int coeff = GetCoeff();
                Console.WriteLine($"{time} * {coeff} = " + "{0}", time * coeff);
            }
            else if (typeOperation == 'D' || typeOperation == 'd')
            {
                Time time = GetTime(0);
                int coeff = GetCoeff();
                Console.WriteLine($"{time} / {coeff} = " + "{0}", time / coeff);
            }
        }
        #endregion

        #region Methods
        static char GetOverloadingType(string pOverloadingType)
        {
            GetOverloadingConversion(pOverloadingType);
            Console.WriteLine("'A' addition, 'S' soustraction, 'M' Multiplication, 'D' division");
            return char.Parse(Console.ReadLine());
        }

        static void GetOverloadingConversion(string pOverloadingType)
        {
            Console.WriteLine($"++++++++++++++++ {pOverloadingType} +++++++++++++++++++++");
        }
        static char GetOperationType(string pOperationType)
        {
            Console.WriteLine($"++++++++++++++++ {pOperationType} +++++++++++++++++++++");
            return pOperationType[0];
        }
        static Time GetTime(int pNumTime)
        {
            Console.WriteLine($"Temps{pNumTime}: entrez les heures:");
            int hour = int.Parse(Console.ReadLine());
            Console.WriteLine($"Temps{pNumTime}: entrez les minutes:");
            int minute = int.Parse(Console.ReadLine());
            return new Time(hour, minute);
        }
        static int GetCoeff()
        {
            Console.WriteLine("Entrez un coefficient pour l'opération: ");
            int myCoeff = int.Parse(Console.ReadLine());
            if (myCoeff <= 0) throw new ArgumentOutOfRangeException("L'entier doit être positif et différnet de 0!");
            return myCoeff;
        }

        static int GetTimeInMinute()
        {
            Console.WriteLine("Entrez un temps en minute: ");
            int inputTimeInMinute = int.Parse(Console.ReadLine());
            if (inputTimeInMinute <= 0) throw new ArgumentOutOfRangeException("Entrez un nombre positif et différent de 0!");
            return inputTimeInMinute;
        }

        static float GetFloatTime()
        {
            Console.WriteLine("Entrez un temps en minute à virgule");
            float inputFloatTime = float.Parse(Console.ReadLine());
            if (inputFloatTime <= 0) throw new ArgumentOutOfRangeException("Entrez nombre strictement supérieur à 0.");
            return inputFloatTime;
        } 
        #endregion
    }
}
