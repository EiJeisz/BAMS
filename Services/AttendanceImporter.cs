using BAMS.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BAMS.Services
{
    public class AttendanceImporter
    {
        public void Import(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            var grouped = lines
                .Select(x => x.Split(','))
                .Select(x => new
                {
                    UserId = int.Parse(x[0]),
                    DateTime = DateTime.Parse(x[1])
                })
                .GroupBy(x => new { x.UserId, Day = x.DateTime.Date });

            foreach (var g in grouped)
            {
                var times = g.Select(x => x.DateTime.TimeOfDay)
                             .OrderBy(t => t)
                             .ToList();

                TimeSpan? amIn = null;
                TimeSpan? amOut = null;
                TimeSpan? pmIn = null;
                TimeSpan? pmOut = null;

                if (times.Count > 0) amIn = times[0];
                if (times.Count > 1) amOut = times[1];
                if (times.Count > 2) pmIn = times[2];
                if (times.Count > 3) pmOut = times[3];

                AttendanceRepository repo = new AttendanceRepository();
                repo.InsertAttendance(g.Key.UserId, g.Key.Day, amIn, amOut, pmIn, pmOut);
            }
        }
    }
}