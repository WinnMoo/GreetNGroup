﻿using GreetNGroup.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreetNGroup.UAD
{
    public class UADHelperFunctions
    {
        public UADHelperFunctions()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logs"></param>
        /// <param name="logid"></param>
        /// <returns></returns>
        public static int NumberofLogs(List<GNGLog> logs, string logid)
        {
            int logcount = 0;
            for (int index = 0; index < logs.Count; index++)
            {
                if (logs[index].logID.Equals(logid) == true)
                {
                    logcount++;
                }
            }




            return logcount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logs"></param>
        /// <param name="month"></param>
        public static void LogsFortheMonth(List<GNGLog> logs, string month)
        {
            for (int i = logs.Count - 1; i >= 0; i--)
            {
                //Return the Name of the month
                DateTime parsedDate = DateTime.Parse(logs[i].dateTime);

                if (string.Compare(parsedDate.ToString("MMMM"), month) != 0)
                {
                    logs.Remove(logs[i]);
                }
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logs"></param>
        /// <param name="month"></param>
        public static void LogswithID(List<GNGLog> logs, string ID)
        {
            for (int i = logs.Count - 1; i >= 0; i--)
            {
                if (string.Compare(logs[i].logID, ID) != 0)
                {
                    logs.Remove(logs[i]);
                }
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usedCounts"></param>
        /// <param name="logID"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void Quick_Sort(List<int> usedCounts, List<string> logID, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(usedCounts, logID, left, right);

                if (pivot > 1)
                {
                    Quick_Sort(usedCounts, logID, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(usedCounts, logID, pivot + 1, right);
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usedCounts"></param>
        /// <param name="logID"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int Partition(List<int> usedCounts, List<string> logID, int left, int right)
        {
            int pivot = usedCounts[left];
            while (true)
            {

                while (usedCounts[left] < pivot)
                {
                    left++;
                }

                while (usedCounts[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    int temp = usedCounts[left];
                    usedCounts[left] = usedCounts[right];
                    usedCounts[right] = temp;

                    string tempID = logID[left];
                    logID[left] = logID[right];
                    logID[right] = tempID;

                   

                    if (usedCounts[left] == usedCounts[right])
                    {
                        left++;
                    }
                        
                }
                else
                {
                    return right;
                }
            }
        }

        public static void QuickSortD<T>(T[] data, List<string> urls) where T : IComparable<T>
        {
            Quick_SortD(data, urls, 0, data.Length - 1);
        }

        public static void Quick_SortD<T>(T[] data, List<string> urls, int left, int right) where T : IComparable<T>
        {
            int i, j;
            T pivot, temp;
            i = left;
            j = right;
            pivot = data[(left + right) / 2];

            do
            {
                while ((data[i].CompareTo(pivot) < 0) && (i < right)) i++;
                while ((pivot.CompareTo(data[j]) < 0) && (j > left)) j--;
                if (i <= j)
                {
                    temp = data[i];
                    string tempUrl = urls[i];
                    data[i] = data[j];
                    urls[i] = urls[j];
                    data[j] = temp;
                    urls[j] = tempUrl;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (left < j) Quick_SortD(data, urls, left, j);
            if (i < right) Quick_SortD(data, urls,  i, right);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public static double FindAverage(List<GNGLog> session)
        {
            double average = 0;
            double totalSessions = (session.Count) / 2;
            int totalTime = 0;
            for(int i = 1; i < session.Count;)
            {
                DateTime end = DateTime.Parse(session[i - 1].dateTime);
                DateTime beginning = DateTime.Parse(session[i].dateTime);
                TimeSpan duration = end - beginning;
                totalTime = totalTime + (int)duration.TotalMinutes;
                i = i + 2;
            }
            average = totalTime / totalSessions;
            
            return average;
        }

        public static void EntryLogswithURL(List<GNGLog> logs, string url)
        {
            for (int i = logs.Count - 1; i >= 0; i--)
            {
                string[] words = logs[i].description.Split(' ');
                if (string.Compare(words[2], url) != 0)
                {
                    
                    logs.Remove(logs[i]);
                }
            }
        }

        public static void ExitLogswithURL(List<GNGLog> logs, string url)
        {
            for (int i = logs.Count - 1; i >= 0; i--)
            {
                string logID = logs[i].logID;
                if(string.Compare(logID, "1001") != 0 && string.Compare(logID, "1005") != 0)
                {
                        logs.Remove(logs[i]);
                }
                if (string.Compare(logID, "1001") == 0)
                {
                    string[] word1001 = logs[i].description.Split(' ');
                    if (string.Compare(word1001[0], url) != 0)
                    {
                        logs.Remove(logs[i]);
                    }
                }
                if (string.Compare(logID, "1005") == 0)
                {
                    string[] word1005 = logs[i].description.Split(' ');
                    if (string.Compare(word1005[4], url) != 0)
                    {
                        logs.Remove(logs[i]);
                    }
                }
            }

        }
    }
}