using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class BiometricLog
{
    public int UserId { get; set; }
    public DateTime LogTime { get; set; }
}

public class BiometricLogParser
{
    public static List<BiometricLog> Parse(string path)
    {
        var logs = new List<BiometricLog>();
        var lines = File.ReadAllLines(path);

        foreach (var line in lines)
        {
            var parts = line.Split(' ');

            if (parts.Length >=2)
            {
                logs.Add(new BiometricLog
                {
                    UserId = int.Parse(parts[0]),
                    LogTime = DateTime.Parse(parts[1] + " " + parts[2])
                });
            }
        }

        return logs ;
    }
}