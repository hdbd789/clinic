using Clinic.Data.Helpers;
using NUnit.Framework;

namespace CLinicTest.Helpers
{
    [TestFixture]
    public class DataHelperTest
    {
        [TestCase("","")]
        [TestCase("Amoxicillin + Acid clavulanic 250,5,7000,3981|Prednison 5mg,5,1400,7364|Salbutamol 2mg,3,1700,1288", "Amoxicillin + Acid clavulanic 250|Prednison 5mg|Salbutamol 2mg")]
        [TestCase("Amoxicillin + Acid clavulanic 250,5,7000,3981|Prednison 5mg|Salbutamol 2mg,3,1700,1288", "Amoxicillin + Acid clavulanic 250|Prednison 5mg|Salbutamol 2mg")]
        [TestCase("Amoxicillin + Acid clavulanic 250,5,7000,3981||Salbutamol 2mg,3,1700,1288", "Amoxicillin + Acid clavulanic 250|Salbutamol 2mg")]
        public void Test_BuildStringMedicines_Correct_Value(string medicine, string expected)
        {
            // Act
            var actualValue = DataHelper.BuildStringMedicines(medicine);
            //Assert
            Assert.That(actualValue, Is.EqualTo(expected));
        }
    }
}
