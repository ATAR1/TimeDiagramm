using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using TimeDiagrammGeneratorLibrary;

namespace TimeDiagrammWPF_View
{
    internal class VM
    {
        public VM()
        {

            var diagramm = TimeDiagramGenerator.GenerateDiagramm(
                new List<Interval[]>(){
                    new Interval[]
                    {
                        new Interval() {StartTime = new TimeSpan(2,0,0), Duration = new TimeSpan(0,15,0)},
                        new Interval() {StartTime = new TimeSpan(0,55,0), Duration = new TimeSpan(0,15,0)},
                        new Interval() {StartTime = new TimeSpan(23,55,0), Duration = new TimeSpan(0,15,0)}
                    },
                    new Interval[]
                    {
                        new Interval() {StartTime = new TimeSpan(1,2,20,0), Duration = new TimeSpan(0,15,0)},
                        new Interval() {StartTime = new TimeSpan(1,1,55,0), Duration = new TimeSpan(0,10,0)},
                        new Interval() {StartTime = new TimeSpan(23,45,0), Duration = new TimeSpan(0,5,0)}
                    },
                    new Interval[]
                    {
                        new Interval() {StartTime = new TimeSpan(1,5,25,0), Duration = new TimeSpan(0,15,0)},
                        new Interval() {StartTime = new TimeSpan(1,4,50,0), Duration = new TimeSpan(0,10,0)},
                        new Interval() {StartTime = new TimeSpan(23,50,0), Duration = new TimeSpan(0,5,0)}
                    },
                    new Interval[]
                    {
                        new Interval() {StartTime = new TimeSpan(1,7,30,0), Duration = new TimeSpan(0,15,0)},
                        new Interval() {StartTime = new TimeSpan(1,6,40,0), Duration = new TimeSpan(0,10,0)},
                        new Interval() {StartTime = new TimeSpan(23,55,0), Duration = new TimeSpan(0,5,0)},
                        new Interval() {StartTime = new TimeSpan(1,22,30,0), Duration = new TimeSpan(0,15,0)},
                        new Interval() {StartTime = new TimeSpan(19,40,0), Duration = new TimeSpan(0,10,0)},
                        new Interval() {StartTime = new TimeSpan(19,28,0), Duration = new TimeSpan(0,10,0)},
                        new Interval() {StartTime = new TimeSpan(19,14,0), Duration = new TimeSpan(0,10,0)},
                        new Interval() {StartTime = new TimeSpan(20,55,0), Duration = new TimeSpan(0,5,0)}
                    }
                });
            MemoryStream ms = new MemoryStream();
            diagramm.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            Diagramm = ms;
        }
        public Stream Diagramm { get; set; }
    }
}