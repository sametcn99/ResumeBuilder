namespace ResumeBuilder
{
    internal class CreatingHtmlPageForPrinting
    {
        public string htmlText;
        public string htmlPageCode()
        {
            htmlText = @"
<!DOCTYPE html>
<html>

<head>
  <style>
    /* Add some style to the page */
    body {
      font-family: Arial, sans-serif;
    }

    h1 {
      color: #333;
    }

    .section {
      margin: 20px 0;
    }

    .section-title {
      font-size: 18px;
      font-weight: bold;
    }

    .section-content {
      margin-left: 20px;
    }

    ul {
      list-style: none;
      padding: 0;
    }

    li {
      margin-bottom: 10px;
    }

    .photo {
      /* Add some style to the photo */
      width: 200px;
      height: 200px;
      border-radius: 50%;
      border: 2px solid #333;
      margin-right: 20px;
      float: right;
    }
  </style>
</head>

<body>
  <h1>CV</h1>
  <img src=""photo.jpg"" alt=""Photo"" class=""photo"">
  <div class=""section"">
    <div class=""section-title"">Personal Information</div>
    <div class=""section-content"">
      <ul>
        <li>Name: John Doe</li>
        <li>Email: john.doe@gmail.com</li>
        <li>Phone: 555-555-5555</li>
        <li>Location: New York, NY</li>
      </ul>
    </div>
  </div>
  <div class=""section"">
    <div class=""section-title"">Education</div>
    <div class=""section-content"">
      <ul>
        <li>
          <b>Bachelor of Science in Computer Science</b><br>
          XYZ University, New York, NY<br>
          Graduated: May 2020
        </li>
        <li>
          <b>Associate of Science in Computer Science</b><br>
          ABC College, New York, NY<br>
          Graduated: May 2018
        </li>
      </ul>
    </div>
  </div>
  <div class=""section"">
    <div class=""section-title"">Work Experience</div>
    <div class=""section-content"">
      <ul>
        <li>
          <b>Software Engineer</b><br>
          ABC Company, New York, NY<br>
          June 2020 - Present
        </li>
        <li>
          <b>Software Developer Intern</b><br>
          XYZ Company, New York, NY<br>
          June 2019 - December 2019
        </li>
      </ul>
    </div>
  </div>
  <div class=""section"">
    <div class=""section-title"">Skills</div>
    <div class=""section-content"">
      <ul>
        <li>Java</li>
        <li>Python</li>
        <li>HTML/CSS</li>
        <li>JavaScript</li>
        <li>SQL</li>
      </ul>
    </div>
  </div>
</body>

</html>";
            return htmlText;
        }
    }
}
