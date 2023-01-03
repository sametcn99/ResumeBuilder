using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder
{
    internal class ResumeLayouts
    {
        public void ClassicLayout(string path, string name, string personDetails, string jobs, string educations, string certifications, string personalProjects, string languages, string interests, string skills)
        {
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
                        page.Content()
                            .PaddingVertical(1, Unit.Centimetre)
                            .Column(x =>
                            {
                                x.Spacing(20);
                                x.Item().Text(name).FontSize(18).FontColor(Colors.Blue.Medium).Bold();
                                x.Item().Text(personDetails);
                                if (jobs != "")
                                {
                                    x.Item().Text("JOB").Bold().FontSize(13);
                                    x.Item().Text(jobs);
                                }
                                if (educations != "")
                                {
                                    x.Item().Text("EDUCATION").Bold().FontSize(13);
                                    x.Item().Text(educations);
                                }
                                if (certifications != "")
                                {
                                    x.Item().Text("CERTIFICATIONS").Bold().FontSize(13);
                                    x.Item().Text(certifications);
                                }
                                if (personalProjects != "")
                                {
                                    x.Item().Text("PERSONAL PROJECTS").Bold().FontSize(13);
                                    x.Item().Text(personalProjects);
                                }
                                if (languages != "")
                                {
                                    x.Item().Text("LANGUAGES").Bold().FontSize(13);
                                    x.Item().Text(languages);
                                }
                                if (interests != "")
                                {
                                    x.Item().Text("INTERESTS").Bold().FontSize(13);
                                    x.Item().Text(interests);
                                }
                                if (skills != "")
                                {
                                    x.Item().Text("SKILLS").Bold().FontSize(13);
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
    }
}
