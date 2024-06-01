namespace EgysegTeszt
{
    public class Tests
    {
        private jaratkezelo jaratKezelo;

        [SetUp]
        public void SetUp()
        {
            jaratKezelo = new jaratkezelo();
        }

        [Test]
        public void UjJarat_ShouldAddNewJarat()
        {
            jaratKezelo.UjJarat("ALMA", "asd", "korte", DateTime.Now);
            var indulasiIdo = jaratKezelo.MikorIndul("ALMA");

            Assert.AreEqual(indulasiIdo.Date, DateTime.Now.Date);
        }

        [Test]
        public void UjJarat_DuplicateJaratSzam_ShouldThrowException()
        {
            jaratKezelo.UjJarat("ALMA", "asd", "korte", DateTime.Now);

            Assert.Throws<ArgumentException>(() =>
            {
                jaratKezelo.UjJarat("ALMA", "asd", "korte", DateTime.Now);
            });
        }

        [Test]
        public void Keses_ShouldUpdateKeses()
        {
            jaratKezelo.UjJarat("ALMA", "asd", "korte", DateTime.Now);
            jaratKezelo.Keses("ALMA", 15);
            var indulasiIdo = jaratKezelo.MikorIndul("ALMA");

            Assert.AreEqual(indulasiIdo, DateTime.Now.AddMinutes(15));
        }

        [Test]
        public void Keses_NegativeResult_ShouldThrowException()
        {
            jaratKezelo.UjJarat("ALMA", "asd", "korte", DateTime.Now);

            Assert.Throws<ArgumentException>(() =>
            {
                jaratKezelo.Keses("ALMA", -10);
            });
        }

        [Test]
        public void MikorIndul_NonExistentJarat_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                jaratKezelo.MikorIndul("NonExistent");
            });
        }

        [Test]
        public void JaratokRepuloterrol_ShouldReturnCorrectJaratok()
        {
            jaratKezelo.UjJarat("ALMA", "asd", "korte", DateTime.Now);
            jaratKezelo.UjJarat("ALMA", "asd", "korte", DateTime.Now);

            var result = jaratKezelo.JaratokRepuloterrol("asd");

            Assert.AreEqual(2, result.Count);
            Assert.Contains("ALMA", result);
            Assert.Contains("22", result);
        }
    }
}