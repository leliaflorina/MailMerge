using Demo.Models;
using Demo.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class DemoProvider : IReportProvider<ReportData>
    {
        public ReportData Build(string title)
        {
            //var notes = new StringModel[3];
            //notes[0] = new StringModel { Value = "<ul><li> This is a list </li><li> This is a list </li> </ul> " };
            //notes[1] = new StringModel { Value = "<h1>Hello World</h1>" };
            //notes[2] = new StringModel { Value = "<strong>This text is important!</strong>" };

            var records = new GroupModel[5];
            records[0] = new GroupModel
            {
                Description = "Lorem ipsum dolor sit amet",
                Notes = "<ul><li> This is a list </li><li> This is a list </li> </ul>",
                Title = "Lorem ipsum",
            };
            records[1] = new GroupModel
            {
                Description = "Lorem ipsum dolor sit amet, qui cu pericula posidonium,g ne usu, an vel iudid usu malorum iracundia.Mei ad munere Aliquando sadipscing ne usu, an vel iudid usu malorum iracundia.Mei ad mun id usu malorum iracundia. Aliquando sadipscing ne usu, an vel iudicabit efficiantur, te oblique sapientem mei. Mel ne scriptorem repudiandae.",
                Notes = "<ul><li> This is a list </li ><li> This is a list </li> </ul>",
                Title = "Nam incorrupte repudiandae reprehendunt ad",
            };
            records[2] = new GroupModel
            {
                Description = "Lorem ipsum dolor sit amet,   putant maiorum, est te option docendi. Te tritani disputationi pro. Vix at adhuc atqui fastidii, duo falli accusata te. Aliquando sadipscing ne usu, an vel iudicabit efficiantur, te oblique sapientem mei. Mel ne scriptorem repudiandae.",
                
                Title = "Tale illud in sea, ocurreret imperdiet posidonium in sed, vim dolor interpretaris te. No vocibus apeirian reprehendunt his.",
            };
            records[3] = new GroupModel
            {
                //Description = "Lorem ipsum dolor sit amet, qui cu pericula posidonium, solum suavitate assentior id quo, id usu malorum iracundia. Aliquando sadipscing ne usu, an vel iudicabit efficiantur, te oblique sapientem mei. Mel ne scriptorem repudiandae.",
                
                Title = "Tale illud in sea, ocurreret imperdiet posidonium in sed.",
                //Notes= "<h1> Hello World </h1>"
            };
            records[4] = new GroupModel
            {
                Notes = "<strong>This text is important!</strong>",
                // Description = "Lorem ipsum dolor sit amet, qui cu pericula posidonium, solum suavitate assentior id quo, id usu malorum iracundia. Aliquando sadipscing ne usu, an vel iudicabit efficiantur, te oblique sapientem mei. Mel ne scriptorem repudiandae.",

                Title = "Tale illud in sea solum suavitate assentior id quo.Aliquando sadipscin",
            };

            return new ReportData
            {
                Title = title,
                Objective = "<h4>Heading 4</h4><h5> Heading 5 </h5><h6> Heading 6 </h6>",
                Records=records,
                Stamp = DateTime.Now,
            };
        }
    }
}
