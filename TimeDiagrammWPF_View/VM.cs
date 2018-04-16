using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using TimeDiagrammGeneratorLibrary;

namespace TimeDiagrammWPF_View
{
    internal class VM
    {
        public VM()
        {
            var ctx = new IntervalsDBTypesLibrary.IntervalsDBModelContainer();
            var list = ctx.Intervals.Where(i=>i.Object=="МДТ 6").ToList();
            var list2 = ctx.Intervals.Where(i => i.Object == "УНСК.ТО1.АУЗККТ").ToList();
            var list3 = ctx.Intervals.Where(i => i.Object == "УНСК.ТО1.МДТ 6").ToList();
            var diagrams = new List<Interval[]>() {
                list.Select(i=>new Interval() { Duration = i.Duration, Level = i.SpecialLevel, StartTime = i.StartTime}).ToArray(),
                list2.Select(i=>new Interval() { Duration = i.Duration, Level = i.SpecialLevel, StartTime = i.StartTime}).ToArray(),
                list3.Select(i=>new Interval() { Duration = i.Duration, Level = i.SpecialLevel, StartTime = i.StartTime}).ToArray()
            };


            var diagramm = TimeDiagramGenerator.GenerateDiagramm(diagrams);
                //new List<Interval[]>(){
                //    new Interval[]
                //    {
                //        new Interval() {StartTime = new DateTime(2018,1,1,8,0,0), Duration = new TimeSpan(0,15,0)},
                //        new Interval() {StartTime = new DateTime(2018,1,1,8,50,0), Duration = new TimeSpan(0,15,0)},
                //        new Interval() {StartTime = new DateTime(2018,1,1,9,20,0), Duration = new TimeSpan(0,15,0)},
                //        new Interval() {StartTime = new DateTime(2018,1,1,9,40,0), Duration = new TimeSpan(0,15,0)},
                //        new Interval() {StartTime = new DateTime(2018,1,1,19,0,0), Duration = new TimeSpan(0,15,0)},
                //        new Interval() {StartTime = new DateTime(2018,1,1,19,33,0), Duration = new TimeSpan(0,15,0)},
                //        new Interval() {StartTime = new DateTime(2018,1,1,19,50,0), Duration = new TimeSpan(0,15,0)},
                //        new Interval() {StartTime = new DateTime(2018,1,1,23,55,0), Duration = new TimeSpan(0,15,0)},
                //        new Interval() {StartTime = new DateTime(2018,1,2,2,0,0), Duration = new TimeSpan(0,15,0)},
                //        new Interval() {StartTime = new DateTime(2018,1,2,0,55,0), Duration = new TimeSpan(0,15,0)},

                //    },
                //    //new Interval[]
                //    //{
                //    //    new Interval() {StartTime = new DateTime(2018,1,2,1,2,20,0), Duration = new TimeSpan(0,15,0)},
                //    //    new Interval() {StartTime = new DateTime(2018,1,2,1,1,55,0), Duration = new TimeSpan(0,10,0)},
                //    //    new Interval() {StartTime = new DateTime(2018,1,1,23,45,0), Duration = new TimeSpan(0,5,0)}
                //    //},
                //    //new Interval[]
                //    //{
                //    //    new Interval() {StartTime = new DateTime(2018,1,2,1,5,25,0), Duration = new TimeSpan(0,15,0)},
                //    //    new Interval() {StartTime = new DateTime(2018,1,2,1,4,50,0), Duration = new TimeSpan(0,10,0)},
                //    //    new Interval() {StartTime = new DateTime(2018,1,1,23,50,0), Duration = new TimeSpan(0,5,0)}
                //    //},
                //    //new Interval[]
                //    //{
                //    //    new Interval() {StartTime = new DateTime(2018,1,2,1,7,30,0), Duration = new TimeSpan(0,15,0)},
                //    //    new Interval() {StartTime = new DateTime(2018,1,2,1,6,40,0), Duration = new TimeSpan(0,10,0)},
                //    //    new Interval() {StartTime = new DateTime(2018,1,1,23,55,0), Duration = new TimeSpan(0,5,0)},
                //    //    new Interval() {StartTime = new DateTime(2018,1,2,1,22,30,0), Duration = new TimeSpan(0,15,0)},
                //    //    new Interval() {StartTime = new DateTime(2018,1,2,19,40,0), Duration = new TimeSpan(0,10,0)},
                //    //    new Interval() {StartTime = new DateTime(2018,1,2,19,28,0), Duration = new TimeSpan(0,10,0)},
                //    //    new Interval() {StartTime = new DateTime(2018,1,2,19,14,0), Duration = new TimeSpan(0,10,0)},
                //    //    new Interval() {StartTime = new DateTime(2018,1,1,20,55,0), Duration = new TimeSpan(0,5,0)}
                //    //}
                //}        );
            MemoryStream ms = new MemoryStream();
            diagramm.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            Diagramm = ms;
        }
        public Stream Diagramm { get; set; }
    }
}