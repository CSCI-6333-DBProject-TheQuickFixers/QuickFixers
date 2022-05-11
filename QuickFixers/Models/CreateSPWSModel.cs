using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace QuickFixers.Models
{
    public class CreateSPWSModel
    {
        [Display(Name = "Service Provider ID")]
        public int SPId { get; set; }

        [Required(ErrorMessage = "Day of the Week is required.")]
        public Day WeekDay { get; set; }

        [Required(ErrorMessage = "Start Time is required.")]
        public string StartT { get; set; }

        [Required (ErrorMessage = "End Time is required.")]
        public string EndT { get; set; }

        [Required(ErrorMessage = "TimeZone is required")]
        public TimeZone TZ { get; set; }

        public IEnumerable<SelectListItem> ListOfTimeIntervals
        {
            get
            {
                var list = new List<SelectListItem>();
                // range of hours, multiplied by 4 (e.g. 24 hours = 96)
                int timeRange = 96;

                // range of minutes, e.g. 15 min
                int minuteRange = 15;

                // starting time, e.g. 0:00
                TimeSpan startTime = new TimeSpan(0, 0, 0);

                // placeholder
                list.Add(new SelectListItem { Text = "Choose a time", Value = "0", Disabled = true });

                // get standard ticks
                DateTime startDate = new DateTime(DateTime.MinValue.Ticks);

                // create time format based on range above
                for (int i = 0; i < timeRange; i++)
                {
                    int minutesAdded = minuteRange * i;
                    TimeSpan timeAdded = new TimeSpan(0, minutesAdded, 0);
                    TimeSpan tm = startTime.Add(timeAdded);
                    DateTime result = startDate + tm;

                    list.Add(new SelectListItem { Text = result.ToString("HH:mm:ss"), Value = result.ToString("HH:mm:ss") });
                }

                return list;
            }
        }

        public IEnumerable<SelectListItem> DayList
        {
            get
            {
                var list = new List<SelectListItem>();

                // placeholder
                list.Add(new SelectListItem { Text = "Choose a Day", Value = "0", Disabled = true });

                list.Add(new SelectListItem { Text = "Monday", Value = "Monday" });
                list.Add(new SelectListItem { Text = "Tuesday", Value = "Tuesday" });
                list.Add(new SelectListItem { Text = "Wednesday", Value = "Wednesday" });
                list.Add(new SelectListItem { Text = "Thursday", Value = "Thursday" });
                list.Add(new SelectListItem { Text = "Friday", Value = "Friday" });
                list.Add(new SelectListItem { Text = "Saturday", Value = "Saturday" });
                list.Add(new SelectListItem { Text = "Sunday", Value = "Sunday" });

                return list;
            }
        }

        public IEnumerable<SelectListItem> TZList
        {
            get
            {
                var list = new List<SelectListItem>();

                // placeholder
                list.Add(new SelectListItem { Text = "Choose a TimeZone", Value = "0", Disabled = true });

                list.Add(new SelectListItem { Text = "HST", Value = "HST" });
                list.Add(new SelectListItem { Text = "AKST", Value = "AKST" });
                list.Add(new SelectListItem { Text = "PST", Value = "PST" });
                list.Add(new SelectListItem { Text = "MST", Value = "MST" });
                list.Add(new SelectListItem { Text = "CST", Value = "CST" });
                list.Add(new SelectListItem { Text = "EST", Value = "EST" });

                return list;
            }
        }
    }

    public enum Day
    {
        Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
    }

    public enum TimeZone
    {
        HST, AKST, PST, MST, CST, EST
    }






}