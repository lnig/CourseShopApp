using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ShopApp.Model;
using ShopApp.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ShopApp.Utils
{
    public class PdfCreator
    {
        private CourseRepository courseRepository = new CourseRepository();
        public PdfCreator()
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
        }

        public void GenerateCourseList()
        {
            List<Course> courses = courseRepository.GetAllCoursesWithCategory();
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A3);
                    page.Margin(2, QuestPDF.Infrastructure.Unit.Centimetre);
                    page.Header().Text(text =>
                    {
                        text.AlignCenter();
                        text.Span("Course List").FontSize(30);
                    });
                    page.Content()
                    .PaddingVertical(1, QuestPDF.Infrastructure.Unit.Centimetre)
                    .Column(x =>
                    {
                        x.Spacing(10, QuestPDF.Infrastructure.Unit.Centimetre);
                        x.Item().Table(table =>
                        {
                            IContainer DefaultCellStyle(IContainer newcontainer, string backgroundColor)
                            {
                                return newcontainer
                                    .Border(1)
                                    .BorderColor(Colors.Grey.Lighten1)
                                    .Background(backgroundColor)
                                    .PaddingVertical(5)
                                    .PaddingHorizontal(10)
                                    .AlignCenter()
                                    .AlignMiddle();
                            }

                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(100);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Element(CellStyle).Text("Image");
                                header.Cell().Element(CellStyle).Text("Title");
                                header.Cell().Element(CellStyle).Text("Description");
                                header.Cell().Element(CellStyle).Text("Category");
                                header.Cell().Element(CellStyle).Text("Price");
                                header.Cell().Element(CellStyle).Text("Author");
                                header.Cell().Element(CellStyle).Text("Rating");

                                IContainer CellStyle(IContainer newcontainer) => DefaultCellStyle(newcontainer, Colors.Grey.Lighten3);
                            });

                            foreach (var course in courses)
                            {
                                table.Cell().Image(GetBytesOfImage());
                                table.Cell().Text(course.Title).AlignCenter();
                                table.Cell().Text(course.ShortDescription).AlignCenter();
                                table.Cell().Text(course.Category.Name).AlignCenter();
                                table.Cell().Text(course.Prize).AlignCenter();
                                table.Cell().Text(course.Author).AlignCenter();
                                table.Cell().Text(course.Rating.ToString()).AlignCenter();
                            }
                        });
                    });
                });
            }).GeneratePdf(GetDesktopPath("CourseList.pdf"));
        }

        public byte[] GetBytesOfImage()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(currentDirectory, @"..\..\Assets\Illustrations\programming.jpg");
            return File.ReadAllBytes(sFile);
        }

        private string GetDesktopPath(string fileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            return Path.Combine(desktopPath, fileName);
        }
    }
}
