using CurriculumViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CurriculumViewerTests.Domain.Models
{
    public class ExamTests
    {
        [Fact]
        public void TestIFECIsCalculated()
        {
            // Arange
            Exam exam = new Exam() { EC = 10 };

            // Act
            int ec = exam.EC;

            // Assert
            Assert.Equal(10, ec);
        }

    }
}
