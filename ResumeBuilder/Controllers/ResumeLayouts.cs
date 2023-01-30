using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ResumeBuilder.Properties;

namespace ResumeBuilder.Controllers
{
    internal class ResumeLayouts
    {
        SqlControllers sqlControllers = new SqlControllers();
        public string[] titles = { "", "", "", "", "", "", "" };

        public void printingLanguage()
        {
            titles[0] = Settings.Default.jobTitleLanguage;
            titles[1] = Settings.Default.educationTitleLanguage;
            titles[2] = Settings.Default.certificationsTitleLanguage;
            titles[3] = Settings.Default.personalProjectsTitleLanguage;
            titles[4] = Settings.Default.languagesTitleLanguage;
            titles[5] = Settings.Default.interestsTitleLanguage;
            titles[6] = Settings.Default.skillsTitleLanguage;
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
                        page.DefaultTextStyle(x => x.FontSize(Settings.Default.detailFontSize));
                        page.Header().Row(row =>
                        {
                            row.Spacing(15);
                            if (!string.IsNullOrEmpty(sqlControllers.getPicture()))
                            {
                                row.ConstantItem(Settings.Default.pictureSize).Image(sqlControllers.getPicture());
                            }
                            row.RelativeItem().Column(column =>
                            {
                                if (name != "") column.Item().Text(name).FontSize(18).FontColor(Colors.Blue.Medium).Bold();
                                if (personDetails != "") column.Item().Text(personDetails);
                                if (summary != "") column.Item().Text(summary);
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
                                if (educations != "")
                                {
                                    x.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                                    x.Item().Text(titles[1]).Bold().FontSize(13);
                                    x.Item().Text(educations);
                                }
                                if (certifications != "")
                                {
                                    x.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);

                                    x.Item().Text(titles[2]).Bold().FontSize(13);
                                    x.Item().Text(certifications);
                                }
                                if (personalProjects != "")
                                {
                                    x.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                                    x.Item().Text(titles[3]).Bold().FontSize(13);
                                    x.Item().Text(personalProjects);
                                }
                                if (languages != "")
                                {
                                    x.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                                    x.Item().Text(titles[4]).Bold().FontSize(13);
                                    x.Item().Text(languages);
                                }
                                if (interests != "")
                                {
                                    x.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                                    x.Item().Text(titles[5]).Bold().FontSize(13);
                                    x.Item().Text(interests);
                                }
                                if (skills != "")
                                {
                                    x.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                                    x.Item().Text(titles[6]).Bold().FontSize(13);
                                    x.Item().Text(skills);
                                }
                            });
                    });
                })
                    .GeneratePdf(path);
            }
            catch (IOException ex)
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
                    page.DefaultTextStyle(x => x.FontSize(Settings.Default.detailFontSize));
                    page.Header().Row(row =>
                    {
                        row.Spacing(10);
                        row.ConstantItem(Settings.Default.pictureSize).Image(sqlControllers.getPicture());
                        row.RelativeItem().Text(text =>
                        {
                            if (name != "") text.Line(name).Bold().FontSize(19);
                            if (summary != "") text.Line(summary).Italic();
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
                                    text.Line(titles[4]).Bold().FontSize(Settings.Default.titleFontSize);
                                    text.Line(languages);
                                }
                                if (certifications != "")
                                {
                                    text.Line(titles[2]).Bold().FontSize(Settings.Default.titleFontSize);
                                    text.Line(certifications);
                                }
                                if (skills != "")
                                {
                                    text.Line(titles[6]).Bold().FontSize(Settings.Default.titleFontSize);
                                    text.Line(skills);
                                }
                                if (personalProjects != "")
                                {
                                    text.Line(titles[3]).Bold().FontSize(Settings.Default.titleFontSize);
                                    text.Line(personalProjects);
                                }
                                if (interests != "")
                                {
                                    column.Item().Text(titles[5]).Bold().FontSize(Settings.Default.titleFontSize);
                                    column.Item().Text(interests);
                                }
                            });
                            row.RelativeItem().Text(text =>
                            {
                                if (jobs != "")
                                {
                                    text.Line(titles[0]).Bold().FontSize(Settings.Default.titleFontSize);
                                    text.Line(jobs);
                                }
                                if (educations != "")
                                {
                                    text.Line(titles[1]).Bold().FontSize(Settings.Default.titleFontSize);
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