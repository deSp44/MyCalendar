using System;
using System.Collections.Generic;
using System.IO;
using MyCalendar.App.Helpers;
using MyCalendar.App.Models;

namespace MyCalendar.App.CalendarService
{
    public class BaseService
    {
        internal static readonly string FilePathCal = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MyCalendarData\CalendarEventData.xml");
        internal static readonly string FilePathTask = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MyCalendarData\CalendarTaskData.xml");
        internal static readonly FileHelpersXml<List<Calendar>> FileHelperEvent = new(FilePathCal);
        internal static readonly FileHelpersXml<List<Task>> FileHelperTask = new(FilePathTask);
    }
}