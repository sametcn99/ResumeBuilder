using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ResumeBuilder.Properties;

namespace ResumeBuilder
{
    internal class ResumeLayouts
    {
        SqlControllers sqlControllers = new SqlControllers();
        public string[] titles = { "", "", "", "", "", "", "" };
        public void printingLanguage()
        {
            AppControllers appControllers = new AppControllers();
            if (Settings.Default.Language == "tr")
            {
                titles = appControllers.titlesTR;
            }
            else
            {
                titles = appControllers.titlesEN;
            }
        }

        public void ClassicLayout(string path, string name, string personDetails, string jobs, string educations, string certifications, string personalProjects, string languages, string interests, string skills, string summary)
        {
            printingLanguage();
            try
            {
                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(1, Unit.Centimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(11));
                        page.Header().Row(row =>
                        {
                            row.Spacing(15);
                            row.ConstantItem(150).Image(sqlControllers.getPicture());
                            row.RelativeItem().Column(column =>
                            {
                                column.Item().Text(name).FontSize(18).FontColor(Colors.Blue.Medium).Bold();
                                column.Item().Text(personDetails);
                                column.Item().Text(summary);
                            });
                        }
                        );
                        page.Content()
                            .PaddingVertical(1, Unit.Centimetre)
                            .Column(x =>
                            {
                                x.Spacing(5);
                                if (jobs != "")
                                {
                                    x.Item().Text(titles[0]).Bold().FontSize(13);
                                    x.Item().Text(jobs);
                                }
                                x.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                                if (educations != "")
                                {
                                    x.Item().Text(titles[1]).Bold().FontSize(13);
                                    x.Item().Text(educations);
                                }
                                x.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                                if (certifications != "")
                                {
                                    x.Item().Text(titles[2]).Bold().FontSize(13);
                                    x.Item().Text(certifications);
                                }
                                x.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                                if (personalProjects != "")
                                {
                                    x.Item().Text(titles[3]).Bold().FontSize(13);
                                    x.Item().Text(personalProjects);
                                }
                                x.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                                if (languages != "")
                                {
                                    x.Item().Text(titles[4]).Bold().FontSize(13);
                                    x.Item().Text(languages);
                                }
                                x.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                                if (interests != "")
                                {
                                    x.Item().Text(titles[5]).Bold().FontSize(13);
                                    x.Item().Text(interests);
                                }
                                x.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                                if (skills != "")
                                {
                                    x.Item().Text(titles[6]).Bold().FontSize(13);
                                    x.Item().Text(skills);
                                }
                            });
                    });
                })
                    .GeneratePdf(path);

            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show(ex.Message + "Please close file and retry!");
            }
        }

        public void ModernLayout(string path, string name, string personDetails, string jobs, string educations, string certifications, string personalProjects, string languages, string interests, string skills, string summary)
        {
            printingLanguage();
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(5, Unit.Millimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11));
                    page.Header().Row(row =>
                    {
                        row.Spacing(10);
                        row.ConstantItem(150).Image(sqlControllers.getPicture());
                        row.RelativeItem().Text(text =>
                        {
                            text.Line(name).Bold().FontSize(19);
                            text.Line(summary).Italic();
                        });
                    });
                    page.Content().Column(column =>
                    {
                        column.Item().Row(row =>
                        {
                            row.ConstantItem(150).Text(text =>
                            {
                                text.Line(personDetails);
                                if (languages != "")
                                {
                                    text.Line(titles[4]).Bold().FontSize(13);
                                    text.Line(languages);
                                }
                                if (certifications != "")
                                {
                                    text.Line(titles[2]).Bold().FontSize(13);
                                    text.Line(certifications);
                                }
                                if (skills != "")
                                {
                                    text.Line(titles[6]).Bold().FontSize(13);
                                    text.Line(skills);
                                }
                                if (personalProjects != "")
                                {
                                    text.Line(titles[3]).Bold().FontSize(13);
                                    text.Line(personalProjects);
                                }
                                if (interests != "")
                                {
                                    column.Item().Text(titles[5]).Bold().FontSize(13);
                                    column.Item().Text(interests);
                                }
                            });
                            row.RelativeItem().Text(text =>
                            {
                                if (jobs != "")
                                {
                                    text.Line(titles[0]).Bold().FontSize(13);
                                    text.Line(jobs);
                                }
                                if (educations != "")
                                {
                                    text.Line(titles[1]).Bold().FontSize(13);
                                    text.Line(educations);
                                }
                            });
                        });
                    });
                });
            }).GeneratePdf(path);
        }
    }
}