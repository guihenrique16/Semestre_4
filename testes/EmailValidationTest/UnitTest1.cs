using EmailValidation;

namespace EmailValidationTest
{
    public class UnitTest1
    {
        [Fact]
        public void ConferirEmail()
        {
            string email = "guilherme@gmail.com";

            Assert.True(Email.ValidarEmail(email));
        }
    }
}