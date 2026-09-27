using BenchmarkDotNet.Running;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace AcademyScheduleAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] sessionNames =
            {
              "C# Basics",
               "Arrays",
                "Functions",
                "Date and Time",
                 "Exception Handling"
        };

            DateTime[] sessionDates =
                    {
                  new DateTime(2026, 9, 10, 18, 0, 0),
                  new DateTime(2026, 9, 13, 18, 0, 0),
                  new DateTime(2026, 9, 17, 18, 0, 0),
                  new DateTime(2026, 9, 20, 18, 0, 0),
                  new DateTime(2026, 9, 24, 18, 0, 0)
                };
            int[] sessionDurations = { 180, 240, 180, 240, 180 };

            int choice;

            do
            {
                Console.WriteLine("===================================");
                Console.WriteLine("Academy Schedule Analyzer");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Display all sessions");
                Console.WriteLine("2. Search for a session");
                Console.WriteLine("3. Sort session names");
                Console.WriteLine("4. Reverse session names");
                Console.WriteLine("5. Find session index");
                Console.WriteLine("6. Check if session exists");
                Console.WriteLine("7. Show duration statistics");
                Console.WriteLine("8. Show session date details");
                Console.WriteLine("9. Show past and upcoming sessions");
                Console.WriteLine("10. Find next session");
                Console.WriteLine("11. Compare two session dates");
                Console.WriteLine("12. Read and validate a custom date");
                Console.WriteLine("13. Select session by index");
                Console.WriteLine("14. Validate session duration");
                Console.WriteLine("15. Generate report using string");
                Console.WriteLine("16. Generate report using StringBuilder");
                Console.WriteLine("17. Add your Durations");
                Console.WriteLine("0. Exit");

                Console.Write("Choose an option: ");
                choice = ReadMenuOption();

                switch (choice)
                {
                    case 1:
                        DisplaySession(sessionNames, sessionDates, sessionDurations);
                        break;

                    case 2:
                     Search(sessionNames, sessionDates, sessionDurations);
                        break;

                    case 3:
                        Sort(sessionNames);
                        break;
                    case 4:
                        Reverse(sessionNames);
                        break;
                    case 5:
                        FindIndex(sessionNames);
                        break;
                    case 6:
                        TestExist(sessionNames);
                        break;
                    case 7:
                        int totalDurations = GetTotalDuration(sessionDurations);
                        Console.WriteLine($"Total Durations = {totalDurations} minutes");
                        double avergDurations = GetAverageDuration(sessionDurations);
                        Console.WriteLine($"Average Durations = {avergDurations} minutes");
                        int shortestDurations = GetShortestDuration(sessionDurations);
                        Console.WriteLine($"Shortest Durations = {shortestDurations} minutes");
                        int longestDurations = GetLongestDuration(sessionDurations);
                        Console.WriteLine($"Longest Durations = {longestDurations} minutes");

                        break;
                    case 8:
                        ShowSessionDateDetails(sessionNames, sessionDurations, sessionDates);
                        break;
                    case 9:
                        ShowPastAndUpcomingSessions(sessionNames, sessionDates);
                        break; 
                    case 10:
                        ShowNextSession(sessionNames, sessionDates);
                        break;
                    case 11:
                        DateDifference(sessionNames, sessionDates);
                        break;
                    case 12:
                        ReadCustomDate();
                        break;
                    case 13:
                        FindByIndex(sessionNames);
                        break;
                    case 14:
                        AcceptedDurations();
                        break;
                    case 15:
                        string stringReport = CreateReport(sessionNames, sessionDurations, sessionDates);
                       Console.WriteLine(stringReport);
                        break;
                    case 16:
                       string secondReport = ReportByStringBuilder(sessionNames, sessionDurations, sessionDates);
                        Console.WriteLine(secondReport);
                        break;
                    case 17:
                        AcceptedDurations();
                        break;

                    case 0:
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

            } while (choice != 0);


            BenchmarkRunner.Run<Benchmark>();

            int number = 5;
            Console.WriteLine($"number before ref test = {number}");
            int result =  RefTest(ref number);
            Console.WriteLine(result);

            int index, duration;
            OutTest(out index, out duration, sessionNames, sessionDurations);

            CalculateTotalDuration(120, 180);
            CalculateTotalDuration(120, 180,240);
            CalculateTotalDuration(60,90,120, 180,240);

        }


        public static void DisplaySession(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            for (int i = 0; i < sessionNames.Length; i++) 
            {

                Console.WriteLine($"{i + 1}. {sessionNames[i]}");
                Console.WriteLine($"Date: {sessionDates[i].ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Start Time: {sessionDates[i]:hh:mm tt}");
                Console.WriteLine($"Duration: {sessionDurations[i]} minutes");
                Console.WriteLine();
            }

        }
        public static void Search(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            Console.WriteLine("Enter session Name ");
            string input = Console.ReadLine()!;

            int index = Array.IndexOf(sessionNames, input);
            if (index == -1)
            {
                Console.WriteLine("Session not found");
            }
            else
            {
                Console.WriteLine($"{index + 1}. {sessionNames[index]}");
                Console.WriteLine($"Date: {sessionDates[index].ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Start Time: {sessionDates[index]:hh:mm tt}");
                Console.WriteLine($"Duration: {sessionDurations[index]} minutes");
                Console.WriteLine($"the index for this session equal: {index}");
            }

        }

        public static  void TestExist(string[] sessionNames) 
        {
            Console.WriteLine("Enter Session Name:");
            string input = Console.ReadLine()!;
            bool isExist = Array.Exists(sessionNames, x => x == input);
            if (!isExist)
            {
                Console.WriteLine($"This Session {input} Dosen't Exist");
            }
            else
            {
                Console.WriteLine($"This Session {input} Exist");
            }

        }

        public static void Sort(string[] sessionNames)
        {
            // COPY AND SORT :
            string[] sessions = new string[5];
            Array.Copy(sessionNames, sessions, 5);
            Array.Sort(sessions);
            Console.WriteLine("The Sorted Elements : ");
            for (int i = 0; i < sessions.Length; i++)
            {
                Console.WriteLine(sessions[i]);
            }

        }
        public static void Reverse(string[] sessionNames)
        {
            string[] sessions = new string[5];
            Array.Copy(sessionNames, sessions, 5);
            // Copy AND Reverse : 
            Array.Reverse(sessions);
            Console.WriteLine("The Reversed Elements : ");
            for (int i = 0; i < sessions.Length; i++)
            {
                Console.WriteLine(sessions[i]);
            }

        }

        public static void CopyAndChange(string[] sessionNames)
        {
            string[] sessions =  new string [5];
            Array.Copy(sessionNames, sessions, 5);
            sessions[0] = "Element changed";

            Console.WriteLine("the original Array :");
            foreach(string s in sessionNames)
            {
                 Console.WriteLine(s); 
            }
            Console.WriteLine("the copied Array :");
            foreach (string s in sessions)
            {
                Console.WriteLine(s);
            }

        }

        public static void FindIndex (string[] sessionNames)
        {
            Console.WriteLine("Enter Session Name: ");
            string input = Console.ReadLine()!;
            string? element = Array.Find(sessionNames, (x) => x.Equals(input, StringComparison.OrdinalIgnoreCase));
            if (sessionNames.Contains(element))
            {
                Console.WriteLine($"Session Exist : {element}");
            }
            else{
                Console.WriteLine("invalid name");
            }
            int index = Array.FindIndex(sessionNames, x => x.Equals(input));
            if (index != -1) 
            {
                Console.WriteLine($"the index for {input} Session = {index}");

            }
            else
            {
                Console.WriteLine("session not found ");
            }
        }

        public static int GetTotalDuration(int[] sessionDurations)
        {
            int totalDuration = 0;
            for(int i = 0;i < sessionDurations.Length; i++)
            {
                totalDuration+= sessionDurations[i];
            }

            return totalDuration;

        }
        public static void CalculateTotalDuration( params int[] sessionDurations)
        {
            int totalDuration = 0;
            for (int i = 0; i < sessionDurations.Length; i++)
            {
                totalDuration += sessionDurations[i];
            }

            Console.WriteLine(totalDuration);

        }

        public static double GetAverageDuration(int[] sessionDurations) 
        {
            double averageDuration = (double) GetTotalDuration(sessionDurations) / sessionDurations.Length;
             return averageDuration;
        }

        public static int GetShortestDuration(int[] sessionDurations)
        {

            int element = sessionDurations[0];
            for (int i = 1; i < sessionDurations.Length; i++) 
            {
                if (element > sessionDurations[i])
                {
                    element = sessionDurations[i];
                }

            }
            return  element;
        }

        public static int GetLongestDuration(int[] sessionDurations)
        {

            int element = sessionDurations[0];
            for (int i = 1; i < sessionDurations.Length; i++)
            {
                if (element < sessionDurations[i])
                {
                    element = sessionDurations[i];
                }
                
            }
            return element;
        }
            
        public static void SortDurations (int[] sessionDurations)
        {
            int[] duration = new int[5];
            Array.Copy(sessionDurations, duration, 5);
            Array.Sort(duration);
            Console.WriteLine("the sorted durations is:");
            foreach (int element in duration)
            {
                Console.WriteLine(element);
            }
        }

        public static void ShowSessionDateDetails(string[] sessionNames, int[] sessionDurations, DateTime[]sessionDates )
        {
            Console.WriteLine("Enter Session Name: ");
            string input = Console.ReadLine()!;
            int index = Array.IndexOf(sessionNames, input);
            if (index == -1)
            {
                Console.WriteLine("session not found , please Enter a valid name");

            }
            else
            {
                DateTime startTime = sessionDates[index];
                int duration = sessionDurations[index];
                DateTime endTime = startTime.AddMinutes(duration);
                Console.WriteLine($"Session: {input}");
                Console.WriteLine($"Date: {startTime.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Day: {startTime.DayOfWeek}");
                Console.WriteLine($"Year: {startTime.Year}");
                Console.WriteLine($"Month: {startTime.Month}");
                Console.WriteLine($"Day Number: {startTime.Day}");
                Console.WriteLine($"Start Time: {startTime.ToString("hh:mm tt", CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Duration: {duration} minutes");
                Console.WriteLine($"End Time: {endTime.ToString(":hh:mm tt", CultureInfo.InvariantCulture)}");
            }

        }



        public static void DateDifference(string[] sessionNames, DateTime[]sessionDates)
        {
            Console.WriteLine("Enter First Session :");
            string input =Console.ReadLine()!;
            Console.WriteLine("Enter Second Session :");
            string input2 = Console.ReadLine()!;
            int firstIndex = Array.IndexOf(sessionNames, input);
            int secondIndex = Array.IndexOf(sessionNames, input2);

            if (firstIndex == -1 && secondIndex == -1)
            {
                Console.WriteLine(" please Enter a valid session name ");

            }
            else
            {
                TimeSpan difference = sessionDates[firstIndex] - sessionDates[secondIndex];
                int days = difference.Days;
                int hours = difference.Hours;
                Console.WriteLine($"days = {days},hours = {hours}");
            }
            //TimeSpan difference = sessionDates[firstIndex] - sessionDates[secondIndex];
            //int days = difference.Days;
           // int hours = difference.Hours;
            //Console.WriteLine($"days = {days},hours = {hours}"); 

        }


        public static void ShowPastAndUpcomingSessions(string[] sessionNames, DateTime[] sessionDates)
        {
            for (int i = 0; i < sessionNames.Length; i++)
            {
                if (sessionDates[i] < DateTime.Now)
                {
                    Console.WriteLine($"{sessionNames[i]} Past");
                }
                else
                {
                    Console.WriteLine($"{sessionNames[i]} Upcoming");
                }
            }
        }
        public static void ShowNextSession(string[] sessionNames, DateTime[] sessionDates)
        {
            for (int i = 0; i < sessionNames.Length; i++)
            {
                if (sessionDates[i] > DateTime.Now)
                {
                    Console.WriteLine($"Next Session is : {sessionNames[i]}");
                    DateTime date =sessionDates[i];
                    TimeSpan difference = date - DateTime.Now;
                    Console.WriteLine($"{sessionDates[i].ToString("dd MMMM yyyy hh:mm tt",CultureInfo.InvariantCulture)}");
                    Console.WriteLine($"Time Remaining: {difference.Days} days {difference.Hours} hours");
                    break;
                }

            }
        }

        public static void FindByIndex(string[] sessionNames)
        {
            Console.Write("Enter session index: ");

            try
            {

                if (int.TryParse(Console.ReadLine(), out int index))
                {

                        Console.WriteLine($"Selected Session: {sessionNames[index]}");
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
            catch (IndexOutOfRangeException)
            {
               Console.WriteLine("Invalid index.The index is outside the array range.");
            }
        }

        public static void ReadCustomDate()
        {
            DateTime date;
            bool isValid;

            do
            {
                Console.Write("Enter a date (yyyy-MM-dd): ");
                string input = Console.ReadLine()!;

                isValid = DateTime.TryParseExact(
                    input,
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out date);

                if (!isValid)
                {
                    Console.WriteLine("Invalid date. Try again.");
                }

            } while (!isValid);

            Console.WriteLine($"Valid date: {date.ToString("dd MMMM yyyy ",CultureInfo.InvariantCulture)}");
        }

        public static void AcceptedDurations()
        {
            try
            {
                Console.WriteLine("Enter Duration :");
                if (int.TryParse(Console.ReadLine(), out int duration))
                {
                    if (duration > 0)
                    {
                        Console.WriteLine("Duration Accepted");
                    }
                    else
                    {
                        throw new ArgumentException() ;
                    }

                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Duration must be greater than zero.");
            }
            finally
            {
                Console.WriteLine("Input operation finished.");
            }
        }

        public static int ReadMenuOption()
        {
            while (true)
            {
                Console.Write("Choose an option: ");

                try
                {
                    int option = int.Parse(Console.ReadLine()!);
                    return option;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid menu option. Enter a number.");
                }
            }
        }

        public static string CreateReport(string[] sessionNames, int[]sessionDurations, DateTime[]sessionDates)
        {
            string report = "";
            for (int i = 0; i < sessionNames.Length; i++)
            {
                report += $"{sessionNames[i]}- {sessionDates[i].ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture)},{sessionDurations[i]} minutes\n";

            }
            return report;
        }
        public static string ReportByStringBuilder(string[] sessionNames, int[] sessionDurations, DateTime[] sessionDates)
        {
            StringBuilder report = new StringBuilder();
            for (int i = 0; i < sessionNames.Length; i++)
            {
                report.AppendLine($"{sessionNames[i]}- {sessionDates[i].ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture)},{sessionDurations[i]} minutes\n"); 

            }
            return report.ToString();
        }


        public static int RefTest(ref int number)
        {
            Console.WriteLine("number after ref test = ");
            number += 10;
            return number;
        }

        public static bool OutTest(out int index,out int duration, string[] sessionNames, int[] sessionDurations)
        {
            Console.WriteLine("Enter session Name:");
            string input = Console.ReadLine()!;
             index = Array.IndexOf(sessionNames, input);
            Console.WriteLine($"index = {index}");
             duration = sessionDurations[index];
            Console.WriteLine($"the duration = {duration}");

            return true;

        }
        
     






    }
}
